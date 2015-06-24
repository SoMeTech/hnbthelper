namespace hnbthelper
{
    partial class frmExport
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbselect = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCacle = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cmbbatch = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMoveAll = new System.Windows.Forms.Button();
            this.cmbCycle = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.LBType = new System.Windows.Forms.ListBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTown = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExpHz = new System.Windows.Forms.Button();
            this.btnToEx = new System.Windows.Forms.Button();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbselect
            // 
            this.lbselect.FormattingEnabled = true;
            this.lbselect.ItemHeight = 12;
            this.lbselect.Location = new System.Drawing.Point(6, 44);
            this.lbselect.Name = "lbselect";
            this.lbselect.Size = new System.Drawing.Size(166, 208);
            this.lbselect.TabIndex = 6;
            this.lbselect.SelectedIndexChanged += new System.EventHandler(this.lbselect_SelectedIndexChanged);
            this.lbselect.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbselect_MouseDoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(200, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "批次/月份";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "选中：";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(416, 302);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "确认导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCacle
            // 
            this.btnCacle.Location = new System.Drawing.Point(295, 302);
            this.btnCacle.Name = "btnCacle";
            this.btnCacle.Size = new System.Drawing.Size(75, 23);
            this.btnCacle.TabIndex = 9;
            this.btnCacle.Text = "取消";
            this.btnCacle.UseVisualStyleBackColor = true;
            this.btnCacle.Click += new System.EventHandler(this.btnCacle_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.lbselect);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.cmbbatch);
            this.groupBox8.Location = new System.Drawing.Point(432, 12);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(313, 262);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "导出条件";
            // 
            // cmbbatch
            // 
            this.cmbbatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbatch.FormattingEnabled = true;
            this.cmbbatch.Location = new System.Drawing.Point(188, 44);
            this.cmbbatch.Name = "cmbbatch";
            this.cmbbatch.Size = new System.Drawing.Size(116, 20);
            this.cmbbatch.TabIndex = 13;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(147, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(95, 12);
            this.label21.TabIndex = 3;
            this.label21.Text = "请选择补贴类型:";
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(292, 159);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 11;
            this.btnMove.Text = "<-删除";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(292, 68);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "选择->";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMoveAll
            // 
            this.btnMoveAll.Location = new System.Drawing.Point(292, 107);
            this.btnMoveAll.Name = "btnMoveAll";
            this.btnMoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnMoveAll.TabIndex = 10;
            this.btnMoveAll.Text = "全选->>";
            this.btnMoveAll.UseVisualStyleBackColor = true;
            this.btnMoveAll.Click += new System.EventHandler(this.btnmoveAll_Click);
            // 
            // cmbCycle
            // 
            this.cmbCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCycle.FormattingEnabled = true;
            this.cmbCycle.Location = new System.Drawing.Point(6, 44);
            this.cmbCycle.Name = "cmbCycle";
            this.cmbCycle.Size = new System.Drawing.Size(115, 20);
            this.cmbCycle.TabIndex = 12;
            this.cmbCycle.SelectedIndexChanged += new System.EventHandler(this.cmbCycle_SelectedIndexChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(292, 206);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "<<-清空";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // LBType
            // 
            this.LBType.FormattingEnabled = true;
            this.LBType.ItemHeight = 12;
            this.LBType.Location = new System.Drawing.Point(138, 41);
            this.LBType.Name = "LBType";
            this.LBType.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LBType.Size = new System.Drawing.Size(120, 208);
            this.LBType.TabIndex = 14;
            this.LBType.SelectedIndexChanged += new System.EventHandler(this.LBType_SelectedIndexChanged);
            this.LBType.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LBType_MouseDoubleClick);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 15;
            this.label20.Text = "发放周期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(270, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 17;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.cmbBank);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.cmbTown);
            this.groupBox7.Controls.Add(this.checkBox1);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.LBType);
            this.groupBox7.Controls.Add(this.btnRemove);
            this.groupBox7.Controls.Add(this.cmbCycle);
            this.groupBox7.Controls.Add(this.btnMoveAll);
            this.groupBox7.Controls.Add(this.btnAdd);
            this.groupBox7.Controls.Add(this.btnMove);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Location = new System.Drawing.Point(3, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(423, 262);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "设置条件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "选择发放银行";
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(6, 209);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(115, 20);
            this.cmbBank.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "乡镇名称：";
            // 
            // cmbTown
            // 
            this.cmbTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTown.Enabled = false;
            this.cmbTown.FormattingEnabled = true;
            this.cmbTown.Location = new System.Drawing.Point(6, 134);
            this.cmbTown.Name = "cmbTown";
            this.cmbTown.Size = new System.Drawing.Size(115, 20);
            this.cmbTown.TabIndex = 12;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 72);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "按乡镇导出？";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(102, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 11;
            // 
            // btnExpHz
            // 
            this.btnExpHz.Location = new System.Drawing.Point(516, 302);
            this.btnExpHz.Name = "btnExpHz";
            this.btnExpHz.Size = new System.Drawing.Size(101, 25);
            this.btnExpHz.TabIndex = 12;
            this.btnExpHz.Text = "按慧舟格式导出";
            this.btnExpHz.UseVisualStyleBackColor = true;
            this.btnExpHz.Click += new System.EventHandler(this.btnExpHz_Click);
            // 
            // btnToEx
            // 
            this.btnToEx.Location = new System.Drawing.Point(634, 302);
            this.btnToEx.Name = "btnToEx";
            this.btnToEx.Size = new System.Drawing.Size(88, 25);
            this.btnToEx.TabIndex = 13;
            this.btnToEx.Text = "导出Excel";
            this.btnToEx.UseVisualStyleBackColor = true;
            this.btnToEx.Click += new System.EventHandler(this.btnToEx_Click);
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 339);
            this.Controls.Add(this.btnToEx);
            this.Controls.Add(this.btnExpHz);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btnCacle);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.groupBox7);
            this.MinimizeBox = false;
            this.Name = "frmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "补贴发放";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.ListBox lbselect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox cmbbatch;
        private System.Windows.Forms.Button btnCacle;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMoveAll;
        private System.Windows.Forms.ComboBox cmbCycle;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox LBType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTown;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnExpHz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Button btnToEx;
    }
}
