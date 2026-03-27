namespace FileBinder
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support. Do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddFile = new Button();
            btnCompile = new Button();
            dgvFiles = new DataGridView();
            btnSelectIcon = new Button();
            pbxIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvFiles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxIcon).BeginInit();
            SuspendLayout();
            // 
            // btnAddFile
            // 
            btnAddFile.Location = new Point(793, 88);
            btnAddFile.Margin = new Padding(4, 3, 4, 3);
            btnAddFile.Name = "btnAddFile";
            btnAddFile.Size = new Size(241, 68);
            btnAddFile.TabIndex = 0;
            btnAddFile.Text = "Add File";
            btnAddFile.UseVisualStyleBackColor = true;
            btnAddFile.Click += btnAddFile_Click;
            // 
            // btnCompile
            // 
            btnCompile.Location = new Point(793, 415);
            btnCompile.Margin = new Padding(4, 3, 4, 3);
            btnCompile.Name = "btnCompile";
            btnCompile.Size = new Size(241, 68);
            btnCompile.TabIndex = 1;
            btnCompile.Text = "Compile";
            btnCompile.UseVisualStyleBackColor = true;
            btnCompile.Click += btnCompile_Click;
            // 
            // dgvFiles
            // 
            dgvFiles.AllowUserToAddRows = false;
            dgvFiles.AllowUserToDeleteRows = false;
            dgvFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFiles.Location = new Point(50, 53);
            dgvFiles.Margin = new Padding(4, 3, 4, 3);
            dgvFiles.MultiSelect = false;
            dgvFiles.Name = "dgvFiles";
            dgvFiles.RowTemplate.Height = 40;
            dgvFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFiles.Size = new Size(691, 456);
            dgvFiles.TabIndex = 2;
            dgvFiles.CurrentCellDirtyStateChanged += dgvFiles_CurrentCellDirtyStateChanged;
            dgvFiles.SelectionChanged += dgvFiles_SelectionChanged;
            // 
            // btnSelectIcon
            // 
            btnSelectIcon.Location = new Point(793, 257);
            btnSelectIcon.Margin = new Padding(4, 3, 4, 3);
            btnSelectIcon.Name = "btnSelectIcon";
            btnSelectIcon.Size = new Size(170, 55);
            btnSelectIcon.TabIndex = 5;
            btnSelectIcon.Text = "Select Icon";
            btnSelectIcon.UseVisualStyleBackColor = true;
            btnSelectIcon.Click += btnSelectIcon_Click;
            // 
            // pbxIcon
            // 
            pbxIcon.Location = new Point(971, 254);
            pbxIcon.Margin = new Padding(4, 3, 4, 3);
            pbxIcon.Name = "pbxIcon";
            pbxIcon.Size = new Size(64, 63);
            pbxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxIcon.TabIndex = 6;
            pbxIcon.TabStop = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(19, 20, 21);
            ClientSize = new Size(1084, 561);
            Controls.Add(pbxIcon);
            Controls.Add(btnSelectIcon);
            Controls.Add(dgvFiles);
            Controls.Add(btnCompile);
            Controls.Add(btnAddFile);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "File Binder";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFiles).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxIcon).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Button btnSelectIcon;
        private System.Windows.Forms.PictureBox pbxIcon;
    }
}

