namespace hnbthelper
{
    partial class frmRCBatchmanager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRCBatchmanager));
            this.dgvTypeManager = new System.Windows.Forms.DataGridView();
            this.batchid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.增加补贴批次ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbColl = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbCycle = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBtlx = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeManager)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTypeManager
            // 
            this.dgvTypeManager.AllowUserToAddRows = false;
            this.dgvTypeManager.AllowUserToDeleteRows = false;
            this.dgvTypeManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypeManager.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.batchid,
            this.typecode,
            this.batchname});
            this.dgvTypeManager.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvTypeManager.Location = new System.Drawing.Point(12, 69);
            this.dgvTypeManager.Name = "dgvTypeManager";
            this.dgvTypeManager.ReadOnly = true;
            this.dgvTypeManager.RowTemplate.Height = 23;
            this.dgvTypeManager.Size = new System.Drawing.Size(425, 400);
            this.dgvTypeManager.TabIndex = 5;
            // 
            // batchid
            // 
            this.batchid.DataPropertyName = "batchid";
            this.batchid.HeaderText = "批次ID";
            this.batchid.Name = "batchid";
            this.batchid.ReadOnly = true;
            // 
            // typecode
            // 
            this.typecode.DataPropertyName = "typecode";
            this.typecode.HeaderText = "补贴类型";
            this.typecode.Name = "typecode";
            this.typecode.ReadOnly = true;
            // 
            // batchname
            // 
            this.batchname.DataPropertyName = "batchname";
            this.batchname.HeaderText = "批次名称";
            this.batchname.Name = "batchname";
            this.batchname.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加补贴批次ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.复制ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 70);
            // 
            // 增加补贴批次ToolStripMenuItem
            // 
            this.增加补贴批次ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("增加补贴批次ToolStripMenuItem.Image")));
            this.增加补贴批次ToolStripMenuItem.Name = "增加补贴批次ToolStripMenuItem";
            this.增加补贴批次ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.增加补贴批次ToolStripMenuItem.Text = "增加补贴批次";
            this.增加补贴批次ToolStripMenuItem.Click += new System.EventHandler(this.增加补贴批次ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("删除ToolStripMenuItem.Image")));
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除ToolStripMenuItem.Text = "删除补贴批次";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("复制ToolStripMenuItem.Image")));
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbColl);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCancle);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Location = new System.Drawing.Point(452, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 458);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "增加补贴批次";
            // 
            // cmbColl
            // 
            this.cmbColl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColl.FormattingEnabled = true;
            this.cmbColl.Location = new System.Drawing.Point(77, 72);
            this.cmbColl.Name = "cmbColl";
            this.cmbColl.Size = new System.Drawing.Size(133, 20);
            this.cmbColl.TabIndex = 18;
            this.cmbColl.SelectedIndexChanged += new System.EventHandler(this.cmbColl_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "发放周期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "批次名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "补贴类型：";
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(128, 343);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(52, 26);
            this.btnCancle.TabIndex = 3;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(39, 343);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(52, 26);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 243);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 21);
            this.textBox1.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(70, 154);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(140, 20);
            this.cmbType.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbCycle);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbBtlx);
            this.groupBox2.Location = new System.Drawing.Point(10, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 52);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // cmbCycle
            // 
            this.cmbCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCycle.FormattingEnabled = true;
            this.cmbCycle.Location = new System.Drawing.Point(66, 20);
            this.cmbCycle.Name = "cmbCycle";
            this.cmbCycle.Size = new System.Drawing.Size(115, 20);
            this.cmbCycle.TabIndex = 16;
            this.cmbCycle.SelectedIndexChanged += new System.EventHandler(this.cmbCycle_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 17;
            this.label20.Text = "发放周期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "补贴类型";
            // 
            // cmbBtlx
            // 
            this.cmbBtlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBtlx.FormattingEnabled = true;
            this.cmbBtlx.Location = new System.Drawing.Point(269, 20);
            this.cmbBtlx.Name = "cmbBtlx";
            this.cmbBtlx.Size = new System.Drawing.Size(142, 20);
            this.cmbBtlx.TabIndex = 19;
            this.cmbBtlx.SelectedIndexChanged += new System.EventHandler(this.cmbBtlx_SelectedIndexChanged);
            // 
            // frmRCBatchmanager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 481);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvTypeManager);
            this.Name = "frmRCBatchmanager";
            this.Text = "补贴批次管理";
            this.Load += new System.EventHandler(this.frmRCBatchmanager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeManager)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.DataGridView dgvTypeManager;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbCycle;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBtlx;
        private System.Windows.Forms.ComboBox cmbColl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem 增加补贴批次ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchid;
        private System.Windows.Forms.DataGridViewTextBoxColumn typecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchname;
    }
}