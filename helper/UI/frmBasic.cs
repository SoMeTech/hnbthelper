using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace hnbthelper
{
    public partial class frmBasic : Common.DockContent
    {
        BLL.BLL_BASEOBJECTCOMPANY B_town = new BLL.BLL_BASEOBJECTCOMPANY();
        BLL.BLL_BASEOBJECT b_basic = new BLL.BLL_BASEOBJECT();
        BLL.BLL_FSREGISTRATION B_sjdc = new BLL.BLL_FSREGISTRATION();
        AutoSizeForm asc = new AutoSizeForm();
        public frmBasic()
        {
            InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("此功能尚未开发", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataView dv = b_basic.CNM("").Tables[0].DefaultView;
            string fn = "CNM";
            Common.DataProces.ExportToTxt(fn, dv);
        }
        private void frmBasic_Load(object sender, EventArgs e)
        {
            DataTable dt = B_town.GetList(" length(categorycode)=9 AND INSTR(categorycode,'"+Common.BasicData.UserPower+"')>0 order by CATEGORYCODE").Tables[0];
            DataRow dr = dt.NewRow();
            dr["CATEGORYNAME"] = "全部乡镇";
            dr["CATEGORYCODE"] = "0";
            dt.Rows.InsertAt(dr, 0);
            cmbTown.DataSource = dt;
            cmbTown.DisplayMember = "CATEGORYNAME";
            cmbTown.ValueMember = "CATEGORYCODE";
            cmbKey.DataSource = Common.BasicData.key;
            cmbKey.DisplayMember = "name";
            cmbKey.ValueMember = "id";
            //button5.Enabled = false;
            asc.controllInitializeSize(this);
        }
        private void frmBasic_Size_Changeed(object sender, EventArgs e)
    {
        asc.controlAutoSize(this);
        //  this.WindowState = (System.Windows.Forms.FormWindowState)(2);//记录完控件的初始位置和大小后，再最大化
    }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strKey = "";
            string strTown = "";
            if (cmbKey.SelectedValue.ToString() == "01")
            {
                strKey = " AND INSTR(SSSSOBJECTNAME,'" +Common.DES.ssssencrypt(txtKey.Text.Trim()) + "')>0";
            }
            if (cmbKey.SelectedValue.ToString() == "02")
            {
                strKey = " AND  INSTR(SSSSIDCARDNUM,'" + Common.DES.ssssencrypt(txtKey.Text.Trim()) + "')>0 ";
            }
            if (cmbKey.SelectedValue.ToString() == "03")
            {
                strKey = " AND INSTR(HOMEADDRESS,'" + txtKey.Text.Trim() + "')>0 ";
            }
            if (cmbKey.SelectedValue.ToString() == "04")
            {
                strKey = " and objectid in (select objectid from countydata.baseobjectaccount where instr(accountnum,'" + txtKey.Text.Trim() + "')>0) ";
            }
            if (cmbTown.SelectedValue.ToString() == "0")
            {
                strTown = "";
            }
            else
            {
                strTown = " AND INSTR(OBJECTCODE,'" + cmbTown.SelectedValue.ToString() + "')>0";
            }
            dgvBasic.DataSource = b_basic.GetBasic(strKey.ToString() + strTown.ToString()).Tables[0];
        }
        private void button2_Click(object sender, EventArgs e)
        {
            GetbasicToExcel();
        }
       
        public void GetbasicToExcel()
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            excel.Visible = true;
            int k = Common.BasicData.UserPower.Length + 3;
            Microsoft.Office.Interop.Excel.Range range;
            object oMissing = System.Reflection.Missing.Value;
            DataSet dpds;
            dpds = B_town.GetList(" LENGTH(CATEGORYCODE)="+k.ToString()+" AND INSTR(categorycode,'" + Common.BasicData.UserPower + "')>0 ORDER BY CATEGORYCODE");
            if (dpds.Tables[0] != null)
            {
                foreach (DataRow dr in dpds.Tables[0].Rows)
                {
                    string id = string.Empty;
                    foreach (Control ctrl in groupBox3.Controls)
                    {
                        if (ctrl is RadioButton)
                        {
                            if (((RadioButton)ctrl).Checked)
                            {
                                id = ctrl.Tag.ToString();
                            }
                        }
                    }
                    DataSet operationds = new System.Data.DataSet();
                    if (id == "")
                    {
                        operationds = b_basic.ExptoExcelBasic(" AND SUBSTR(OBJECTCODE,1,"+k.ToString()+")=\'" + dr["CATEGORYCODE"].ToString() + "\'");
                    }
                    else
                    {
                        operationds = b_basic.ExptoExcelBasic(" AND SUBSTR(OBJECTCODE,1," + k.ToString() + ")=\'" + dr["CATEGORYCODE"].ToString() + "\' AND ISENABLE=" + int.Parse(id));
                    }
                    DataTable dt =Common.DataProces.OutPutTable(operationds.Tables[0]);
                    int rowNumber = dt.Rows.Count;//不包括字段名
                    int columnNumber = dt.Columns.Count;
                    int colIndex = 0;
                    if (operationds.Tables[0] != null)
                    {
                        //foreach (DataRow ddr in operationds.Tables[0].Rows)
                        //{
                        //    ddr["农户代码"] = dr["CATEGORYNAME"];
                        //}
                        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(oMissing, oMissing, 1, oMissing);
                        worksheet.Name = dr["CATEGORYNAME"].ToString();
                        foreach (DataColumn col in dt.Columns)
                        {
                            colIndex++;
                            excel.Cells[1, colIndex] = col.ColumnName;
                        }
                        object[,] objData = new object[rowNumber, columnNumber];
                        for (int r = 0; r < rowNumber; r++)
                        {
                            for (int c = 0; c < columnNumber; c++)
                            {
                                objData[r, c] = dt.Rows[r][c];
                            }
                            //Application.DoEvents();
                        }
                        // 写入Excel 
                        range = worksheet.get_Range(excel.Cells[2, 1], excel.Cells[rowNumber + 1, columnNumber]);
                        range.NumberFormat = "@";//设置单元格为文本格式
                        range.Value2 = objData;
                        worksheet.get_Range(excel.Cells[2, 1], excel.Cells[rowNumber + 1, 1]).NumberFormat = "yyyy-m-d h:mm";
                        operationds.Dispose();
                    }
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
                GetzbmjToExcel();
        }
        public void GetzbmjToExcel()
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            excel.Visible = true;
            Microsoft.Office.Interop.Excel.Range range;
            object oMissing = System.Reflection.Missing.Value;
            DataTable dpds = new DataTable();
            int k = Common.BasicData.UserPower.Length + 3;
            dpds = B_town.GetList(" LENGTH(CATEGORYCODE)="+k.ToString()+" AND INSTR(categorycode,'" + Common.BasicData.UserPower + "')>0 ORDER BY CATEGORYCODE").Tables[0];
            if (dpds!= null)
            {
                foreach (DataRow dr in dpds.Rows)
                {
                    string id = string.Empty;
                    foreach (Control ctrl in groupBox3.Controls)
                    {
                        if (ctrl is RadioButton)
                        {
                            if (((RadioButton)ctrl).Checked)
                            {
                                id = ctrl.Tag.ToString();
                            }
                        }
                    }
                    DataTable dt = new DataTable();
                    if (id == "")
                    {
                        dt = b_basic.GetZbmj(" AND SUBSTR(OBJECTCODE,1," + k.ToString() + ")=\'" + dr["CATEGORYCODE"].ToString() + "\'").Tables[0];
                    }
                    else
                    {
                        dt = b_basic.GetZbmj(" AND SUBSTR(OBJECTCODE,1," + k.ToString() + ")=\'" + dr["CATEGORYCODE"].ToString() + "\' AND ISENABLE=" + int.Parse(id)).Tables[0];
                    }
                    DataTable dt1 = Common.DataProces.OutPutTable(dt);
                    int rowNumber = dt1.Rows.Count;//不包括字段名
                    int columnNumber = dt1.Columns.Count;
                    int colIndex = 0;
                    if (dt1 != null)
                    {
                        //foreach (DataRow ddr in operationds.Tables[0].Rows)
                        //{
                        //    ddr["农户代码"] = dr["CATEGORYNAME"];
                        //}
                        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(oMissing, oMissing, 1, oMissing);
                        worksheet.Name = dr["CATEGORYNAME"].ToString();
                        foreach (DataColumn col in dt.Columns)
                        {
                            colIndex++;
                            excel.Cells[1, colIndex] = col.ColumnName;
                        }
                        object[,] objData = new object[rowNumber, columnNumber];
                        for (int r = 0; r < rowNumber; r++)
                        {
                            for (int c = 0; c < columnNumber; c++)
                            {
                                objData[r, c] = dt1.Rows[r][c];
                            }
                            //Application.DoEvents();
                        }
                        // 写入Excel 
                        range = worksheet.get_Range(excel.Cells[2, 1], excel.Cells[rowNumber + 1, columnNumber]);
                        range.NumberFormat = "@";//设置单元格为文本格式
                        range.Value2 = objData;
                        worksheet.get_Range(excel.Cells[2, 1], excel.Cells[rowNumber + 1, 1]).NumberFormat = "yyyy-m-d h:mm";
                        dt.Dispose();
                    }
                }
            }
        }
        private void 复制CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string copyCode = this.dgvBasic.CurrentCell.Value.ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            DataView dv = b_basic.ExpBasic(" ORDER BY OBJECTCODE ").Tables[0].DefaultView;
            string fn = "基础数据";
            Common.DataProces.ExportToTxt(fn, dv);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strwhere=string.Empty;
            ArrayList SQLStringList = new ArrayList();
            B_sjdc.DeleteCurr("");
            DataTable dt =b_basic.CNM("").Tables[0];
             string str = "INSERT INTO COUNTYDATA.CURRENTPAY(SSSSOBJECTNAME,OBJECTID,SSSSIDCARDNUM,OBJECTCODE)  VALUES(";
             try
             {
                 for (int i = 0; i < dt.Rows.Count; i++)
                 {
                     strwhere = "'" + dt.Rows[i][0].ToString() + "','" + dt.Rows[i][1].ToString() + "','" + dt.Rows[i][2].ToString() + "','" + dt.Rows[i][3].ToString() + "')";
                     SQLStringList.Add(str + strwhere);
                 }
                 DBUtility.DbHelperOra.ExecuteSqlTran(SQLStringList);
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
             }
        }
    }
}
