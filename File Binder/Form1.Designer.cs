namespace FileBinder
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnCompile = new System.Windows.Forms.Button();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.btnSelectIcon = new System.Windows.Forms.Button();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(680, 76);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(207, 59);
            this.btnAddFile.TabIndex = 0;
            this.btnAddFile.Text = "Add File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(680, 360);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(207, 59);
            this.btnCompile.TabIndex = 1;
            this.btnCompile.Text = "Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // dgvFiles
            // 
            this.dgvFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Location = new System.Drawing.Point(43, 46);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.Size = new System.Drawing.Size(592, 395);
            this.dgvFiles.TabIndex = 2;
            this.dgvFiles.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvFiles_CurrentCellDirtyStateChanged);
            // 
            // btnSelectIcon
            // 
            this.btnSelectIcon.Location = new System.Drawing.Point(680, 223);
            this.btnSelectIcon.Name = "btnSelectIcon";
            this.btnSelectIcon.Size = new System.Drawing.Size(146, 48);
            this.btnSelectIcon.TabIndex = 5;
            this.btnSelectIcon.Text = "Select Icon";
            this.btnSelectIcon.UseVisualStyleBackColor = true;
            this.btnSelectIcon.Click += new System.EventHandler(this.btnSelectIcon_Click);
            // 
            // pbxIcon
            // 
            this.pbxIcon.Location = new System.Drawing.Point(832, 220);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(55, 55);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxIcon.TabIndex = 6;
            this.pbxIcon.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(20)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(929, 486);
            this.Controls.Add(this.pbxIcon);
            this.Controls.Add(this.btnSelectIcon);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.btnCompile);
            this.Controls.Add(this.btnAddFile);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Binder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Button btnSelectIcon;
        private System.Windows.Forms.PictureBox pbxIcon;
    }
}

