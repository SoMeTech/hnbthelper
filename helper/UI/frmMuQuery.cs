using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using DBUtility;
namespace hnbthelper
{
    public partial class frmMuQuery : Common.DockContent
    {
        AutoSizeForm asc = new AutoSizeForm();
        public frmMuQuery()
        {
            InitializeComponent();
        }
        BLL.BLL_BASEOBJECT b_basic = new BLL.BLL_BASEOBJECT();
        string strConn;
        private void frmMuQuery_Size_Changeed(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
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
            cmbTable.DataSource = LoadSchemaFromFile(strFile);
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
            dgvPreview.DataSource = dsExcel.Tables[0];
        }
        private void frmMuQuery_Load(object sender, EventArgs e)
        {
            cmbType.DataSource = Common.BasicData.querytype;
            cmbType.DisplayMember = "name";
            cmbType.ValueMember = "id";
            btnQuery.Enabled = false;
            btnToExcel.Enabled = false;
            asc.controlAutoSize(this);
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            #region 方法二，建立临时表
            //按身份证查询
            if (cmbType.SelectedValue.ToString() == "1")
            {
                DbHelperOra.ExecuteSql("update countydata.querytb set queryid='^1'||translate(queryid,'1234567890X','BA@GFEDKJC+') where queryid not like '^1%'");               
                dt = b_basic.GetByCardTemp("").Tables[0];
            }
            //按银行账号查询
            else
            {
                dt = b_basic.GetByYhzhTemp("").Tables[0];
            }
            DataTable dtExcel = new DataTable();
            //dtExcel = (DataTable)dgvPreview.DataSource;
            dtExcel = b_basic.getquery("").Tables[0];
            dtExcel.Columns[0].ColumnName = "QUERY";
            Common.DataProces dp = new Common.DataProces();
            dgvShow.DataSource = dp.MergeDataTable(dtExcel, dt, "QUERY");
            btnToExcel.Enabled = true;
        }
            #endregion
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvShow.DataSource;
            Common.DataProces toexcel = new Common.DataProces();
            toexcel.DataTableToExcel(dt, true);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBefor_Click(object sender, EventArgs e)
        {
            b_basic.DelQuery("");
            string strwhere = string.Empty;
            ArrayList SQLStringList = new ArrayList();
            string str = "INSERT INTO countydata.querytb (queryid)  VALUES(";
            DataTable dt = (DataTable)dgvPreview.DataSource;
            try
            {
                for (int i = 0; i < dgvPreview.Rows.Count; i++)
                {
                    strwhere = "'" + dt.Rows[i][0].ToString() +"')";
                    SQLStringList.Add(str + strwhere);
                    //B_sjdc.imptcurr(strwhere);
                }
                DBUtility.DbHelperOra.ExecuteSqlTran(SQLStringList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            btnQuery.Enabled = true;
            
        }


    }
}
