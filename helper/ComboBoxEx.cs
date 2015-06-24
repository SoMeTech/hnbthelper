using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
namespace hnbthelper
{
    /// <summary>
    /// 可带ToolTip的组合框控件
    /// </summary>
    public class ComboBoxEx : ComboBox
    {
        /// <summary>
        /// 这个子类窗口用来存放下拉列表窗口，通过它来操作下拉列表
        /// </summary>
        private SubWindow m_SubWindow;
        /// <summary>
        /// 通常的构造函数
        /// </summary>
        public ComboBoxEx()
        {
        }
        /// <summary>
        /// 处理Windows的消息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            //通过这个消息可以得到下拉列表的窗口名柄
            if (m.Msg == 0x210 && (int)m.WParam == 0x3e80001)
            {
                //构建子类化窗口
                SubWindow sw = new SubWindow();
                //把当前ComboBox实例做为属性传入方便处理
                sw.Owner = this;
                //把得到的列表句柄关联到子类窗口类上。
                sw.AssignHandle(m.LParam);
                //这里的做用是保证子类窗口和ComboBoxEx生存期同步
                this.m_SubWindow = sw;
            }
            base.WndProc(ref m);
        }
        /// <summary>
        /// 重写以释放子类
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.m_SubWindow != null)
            {
                this.m_SubWindow.DestroyHandle();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
    /// <summary>
    /// 子类化窗口的类
    /// </summary>
    internal class SubWindow : NativeWindow
    {
        /// <summary>
        /// 为了得到列表上的鼠标坐标而使用Api函数及其所用到的数据结构
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        /// <summary>
        /// 映射窗体的坐标
        /// </summary>
        /// <param name="hWndFrom">源窗口句柄</param>
        /// <param name="hWndTo">要影射到的窗口句柄</param>
        /// <param name="pt">转换前后的坐标数据</param>
        /// <param name="cPoints"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, [In, Out] POINT pt, int cPoints);
        /// <summary>
        /// 为了得到指定坐标下的项而需要向列表发送消息
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        /// <summary>
        /// 为了得到指定索引的列表的内容而需要向列表发送消息，因为列表文本可能被格式化，所以这是合理的。
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, StringBuilder lParam);
        /// <summary>
        /// 上一索引值
        /// </summary>
        private int m_Index;
        /// <summary>
        /// 用来显示信息ToolTip
        /// </summary>
        private ToolTip toolTip;
        /// <summary>
        /// 所属性的ComboBox
        /// </summary>
        private Control m_Owner;
        /// <summary>
        /// 构造函数
        /// </summary>
        public SubWindow()
        {
            this.m_Index = -1;
            this.toolTip = new ToolTip();
        }
        /// <summary>
        /// 所属的控件
        /// </summary>
        public Control Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }
        /// <summary>
        /// 处理鼠标的消息以显示ToolTip信息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x200)
            {
                //获取鼠标坐标
                Point msPoint = Cursor.Position;
                POINT pt = new POINT(msPoint.X, msPoint.Y);
                //影射到列表上的坐标
                MapWindowPoints(IntPtr.Zero, this.Handle, pt, 1);
                //获取鼠标下的项的索引
                int index = SendMessage(m.HWnd, 0x1a9, 0, (pt.y << 0x10) | (pt.x & 0xffff));
                if (((index >> 0x10) & 0xffff) == 0)
                {
                    index = (index & 0xffff);
                    if (m_Index != index)
                    {
                        //获取项的字符串的长度
                        int num = SendMessage(this.Handle, 0x18a, index, 0);
                        StringBuilder lParam = new StringBuilder(num + 1);
                        //获取项的字符串内容
                        SendMessage(this.Handle, 0x189, index, lParam);
                        //获取鼠标在所属的控件的坐标信息
                        Point owPoint = this.Owner.PointToClient(msPoint);
                        //设置ToolTip信息并显示
                        this.toolTip.RemoveAll();
                        this.toolTip.Show(lParam.ToString(), this.Owner, owPoint.X + 10, owPoint.Y + 10, 1000);
                        m_Index = index;
                    }
                }
            }
            base.WndProc(ref m);
        }
    }
}