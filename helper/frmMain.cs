using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Runtime.Remoting;
using WeifenLuo.WinFormsUI.Docking;
using System.Reflection;
namespace hnbthelper
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void ShowFrmTools()
        {
            if (m_FrmTools == null || m_FrmTools.IsDisposed)
            {
                m_FrmTools = new frmTools();
            }
            m_FrmTools.AutoHidePortion = 0.15;
            m_FrmTools.Show(dockPanel, DockState.DockLeft);
        }
        private frmTools m_FrmTools = new frmTools();
        private Singleton singleton = Singleton.Instance;
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.关于ToolStripMenuItem.Image = icoLargeList.Images[17];
            this.重新登录ToolStripMenuItem.Image = icoLargeList.Images[1];
            this.退出ToolStripMenuItem.Image = icoLargeList.Images[2];
            singleton.m_FrmMain = this;
            ShowFrmTools();
            InitMenu();
            this.toolStripStatusLabel4.Text = "系统当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.timer1.Interval = 1000;
            this.timer1.Start();
            toolStripStatusLabel2.Text = "当前用户：" + Common.BasicData.UserName;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel4.Text = "系统当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        //初始化菜单
        private void InitMenu()
        {
            //   MainMenuStrip.AutoSize = false;
            //初始化datatable
            //MainMenu.Items.Clear();
            string menuGroupName = string.Empty;
            string funcationName = string.Empty;
            string frmName = string.Empty;
            int icoIndex;
            Common.DataProces dp = new Common.DataProces();
            DataTable dt_role = dp.GetMenuDt(Common.MenuData.RoleTable);
            //遍历datatable增加菜单项
            for (int i = 0; i < dt_role.Rows.Count; i++)
            {
                DataRow dr = dt_role.Rows[i];
                menuGroupName = dr["MenuGroupName"].ToString();
                funcationName = dr["FunctionName"].ToString();
                frmName = dr["FrmName"].ToString();
                icoIndex = int.Parse(dr["ICO"].ToString());
                //创建二级子菜单
                ToolStripMenuItem tsi = new ToolStripMenuItem(funcationName, icoLargeList.Images[icoIndex]);
                tsi.Tag = frmName;
                tsi.Click += new EventHandler(tsi_Click);
                //创建工具栏
                ToolStripButton tsb = new ToolStripButton(funcationName, icoLargeList.Images[icoIndex]);
                tsb.Tag = frmName;
                tsb.ToolTipText = funcationName;
                tsb.Click += new EventHandler(tsb_Click);
                tsb.TextImageRelation = TextImageRelation.ImageAboveText;
                MainToolStrip.Items.Add(tsb);
                MainToolStrip.Items.Add(new ToolStripSeparator());
                MenuAddNewFunction(menuGroupName, tsi);
            }
        }
        //创建二级菜单
        private void MenuAddNewFunction(string menuGroupName, ToolStripMenuItem childItem)
        {
            //首先判断一级菜单是否存在
            ToolStripDropDownItem rootMenu = null;
            foreach (ToolStripDropDownItem item in MainMenu.Items)
            {
                if (item.Text == menuGroupName)
                {
                    rootMenu = item;
                    break;
                }
            }
            //不存在一级菜单则创建相应一级菜单
            if (rootMenu == null)
            {
                MainMenu.Items.Add(menuGroupName);
                rootMenu = MainMenu.Items[MainMenu.Items.Count - 1] as ToolStripDropDownItem;
            }
            //创建二级子菜单
            rootMenu.DropDownItems.Add(childItem);
        }
        //菜单clicked事件
        void tsi_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = sender as ToolStripDropDownItem;
            string frmName = tsi.Tag.ToString();
            if (!string.IsNullOrEmpty(frmName))
            {
                    ShowFunctionFrm(frmName);
                    toolStripStatusLabel3.Text = tsi.Text;
            }
        }
        /// <summary>
        /// 工具栏CLICKED方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tsb_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            string frmName = tsb.Tag.ToString();
            if (!string.IsNullOrEmpty(frmName))
            {          
                    ShowFunctionFrm(frmName);
                    toolStripStatusLabel3.Text = tsb.Text;

            }
        }
        public Dictionary<string, Common.DockContent> m_FunctionName = new Dictionary<string, Common.DockContent>();
        public void ShowFunctionFrm(string frmName)
        {
            if (!m_FunctionName.ContainsKey(frmName))
            {
                m_FunctionName.Add(frmName, null);
            }
            if (m_FunctionName[frmName] == null || m_FunctionName[frmName].IsDisposed)
            {
                ObjectHandle obj = Activator.CreateInstance(Assembly.GetExecutingAssembly().GetName().Name, frmName);
                m_FunctionName[frmName] = (Common.DockContent)obj.Unwrap();
            }
            m_FunctionName[frmName].AutoHidePortion = 0.15;
            m_FunctionName[frmName].Show(dockPanel, DockState.Document);
        }

        private void 修改dmp文件版本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdmp fm = new frmdmp();
            ShowFunctionFrm(this.GetType().Namespace.ToString() + "." + fm.Name);
        }

        private void 重新登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox fm = new AboutBox();
            fm.ShowDialog();
        }

        private void 命令行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcmd fm = new frmcmd();
            ShowFunctionFrm(this.GetType().Namespace.ToString() + "." + fm.Name);
        }
    }
}
