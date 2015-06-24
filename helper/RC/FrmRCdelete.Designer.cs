namespace hnbthelper
{
    partial class FrmRCdelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRCdelete));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label12 = new System.Windows.Forms.Label();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bdnInfo = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtCurrentPage = new System.Windows.Forms.ToolStripTextBox();
            this.lblPageCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvbtdj = new System.Windows.Forms.DataGridView();
            this.gh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.object_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfzh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yhzh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zhm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btlx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wfyy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btbtbz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbCycle = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bdnInfo)).BeginInit();
            this.bdnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbtdj)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(457, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 37;
            this.label12.Text = "补贴金额合计：";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(15, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(364, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 14);
            this.label11.TabIndex = 36;
            this.label11.Text = "0";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "户数：";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bdnInfo
            // 
            this.bdnInfo.AddNewItem = null;
            this.bdnInfo.CountItem = this.bindingNavigatorCountItem;
            this.bdnInfo.DeleteItem = null;
            this.bdnInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.bdnInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.txtCurrentPage,
            this.lblPageCount,
            this.toolStripSeparator4,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton3,
            this.toolStripSeparator1});
            this.bdnInfo.Location = new System.Drawing.Point(28, 54);
            this.bdnInfo.MoveFirstItem = null;
            this.bdnInfo.MoveLastItem = null;
            this.bdnInfo.MoveNextItem = null;
            this.bdnInfo.MovePreviousItem = null;
            this.bdnInfo.Name = "bdnInfo";
            this.bdnInfo.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnInfo.Size = new System.Drawing.Size(286, 25);
            this.bdnInfo.TabIndex = 34;
            this.bdnInfo.Text = "bindingNavigator1";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ForeColor = System.Drawing.Color.Blue;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(48, 22);
            this.toolStripButton1.Text = "上一页";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtCurrentPage
            // 
            this.txtCurrentPage.Name = "txtCurrentPage";
            this.txtCurrentPage.Size = new System.Drawing.Size(40, 25);
            // 
            // lblPageCount
            // 
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(15, 22);
            this.lblPageCount.Text = "0";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.ForeColor = System.Drawing.Color.Blue;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(48, 22);
            this.toolStripButton2.Text = "下一页";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.ForeColor = System.Drawing.Color.Blue;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton3.Text = "关闭";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dgvbtdj
            // 
            this.dgvbtdj.AllowUserToAddRows = false;
            this.dgvbtdj.AllowUserToDeleteRows = false;
            this.dgvbtdj.AllowUserToOrderColumns = true;
            this.dgvbtdj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbtdj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gh,
            this.dz,
            this.object_name,
            this.sfzh,
            this.yhzh,
            this.zhm,
            this.btlx,
            this.batch,
            this.wfyy,
            this.btsl,
            this.btbtbz,
            this.btje});
            this.dgvbtdj.Location = new System.Drawing.Point(16, 82);
            this.dgvbtdj.Name = "dgvbtdj";
            this.dgvbtdj.ReadOnly = true;
            this.dgvbtdj.RowTemplate.Height = 23;
            this.dgvbtdj.Size = new System.Drawing.Size(729, 550);
            this.dgvbtdj.TabIndex = 33;
            // 
            // gh
            // 
            this.gh.DataPropertyName = "gh";
            this.gh.HeaderText = "工号";
            this.gh.Name = "gh";
            this.gh.ReadOnly = true;
            this.gh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dz
            // 
            this.dz.DataPropertyName = "dz";
            this.dz.HeaderText = "家庭住址";
            this.dz.Name = "dz";
            this.dz.ReadOnly = true;
            this.dz.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // object_name
            // 
            this.object_name.DataPropertyName = "object_name";
            this.object_name.HeaderText = "补贴对象姓名";
            this.object_name.Name = "object_name";
            this.object_name.ReadOnly = true;
            // 
            // sfzh
            // 
            this.sfzh.DataPropertyName = "sfzh";
            this.sfzh.HeaderText = "身份证号";
            this.sfzh.Name = "sfzh";
            this.sfzh.ReadOnly = true;
            // 
            // yhzh
            // 
            this.yhzh.DataPropertyName = "yhzh";
            this.yhzh.HeaderText = "银行账号";
            this.yhzh.Name = "yhzh";
            this.yhzh.ReadOnly = true;
            // 
            // zhm
            // 
            this.zhm.DataPropertyName = "zhm";
            this.zhm.HeaderText = "账户名";
            this.zhm.Name = "zhm";
            this.zhm.ReadOnly = true;
            // 
            // btlx
            // 
            this.btlx.DataPropertyName = "lxmc";
            this.btlx.HeaderText = "补贴类型";
            this.btlx.Name = "btlx";
            this.btlx.ReadOnly = true;
            // 
            // batch
            // 
            this.batch.DataPropertyName = "batchname";
            this.batch.HeaderText = "补贴批次";
            this.batch.Name = "batch";
            this.batch.ReadOnly = true;
            // 
            // wfyy
            // 
            this.wfyy.DataPropertyName = "wfyy";
            this.wfyy.HeaderText = "未发原因";
            this.wfyy.Name = "wfyy";
            this.wfyy.ReadOnly = true;
            // 
            // btsl
            // 
            this.btsl.DataPropertyName = "btsl";
            this.btsl.HeaderText = "补贴数量";
            this.btsl.Name = "btsl";
            this.btsl.ReadOnly = true;
            // 
            // btbtbz
            // 
            this.btbtbz.DataPropertyName = "btbz";
            this.btbtbz.HeaderText = "补贴标准";
            this.btbtbz.Name = "btbtbz";
            this.btbtbz.ReadOnly = true;
            // 
            // btje
            // 
            this.btje.DataPropertyName = "btje";
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0.00";
            this.btje.DefaultCellStyle = dataGridViewCellStyle7;
            this.btje.HeaderText = "补贴金额";
            this.btje.Name = "btje";
            this.btje.ReadOnly = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(543, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 14);
            this.label13.TabIndex = 38;
            this.label13.Text = "0";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(584, 18);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(88, 24);
            this.btnQuery.TabIndex = 32;
            this.btnQuery.Text = "查询补贴数据";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(678, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 25);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "删除补贴数据";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "批次：";
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(451, 21);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(121, 20);
            this.cmbBatch.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "补贴类型：";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(277, 20);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 20);
            this.cmbType.TabIndex = 27;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(14, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 40;
            this.label20.Text = "发放周期";
            // 
            // cmbCycle
            // 
            this.cmbCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCycle.FormattingEnabled = true;
            this.cmbCycle.Location = new System.Drawing.Point(73, 21);
            this.cmbCycle.Name = "cmbCycle";
            this.cmbCycle.Size = new System.Drawing.Size(115, 20);
            this.cmbCycle.TabIndex = 39;
            this.cmbCycle.SelectedIndexChanged += new System.EventHandler(this.cmbCycle_SelectedIndexChanged);
            // 
            // FrmRCdelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 463);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cmbCycle);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bdnInfo);
            this.Controls.Add(this.dgvbtdj);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBatch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbType);
            this.Name = "FrmRCdelete";
            this.Text = "删除补贴数据";
            this.Load += new System.EventHandler(this.FrmRCdelete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdnInfo)).EndInit();
            this.bdnInfo.ResumeLayout(false);
            this.bdnInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbtdj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.BindingNavigator bdnInfo;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox txtCurrentPage;
        private System.Windows.Forms.ToolStripLabel lblPageCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView dgvbtdj;
        private System.Windows.Forms.DataGridViewTextBoxColumn gh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dz;
        private System.Windows.Forms.DataGridViewTextBoxColumn object_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfzh;
        private System.Windows.Forms.DataGridViewTextBoxColumn yhzh;
        private System.Windows.Forms.DataGridViewTextBoxColumn zhm;
        private System.Windows.Forms.DataGridViewTextBoxColumn btlx;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch;
        private System.Windows.Forms.DataGridViewTextBoxColumn wfyy;
        private System.Windows.Forms.DataGridViewTextBoxColumn btsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn btbtbz;
        private System.Windows.Forms.DataGridViewTextBoxColumn btje;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbCycle;
    }
}