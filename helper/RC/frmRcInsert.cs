using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
namespace hnbthelper
{
    public partial class frmRcInsert : Common.DockContent
    {
        BLL.BLL_BTLX B_BTLX = new BLL.BLL_BTLX();
        BLL.BLL_BATCH B_BATCH = new BLL.BLL_BATCH();
        string strConn;
        DataTable dtSql = new DataTable();
        DataTable dtParm = new DataTable();
        public frmRcInsert()
        {
            InitializeComponent();
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
        private OleDbConnection ReturnConnection(string fileName)
        {
            return new OleDbConnection(strConn);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmInsert_Load(object sender, EventArgs e)
        {
            cmbCycle.DataSource = Common.BasicData.collection;
            cmbCycle.DisplayMember = "name";
            cmbCycle.ValueMember = "id";
            cmbCycle.SelectedIndex = 0;
            cmbType.DataSource = B_BTLX.GetList("").Tables[0];
            cmbType.DisplayMember = "TYPENAME";
            cmbType.ValueMember = "TYPECODE";
            cmbBatch.DataSource = B_BATCH.GetList("").Tables[0];
            cmbBatch.DisplayMember = "BATCHNAME";
            cmbBatch.ValueMember = "BATCHID";
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
                cmbBatch.DataSource = B_BATCH.GetList(" TYPECODE='"+id.ToString()+"' ORDER BY BATCHID" ).Tables[0];
                cmbBatch.DisplayMember = "BATCHNAME";
                cmbBatch.ValueMember = "BATCHID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void btnLook_Click(object sender, EventArgs e)
        {
            try
            {
                ImportExcel();
                dtParm.Columns.Add("Id");
                dtParm.Columns.Add("Value");
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
            dataGridView1.DataSource = dsExcel.Tables[0];
            dtParm.Clear();
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                string str = dataGridView1.Columns[i].HeaderText;
                dtParm.Rows.Add();
                dtParm.Rows[i][0] = i;
                dtParm.Rows[i][1] = str;
            }
            GetParm();
            if (dataGridView1.Rows.Count > 0)
            {
                btnLook.Enabled = false;
                btnIN.Enabled = true;
            }
        }
        /// <summary>
        /// 获取参数
        /// </summary>
        private void GetParm()
        {
            //dtSql.Clear();
            //panel2.Controls.Clear();
            List<Common.BasicData.Master> master = new List<Common.BasicData.Master>();
            master = Common.BasicData.master;
            dtSql.Columns.Add("name");
            dtSql.Columns.Add("value");
            foreach (var info in master)
            {
                DataRow dr = dtSql.NewRow();
                dr["name"] = info.name;
                dr["value"] = info.value;
                dtSql.Rows.Add(dr);
            }
            for (int i = 0; i < dtSql.Rows.Count; i++)
            {
                DataRow dr = dtSql.Rows[i];
                Label Label = new Label();
                Label.Text = dr["value"].ToString() + ":";
                Label.Name = dr["name"].ToString();
                Label.Size = new Size(117, 21);
                Label.Location = new Point(0, 25 * i + 5);
                panel1.Controls.Add(Label);
                ComboBox Cmb = new ComboBox();
                Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                Cmb.Name = dr["name"].ToString();
                Cmb.Size = new Size(200, 21);
                Cmb.Location = new Point(0, 25 * i + 5);
                Cmb.Items.Remove(Cmb.SelectedIndex);
                Cmb.Items.Add("");
                for (int j = 0; j < dtParm.Rows.Count; j++)
                {
                    Cmb.Items.Add(dtParm.Rows[j][1].ToString());
                }
                Cmb.SelectedIndexChanged += (o, j) =>
                {
                    Cmb.Items.Remove(Cmb.SelectedIndex);//索引发生变化时，移除选中当前项目
                };
                panel2.Controls.Add(Cmb);
            }
        }
        private void btnIN_Click(object sender, EventArgs e)
        {
            if (cmbBatch.Text == "")
            {
                MessageBox.Show("批次不能为空！", "提示");
                return;
            }
            if (cmbType.Text == "")
            {
                MessageBox.Show("补贴类型不能为空！", "提示");
                return;
            }
            DataTable dtType = new DataTable();
            string strSql2 = "SELECT * from countydata.rcbtdjtemp where rownum=0";
            dtType = DBUtility.DbHelperOra.Query(strSql2).Tables[0];
            string strType;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            string sqlstr = "";
            string sqlValue = "";
            string sqlValueEnd = "";
            foreach (Control cl in panel2.Controls)
            {
                if (cl is ComboBox)
                {
                    if (((ComboBox)cl).Text != "")
                    {
                        sqlstr = sqlstr + "," + ((ComboBox)cl).Name;
                        sqlValue = sqlValue + "," + ((ComboBox)cl).Text + "";
                        strType = dtType.Columns["" + ((ComboBox)cl).Name + ""].DataType.ToString();
                        switch (strType)
                        {
                            case "System.Int32":
                                for (int k = 0; k < dt.Rows.Count; k++)
                                {
                                    try
                                    {
                                        string strd = dt.Rows[k][((ComboBox)cl).Text].ToString();
                                        Convert.ToInt32(dt.Rows[k][((ComboBox)cl).Text]);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("" + ((ComboBox)cl).Text + "的第" + (k + 1).ToString() + "行数据类型不正确！不能进行导入");
                                        return;
                                    }
                                }
                                break;
                            case "System.Double":
                                for (int k = 0; k < dt.Rows.Count; k++)
                                {
                                    try
                                    {
                                        Convert.ToDouble(dt.Rows[k][((ComboBox)cl).Text]);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("" + ((ComboBox)cl).Text + "的第" + (k + 1).ToString() + "行数据类型不正确！不能进行导入!");
                                        return;
                                    }
                                }
                                break;
                            case "System.Decimal":
                                for (int k = 0; k < dt.Rows.Count; k++)
                                {
                                    try
                                    {
                                        Convert.ToDecimal(dt.Rows[k][((ComboBox)cl).Text]);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("" + ((ComboBox)cl).Text + "的第" + (k + 1).ToString() + "行数据类型不正确！不能进行导入!");
                                        return;
                                    }
                                }
                                break;
                            case "System.Boolean":
                                for (int k = 0; k < dt.Rows.Count; k++)
                                {
                                    try
                                    {
                                        Convert.ToBoolean(dt.Rows[k][((ComboBox)cl).Text]);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("" + ((ComboBox)cl).Text + "的第" + (k + 1).ToString() + "行数据类型不正确！不能进行导入!");
                                        return;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            sqlstr = sqlstr.Substring(1);
            sqlValue = sqlValue.Substring(1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sqlValueEnd = "";
                string[] str = sqlValue.Split(',');
                for (int k = 0; k < str.Length; k++)
                {
                    sqlValueEnd = sqlValueEnd + ",'" + dt.Rows[i][str[k]].ToString() + "'";
                }
                sqlValueEnd = sqlValueEnd.Substring(1);
                try
                {
                    DBUtility.DbHelperOra.ExecuteSql("insert into countydata.rcbtdjtemp(btlx,batchid," + sqlstr + ",regdate,fsyear) values('" + cmbType.SelectedValue + "','" + cmbBatch.SelectedValue + "'," + sqlValueEnd + ",'" + System.DateTime.Now + "'," + Convert.ToInt32(System.DateTime.Now.Year) + ")");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("第" + (i + 1).ToString() + "行数据类型不正确！不能进行导入!");
                    return;
                }
            }
            MessageBox.Show("数据导入成功！", "提示");
        }
    }
}
