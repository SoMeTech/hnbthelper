using System.ComponentModel;
using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;
namespace FrmBase
{
    partial class BaseForm : DockContent
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BaseForm));
            this.SuspendLayout();
            this.ClientSize = new Size(292, 266);
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = "BaseForm";
            this.ResumeLayout(false);
        }

        #endregion
    }
}