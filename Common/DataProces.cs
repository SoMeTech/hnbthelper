﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
namespace Common
{
    public class DataProces
    {
        public DataTable GetMenuDt(DataTable dt)
        {
            if (Common.BasicData.UserPower.Length == 6)
            {
                if (Common.BasicData.UserPower == "431106")
                {
                    return dt;
                }
                else
                {
                    DataTable tmp = dt.Clone();
                    DataRow[] drs = dt.Select("MenuGroupName<>'汝城县专用功能(&R)'");
                    foreach (DataRow dr in drs)
                    {
                        tmp.Rows.Add(dr.ItemArray);
                    }
                    return tmp;
                }
            }
            else
            {
                DataTable tmp = dt.Clone();
                DataRow[] drs = dt.Select("MenuGroupName='数据查询导出(&E)'");
                foreach (DataRow dr in drs)
                {
                    tmp.Rows.Add(dr.ItemArray);
                }
                return tmp;
            }
        }
        /// <summary>
        /// datatable导出为Excel
        /// </summary>
        /// <param name="dataTable">datatable</param>
        /// <param name="isShowExcle">是否显示</param>
        /// <returns></returns>
        public bool DataTableToExcel(DataTable dataTable, bool isShowExcle)
        {
            int rowNumber = dataTable.Rows.Count;//不包括字段名 
            int columnNumber = dataTable.Columns.Count;
            int colIndex = 0;
            if (rowNumber == 0)
            {
                return false;
            }
            //建立Excel对象 
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //excel.Application.Workbooks.Add(true); 
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            excel.Visible = isShowExcle;
            //Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.Worksheets[1]; 
            Microsoft.Office.Interop.Excel.Range range;
            //生成字段名称 
            foreach (DataColumn col in dataTable.Columns)
            {
                colIndex++;
                excel.Cells[1, colIndex] = col.ColumnName;
            }
            object[,] objData = new object[rowNumber, columnNumber];
            for (int r = 0; r < rowNumber; r++)
            {
                for (int c = 0; c < columnNumber; c++)
                {
                    objData[r, c] = dataTable.Rows[r][c];
                }
                //Application.DoEvents(); 
            }
            // 写入Excel 
            range = worksheet.get_Range(excel.Cells[2, 1], excel.Cells[rowNumber + 1, columnNumber]);
            range.NumberFormat = "@";//设置单元格为文本格式 
            range.Value2 = objData;
            worksheet.get_Range(excel.Cells[2, 1], excel.Cells[rowNumber + 1, 1]).NumberFormat = "yyyy-m-d h:mm";
            return true;
        }
        /// <summary>
        /// 两个datatable合并
        /// </summary>
        /// <param name="dt1">要合并的表一dt1</param>
        /// <param name="dt2">要合并的表二dt2</param>
        /// <param name="KeyColName">dt1与dt2联系的关键列名(类似与 select *from dt1 left join dt2)</param>
        public DataTable MergeDataTable(DataTable dt1, DataTable dt2, String KeyColName)
        {
            //定义临时变量 
            DataTable dtReturn = new DataTable();
            int i = 0;
            int j = 0;
            int k = 0;
            int colKey1 = 0;
            int colKey2 = 0;
            //设定表dtReturn的名字 
            dtReturn.TableName = dt1.TableName + "_" + dt2.TableName;
            //设定表dtReturn的列名 
            for (i = 0; i < dt1.Columns.Count; i++)
            {
                if (dt1.Columns[i].ColumnName == KeyColName)
                {
                    colKey1 = i;
                }
                dtReturn.Columns.Add(dt1.Columns[i].ColumnName, dt1.Columns[i].DataType);
            }
            for (j = 0; j < dt2.Columns.Count; j++)
            {
                if (dt2.Columns[j].ColumnName == KeyColName)
                {
                    colKey2 = j;
                    continue;
                }
                dtReturn.Columns.Add(dt2.Columns[j].ColumnName, dt2.Columns[j].DataType);
            }
            //建立表的空间 
            for (i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr;
                dr = dtReturn.NewRow();
                dtReturn.Rows.Add(dr);
            }
            #region Add data into dtReturn...
            //将表dt1,dt2的数据写入dtReturn 
            for (i = 0; i < dt1.Rows.Count; i++)
            {
                int m = -1;
                //表dt1的第i行数据拷贝到dtReturn中去 
                for (j = 0; j < dt1.Columns.Count; j++)
                {
                    dtReturn.Rows[i][j] = dt1.Rows[i][j];
                }
                //查找的dt2中KeyColName的数据,与dt1相同的行
                for (k = 0; k < dt2.Rows.Count; k++)
                {
                    if (dt1.Rows[i][colKey1].ToString() == dt2.Rows[k][colKey2].ToString())
                    {
                        m = k;
                    }
                }
                //表dt2的第m行数据拷贝到dtReturn中去,且不要KeyColName(ID)列 
                if (m != -1)
                {
                    for (k = 0; k < dt2.Columns.Count; k++)
                    {
                        if (k == colKey2)
                        {
                            continue;
                        }
                        dtReturn.Rows[i][j] = dt2.Rows[m][k];
                        j++;
                    }
                }
            }
            #endregion
            return dtReturn;
        }
        /// <summary>
        /// datagridview导出Excel,
        /// </summary>
        /// <param name="fname">保存的文件名</param>
        /// <param name="strCaption">标题行</param>
        /// <param name="myDGV">datagridview</param>
        /// <returns></returns>
        public static string ExportExcel(string fname, string strCaption, DataGridView myDGV)
        {
            string result = "";
            // 列索引，行索引，总列数，总行数
            int ColIndex = 0;
            int RowIndex = 0;
            int ColCount = myDGV.ColumnCount;
            int RowCount = myDGV.RowCount + 1;
            if (myDGV.RowCount == 0)
            {
                result = "没有数据可供导出";
            }
            // 创建Excel对象
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            if (xlApp == null)
            {
                result = "创建Excel文件失败";
            }
            try
            {
                // 创建Excel工作薄
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Microsoft.Office.Interop.Excel.Worksheet xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlBook.Worksheets[1];
                // 设置标题
                Microsoft.Office.Interop.Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, ColCount]); //标题所占的单元格数与DataGridView中的列数相同
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = strCaption;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, ColCount];
                //获取列标题
                foreach (DataGridViewColumn col in myDGV.Columns)
                {
                    objData[RowIndex, ColIndex++] = col.HeaderText;
                }
                // 获取数据
                for (RowIndex = 1; RowIndex < RowCount; RowIndex++)
                {
                    for (ColIndex = 0; ColIndex < ColCount; ColIndex++)
                    {
                        if (myDGV[ColIndex, RowIndex - 1].ValueType == typeof(string)
                            || myDGV[ColIndex, RowIndex - 1].ValueType == typeof(DateTime))//这里就是验证DataGridView单元格中的类型,如果是string或是DataTime类型,则在放入缓存时在该内容前加入" ";
                        {
                            objData[RowIndex, ColIndex] = "'" + myDGV[ColIndex, RowIndex - 1].Value;
                        }
                        else
                        {
                            objData[RowIndex, ColIndex] = myDGV[ColIndex, RowIndex - 1].Value;
                        }
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount, ColCount]);
                range.Value2 = objData;
                //保存
                xlBook.Saved = true;
                xlBook.SaveCopyAs(fname);
                //返回值
                result = "成功导出，保存在c:\\";
            }
            catch (Exception)
            {
                result = "出现错误";
            }
            finally
            {
                xlApp.Quit();
                GC.Collect(); //强制回收
            }
            return result;
        }
        /// <summary>
        /// 将运行的SQL脚本保存在日志中
        /// </summary>
        /// <param name="SQLString">sql脚本</param>
        public static void writelog(string SQLString)
        {
            StreamWriter sw;
            if (!File.Exists(@"oraclelog.txt"))
            {
                sw = File.CreateText(@"oraclelog.txt");
            }
            else
            {
                sw = File.AppendText(@"oraclelog.txt");
                sw.WriteLine(SQLString);
            }
            sw.Close();
        }
        public static void ExportToTxt(string fn, DataView dv)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt(*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.Title = "导出txt文件到 ";
            DateTime now = DateTime.Now;
            saveFileDialog1.FileName = fn + now.Second.ToString().PadLeft(2, '0');
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
        public static DataTable OutPutTable(DataTable dt)
        {
            var dict = ColumnDict();
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ColumnName = dict[dt.Columns[i].ColumnName];
            }
            return dt;
        }
        private readonly static Func<Dictionary<string, string>> ColumnDict = () => new Dictionary<string, string> 
        {
        { "SSSSOBJECTNAME", "姓名" }, 
        { "SSSSIDCARDNUM", "身份证号" }, 
        { "HOMEADDRESS", "家庭住址" },
        {"OBJECTCODE","农户代码"},
        {"ACCOUNTNUM","银行账号"},
        {"ZDMJ","早稻面积"},
        {"MDMJ","中稻面积"},
        {"WDMJ","晚稻面积"},
        {"ZBMJ","直补面积"},
        {"BTJE","补贴金额"},
        {"GH","工号"},
        {"YXM","原姓名"},
        {"YZH","原账号"},
        {"DZ","家庭住址"},
        {"LB","补贴类别"},
        {"JE","补贴金额"},
        {"WFYY","未发原因"}
        };
    }
}