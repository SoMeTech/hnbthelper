using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace hnbthelper
{
    public partial class frmLogin : Form
    {
        BLL.BLL_T_PF_USER b_user = new BLL.BLL_T_PF_USER();
        ArrayList al = new ArrayList(); //用此存储用户名 当然还想存储密码就用Dictionary<>
        public frmLogin()
        {
            InitializeComponent();
        }
        //登陆按钮
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = this.comboBox1.Text;
            DataTable dt = new DataTable();
            //check name
            if (true) //存在此用户
            {
                if (this.checkBox1.Checked)  //勾选记住用户
                {
                    if (!al.Contains(name)) //如果al中没有这个用户
                    {
                        FileStream fs = new FileStream("user.data", FileMode.Create); //创建新文件user.data
                        BinaryFormatter bf = new BinaryFormatter(); //创建二进制序列化对象
                        al.Add(name);
                        bf.Serialize(fs, al); //序列化到fs
                        fs.Close();           //关闭文件流
                    }
                }
                dt = b_user.GetList(" LOGINNAME='" + name + "'").Tables[0];
                if (dt.Rows.Count > 0)//数据库存在此用户
                {
                    string inpwd = Common.DES.Jm(txtPwd.Text.ToString());
                    string dbname = dt.Rows[0]["LOGINNAME"].ToString();
                    string dbpwd = dt.Rows[0]["PASSWRD"].ToString();
                    string usercode = dt.Rows[0]["USERCODE"].ToString();
                    if (inpwd == dbpwd && dbname == name)
                    {
                        this.DialogResult = DialogResult.OK;
                        Common.BasicData.UserPower = usercode.Substring(0, usercode.Length - 3);
                        Common.BasicData.UserName = dbname;
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误！");
                    }
                }
                else
                {
                    MessageBox.Show("不存在此用户！");
                }
            }
            else
            {
                //no user
            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPwd.Text = "";
        }
        //窗体load 读取本地user.data文件，获取用户
        private void frmLogin_Load(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("user.data", FileMode.OpenOrCreate);//打开user.data，若不存在就建立新的
            if (fs.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                al = bf.Deserialize(fs) as ArrayList; //将打开的文件流反序列化到al
                foreach (string item in al)
                {
                    this.comboBox1.Items.Add(item); //将al各项添加到combobox中
                }
            }
            fs.Close();  //关闭流
            this.comboBox1.SelectedIndex = this.comboBox1.Items.Count - 1; //设置combobox默认项
        }
    }
}
