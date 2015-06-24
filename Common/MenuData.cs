using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace Common
{
    public class MenuData
    {
        private static DataTable dt_role = new DataTable();
        private MenuData() { }
        static MenuData()
        {
            dt_role.Columns.Add("MenuGroupName", typeof(string));
            dt_role.Columns.Add("FunctionName", typeof(string));
            dt_role.Columns.Add("FrmName", typeof(string));
            dt_role.Columns.Add("ICO", typeof(Int16));
            dt_role.Columns.Add("FrmCode", typeof(string));
            dt_role.Columns.Add("IsAutoLoad", typeof(string));
            string[] rows = File.ReadAllLines(Application.StartupPath + @"\b.txt");
            foreach (string row in rows)
                dt_role.Rows.Add(row.Split(','));
        }
        public static DataTable RoleTable
        {
            get { return dt_role; }
        }
    }
}
