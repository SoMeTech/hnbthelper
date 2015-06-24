using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
namespace hnbthelper
{
    public partial class frmImport : Common.DockContent
    {
        BLL.BLL_BTLX b_btlx = new BLL.BLL_BTLX();
        BLL.BLL_BTDJTEMP b_btdj = new BLL.BLL_BTDJTEMP();
        BLL.BLL_FSREGISTRATION b_fsregistration = new BLL.BLL_FSREGISTRATION();
        int tb;
        string batchid = "";
        int batchcode;
        string offset = "";
        string btyf = "null";
        string btbat = "null";

        public frmImport()
        {
            InitializeComponent();
        }
        DataTable dtParm = new DataTable();
        string strConn;
        private void btnLook_Click(object sender, EventArgs e)
        {
            try
            {
                ImportExcel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        public void ImportExcel()
        {
            string strFile = ShowOpenFileDialog("Excel 文件", "Excel 文件|*.xls;*.xlsx");
            if (strFile == "") return;
            //if (MessageBox.Show("真的要从选定Excel文件引入数据吗?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            if (strFile.ToLower().IndexOf(".xlsx") > 0)
            {
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source='" + strFile + "';Extended Properties='Excel 12.0;HDR=YES; IMEX=1'";
            }
            if (strFile.ToLower().IndexOf(".xls") > 0 && strFile.EndsWith("xls"))
            {
                strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Data Source=" + strFile + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
            }
            comboBox1.DataSource = LoadSchemaFromFile(strFile);
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
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
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
        private OleDbConnection ReturnConnection(string fileName)
        {
            return new OleDbConnection(strConn);
        }
        public static string ShowOpenFileDialog(string title, string filter)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "打开" + title;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtParm.Clear();
            dtParm.Columns.Clear();
            dtParm.Columns.Add("Id");
            dtParm.Columns.Add("Value");
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            OleDbDataAdapter myCommand = null;
            string strExcel = "SELECT * from [" + comboBox1.SelectedValue + "$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            DataSet dsExcel = new DataSet();
            myCommand.Fill(dsExcel, "table1");
            conn.Close();
            dgvPreview.DataSource = dsExcel.Tables[0];
            dtParm.Clear();
            for (int i = 0; i < dgvPreview.ColumnCount; i++)
            {
                string str = dgvPreview.Columns[i].HeaderText;
                dtParm.Rows.Add();
                dtParm.Rows[i][0] = i;
                dtParm.Rows[i][1] = str;
            }
            if (dgvPreview.Rows.Count > 0)
            {
                btnLook.Enabled = false;
                btnIN.Enabled = true;
            }
            //是否存在临时表，如果不存在，创建
            if (tb == 0)
            {
                b_fsregistration.Createtb("");
            }
            else
            { }
        }
        public bool intotemp()
        {
            Model.BTDJTEMP model = new Model.BTDJTEMP();
            int id = 0;
            try
            {
                for (int i = 0; i < dgvPreview.Rows.Count; i++)
                {
                    id = 0 + i;
                    model.OBJECTCODE = dgvPreview.Rows[i].Cells[0].Value.ToString();
                    model.SSSSIDCARDNUM = dgvPreview.Rows[i].Cells[1].Value.ToString();
                    model.SSSSOBJECTNAME = dgvPreview.Rows[i].Cells[2].Value.ToString();
                    model.REGMONEY = decimal.Parse(dgvPreview.Rows[i].Cells[3].Value.ToString());
                    model.AMOUNT = decimal.Parse(dgvPreview.Rows[i].Cells[4].Value.ToString());
                    model.TYPECODE = dgvPreview.Rows[i].Cells[5].Value.ToString();
                    model.Batchid = batchid;
                    model.Batchcode = batchcode;
                    model.Offset = offset;
                    model.Lssuecycle = cmbCycle.SelectedValue.ToString();
                    model.Bankcode = cmbbank.SelectedText.ToString();
                    b_btdj.imptmp(model);
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("第" + (id + 1).ToString() + "行数据类型不正确！无法导入!");
                b_btdj.delete("");
                return false;
                throw;
            }
        }
        private void btnIN_Click(object sender, EventArgs e)
        {
            int ct = int.Parse(b_btdj.GetErrCount("").ToString());
            cmbCycle_SelectedIndexChanged(sender, e);
            if (ct == 0)
            {
                if (dgvPreview.RowCount >= 1)
                {
                    if (MessageBox.Show("发放周期：" + cmbCycle.SelectedValue.ToString() + "，月份:" + btyf + ",批次:" + btbat + "", "确认以下条件吗？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (intotemp())
                        {
                            MessageBox.Show("导入临时表成功，共导入" + dgvPreview.Rows.Count.ToString() + "条数据", "提示");
                            btnIN.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("导入失败");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("没有数据", "提示");
                }
            }
            else
            {
                MessageBox.Show("临时表中尚有数据，请先清空临时表。", "提示");
            }
        }
        private void btnMatch_Click(object sender, EventArgs e)
        {
            Model.BTDJTEMP model = new Model.BTDJTEMP();
            bool id = b_btdj.UpObjectid(model);
            bool ty = b_btdj.UptypeID(model);
            bool zh = b_btdj.UpAccountnum(model);
            if (id && ty && zh)
            {
                MessageBox.Show("数据比对完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btncheck_Click(object sender, EventArgs e)
        {
            int ct = int.Parse(b_btdj.GetErrCount(" typeid IS NULL OR objectid IS NULL ").ToString());
            if (ct == 0)
            {
                MessageBox.Show("数据校验正确，可以导入补贴登记表", "提示");
                btnintobtdj.Enabled = true;
            }
            else
            {
                MessageBox.Show("尚有" + ct.ToString() + "条数据未通过验证，不能导入。请清空临时表", "警告");
            }
        }
        private void frmImport_Load(object sender, EventArgs e)
        {
            btnintobtdj.Enabled = false;
            btnIN.Enabled = false;
            tb = int.Parse(b_btdj.exists("  table_name = 'BTDJTEMP'").ToString());//是否存在临时表
            cmbbank.DataSource = b_btdj.GetBank("").Tables[0];
            cmbbank.ValueMember = "bankcode";
            cmbbank.DisplayMember = "bankname";
            cmbbank.SelectedIndex = 0;
            panel2.Visible = false;
            panel3.Visible = false;
            cmbCycle.DataSource = Common.BasicData.collection;
            cmbCycle.DisplayMember = "name";
            cmbCycle.ValueMember = "id";
            cmbCycle.SelectedIndex = 0;
        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            bool flag = b_btdj.delete("");
            if (flag)
            {
                MessageBox.Show("临时表已清空", "提示");
            }
        }
        private void btnintobtdj_Click(object sender, EventArgs e)
        {
            bool flag = b_fsregistration.imptodjb("");
            if (flag)
            {
                MessageBox.Show("导入补贴系统补贴登记表成功", "提示");
            }
        }
        private void cmbbtlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbbatch.DataSource = b_fsregistration.GetBatch(" year=" + DateTime.Now.ToString("yyyy") + " and typecode='" + cmbbtlx.SelectedValue.ToString() + "'").Tables[0];
            cmbbatch.DisplayMember = "description";
            cmbbatch.ValueMember = "batchcode";
        }
        private void cmbbatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            label11.Text = cmbbatch.SelectedValue.ToString();
            batchid = ((DataRowView)cmbbatch.SelectedItem)["batchid"].ToString();
            batchcode = int.Parse(cmbbatch.SelectedValue.ToString());
            btbat = cmbbatch.SelectedValue.ToString();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label12.Text = cmbbank.SelectedValue.ToString();
        }
        private void cmbCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCycle.SelectedValue.ToString() == "4")
            {
                panel3.Visible = false;
                panel2.Visible = true;
                cmbbtlx.DataSource = b_btlx.GetList(" AND LSSUECYCLE=4 ").Tables[0];
                cmbbtlx.DisplayMember = "TYPENAME";
                cmbbtlx.ValueMember = "TYPECODE";
                label10.Text = cmbbtlx.SelectedValue.ToString();
            }
            else
            {
                panel2.Visible = false;
            }
            if (cmbCycle.SelectedValue.ToString() == "3")
            {
                panel3.Visible = true;
                cmbmonth.DataSource = Common.BasicData.GetMonths();
            }
            else
            {
                panel3.Visible = false;
            }
        }
        private void cmbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            offset = cmbmonth.SelectedValue.ToString();
            btyf = cmbmonth.SelectedValue.ToString();
        }
    }
}
