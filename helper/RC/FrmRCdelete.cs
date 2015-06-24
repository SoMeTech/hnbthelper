using System;
using System.Data;
using System.Windows.Forms;
namespace hnbthelper
{
    public partial class FrmRCdelete : Common.DockContent
    {
        BLL.BLL_BTLX B_BTLX = new BLL.BLL_BTLX();
        BLL.BLL_BATCH B_BATCH = new BLL.BLL_BATCH();
        BLL.BLL_RCBTDJTEMP B_btdj = new BLL.BLL_RCBTDJTEMP();
        DataTable dtInfo = new DataTable();
        public FrmRCdelete()
        {
            InitializeComponent();
        }
        private void FrmRCdelete_Load(object sender, EventArgs e)
        {
            cmbCycle.DataSource = Common.BasicData.collection;
            cmbCycle.DisplayMember = "name";
            cmbCycle.ValueMember = "id";
            cmbCycle.SelectedIndex = 0;
            cmbType.DataSource = B_BTLX.GetList("").Tables[0];
            cmbType.DisplayMember = "TYPENAME";
            cmbType.ValueMember = "TYPECODE";
            cmbBatch.DataSource = B_BATCH.GetList("").Tables[0];
            cmbBatch.DisplayMember = "BATCHNAME";
            cmbBatch.ValueMember = "BATCHID"; 
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
            string id = cmbType.SelectedValue.ToString();
            try
            {
                cmbBatch.DataSource = B_BATCH.GetList(" TYPECODE='" + id.ToString() + "' ORDER BY BATCHID").Tables[0];
                cmbBatch.DisplayMember = "BATCHNAME";
                cmbBatch.ValueMember = "BATCHID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string id = "";
            if (cmbType.SelectedValue.ToString() != null)
            {
                id += " and c.typecode='" + cmbType.SelectedValue.ToString() + "'";
            }
            if (cmbBatch.Items.Count > 0)
            {
                if (cmbBatch.SelectedValue.ToString() != null)
                {
                    id += " and b.batchid='" + cmbBatch.SelectedValue.ToString() + "'";
                }
            }
            else
            {
                MessageBox.Show("请选择批次！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dtInfo = B_btdj.Find(id).Tables[0];
            if (dtInfo.Rows.Count == 0)
            {
                MessageBox.Show("未找到数据");
                return;
            }
            else
            {
                label11.Text = dtInfo.Rows.Count.ToString();
                label13.Text = Convert.ToDouble(dtInfo.Compute("Sum(btje)", null)).ToString();
                dgvbtdj.DataSource = dtInfo;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbBatch.SelectedValue == null)
            {
                MessageBox.Show("请选择补贴批次");
            }
            else
            {
                DialogResult result = MessageBox.Show("确认要删除吗？", "消息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    string lxdm = cmbType.SelectedValue.ToString();
                    int batchid = int.Parse(cmbBatch.SelectedValue.ToString());
                    bool flag = B_btdj.DeleteBybatchid(batchid);
                    if (flag)
                    {
                        MessageBox.Show("信息删除成功！点击确定继续操作！", "提交提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
