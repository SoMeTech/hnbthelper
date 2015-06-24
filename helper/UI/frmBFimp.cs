using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.IO;
using Common;
using System.Collections;
namespace hnbthelper
{
    public partial class frmBFimp : Common.DockContent
    {
        public frmBFimp()
        {
            InitializeComponent();
        }
        BLL.BLL_WFBT b_wfbt = new BLL.BLL_WFBT();
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
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtParm.Clear();
            dtParm.Columns.Clear();
            dtParm.Columns.Add("Id");
            dtParm.Columns.Add("Value");
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            OleDbDataAdapter myCommand = null;
            string strExcel = "SELECT * from [" + cmbTable.SelectedValue + "$]";
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
        }
        public void ImportExcel()
        {
            string strFile = ShowOpenFileDialog("Excel 文件", "Excel 文件|*.xls;*.xlsx");
            if (strFile == "") return;
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
        public static string ShowOpenFileDialog(string title, string filter)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "打开" + title;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
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
        private void btnIN_Click(object sender, EventArgs e)
        {
            int ct = int.Parse(b_wfbt.GetErrCount("").ToString());
            if (ct == 0)
            {
                if (dgvPreview.RowCount >= 1)
                {
                    if (MessageBox.Show(" ", "确认导入吗？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    { 
                        if (intowfbt())
                        {
                            //这个地方错误，当未导入时，不能提示导入成功
                            MessageBox.Show("导入补发数据成功，共导入" + dgvPreview.Rows.Count.ToString() + "条数据，", "提示");
                            btnIN.Enabled = false;
                            dgvbf.DataSource = Common.DataProces.OutPutTable(b_wfbt.GetList("").Tables[0]);
                            cmbLb.DataSource = b_wfbt.GetLb("").Tables[0];
                            cmbLb.DisplayMember = "lb";
                            cmbLb.ValueMember = "lb";
                        }
                        else
                        {
                            MessageBox.Show("导入失败");
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有数据", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("原表中尚有数据，请先清空临时表。", "提示");
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            bool flag = b_wfbt.delete("");
            if (flag)
            {
                MessageBox.Show("临时表已清空", "提示");
            }
            dgvbf.DataSource = Common.DataProces.OutPutTable(b_wfbt.GetList("").Tables[0]);
            cmbLb.DataSource = b_wfbt.GetLb("").Tables[0];
            cmbLb.DisplayMember = "lb";
            cmbLb.ValueMember = "lb";
        }
        public bool intowfbt()
        {
            Model.WFBT model = new Model.WFBT();
            int id = 0;
            try
            {
                for (int i = 0; i < dgvPreview.Rows.Count; i++)
                {
                    id = 0 + i;
                    model.Gh = int.Parse(dgvPreview.Rows[i].Cells[0].Value.ToString());
                    model.Yxm = dgvPreview.Rows[i].Cells[1].Value.ToString();
                    model.Je = decimal.Parse(dgvPreview.Rows[i].Cells[2].Value.ToString());
                    model.Lb = dgvPreview.Rows[i].Cells[3].Value.ToString();
                    model.Yzh = dgvPreview.Rows[i].Cells[4].Value.ToString();
                    model.Wfyy = dgvPreview.Rows[i].Cells[5].Value.ToString();
                    b_wfbt.impWFBT(model);
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("第" + (id + 1).ToString() + "行数据类型不正确！无法导入!");
                b_wfbt.delete("");
                return false;
                throw;                
            }
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                dataUp();
                MessageBox.Show("处理成功！");
                dgvbf.DataSource = Common.DataProces.OutPutTable(b_wfbt.GetList("").Tables[0]);
                cmbLb.DataSource = b_wfbt.GetLb("").Tables[0];
                cmbLb.DisplayMember = "lb";
                cmbLb.ValueMember = "lb";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private static void dataUp()
        {
            string connection = Common.DES.DESDecrypt(File.ReadAllText(Application.StartupPath.ToString() + "\\config.ini"), "WENWARDH");
            System.Data.OracleClient.OracleConnection cnn = new OracleConnection(connection);
            try
            {
                for (int i = 1; i < 3; i++)
                {
                    string filepath = Application.StartupPath.ToString() + "\\" + i.ToString() + ".txt";
                    System.IO.StreamReader sr = new System.IO.StreamReader(filepath);
                    string sqlstr = sr.ReadToEnd().Replace("\r\n", " ").Replace("\n", " ");
                    sr.Close();
                    System.Data.OracleClient.OracleCommand Command = new System.Data.OracleClient.OracleCommand(sqlstr, cnn);
                    Command.Connection.Open();
                    Command.ExecuteNonQuery();
                    Command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void frmBFimp_Load(object sender, EventArgs e)
        {
            cmbLb.DataSource = b_wfbt.GetLb("").Tables[0];
            cmbLb.DisplayMember = "lb";
            cmbLb.ValueMember = "lb";
            dgvbf.DataSource = Common.DataProces.OutPutTable(b_wfbt.GetList("").Tables[0]);
            cmbLb.SelectedIndexChanged+=new EventHandler(cmbLb_SelectedIndexChanged);
        }
        private void btnExp_Click(object sender, EventArgs e)
        {
            string strwhere = string.Empty;
            b_wfbt.DeleteCurr("");
            DataTable dt = b_wfbt.Currentpay(" where lb='" + cmbLb.SelectedValue.ToString() + "'").Tables[0];
            ArrayList SQLStringList = new ArrayList();
            string str = "INSERT INTO COUNTYDATA.CURRENTPAY(ACCOUNTNUM,SSSSOBJECTNAME,GH,SSSSIDCARDNUM,REGMONEY)  VALUES(";
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strwhere = "'" + dt.Rows[i][0].ToString() + "','" + dt.Rows[i][1].ToString() + "'," + dt.Rows[i][2].ToString() + ",'" + dt.Rows[i][3].ToString() + "'," + dt.Rows[i][4].ToString() + ")";
                    SQLStringList.Add(str + strwhere);
                }
                DBUtility.DbHelperOra.ExecuteSqlTran(SQLStringList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            DataView dv = b_wfbt.GetFF(" group by gh,ACCOUNTNUM,SSSSOBJECTNAME,SSSSIDCARDNUM ").Tables[0].DefaultView;
            ExportToTxt(dv);
        }
        public void ExportToTxt(DataView dv)
        {
            string fn = "bf" + Common.ChineseToSpell.GetChineseSpell(cmbLb.SelectedValue.ToString()).ToLower();//此处把值转换为拼音
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt(*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.Title = "导出txt文件到 ";
            DateTime now = DateTime.Now;
            saveFileDialog1.FileName = fn;
            saveFileDialog1.ShowDialog();
            Stream myStream;
            myStream = saveFileDialog1.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            for (int rowNo = 0; rowNo < dv.Count; rowNo++)
            {
                String tempstr = "";
                for (int columnNo = 0; columnNo < dv.Table.Columns.Count; columnNo++)
                {
                    if (columnNo > 0)
                    {
                        tempstr += "\t ";
                    }
                    tempstr += dv.Table.Rows[rowNo][columnNo].ToString();
                }
                sw.WriteLine(tempstr);
            }
            sw.Close();
            myStream.Close();
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            DataTable dv = b_wfbt.GetList("").Tables[0];
            Common.DataProces toexcel = new DataProces();
           toexcel.DataTableToExcel(dv, true);
        }
        private void cmbLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = " lb='" + cmbLb.SelectedValue.ToString() + "'";
            dgvbf.DataSource = Common.DataProces.OutPutTable(b_wfbt.GetList(str).Tables[0]);
        }
    }
}
