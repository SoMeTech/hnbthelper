namespace hnbthelper
{
    partial class frmExtract
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTown = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbCycle = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBtlx = new System.Windows.Forms.ComboBox();
            this.cmbbatchmonth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbFlow = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCy = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbLx = new System.Windows.Forms.ComboBox();
            this.cmbBat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnModi = new System.Windows.Forms.Button();
            this.btnExt = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvPre = new System.Windows.Forms.DataGridView();
            this.REGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBJECTCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSSSOBJECTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOMEADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPECODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REGMONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnview = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPre)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTown);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.cmbCycle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbBtlx);
            this.groupBox1.Controls.Add(this.cmbbatchmonth);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "源数据";
            // 
            // cmbTown
            // 
            this.cmbTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTown.Enabled = false;
            this.cmbTown.FormattingEnabled = true;
            this.cmbTown.Location = new System.Drawing.Point(106, 184);
            this.cmbTown.Name = "cmbTown";
            this.cmbTown.Size = new System.Drawing.Size(115, 20);
            this.cmbTown.TabIndex = 30;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 184);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "按乡镇提取？";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 29;
            this.label20.Text = "发放周期：";
            // 
            // cmbCycle
            // 
            this.cmbCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCycle.FormattingEnabled = true;
            this.cmbCycle.Location = new System.Drawing.Point(81, 25);
            this.cmbCycle.Name = "cmbCycle";
            this.cmbCycle.Size = new System.Drawing.Size(140, 20);
            this.cmbCycle.TabIndex = 28;
            this.cmbCycle.SelectedIndexChanged += new System.EventHandler(this.cmbCycle_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "补贴类型：";
            // 
            // cmbBtlx
            // 
            this.cmbBtlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBtlx.FormattingEnabled = true;
            this.cmbBtlx.Location = new System.Drawing.Point(81, 75);
            this.cmbBtlx.Name = "cmbBtlx";
            this.cmbBtlx.Size = new System.Drawing.Size(140, 20);
            this.cmbBtlx.TabIndex = 25;
            // 
            // cmbbatchmonth
            // 
            this.cmbbatchmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbatchmonth.FormattingEnabled = true;
            this.cmbbatchmonth.Location = new System.Drawing.Point(81, 130);
            this.cmbbatchmonth.Name = "cmbbatchmonth";
            this.cmbbatchmonth.Size = new System.Drawing.Size(140, 20);
            this.cmbbatchmonth.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "批次/月份：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "====>";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbFlow);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbCy);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbLx);
            this.groupBox2.Controls.Add(this.cmbBat);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(418, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 217);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目标";
            // 
            // cmbFlow
            // 
            this.cmbFlow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFlow.Enabled = false;
            this.cmbFlow.FormattingEnabled = true;
            this.cmbFlow.Location = new System.Drawing.Point(96, 184);
            this.cmbFlow.Name = "cmbFlow";
            this.cmbFlow.Size = new System.Drawing.Size(115, 20);
            this.cmbFlow.TabIndex = 36;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(8, 186);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 37;
            this.checkBox2.Text = "已建流程";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "发放周期：";
            // 
            // cmbCy
            // 
            this.cmbCy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCy.FormattingEnabled = true;
            this.cmbCy.Location = new System.Drawing.Point(71, 25);
            this.cmbCy.Name = "cmbCy";
            this.cmbCy.Size = new System.Drawing.Size(140, 20);
            this.cmbCy.TabIndex = 34;
            this.cmbCy.SelectedIndexChanged += new System.EventHandler(this.cmbCy_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "补贴类型：";
            // 
            // cmbLx
            // 
            this.cmbLx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLx.FormattingEnabled = true;
            this.cmbLx.Location = new System.Drawing.Point(71, 75);
            this.cmbLx.Name = "cmbLx";
            this.cmbLx.Size = new System.Drawing.Size(140, 20);
            this.cmbLx.TabIndex = 31;
            // 
            // cmbBat
            // 
            this.cmbBat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBat.FormattingEnabled = true;
            this.cmbBat.Location = new System.Drawing.Point(71, 130);
            this.cmbBat.Name = "cmbBat";
            this.cmbBat.Size = new System.Drawing.Size(140, 20);
            this.cmbBat.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "批次/月份：";
            // 
            // btnModi
            // 
            this.btnModi.Location = new System.Drawing.Point(694, 45);
            this.btnModi.Name = "btnModi";
            this.btnModi.Size = new System.Drawing.Size(85, 36);
            this.btnModi.TabIndex = 2;
            this.btnModi.Text = "修改";
            this.btnModi.UseVisualStyleBackColor = true;
            // 
            // btnExt
            // 
            this.btnExt.Location = new System.Drawing.Point(692, 123);
            this.btnExt.Name = "btnExt";
            this.btnExt.Size = new System.Drawing.Size(87, 39);
            this.btnExt.TabIndex = 3;
            this.btnExt.Text = "提取";
            this.btnExt.UseVisualStyleBackColor = true;
            this.btnExt.Click += new System.EventHandler(this.btnExt_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvPre);
            this.groupBox3.Location = new System.Drawing.Point(3, 235);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(782, 378);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "源数据预览";
            // 
            // dgvPre
            // 
            this.dgvPre.AllowUserToAddRows = false;
            this.dgvPre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.REGID,
            this.OBJECTCODE,
            this.SSSSOBJECTNAME,
            this.HOMEADDRESS,
            this.TYPEID,
            this.TYPECODE,
            this.TYPENAME,
            this.REGMONEY});
            this.dgvPre.Location = new System.Drawing.Point(9, 21);
            this.dgvPre.Name = "dgvPre";
            this.dgvPre.ReadOnly = true;
            this.dgvPre.RowTemplate.Height = 23;
            this.dgvPre.Size = new System.Drawing.Size(766, 351);
            this.dgvPre.TabIndex = 0;
            // 
            // REGID
            // 
            this.REGID.DataPropertyName = "REGID";
            this.REGID.HeaderText = "登记ID";
            this.REGID.Name = "REGID";
            this.REGID.ReadOnly = true;
            this.REGID.Visible = false;
            // 
            // OBJECTCODE
            // 
            this.OBJECTCODE.DataPropertyName = "OBJECTCODE";
            this.OBJECTCODE.HeaderText = "农户代码";
            this.OBJECTCODE.Name = "OBJECTCODE";
            this.OBJECTCODE.ReadOnly = true;
            // 
            // SSSSOBJECTNAME
            // 
            this.SSSSOBJECTNAME.DataPropertyName = "SSSSOBJECTNAME";
            this.SSSSOBJECTNAME.HeaderText = "农户姓名";
            this.SSSSOBJECTNAME.Name = "SSSSOBJECTNAME";
            this.SSSSOBJECTNAME.ReadOnly = true;
            // 
            // HOMEADDRESS
            // 
            this.HOMEADDRESS.DataPropertyName = "HOMEADDRESS";
            this.HOMEADDRESS.HeaderText = "家庭住址";
            this.HOMEADDRESS.Name = "HOMEADDRESS";
            this.HOMEADDRESS.ReadOnly = true;
            // 
            // TYPEID
            // 
            this.TYPEID.DataPropertyName = "TYPEID";
            this.TYPEID.HeaderText = "类型ID";
            this.TYPEID.Name = "TYPEID";
            this.TYPEID.ReadOnly = true;
            // 
            // TYPECODE
            // 
            this.TYPECODE.DataPropertyName = "TYPECODE";
            this.TYPECODE.HeaderText = "类型代码";
            this.TYPECODE.Name = "TYPECODE";
            this.TYPECODE.ReadOnly = true;
            // 
            // TYPENAME
            // 
            this.TYPENAME.DataPropertyName = "TYPENAME";
            this.TYPENAME.HeaderText = "类型名称";
            this.TYPENAME.Name = "TYPENAME";
            this.TYPENAME.ReadOnly = true;
            // 
            // REGMONEY
            // 
            this.REGMONEY.DataPropertyName = "REGMONEY";
            this.REGMONEY.HeaderText = "补贴金额";
            this.REGMONEY.Name = "REGMONEY";
            this.REGMONEY.ReadOnly = true;
            // 
            // btnview
            // 
            this.btnview.Location = new System.Drawing.Point(323, 145);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(82, 32);
            this.btnview.TabIndex = 5;
            this.btnview.Text = "预览";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // frmExtract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 617);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExt);
            this.Controls.Add(this.btnModi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmExtract";
            this.Text = "跨类型提取补贴数据";
            this.Load += new System.EventHandler(this.frmExtract_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBtlx;
        private System.Windows.Forms.ComboBox cmbbatchmonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbCycle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbLx;
        private System.Windows.Forms.ComboBox cmbBat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnModi;
        private System.Windows.Forms.Button btnExt;
        private System.Windows.Forms.ComboBox cmbTown;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvPre;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.ComboBox cmbFlow;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn REGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBJECTCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSSSOBJECTNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOMEADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPECODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn REGMONEY;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}