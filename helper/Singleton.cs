using System;
using System.Collections.Generic;
namespace hnbthelper
{
    /// <summary>
    /// 这个类很重要，主要用来保存 一些临时信息，可以在整个项目中使用
    /// </summary>
    public sealed class Singleton
    {         
        private static volatile Singleton instance;
        private static object syncRoot = new Object();
        private Singleton() { }
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Singleton();
                    }
                }
                return instance;
            }
        }
        public interface IPugins
        {
            string FrmCode { get; }
            string FrmName { get; }
        }
        public class SubMenu
        {
            public string FrmCode { set; get; }
            public string FrmName { set; get; }
            public string Ico { set; get; }
        }
        public Dictionary<string, IPugins> DicLoadDll = new Dictionary<string, IPugins>(); //装载当前的插件
        public Dictionary<string, IPugins> DicPugins = new Dictionary<string, IPugins>(); //缓存所有的插件
        public Dictionary<string, SubMenu> DicTcode = new Dictionary<string, SubMenu>(); //TCode
        //public string UserID;
        //public string Password;
        //public string UserDep;
        //public string ServerID;
        //public string Lang;
        public hnbthelper.frmMain m_FrmMain;
        //public string Company;
        //public string AppConfigFile;
        //public Dictionary<string, string> DicLang;       
        //public string Role;
        //public string RoleName; 
        //public string WorkBeginTime;        
        //public string currentlyVersion = "1.001";
        //public string ServerVersion;
        //public string SystemName = "Allen.Tools";
        //public string UserDetailUserID;
        //public string AllowCreate;
        //public string AllowDelete;
        //public string AllowEdit;
        //public string AllowPrint;
        //public static class GlobalData
        //{
        //    public static Dictionary<string, Action> dict = new Dictionary<string, Action>();
        //}
    }
}
