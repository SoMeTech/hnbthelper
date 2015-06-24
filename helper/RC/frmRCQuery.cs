using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;
namespace hnbthelper
{
    public partial class frmRCQuery : Common.DockContent
    {
        BLL.BLL_BTLX B_BTLX = new BLL.BLL_BTLX();
        BLL.BLL_BATCH B_BATCH = new BLL.BLL_BATCH();
        BLL.BLL_RCBTDJTEMP B_btdj = new BLL.BLL_RCBTDJTEMP();
        string strConn;
        private int id;
        public frmRCQuery()
        {
            InitializeComponent();
        }
        private void frmRCQuery_Load(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            cmbKey.DataSource = Common.BasicData.master;
            cmbKey.DisplayMember = "value";
            cmbKey.ValueMember = "name";
            cmbTypeA.DataSource = B_BTLX.GetList("").Tables[0];
            cmbTypeA.DisplayMember = "TYPENAME";
            cmbTypeA.ValueMember = "TYPECODE";
            cmbTypeB.DataSource = B_BTLX.GetList("").Tables[0];
            cmbTypeB.DisplayMember = "TYPENAME";
            cmbTypeB.ValueMember = "TYPECODE";
            cmbBatchA.DataSource = B_BATCH.GetList("").Tables[0];
            cmbBatchA.DisplayMember = "BATCHNAME";
            cmbBatchA.ValueMember = "BATCHID";
            cmbBatchB.DataSource = B_BATCH.GetList("").Tables[0];
            cmbBatchB.DisplayMember = "BATCHNAME";
            cmbBatchB.ValueMember = "BATCHID";
            cmbTypeC.DataSource = B_BTLX.GetList("").Tables[0].DefaultView;
            cmbTypeC.DisplayMember = "TYPENAME";
            cmbTypeC.ValueMember = "TYPECODE";
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == this.tabPage1)
            {
                this.tabPage2.Controls.Remove(this.dgvbtdj);
                this.tabPage1.Controls.Add(this.dgvbtdj);
            }
            else if (e.TabPage == this.tabPage2)
            {
                this.tabPage1.Controls.Remove(this.dgvbtdj);
                this.tabPage2.Controls.Add(this.dgvbtdj);
            }
            else if (e.TabPage == this.tabPage3)
            {
                groupBox3.Visible = false;
            }
        }
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cmbTypeA.SelectedValue.ToString();
            try
            {
                cmbBatchA.DataSource = B_BATCH.GetList(" TYPECODE='" + id.ToString() + "' ORDER BY BATCHID").Tables[0];
                cmbBatchA.DisplayMember = "BATCHNAME";
                cmbBatchA.ValueMember = "BATCHID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入关键字值！", "提示");
                return;
            }
            else
            {
                if (int.Parse(cmbTypeA.SelectedValue.ToString()) != 0)
                {
                    dgvbtdj.DataSource = B_btdj.Find(" and a." + cmbKey.SelectedValue.ToString() + " like '%" + textBox1.Text.Trim() + "%' and btlx='" + cmbTypeA.SelectedValue.ToString() + "' ").Tables[0];
                }
                else
                {
                    dgvbtdj.DataSource = B_btdj.Find(" and a." + cmbKey.SelectedValue.ToString() + " like '%" + textBox1.Text.Trim() + "%'").Tables[0];
                }
            }
        }
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox3.Enabled = true;
            txtbtsl.Text = "1";
        }
        private void 复制CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string copyCode = this.dgvbtdj.CurrentCell.Value.ToString();
                if (!string.IsNullOrEmpty(copyCode))
                {
                    //复制到剪切板
                    Clipboard.SetDataObject(copyCode);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(this, exp.Message);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            string str = "";
            if (checkBox1.Checked)
            {
                str += " and ff=0 ";
            }
            if (cmbBatchB.SelectedItem != null)
            {
                str += " and a.batchid='" + cmbBatchB.SelectedValue + "' ";
            }
            else
            {
                MessageBox.Show("请选择批次");
                return;
            }
            if (cmbTypeB.SelectedItem != null)
            {
                str += " and a.btlx='" + cmbTypeB.SelectedValue + "' ";
            }
            dgvbtdj.DataSource = B_btdj.Find(str).Tables[0];
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvbtdj.DataSource;
            Common.DataProces toexcel = new Common.DataProces();
            toexcel.DataTableToExcel(dt, true);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("没有要修改的数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataSet ds = B_btdj.GetList(" ff=1 and gh=" + id + "");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("只能修改未发放的补贴数据！", "提示");
                }
                else
                {
                    DialogResult result = MessageBox.Show("确认要修改您选中的信息吗？", "消息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        Model.RCBTDJTEMP model = new Model.RCBTDJTEMP();
                        model.OBJECT_NAME = txtxm.Text.Trim();
                        model.ZHM = txtzhm.Text.Trim();
                        model.SFZH = txtsfzh.Text.Trim();
                        model.DZ = txtdz.Text.Trim();
                        model.YHZH = txtyhzh.Text.Trim();
                        model.BTSL = decimal.Parse(txtbtsl.Text.ToString());
                        model.BTJE = decimal.Parse(txtbtje.Text.ToString());
                        model.GH = id;
                        bool flag = B_btdj.Upbt(model);
                        if (flag)
                        {
                            MessageBox.Show("信息修改成功", "提交提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
        private void dgvbtdj_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int count = this.dgvbtdj.Rows.Count;
            if (count != 0)
            {
                this.groupBox1.Visible = true;
                id = Convert.ToInt32(this.dgvbtdj["gh", dgvbtdj.CurrentCell.RowIndex].Value);
                txtdz.Text = this.dgvbtdj["dz", dgvbtdj.CurrentCell.RowIndex].Value.ToString();
                txtxm.Text = this.dgvbtdj["object_name", dgvbtdj.CurrentCell.RowIndex].Value.ToString();
                txtsfzh.Text = this.dgvbtdj["sfzh", dgvbtdj.CurrentCell.RowIndex].Value.ToString();
                txtyhzh.Text = this.dgvbtdj["yhzh", dgvbtdj.CurrentCell.RowIndex].Value.ToString();
                if (this.dgvbtdj["btsl", dgvbtdj.CurrentCell.RowIndex].Value.ToString() == "")
                { 
                    txtbtsl.Text = "1"; 
                }
                else
                {
                    txtbtsl.Text = this.dgvbtdj["btsl", dgvbtdj.CurrentCell.RowIndex].Value.ToString();
                }
                txtzhm.Text = this.dgvbtdj["zhm", dgvbtdj.CurrentCell.RowIndex].Value.ToString();
                txtbtje.Text = this.dgvbtdj["btje", dgvbtdj.CurrentCell.RowIndex].Value.ToString();
            }
        }
        private void dgvbtdj_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvbtdj.Columns[e.ColumnIndex].Name == "sfff" && e.Value != null)
            {
                if (Convert.ToString(e.Value) == "1")
                {
                    e.Value = "是";
                }
                else if (Convert.ToString(e.Value) == "0")
                {
                    e.Value = "否";
                }
            }
        }
        private void cmbTypeB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cmbTypeB.SelectedValue.ToString();
            try
            {
                cmbBatchB.DataSource = B_BATCH.GetList(" TYPECODE='" + id.ToString() + "' ORDER BY BATCHID").Tables[0];
                cmbBatchB.DisplayMember = "BATCHNAME";
                cmbBatchB.ValueMember = "BATCHID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void 更新此户为未发放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = this.dgvbtdj.Rows.Count;
            if (count != 0)
            {
                id = Convert.ToInt32(this.dgvbtdj["gh", dgvbtdj.CurrentCell.RowIndex].Value);
                try
                {
                    DBUtility.DbHelperOra.ExecuteSql("update countydata.rcbtdjtemp set ff=0 where gh=" + id + "");
                }
                catch (Exception ex)
                {
                }
                MessageBox.Show("更新成功", "提示");
            }
        }
        private void 更新此户为已发放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = this.dgvbtdj.Rows.Count;
            if (count != 0)
            {
                id = Convert.ToInt32(this.dgvbtdj["gh", dgvbtdj.CurrentCell.RowIndex].Value);
                try
                {
                    DBUtility.DbHelperOra.ExecuteSql("update countydata.rcbtdjtemp set ff=1 where gh=" + id + "");
                }
                catch (Exception ex)
                {
                }
                MessageBox.Show("更新成功", "提示");
            }
        }
        private void cmbTypeC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbBatchC.DataSource = B_BATCH.GetList(" TYPECODE='" + cmbTypeC.SelectedValue.ToString() + "'").Tables[0].DefaultView;
                cmbBatchC.DisplayMember = "batchname";
                cmbBatchC.ValueMember = "batchid";
            }
            catch (Exception ex)
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ImportExcel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ImportExcel()
        {
            string strFile = ShowOpenFileDialog("Excel 文件", "Excel 文件|*.xls;*.xlsx");
            if (strFile == "") return;
            if (MessageBox.Show("真的要从选定Excel文件引入数据吗?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            if (strFile.ToLower().IndexOf(".xlsx") > 0)
            {
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source='" + strFile + "';Extended Properties='Excel 12.0;HDR=YES; IMEX=1'";
            }
            if (strFile.ToLower().IndexOf(".xls") > 0 && strFile.EndsWith("xls"))
            {
                strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Data Source=" + strFile + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
            }
            cmbTable.DataSource = LoadSchemaFromFile(strFile);
        }
        private OleDbConnection ReturnConnection(string fileName)
        {
            return new OleDbConnection(strConn);
        }
        private string[] LoadSchemaFromFile(string fileName)
        {
            string[] SheetNames = null;
            OleDbConnection conn = this.ReturnConnection(fileName);
            try
            {
                conn.Open();
                DataTable SchemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null });
                if (SchemaTable.Rows.Count > 0)
                {
                    SheetNames = new string[SchemaTable.Rows.Count];
                    int i = 0;
                    foreach (DataRow TmpRow in SchemaTable.Rows)
                    {
                        SheetNames[i] = TmpRow["TABLE_NAME"].ToString().Replace("$", "");
                        ////将$替换掉
                        //SheetNames[i].Replace("$", "");
                        i++;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                //Trace.WriteLine(Ex.StackTrace);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return SheetNames;
        }
        public static string ShowOpenFileDialog(string title, string filter)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "打开" + title;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBatchC.Text == "")
            {
                MessageBox.Show("批次不能为空！");
                return;
            }
            if (cmbTypeC.Text == "")
            {
                MessageBox.Show("补贴类型不能为空！");
                return;
            }
            DataTable dt = (DataTable)dgvpre.DataSource;
            if (dt == null) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    Convert.ToInt32(dt.Rows[i][0]);
                }
                catch
                {
                    MessageBox.Show("第" + (i + 1).ToString() + "行第零列数据类型不正确！不能进行导入");
                    return;
                }
                try
                {
                    Convert.ToBoolean(dt.Rows[i][0]);
                }
                catch
                {
                    MessageBox.Show("第" + (i + 1).ToString() + "行第零列数据类型不正确！不能进行导入");
                    return;
                }
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                try
                {
                    DBUtility.DbHelperOra.ExecuteSql("update countydata.RCbtdjtemp set object_name ='" + dt.Rows[j][1].ToString() + "',zhm='" + dt.Rows[j][2].ToString() + "',yhzh='" + dt.Rows[j][3].ToString() + "' where gh='" + dt.Rows[j][0].ToString() + "'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("第" + (j + 1).ToString() + "行数据类型不正确！此行以及此行以下不能进行导入!");
                    return;
                }
            }
            MessageBox.Show("批量修改成功！");
        }
        private void label17_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = path + "\\zw.xls";
            Process.Start(psi);
        }
        private void cmbTable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            OleDbDataAdapter myCommand = null;
            string strExcel = "SELECT * from [" + cmbTable.SelectedValue + "$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            DataSet dsExcel = new DataSet();
            myCommand.Fill(dsExcel, "table1");
            conn.Close();
            dgvpre.DataSource = dsExcel.Tables[0];
        }
        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTable.SelectedItem != null)
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }
        private void 删除选中行补贴数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(this.dgvbtdj["gh", dgvbtdj.CurrentCell.RowIndex].Value);
            if (id != 0)
            {
                try
                {
                    bool flag = B_btdj.DeleteBtByGh(id);
                    if (flag)
                    {
                        MessageBox.Show("删除成功", "提示");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败！");
                    return;
                }
            }
        }
    }
}
