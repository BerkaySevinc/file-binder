﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using BekoS.IO.FileBinding;

namespace FileBinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly Binder binder = new Binder();
        private readonly BindingSource bs = new BindingSource();

        private void Form1_Load(object sender, EventArgs e)
        {
            bs.DataSource = binder.Files;
            dgvFiles.DataSource = bs;
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                DialogResult result = ofd.ShowDialog();

                if (!(result is DialogResult.OK) || string.IsNullOrWhiteSpace(ofd.FileName)) return;

                var file = new FileInfo(ofd.FileName);

                binder.AddFile(file.FullName, file.Extension == ".exe");

                bs.ResetBindings(false);
            }
        }

        private void dgvFiles_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (!(dgv.CurrentCell is DataGridViewCheckBoxCell)) return;

            dgv.EndEdit();
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = "Output",
                Filter = "Exe File|*.exe"
            })
            {
                DialogResult result = sfd.ShowDialog();

                if (!(result is DialogResult.OK) || string.IsNullOrWhiteSpace(sfd.FileName)) return;

                CompilerResults compilerResults = binder.Compile(sfd.FileName, iconPath);
                var compilerErrors = compilerResults.Errors.Cast<CompilerError>();

                if (compilerErrors.Any())
                {
                    var errorMessage = "Errors:\n\n" + string.Join("\n\n", compilerErrors.Select(ce => ce.ErrorText));
                    MessageBox.Show(errorMessage);
                }
            }
        }

        private string? iconPath;
        private void btnSelectIcon_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Icon Files|*.ico";
                DialogResult result = ofd.ShowDialog();

                if (!(result is DialogResult.OK) || string.IsNullOrWhiteSpace(ofd.FileName)) return;

                pbxIcon.Image = Image.FromFile(ofd.FileName);
                iconPath = ofd.FileName;
            }
        }
    }
}