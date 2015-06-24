using System;
using System.Windows.Forms;
namespace hnbthelper
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool runone;
            System.Threading.Mutex run = new System.Threading.Mutex(true, "hnbthelper", out runone);
            //验证是否启动当前系统两次
            if (!runone)
            {
                MessageBox.Show("【湖南补贴系统助手】程序已经运行，请查看右下角的系统托盘区域！", "提示");
                return;
            }
            // 验证应用程序是否被改名，启动程序改名后将不允许运行
            string exeName = Application.ExecutablePath.Substring(Application.ExecutablePath.LastIndexOf("\\") + 1);
            if (!exeName.ToLower().Equals("hnbthelper.exe"))
            {
                MessageBox.Show("无法找到启动程序！", "提示");
                return;
            }
            //string oraclePath = System.Windows.Forms.Application.StartupPath;
            //Environment.SetEnvironmentVariable("PATH", oraclePath, EnvironmentVariableTarget.Process);
            //Environment.SetEnvironmentVariable("NLS_LANG", "SIMPLIFIED CHINESE_CHINA.ZHS16GBK", EnvironmentVariableTarget.Process);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            frmLogin login = new frmLogin();
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
            

                Application.Run(new frmMain());
            }
            else { return; }
        }
    }
}
