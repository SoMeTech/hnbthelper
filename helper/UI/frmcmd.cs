using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace hnbthelper
{
    public partial class frmcmd : Common.DockContent
    {
        Process p;
        StreamWriter input;
        public frmcmd()
        {
            InitializeComponent();
            p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.Start();
            input = p.StandardInput;
            p.BeginOutputReadLine();
        }
        //_5_1_a__s_p_x
        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            update(e.Data + Environment.NewLine);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            input.WriteLine(textBox1.Text);
            textBox1.SelectAll();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            p.Close();
        }
        delegate void updateDelegate(string msg);
        void update(string msg)
        {
            if (this.InvokeRequired)
                Invoke(new updateDelegate(update), new object[] { msg });
            else
            {
                textBox2.Text += msg;
                textBox2.SelectionStart = textBox2.Text.Length - 1;
                textBox2.ScrollToCaret();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}