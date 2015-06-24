using System.Collections.Generic;
namespace Common
{
    public class BasicData
    {
        /// <summary>
        /// 发放周期
        /// </summary>
        public class Cycle
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public static List<Cycle> collection = new List<Cycle>
            {
                new Cycle {id=0,name="按年发放"},
                new Cycle {id=1,name="按半年发放"},
                new Cycle {id=2,name="按季度发放"},
                new Cycle {id=3,name="按月发放"},
                new Cycle {id=4,name="不定期发放"},
            };
        public class Master
        {
            public string name { get; set; }
            public string value { get; set; }
        }
        public static List<Master> master = new List<Master> 
        {
                new Master {name="object_name",value="补贴对象姓名"},
                new Master {name="zhm",value="账户名"},
                new Master {name="sfzh",value="身份证号"},
                new Master {name="dz",value="家庭地址"},
                new Master {name="lxdh",value="联系电话"},
                new Master {name="yhzh",value="银行账号"},
                new Master {name="btsl",value="补贴数量"},
                new Master {name="btbz",value="补贴标准"},
                new Master {name="btje",value="补贴金额"},
                new Master {name="memo",value="备注"},
                new Master {name="expand1",value="扩展1"},
                new Master {name="expand2",value="扩展2"},
                new Master {name="expand3",value="扩展3"},
                new Master {name="expand4",value="扩展4"},
                new Master {name="expand5",value="扩展5"}
        };
        /// <summary>
        /// 汇总方式
        /// </summary>
        public class SumType
        {
            public int id { get; set; }
            public string text { get; set; }
        }
        public static List<SumType> sumtype = new List<SumType>
        {
            new SumType {id=0,text="本级汇总"},
            new SumType{id=1,text="下一级汇总"}
        };
        /// <summary>
        /// 用户权限
        /// </summary>
        private static string _userPower;
        public static string UserPower
        {
            get { return _userPower; }
            set { _userPower = value; }
        }
        private static string _userName;

        public static string UserName
        {
            get { return BasicData._userName; }
            set { BasicData._userName = value; }
        }
    

        /// <summary>
        /// 查询关键字
        /// </summary>
        public class Key
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        public static List<Key> key = new List<Key> 
            {
               new Key{id="01",name="对象姓名"},
               new Key{id="02",name="身份证号"},
               new Key{id="03",name="家庭地址"},
               new Key{id="04",name="银行账号"},
            };
        /// <summary>
        /// 查询类型
        /// </summary>
        public class QueryType
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        public static List<QueryType> querytype = new List<QueryType>
        {
            new QueryType{id="1",name="按身份证查询" },
            new QueryType{id="2",name="按银行账号查询"}
        };
        /// <summary>
        /// 月份，每年12个月
        /// </summary>
        /// <returns></returns>
        public static List<string> GetMonths()
        {
            List<string> GetMonths = new List<string>();
            for (int i = 1; i < 13; i++)
            {
                GetMonths.Add(i.ToString("00"));
            }
            return GetMonths;
        }
    }
}
