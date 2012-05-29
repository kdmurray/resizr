namespace Resizr
{
    partial class ResizrForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResizrForm));
            this.lblDrop = new System.Windows.Forms.Label();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prgStatus = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblDrop
            // 
            this.lblDrop.AllowDrop = true;
            this.lblDrop.AutoSize = true;
            this.lblDrop.BackColor = System.Drawing.Color.Transparent;
            this.lblDrop.Font = new System.Drawing.Font("Copperplate Gothic Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrop.ForeColor = System.Drawing.Color.Snow;
            this.lblDrop.Location = new System.Drawing.Point(31, 88);
            this.lblDrop.Name = "lblDrop";
            this.lblDrop.Size = new System.Drawing.Size(370, 159);
            this.lblDrop.TabIndex = 0;
            this.lblDrop.Text = "DROP OR\r\nPASTE FILES\r\nHERE";
            this.lblDrop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblDrop_DragDrop);
            this.lblDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblDrop_DragEnter);
            this.lblDrop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
            this.lblDrop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseMove);
            this.lblDrop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseUp);
            // 
            // cboSize
            // 
            this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSize.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Items.AddRange(new object[] {
            "Thumbnail (120px)",
            "Email (800px)",
            "Facebook (1024px)",
            "Flickr (1600px)",
            "Flickr (2400px)"});
            this.cboSize.Location = new System.Drawing.Point(109, 63);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(212, 24);
            this.cboSize.TabIndex = 1;
            this.cboSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboSize_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(150, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Optimize For";
            // 
            // prgStatus
            // 
            this.prgStatus.Location = new System.Drawing.Point(109, 260);
            this.prgStatus.Name = "prgStatus";
            this.prgStatus.Size = new System.Drawing.Size(212, 10);
            this.prgStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgStatus.TabIndex = 3;
            // 
            // ResizrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(427, 326);
            this.Controls.Add(this.prgStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSize);
            this.Controls.Add(this.lblDrop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResizrForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resizr";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.ResizrForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDrop;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar prgStatus;

    }
}

