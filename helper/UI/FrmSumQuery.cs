using System;
using System.Data;
using System.Windows.Forms;
namespace hnbthelper
{
    public partial class FrmSumQuery : Common.DockContent
    {
        BLL.BLL_BTLX B_BTLX = new BLL.BLL_BTLX();
        BLL.BLL_BASEOBJECTCOMPANY B_town = new BLL.BLL_BASEOBJECTCOMPANY();
        BLL.BLL_FSREGISTRATION b_fsregistration = new BLL.BLL_FSREGISTRATION();
        int l = Common.BasicData.UserPower.Length + 3;
        string k = Common.BasicData.UserPower;
        public FrmSumQuery()
        {
            InitializeComponent();
        }
        private void FrmSumQuery_Load(object sender, EventArgs e)
        {
            int year = DateTime.Now.AddYears(-5).Year;
            for (int i = 0; i <= 10; i++)
            {
                cmbyear.Items.Add(year + i);
            }
            cmbWhere.DataSource = Common.BasicData.sumtype;
            cmbWhere.DisplayMember = "text";
            cmbWhere.ValueMember = "id";
            if(l!=9)
            {
                //cmbWhere.Enabled = false;
                cmbWhere.SelectedIndex = 1;
                cmbTown.DataSource = B_town.GetList(" length(categorycode)=" + l  + " AND INSTR(CATEGORYCODE,'" + k + "')>0 order by CATEGORYCODE").Tables[0];
                cmbTown.DisplayMember = "CATEGORYNAME";
                cmbTown.ValueMember = "CATEGORYCODE";
            }
            cmbyear.SelectedItem = int.Parse(DateTime.Now.ToString("yyyy"));
            cmbTown.Enabled = false;
            cmbCycle.DataSource = Common.BasicData.collection;
            cmbCycle.DisplayMember = "name";
            cmbCycle.ValueMember = "id";
            cmbWhere.SelectedIndex = 0;
            cmbCycle.SelectedIndex = 0;            
            cmbBtlx.DataSource = B_BTLX.GetList("").Tables[0];
            cmbBtlx.DisplayMember = "TYPENAME";
            cmbBtlx.ValueMember = "TYPECODE";
            cmbBtlx.SelectedIndex = 0;
        }
        private void cmbWhere_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (l != 9)
            {
                cmbTown.DataSource = B_town.GetList(" length(categorycode)=" + (l-3) + " AND INSTR(CATEGORYCODE,'" + k + "')>0 order by CATEGORYCODE").Tables[0];
                cmbTown.DisplayMember = "CATEGORYNAME";
                cmbTown.ValueMember = "CATEGORYCODE";
            }
            if (cmbWhere.SelectedValue.ToString() == "1")
            {
                cmbTown.Enabled = true;
                cmbTown.DataSource = B_town.GetList(" length(categorycode)=" + l + " AND INSTR(CATEGORYCODE,'" + k + "')>0 order by CATEGORYCODE").Tables[0];
                cmbTown.DisplayMember = "CATEGORYNAME";
                cmbTown.ValueMember = "CATEGORYCODE";
            }
            else
            {
                cmbTown.Enabled = false;
            }
        }
        private void cmbCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cmbCycle.SelectedValue.ToString();
            if (id.Length != 1)
            {
                id = "0";
            }
            try
            {
                cmbBtlx.DataSource = B_BTLX.GetList(" AND LSSUECYCLE=" + id.ToString()).Tables[0];
                cmbBtlx.DisplayMember = "TYPENAME";
                cmbBtlx.ValueMember = "TYPECODE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            if (cmbCycle.SelectedValue.ToString() == "3" || cmbCycle.SelectedValue.ToString() == "4")
            {
                if (cmbCycle.SelectedValue.ToString() == "3")
                {
                    label3.Text = "月份";
                    cmbbatchmonth.Enabled = true;
                    cmbbatchmonth.DataSource = null;
                    cmbbatchmonth.Items.Clear();
                    cmbbatchmonth.DataSource = Common.BasicData.GetMonths();
                }
                if (cmbCycle.SelectedValue.ToString() == "4")
                {
                    label3.Text = "批次名称";
                    cmbbatchmonth.Enabled = true;
                    cmbbatchmonth.DataSource = b_fsregistration.GetBatch(" and typecode='" + cmbBtlx.SelectedValue.ToString() + "'").Tables[0];
                    cmbbatchmonth.DisplayMember = "description";
                    cmbbatchmonth.ValueMember = "batchcode";
                }
            }
            else
            {
                cmbbatchmonth.Enabled = false;
            }
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("选择值："+cmbWhere.SelectedValue.ToString()+"权限值："+k.Length.ToString());
            DataTable dt = new DataTable();
            string strWhere = "and a.fsyear=" + cmbyear.SelectedItem.ToString() + " and a.typecode='" + cmbBtlx.SelectedValue.ToString() + "' and a.lssuecycle=" + cmbCycle.SelectedValue.ToString();
            //string groupvillage = " group by substr(a.OBJECTCODE,1,12), b.categoryname,c.typename,a.typecode order by substr(a.OBJECTCODE,1,12)";
            if (cmbCycle.SelectedValue.ToString() == "3")
            {
                strWhere += " and a.offset='" + cmbbatchmonth.SelectedValue.ToString() + "'";
            }
            if (cmbCycle.SelectedValue.ToString() == "4")
            {
                strWhere += " and a.batchcode='" + cmbbatchmonth.SelectedValue.ToString() + "'";
            }
            if (checkBox1.Checked)
            {
                strWhere += " and a.hzcustid='SoMe001'";
            }
            if (cmbWhere.SelectedValue.ToString() == "0" && k.Length == 6)
            {
                string group = " group by substr(OBJECTCODE,1,9), b.categoryname,c.typename,a.typecode order by substr(OBJECTCODE,1,9)";
                dt = b_fsregistration.GetTownSum(strWhere + group).Tables[0];
            }
            else if (cmbWhere.SelectedValue.ToString() == "1" && k.Length == 9)
            {
                string group = " group by substr(OBJECTCODE,1,15), b.categoryname,c.typename,a.typecode order by substr(OBJECTCODE,1,15)";
                strWhere += " AND INSTR(a.OBJECTCODE,'" + cmbTown.SelectedValue.ToString() + "')>0";
                dt = b_fsregistration.GetGroupSum(strWhere + group).Tables[0];
            }
            else
            {
                string group = " group by substr(OBJECTCODE,1,12), b.categoryname,c.typename,a.typecode order by substr(OBJECTCODE,1,12)";
                strWhere += " AND INSTR(a.OBJECTCODE,'" + cmbTown.SelectedValue.ToString() + "')>0";
                dt = b_fsregistration.GetVillageSum(strWhere + group).Tables[0];
            }
            double sumbtsl = 0;
            double summoney = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sumbtsl += Convert.ToDouble(dt.Rows[i]["f补贴数量"]);
                summoney += Convert.ToDouble(dt.Rows[i]["e补贴金额"]);
            }
            DataRow dr = dt.NewRow();
            dr["c补贴类型名称"] = "合计";
            dr["f补贴数量"] = sumbtsl;
            dr["e补贴金额"] = summoney;
            dt.Rows.Add(dr);
            dgvShow.DataSource = dt;
        }
        private void btnExp_Click(object sender, EventArgs e)
        {
            string fname = "C:\\补贴数据汇总查询" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string bt = cmbyear.SelectedItem.ToString() + "年" + cmbBtlx.SelectedValue.ToString() + "汇总表";
            string result = Common.DataProces.ExportExcel(fname, bt, this.dgvShow).ToString(); ; //this.dataGridView1:DataGridView控件
            MessageBox.Show(result.ToString(), "提示");
        }
    }
}
