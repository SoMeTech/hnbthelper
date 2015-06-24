using System;
using System.Data;
using System.Windows.Forms;
namespace hnbthelper
{
    public partial class frmRCexport : Common.DockContent
    {
        BLL.BLL_BTLX B_BTLX = new BLL.BLL_BTLX();
        BLL.BLL_BATCH B_BATCH = new BLL.BLL_BATCH();
        BLL.BLL_RCBTDJTEMP b_rcbtdjtemp = new BLL.BLL_RCBTDJTEMP();
        public frmRCexport()
        {
            InitializeComponent();
        }
        ToolTip toolTip1 = new ToolTip();
        private void cmbType_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.cmbType, this.cmbType.Text);
        }
        private void frmRCexport_Load(object sender, EventArgs e)
        {
            cmbCycle.DataSource = Common.BasicData.collection;
            cmbCycle.DisplayMember = "name";
            cmbCycle.ValueMember = "id";
            cmbCycle.SelectedIndex = 0;
            cmbType.DataSource = B_BTLX.GetList("").Tables[0].DefaultView;
            cmbType.DisplayMember = "TYPENAME";
            cmbType.ValueMember = "TYPECODE";
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
                cmbType.DataSource = B_BTLX.GetList(" AND LSSUECYCLE=" + id.ToString()).Tables[0];
                cmbType.DisplayMember = "TYPENAME";
                cmbType.ValueMember = "TYPECODE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbBatch.Text = "";
                lbBatch.DataSource = B_BATCH.GetList("TYPECODE='" + cmbType.SelectedValue.ToString() + "'").Tables[0];
                lbBatch.DisplayMember = "BATCHNAME";
                lbBatch.ValueMember = "BATCHID";
            }
            catch (Exception ex)
            {
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.Move(lbBatch, lbselected);
            lbselected.DisplayMember = "BATCHNAME";
            lbselected.ValueMember = "BATCHID";
        }
        private void btnmoveAll_Click(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.Move(lbBatch, lbselected);
            lbselected.DisplayMember = "BATCHNAME";
            lbselected.ValueMember = "BATCHID";
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.Move(lbselected, lbBatch);
            lbBatch.DisplayMember = "BATCHNAME";
            lbBatch.ValueMember = "BATCHID";
        }
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.MoveAll(lbselected, lbBatch);
            lbBatch.DisplayMember = "BATCHNAME";
            lbBatch.ValueMember = "BATCHID";
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (lbselected.Items.Count > 0)
            {
                string sqlstr = "";
                for (int i = 0; i < this.lbselected.Items.Count; i++)
                {
                    lbselected.SelectedIndex = i;
                    sqlstr = sqlstr + "," + lbselected.SelectedValue.ToString();
                }
                sqlstr = sqlstr.Substring(1);
                DataView dv = b_rcbtdjtemp.Export(" and btlx ='" + cmbType.SelectedValue.ToString() + "' and batchid in (" + sqlstr + ")  group by gh,yhzh,zhm,sfzh order by yhzh,gh").Tables[0].DefaultView;
                label4.Text = "共导出" + dv.Count.ToString() + "条记录！";
                string fn = "cdp0" + lbselected.SelectedValue.ToString();
                Common.DataProces.ExportToTxt(fn, dv);
            }
            else
            {
                MessageBox.Show("请选择批次！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void lbBatch_MouseDoubleClick(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.Move(lbBatch, lbselected);
            lbselected.DisplayMember = "BATCHNAME";
            lbselected.ValueMember = "BATCHID";
        }
        private void lbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //当前行批次补贴数据
            string id = "";
            if (lbBatch.SelectedItem == null)
            {
                return;
            }
            else
            {
                id = " and batchid=" + lbBatch.SelectedValue.ToString();
            }
            double sum = Convert.ToDouble(b_rcbtdjtemp.SUM(id).Tables[0].Rows[0][0].ToString());
            double count = Convert.ToDouble(b_rcbtdjtemp.SUM(id).Tables[0].Rows[0][1].ToString());
            DataRowView drv = lbBatch.SelectedItem as DataRowView;
            DataRow dr = drv.Row;
            label5.Text = dr[lbBatch.DisplayMember].ToString() + "尚有" + sum.ToString("C") + "元、" + count.ToString() + "户未发放。"; 
        }
    }
}
