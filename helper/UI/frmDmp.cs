using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
namespace hnbthelper
{
    public partial class frmdmp : Common.DockContent
    {
        public frmdmp()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = Application.ExecutablePath
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = this.label11.Text = dialog.FileName;
                FileStream stream = File.OpenRead(path);
                stream.Seek(0L, SeekOrigin.Begin);
                byte[] buffer = new byte[100];
                stream.Read(buffer, 0, 50);
                string input = new UTF8Encoding(true).GetString(buffer, 0, buffer.Length);
                string[] strArray = Regex.Split(input, ":V", RegexOptions.IgnoreCase);
                Match match = new Regex(@":V\d{2}\.\d{2}\.\d{2}").Match(input);
                this.label9.Text = match.Index.ToString();
                this.label10.Text = match.Length.ToString();
                this.textBox1.Text = Regex.Split(match.Value, ":V", RegexOptions.IgnoreCase)[1];
                stream.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"\d{2}\.\d{2}\.\d{2}");
            if (regex.Match(this.textBox1.Text).Success)
            {
                FileStream stream = File.OpenWrite(this.label11.Text);
                stream.Seek((long)(int.Parse(this.label9.Text.ToString()) + 2), SeekOrigin.Begin);
                byte[] bytes = new UTF8Encoding(true).GetBytes(this.textBox1.Text);
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
                MessageBox.Show("版本修改成功。");
            }
            else
            {
                MessageBox.Show("版本格式错误。");
            }
        }
    }
}
