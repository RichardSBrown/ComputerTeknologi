namespace UpOrDownFiles
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButUpload = new System.Windows.Forms.Button();
            this.butDownload = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.butShowLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButUpload
            // 
            this.ButUpload.Location = new System.Drawing.Point(10, 12);
            this.ButUpload.Name = "ButUpload";
            this.ButUpload.Size = new System.Drawing.Size(140, 23);
            this.ButUpload.TabIndex = 0;
            this.ButUpload.Text = "Choose file to upload";
            this.ButUpload.UseVisualStyleBackColor = true;
            this.ButUpload.Click += new System.EventHandler(this.butUpload_Click);
            // 
            // butDownload
            // 
            this.butDownload.Location = new System.Drawing.Point(10, 139);
            this.butDownload.Name = "butDownload";
            this.butDownload.Size = new System.Drawing.Size(140, 23);
            this.butDownload.TabIndex = 2;
            this.butDownload.Text = "Choose file to download";
            this.butDownload.UseVisualStyleBackColor = true;
            this.butDownload.Click += new System.EventHandler(this.butDownload_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(186, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(595, 328);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // butShowLog
            // 
            this.butShowLog.Location = new System.Drawing.Point(12, 72);
            this.butShowLog.Name = "butShowLog";
            this.butShowLog.Size = new System.Drawing.Size(140, 23);
            this.butShowLog.TabIndex = 4;
            this.butShowLog.Text = "Show Log";
            this.butShowLog.UseVisualStyleBackColor = true;
            this.butShowLog.Click += new System.EventHandler(this.butShowLog_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 352);
            this.Controls.Add(this.butShowLog);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.butDownload);
            this.Controls.Add(this.ButUpload);
            this.Name = "UserInterface";
            this.Text = "Form1";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ButUpload;
        private System.Windows.Forms.Button butDownload;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butShowLog;
    }
}

