using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace hnbthelper
{
    public partial class frmRCBatchmanager : Common.DockContent
    {
        BLL.BLL_BTLX B_BTLX = new BLL.BLL_BTLX();
        BLL.BLL_BATCH b_batch = new BLL.BLL_BATCH();
        BLL.BLL_RCBTDJTEMP B_btdjtemp = new BLL.BLL_RCBTDJTEMP();
        public frmRCBatchmanager()
        {
            InitializeComponent();
        }
        private void frmRCBatchmanager_Load(object sender, EventArgs e)
        {
            SetEnable();
            GetCmbDataSource();
            groupBox1.Visible = false;
        }
        protected void SetEnable()
        {
            dgvTypeManager.DataSource = b_batch.GetList("").Tables[0];
        }
        private void GetCmbDataSource()
        {
            cmbCycle.DataSource = Common.BasicData.collection;
            cmbCycle.DisplayMember = "name";
            cmbCycle.ValueMember = "id";
            cmbCycle.SelectedIndex = 0;
            cmbBtlx.DataSource = B_BTLX.GetList("").Tables[0];
            cmbBtlx.DisplayMember = "TYPENAME";
            cmbBtlx.ValueMember = "TYPECODE";
            cmbBtlx.SelectedIndex = 0;
        }
        private void cmbBtlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = cmbBtlx.SelectedValue.ToString();
            dgvTypeManager.DataSource = b_batch.GetList(" typecode='"+str+"'").Tables[0];
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
        }
        private void 增加补贴批次ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Common.BasicData.Cycle> collection = new List<Common.BasicData.Cycle>();
            collection = Common.BasicData.collection;
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("id");
            foreach (var info in collection)
            {
                DataRow dr = dt.NewRow();
                dr["name"] = info.name;
                dr["id"] = info.id;
                dt.Rows.Add(dr);
            }
            groupBox1.Visible = true;
            cmbColl.DataSource = dt;
            cmbColl.DisplayMember = "name";
            cmbColl.ValueMember = "id";
        }
        private void cmbColl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cmbColl.SelectedValue.ToString();
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
        private void btnOK_Click(object sender, EventArgs e)
        {
            Model.BATCH model = new Model.BATCH();
            model.TYPECODE = cmbType.SelectedValue.ToString();
            model.BATCHNAME = textBox1.Text.Trim();
            bool flag=b_batch.Add(model);
            if (flag)
            {
                MessageBox.Show("增加补贴批次成功");
                return;
            }
            btnOK.Enabled = false;
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvTypeManager.CurrentRow.Cells["BATCHID"].Value.ToString());
            if (id == 0)
            {
                MessageBox.Show("没有可删除的信息！请点击表内任意行！", "提交提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("确认要删除您选中的信息吗？", "消息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    DataTable dt = B_btdjtemp.GetList(" batchid='" + id + "'").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("不能删除已使用的批次", "提示");
                    }
                    else
                    {
                        bool flag =b_batch.Delete(id);
                        if (flag)
                        {
                            //刷新用户信息列表
                            SetEnable();
                            MessageBox.Show("信息删除成功！点击确定继续操作！", "提交提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string copyCode = this.dgvTypeManager.CurrentCell.Value.ToString();
                if (!string.IsNullOrEmpty(copyCode))
                {
                    //复制到剪切板
                    Clipboard.SetDataObject(copyCode);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(this, exp.Message);
            }
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }
    }
}
