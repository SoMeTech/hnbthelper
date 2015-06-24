namespace hnbthelper
{
    partial class frmQuery
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
            this.label20 = new System.Windows.Forms.Label();
            this.cmbCycle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBtlx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbyear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbbatchmonth = new System.Windows.Forms.ComboBox();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.OBJECTCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSSSOBJECTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOMEADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSSSIDCARDNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCOUNTNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPECODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STANDARD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REGMONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnExp = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTown = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "补贴类型";
            // 
            // cmbBtlx
            // 
            this.cmbBtlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBtlx.FormattingEnabled = true;
            this.cmbBtlx.Location = new System.Drawing.Point(269, 20);
            this.cmbBtlx.Name = "cmbBtlx";
            this.cmbBtlx.Size = new System.Drawing.Size(142, 20);
            this.cmbBtlx.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "补贴年度";
            // 
            // cmbyear
            // 
            this.cmbyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyear.FormattingEnabled = true;
            this.cmbyear.Location = new System.Drawing.Point(487, 20);
            this.cmbyear.Name = "cmbyear";
            this.cmbyear.Size = new System.Drawing.Size(110, 20);
            this.cmbyear.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(603, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "批次/月份";
            // 
            // cmbbatchmonth
            // 
            this.cmbbatchmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbatchmonth.FormattingEnabled = true;
            this.cmbbatchmonth.Location = new System.Drawing.Point(668, 17);
            this.cmbbatchmonth.Name = "cmbbatchmonth";
            this.cmbbatchmonth.Size = new System.Drawing.Size(124, 20);
            this.cmbbatchmonth.TabIndex = 23;
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToAddRows = false;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OBJECTCODE,
            this.SSSSOBJECTNAME,
            this.HOMEADDRESS,
            this.SSSSIDCARDNUM,
            this.ACCOUNTNUM,
            this.TYPENAME,
            this.TYPECODE,
            this.AMOUNT,
            this.STANDARD,
            this.REGMONEY});
            this.dgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShow.Location = new System.Drawing.Point(3, 17);
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.RowHeadersVisible = false;
            this.dgvShow.RowTemplate.Height = 23;
            this.dgvShow.Size = new System.Drawing.Size(1009, 380);
            this.dgvShow.TabIndex = 24;
            // 
            // OBJECTCODE
            // 
            this.OBJECTCODE.DataPropertyName = "OBJECTCODE";
            this.OBJECTCODE.HeaderText = "农户代码";
            this.OBJECTCODE.Name = "OBJECTCODE";
            // 
            // SSSSOBJECTNAME
            // 
            this.SSSSOBJECTNAME.DataPropertyName = "SSSSOBJECTNAME";
            this.SSSSOBJECTNAME.HeaderText = "农户姓名";
            this.SSSSOBJECTNAME.Name = "SSSSOBJECTNAME";
            // 
            // HOMEADDRESS
            // 
            this.HOMEADDRESS.DataPropertyName = "HOMEADDRESS";
            this.HOMEADDRESS.HeaderText = "家庭地址";
            this.HOMEADDRESS.Name = "HOMEADDRESS";
            // 
            // SSSSIDCARDNUM
            // 
            this.SSSSIDCARDNUM.DataPropertyName = "SSSSIDCARDNUM";
            this.SSSSIDCARDNUM.HeaderText = "身份证号";
            this.SSSSIDCARDNUM.Name = "SSSSIDCARDNUM";
            // 
            // ACCOUNTNUM
            // 
            this.ACCOUNTNUM.DataPropertyName = "ACCOUNTNUM";
            this.ACCOUNTNUM.HeaderText = "银行账号";
            this.ACCOUNTNUM.Name = "ACCOUNTNUM";
            // 
            // TYPENAME
            // 
            this.TYPENAME.DataPropertyName = "TYPENAME";
            this.TYPENAME.HeaderText = "补贴类型名称";
            this.TYPENAME.Name = "TYPENAME";
            // 
            // TYPECODE
            // 
            this.TYPECODE.DataPropertyName = "TYPECODE";
            this.TYPECODE.HeaderText = "补贴类型代码";
            this.TYPECODE.Name = "TYPECODE";
            // 
            // AMOUNT
            // 
            this.AMOUNT.DataPropertyName = "AMOUNT";
            this.AMOUNT.HeaderText = "补贴数量";
            this.AMOUNT.Name = "AMOUNT";
            // 
            // STANDARD
            // 
            this.STANDARD.DataPropertyName = "STANDARD";
            this.STANDARD.HeaderText = "补贴标准";
            this.STANDARD.Name = "STANDARD";
            // 
            // REGMONEY
            // 
            this.REGMONEY.DataPropertyName = "REGMONEY";
            this.REGMONEY.HeaderText = "补贴金额";
            this.REGMONEY.Name = "REGMONEY";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(34, 20);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(109, 29);
            this.btnQuery.TabIndex = 25;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnExp
            // 
            this.btnExp.Location = new System.Drawing.Point(290, 20);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(104, 29);
            this.btnExp.TabIndex = 26;
            this.btnExp.Text = "导出为Excel";
            this.btnExp.UseVisualStyleBackColor = true;
            this.btnExp.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(477, 30);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(180, 16);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "只查询通过本助手导入的补贴";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTown);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.cmbyear);
            this.groupBox1.Controls.Add(this.cmbCycle);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbBtlx);
            this.groupBox1.Controls.Add(this.cmbbatchmonth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(78, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 99);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // cmbTown
            // 
            this.cmbTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTown.FormattingEnabled = true;
            this.cmbTown.Location = new System.Drawing.Point(417, 64);
            this.cmbTown.Name = "cmbTown";
            this.cmbTown.Size = new System.Drawing.Size(110, 20);
            this.cmbTown.TabIndex = 25;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(327, 66);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 16);
            this.checkBox2.TabIndex = 24;
            this.checkBox2.Text = "按乡镇查询";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.btnQuery);
            this.groupBox2.Controls.Add(this.btnExp);
            this.groupBox2.Location = new System.Drawing.Point(165, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(690, 63);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.dgvShow);
            this.groupBox3.Location = new System.Drawing.Point(-1, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1015, 400);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            // 
            // frmQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 589);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmQuery";
            this.Text = "补贴明细查询";
            this.Load += new System.EventHandler(this.frmQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbCycle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBtlx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbyear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbbatchmonth;
        private System.Windows.Forms.DataGridView dgvShow;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnExp;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTown;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBJECTCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSSSOBJECTNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOMEADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSSSIDCARDNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCOUNTNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPECODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn STANDARD;
        private System.Windows.Forms.DataGridViewTextBoxColumn REGMONEY;
    }
}