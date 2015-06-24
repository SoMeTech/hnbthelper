using LumiSoft.UI.Controls.WOutlookBar;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
namespace hnbthelper
{
    public partial class frmTools : DockContent
    {
        public frmTools()
        {
            InitializeComponent();
        }
        private WOutlookBar _outlookBar = null;
        private Singleton singleton = Singleton.Instance;
        private void wOutlookBar_BarClicked(object sender, LumiSoft.UI.Controls.WOutlookBar.BarClicked_EventArgs e)
        {
        }
        private void wOutlookBar_ItemClicked(object sender, LumiSoft.UI.Controls.WOutlookBar.ItemClicked_EventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Item.Tag.ToString().Trim()))
            {              
                    singleton.m_FrmMain.ShowFunctionFrm(e.Item.Tag.ToString().Trim());
                    singleton.m_FrmMain.toolStripStatusLabel3.Text = e.Item.Caption.ToString();
            }
        }
        private void frmTools_Load(object sender, EventArgs e)
        {
            //dt_role = new BLL.sys_SetRoleManager().GetUserRoleByUserID(allensingleton.UserID);
            _outlookBar = new LumiSoft.UI.Controls.WOutlookBar.WOutlookBar();
            //_outlookBar.BorderStyle = BorderStyle.FixedSingle; 
            _outlookBar.ImageList = singleton.m_FrmMain.icoLargeList;
            _outlookBar.ImageListSmall = singleton.m_FrmMain.icoLargeList;
            _outlookBar.Dock = DockStyle.Fill;
            _outlookBar.ItemClicked += wOutlookBar_ItemClicked;
            _outlookBar.BarClicked += wOutlookBar_BarClicked;
            _outlookBar.ViewStyle.BarClientAreaColor = Color.Wheat;//工具箱的背影颜色
            _outlookBar.ViewStyle.BarItemHotTextColor = Color.Blue;//鼠标悬浮在菜单上面的时候菜单的文字前景色
            _outlookBar.ViewStyle.BarItemTextColor = Color.Black;//菜单的文字前景色
            _outlookBar.ViewStyle.BarColor = Color.CadetBlue;//主菜单名称的背景颜色
            //_outlookBar.ViewStyle.BarClientAreaColor = Color.LightBlue;//工具箱的背影颜色
            _outlookBar.ViewStyle.BarItemHotTextColor = Color.Red;//鼠标悬浮在菜单上面的时候菜单的文字前景色
            //_outlookBar.ViewStyle.BarItemTextColor = Color.Black;//菜单的文字前景色
            //_outlookBar.ViewStyle.BarColor = Color.Violet;//主菜单名称的背景颜色
            Item it = null;
            Bar bar = null;
            string strMenu = string.Empty;
            Common.DataProces dp = new Common.DataProces();
            DataTable dt_role = dp.GetMenuDt(Common.MenuData.RoleTable);
            for (int i = 0; i < dt_role.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(strMenu) || strMenu != dt_role.Rows[i]["MenuGroupName"].ToString())
                {
                    //处理快捷键如“系统设置(&M)”
                    string str = dt_role.Rows[i]["MenuGroupName"].ToString();
                    int index = str.IndexOf("(");
                    if (index != -1)
                        str = str.Remove(index);
                    bar = _outlookBar.Bars.Add(str);
                    bar.ItemsStyle = ItemsStyle.IconSelect;
                    strMenu = dt_role.Rows[i]["MenuGroupName"].ToString();
                }
                it = bar.Items.Add(dt_role.Rows[i]["FunctionName"].ToString(), dt_role.Rows[i]["FrmName"].ToString(),
                                   int.Parse(dt_role.Rows[i]["ICO"].ToString()), true, dt_role.Rows[i]["FrmName"].ToString());
                it.AllowStuck = false;
            }
            //_outlookBar.BackColor = Color.Red;
            ploutlookBar.Controls.AddRange(new Control[] { _outlookBar });
        }
    }
}
