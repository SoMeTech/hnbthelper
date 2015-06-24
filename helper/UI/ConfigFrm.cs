using System;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.IO;
namespace hnbthelper
{
    public partial class ConfigFrm : Common.DockContent
    {
        BLL.BLL_BASEOBJECT b_basic = new BLL.BLL_BASEOBJECT();
        BLL.BLL_BTDJTEMP B_btdj = new BLL.BLL_BTDJTEMP();
        public ConfigFrm()
        {
            InitializeComponent();
        }
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (txtservice.Text == "")
            {
                MessageBox.Show("服务名为空", "提示");
                return;
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("用户名为空", "提示");
                return;
            }
            else
            {
                string datakeyvalue;
                //datakeyvalue = "Data Source=" + txtservice.Text + ";User ID=" + txtName.Text + ";Password=" + txtPwd.Text + ";Unicode=True";//需要oracle客户端
                //以下无需oracle客户端，可用Instant
                datakeyvalue = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + txtIP.Text + ")(PORT=1521))(CONNECT_DATA=(SID=" + txtservice.Text + ")));Unicode=True;User Id=" + txtName.Text + ";Password=" + txtPwd.Text + "";
                //加密
                string wdv = Common.DES.DESEncrypt(datakeyvalue, "WENWARDH");
                File.WriteAllText(@"config.ini",wdv);
                MessageBox.Show("数据库设置成功,程序将重启", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Application.Restart();
        }
        private void btncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            //备份程序命令名称
            string strEXEName = @"exp";
            //备份程序的参数字符串
            string strCmdParam = @" " + getArgs()[2] + "/" + getArgs()[3] + "@" + getArgs()[1] + " file =D:\\hnbtoracle" + DateTime.Now.ToString("yyyymmdd") + ".dmp" + " owner=" + getArgs()[2] + " log=D:\\hnbtoracle" + DateTime.Now.ToString("yyyymmdd") + ".log";
            //创建进程,并把备份程序的相关参数赋值给该进程
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = strEXEName;
            proc.StartInfo.Arguments = strCmdParam;
            //运行进程
            if (MessageBox.Show("备份文件将保存在D盘根目录下", "确认？", MessageBoxButtons.OKCancel) == DialogResult.OK) 
            { 
            try
            {
                proc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("你的电脑未安装Oracle客户端。"+ex.Message);
                return;
            }
            }
            //添加进程退出响应事件
            //*proc.Exited += new EventHandler(MyProcessExited);
            //设置进程退出事件执行的参数
            proc.EnableRaisingEvents = true;
            proc.SynchronizingObject = null;
            //MessageBox.Show("Waiting for the process 'mspaint' to exit....");
            //等待进程退出
            proc.WaitForExit();
            //进程关闭
            proc.Close();
        }
        private void btnResore_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此功能暂不开放", "提示");
        }
        private static void CreateFuntion()
        {
            string connection = File.ReadAllText(@"config.ini");
            System.Data.OracleClient.OracleConnection cnn = new OracleConnection(connection);
            string filepath = "Function.txt";
            System.IO.StreamReader sr = new System.IO.StreamReader(filepath);
            string sqlstr = sr.ReadToEnd();
            sr.Close();
            System.Data.OracleClient.OracleCommand Command = new System.Data.OracleClient.OracleCommand(sqlstr, cnn);
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
        public string[] getArgs()
        {
            string strCnn =  File.ReadAllText(@"config.ini");
            string[] strs = strCnn.Split(new char[3] { ';', '(', ')' });
            string hostname = "";//IP地址
            string service = "";//服务名或实例名
            string userID = "";//用户名
            string password = "";//密码
            #region 获取
            foreach (string str in strs)
            {
                if (str.Contains("HOST"))//SQLServer服务器名称
                {
                    hostname = str.Substring(str.IndexOf("=") + 1);
                }
                else
                {
                    if (str.Contains("SID"))
                    {
                        service = str.Substring(str.IndexOf("=") + 1);
                    }
                    else
                    {
                        if (str.Contains("User Id"))
                        {
                            userID = str.Substring(str.IndexOf("=") + 1);
                        }
                        else
                        {
                            if (str.Contains("Password"))
                            {
                                password = str.Substring(str.IndexOf("=") + 1);
                            }
                        }
                    }
                }
            }
            string[] result = new string[4];
            result[0] = hostname;
            result[1] = service;
            result[2] = userID;
            result[3] = password;
            return result;
            #endregion
        }
    }
}
