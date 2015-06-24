using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
namespace hnbthelper
{
    public partial class frmRCpay : Common.DockContent
    {
        BLL.BLL_BTLX B_BTLX = new BLL.BLL_BTLX();
        BLL.BLL_BATCH B_BATCH = new BLL.BLL_BATCH();
        string strConn;
        public frmRCpay()
        {
            InitializeComponent();
        }
        private void frmRCpay_Load(object sender, EventArgs e)
        {
            cmbCycle.DataSource = Common.BasicData.collection;
            cmbCycle.DisplayMember = "name";
            cmbCycle.ValueMember = "id";
            cmbType.DataSource = B_BTLX.GetList("").Tables[0];
            cmbType.DisplayMember = "TYPENAME";
            cmbType.ValueMember = "TYPECODE";
        }
        private void cmbCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cmbCycle.SelectedValue.ToString();
            if (id.Length != 1)
            {
                id = "0";
            }
            try
            {
                cmbType.DataSource = B_BTLX.GetList(" AND LSSUECYCLE=" + id.ToString()).Tables[0];
                cmbType.DisplayMember = "TYPENAME";
                cmbType.ValueMember = "TYPECODE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cmbType.SelectedValue.ToString();
            try
            {
                cmbBatch.DataSource = B_BATCH.GetList(" TYPECODE='" + id.ToString() + "' ORDER BY BATCHID").Tables[0];
                cmbBatch.DisplayMember = "BATCHNAME";
                cmbBatch.ValueMember = "BATCHID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
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
            comboBox1.DataSource = LoadSchemaFromFile(strFile);
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
            if (cmbBatch.Text == "")
            {
                MessageBox.Show("批次不能为空！");
                return;
            }
            if (cmbType.Text == "")
            {
                MessageBox.Show("补贴类型不能为空！");
                return;
            }
            DataTable dt=(DataTable)dgvpre.DataSource;
            if (dgvpre.Rows.Count == 0) return;
            //for (int i = 0; i < dgvpre.Rows.Count; i++)
            //{
            //    try
            //    {
            //        Convert.ToInt32(dgvpre.Rows[i].Cells[0]);
            //        
            //    }
            //    catch
            //    {
            //        MessageBox.Show("第" + (i + 1).ToString() + "行第零列数据类型不正确！不能进行导入");
            //        return;
            //    }
            //    try
            //    {
            //        Convert.ToBoolean(dgvpre.Rows[i].Cells[0]);
            //    }
            //    catch
            //    {
            //        MessageBox.Show("第" + (i + 1).ToString() + "行第零列数据类型不正确！不能进行导入");
            //        return;
            //    }
            //}
            else
            {
                for (int j = 0; j < dgvpre.Rows.Count; j++)
                {
                    try
                    {
                        DBUtility.DbHelperOra.ExecuteSql("update countydata.RCbtdjtemp set ff =" + dt.Rows[j][1].ToString() + ", ffdate='" + System.DateTime.Now + "', wfyy='" + dt.Rows[j][2].ToString() + "' where gh=" + dt.Rows[j][0].ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("第" + (j + 1).ToString() + "行数据类型不正确！此行以及此行以下不能进行导入!");
                        return;
                    }
                }
                MessageBox.Show("更新发放情况成功！");
            }
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            OleDbDataAdapter myCommand = null;
            string strExcel = "SELECT * from [" + comboBox1.SelectedValue + "$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            DataSet dsExcel = new DataSet();
            myCommand.Fill(dsExcel, "table1");
            conn.Close();
            dgvpre.DataSource = dsExcel.Tables[0];
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }
    }
}
