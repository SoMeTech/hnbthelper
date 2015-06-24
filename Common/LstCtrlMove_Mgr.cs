using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace Common
{
    //用于统一处理两个List类型控件之间互相转移Items
    public static class LstCtrlMove_Mgr<T>
    {
        //从一个ListBox中删除Items
        public static void RemoveItems(ListBox lstBox, IEnumerable items)
        {
            if (typeof(T) == typeof(DataRow))
            {
                DataTable dt = ((DataTable)lstBox.DataSource);
                DataTable newDt = dt.Clone();
                bool flag = false;
                //因为直接删除DataRow会保存，所以用这样丑陋的方式处理了
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataRowView item in items)
                    {
                        if (dr == item.Row)
                        {
                            flag = true;
                            break;
                        }
                        else
                            flag = false;
                    }
                    if (!flag)
                        newDt.Rows.Add(dr.ItemArray);
                    else
                        continue;
                }
                lstBox.DataSource = newDt;
            }
            else
            {
                List<T> lst = new List<T>();
                lst.AddRange((List<T>)lstBox.DataSource);
                lst.RemoveAll(delegate(T item1)
                {
                    foreach (T item2 in items)
                    {
                        if (item1.Equals(item2))
                            return true;
                    }
                    return false;
                });
                lstBox.DataSource = lst;
            }
        }
        //向一个ListBox中添加Items
        public static void AddItems(ListBox lstBox, IEnumerable items)
        {
            if (typeof(T) == typeof(DataRow))
            {
                DataTable dt = null;
                foreach (object item in items)
                {
                    if (item is DataRowView)
                        dt = ((DataRowView)item).Row.Table.Clone();
                    if (item is DataRow)
                        dt = ((DataRow)item).Table.Clone();
                    break;
                }
                if (lstBox.DataSource != null)
                    dt = ((DataTable)lstBox.DataSource).Copy();
                foreach (object item in items)
                {
                    if (item is DataRowView)
                        dt.Rows.Add(((DataRowView)item).Row.ItemArray);
                    if (item is DataRow)
                        dt.Rows.Add(((DataRow)item).ItemArray);
                }
                lstBox.DataSource = dt;
            }
            else
            {
                List<T> lst = new List<T>();
                if (lstBox.DataSource != null)
                    lst.AddRange((List<T>)lstBox.DataSource);
                foreach (T item in items)
                {
                    lst.Add(item);
                }
                lstBox.DataSource = lst;
            }
        }
        //将ListBox1的选定项转移到ListBox2中，并从ListBox1中去除
        public static void Move(ListBox lstBox1, ListBox lstBox2)
        {
            if (lstBox1.SelectedItems.Count > 0)
            {
                AddItems(lstBox2, lstBox1.SelectedItems);
                RemoveItems(lstBox1, lstBox1.SelectedItems);
            }
        }
        //将整个lstBox1的项转移到ListBox2中，并清空ListBox1
        public static void MoveAll(ListBox lstBox1, ListBox lstBox2)
        {
            if (typeof(T) == typeof(DataRow))
            {
                DataTable dt = (DataTable)lstBox1.DataSource;
                AddItems(lstBox2, dt.Rows);
                lstBox1.DataSource = dt.Clone();
            }
            else
            {
                AddItems(lstBox2, (List<T>)lstBox1.DataSource);
                lstBox1.DataSource = new List<T>();
            }
        }
    }
}