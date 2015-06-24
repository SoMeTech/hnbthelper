using System;
using System.Data;
using System.Windows.Forms;
namespace hnbthelper
{
    public partial class frmQuery : Common.DockContent
    {
        BLL.BLL_BTLX B_BTLX = new BLL.BLL_BTLX();
        BLL.BLL_BASEOBJECTCOMPANY B_town = new BLL.BLL_BASEOBJECTCOMPANY();
        BLL.BLL_FSREGISTRATION b_fsregistration = new BLL.BLL_FSREGISTRATION();
        public frmQuery()
        {
            InitializeComponent();
        }
        private void frmQuery_Load(object sender, EventArgs e)
        {
            int year = DateTime.Now.AddYears(-5).Year;
            for (int i = 0; i <= 10; i++)
            {
                cmbyear.Items.Add(year + i);
            }
            cmbyear.SelectedItem = int.Parse(DateTime.Now.ToString("yyyy"));
            cmbTown.Enabled = false;
            cmbCycle.DataSource = Common.BasicData.collection;
            cmbCycle.DisplayMember = "name";
            cmbCycle.ValueMember = "id";
            cmbCycle.SelectedIndex = 0;
            cmbBtlx.DataSource = B_BTLX.GetList("").Tables[0];
            cmbBtlx.DisplayMember = "TYPENAME";
            cmbBtlx.ValueMember = "TYPECODE";
            cmbBtlx.SelectedIndex = 0;
            cmbTown.Enabled = false;
            checkBox2.Checked = true;
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
                    cmbbatchmonth.DataSource =Common.BasicData.GetMonths();
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
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                cmbTown.Enabled = true;
                cmbTown.DataSource = B_town.GetList(" length(categorycode)=9 and instr(CATEGORYCODE,'"+Common.BasicData.UserPower.ToString()+"')>0 order by CATEGORYCODE").Tables[0];
                cmbTown.DisplayMember = "CATEGORYNAME";
                cmbTown.ValueMember = "CATEGORYCODE";
            }
            else
            {
                cmbTown.Enabled = false;
            }
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string strWhere = " AND A.FSYEAR=" + cmbyear.SelectedItem.ToString() + " AND A.TYPECODE='" + cmbBtlx.SelectedValue.ToString() + "' AND A.LSSUECYCLE=" + cmbCycle.SelectedValue.ToString();
            string group = " ORDER BY B.OBJECTCODE";
            if (cmbCycle.SelectedValue.ToString() == "3")
            {
                strWhere += " AND A.OFFSET='" + cmbbatchmonth.SelectedValue.ToString() + "'";
            }
            if (cmbCycle.SelectedValue.ToString() == "4")
            {
                strWhere += " AND A.BATCHCODE='" + cmbbatchmonth.SelectedValue.ToString() + "'";
            }
            if (checkBox1.Checked)
            {
                strWhere += " AND A.HZCUSTID='SoMe001'";
            }
            if (checkBox2.Checked)
            {
                strWhere += " AND INSTR(A.OBJECTCODE,'" + cmbTown.SelectedValue.ToString() + "')>0";
            }
            DataTable dt = b_fsregistration.GetQuery(strWhere + group).Tables[0];
            double sumbtsl = 0;
            double summoney = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sumbtsl += Convert.ToDouble(dt.Rows[i]["AMOUNT"]);
                summoney += Convert.ToDouble(dt.Rows[i]["REGMONEY"]);
            }
            DataRow dr = dt.NewRow();
            dr["OBJECTCODE"] = "合计";
            dr["AMOUNT"] = sumbtsl;
            dr["REGMONEY"] = summoney;
            dt.Rows.Add(dr);
            dgvShow.DataSource = dt;
        }
        private void btnExp_Click(object sender, EventArgs e)
        {
            string fname = "C:\\补贴数据明细查询" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string bt = cmbyear.SelectedItem.ToString() + "年" + cmbBtlx.SelectedValue.ToString() + "明细情况表";//标题名称
            string result = Common.DataProces.ExportExcel(fname, bt, this.dgvShow); //this.dataGridView1:DataGridView控件
            MessageBox.Show(result.ToString(), "提示");
        }


    }
}
