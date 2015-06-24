namespace hnbthelper
{
    partial class frmTools
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
            this.ploutlookBar = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ploutlookBar
            // 
            this.ploutlookBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ploutlookBar.Location = new System.Drawing.Point(0, 0);
            this.ploutlookBar.Name = "ploutlookBar";
            this.ploutlookBar.Size = new System.Drawing.Size(292, 273);
            this.ploutlookBar.TabIndex = 4;
            // 
            // frmTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.CloseButton = false;
            this.Controls.Add(this.ploutlookBar);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Name = "frmTools";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.Text = "导航菜单";
            this.Load += new System.EventHandler(this.frmTools_Load);
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Panel ploutlookBar;
    }
}