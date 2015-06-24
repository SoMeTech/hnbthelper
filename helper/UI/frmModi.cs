using System;
using System.Data;
using System.Windows.Forms;
namespace hnbthelper
{
    public partial class frmModi : Common.DockContent
    {
        BLL.BLL_BTLX B_BTLX = new BLL.BLL_BTLX();
        BLL.BLL_BASEOBJECT b_base = new BLL.BLL_BASEOBJECT();
        BLL.BLL_FSREGISTRATION B_btdj = new BLL.BLL_FSREGISTRATION();
        public frmModi()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Model.BASEOBJECT sfz = new Model.BASEOBJECT();
            bool flag = b_base.Updatesfz(sfz);
            if (flag)
            {
                MessageBox.Show("信息修改成功", "提交提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //MessageBox.Show("此功能暂不提供","提示");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Model.BASEOBJECT xm = new Model.BASEOBJECT();
            bool flag = b_base.Updatexm(xm);
            if (flag)
            {
                MessageBox.Show("信息修改成功", "提交提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //MessageBox.Show("此功能暂不提供", "提示");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool flag = B_btdj.DeleteNull();
            if (flag)
            {
                MessageBox.Show("清除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            frmExport fm = new frmExport();
            fm.ShowDialog();
        }
        private void frmmodi_Load(object sender, EventArgs e)
        {
            cmbCycle.DisplayMember = "name";
            cmbCycle.ValueMember = "id";
            cmbCycle.Items.Clear();
            cmbCycle.DataSource = Common.BasicData.collection;
            cmbbatch.Enabled = false;
        }
        private void cmbCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cmbCycle.SelectedValue.ToString();
            try
            {
                LBType.DataSource = B_BTLX.GetList(" AND LSSUECYCLE=" + id.ToString()).Tables[0];
                LBType.DisplayMember = "TYPENAME";
                LBType.ValueMember = "TYPECODE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            string sqlstr = "";
            if (lbselect.Items.Count > 0)
            {
                for (int i = 0; i < this.lbselect.Items.Count; i++)
                {
                    lbselect.SelectedIndex = i;
                    sqlstr = sqlstr + "," + lbselect.SelectedValue.ToString();
                }
                sqlstr = " AND  TYPECODE IN  (" + sqlstr.Substring(1)+")";
            }
            if (cmbCycle.SelectedValue.ToString() == "3" || cmbCycle.SelectedValue.ToString() == "4")
            {
                if (cmbCycle.SelectedValue.ToString() == "3")
                {
                    label10.Text = "月份";
                    cmbbatch.Enabled = true;
                    cmbbatch.DataSource = null;
                    cmbbatch.Items.Clear();
                    cmbbatch.DataSource = Common.BasicData.GetMonths();
                }
                if (cmbCycle.SelectedValue.ToString() == "4")
                {
                    label10.Text = "批次";
                    cmbbatch.Enabled = true;
                    cmbbatch.DataSource = null;
                    cmbbatch.Items.Clear();
                    cmbbatch.DataSource = B_btdj.GetBatch(sqlstr).Tables[0];
                    cmbbatch.DisplayMember = "description";
                    cmbbatch.ValueMember = "batchcode";
                }
            }
            else
            {
                cmbbatch.Enabled = false;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.Move(LBType, lbselect);
            lbselect.DisplayMember = "TYPENAME";
            lbselect.ValueMember = "TYPECODE";
        }
        private void LBType_MouseDoubleClick(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.Move(LBType, lbselect);
            lbselect.DisplayMember = "TYPENAME";
            lbselect.ValueMember = "TYPECODE";
        }
        private void btnMoveAll_Click(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.MoveAll(LBType, lbselect);
            lbselect.DisplayMember = "TYPENAME";
            lbselect.ValueMember = "TYPECODE";
        }
        private void btnMove_Click(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.Move(lbselect, LBType);
            LBType.DisplayMember = "TYPENAME";
            LBType.ValueMember = "TYPECODE";
        }
        private void lbselect_MouseDoubleClick(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.Move(lbselect, LBType);
            LBType.DisplayMember = "TYPENAME";
            LBType.ValueMember = "TYPECODE";
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.MoveAll(lbselect, LBType);
            LBType.DisplayMember = "TYPENAME";
            LBType.ValueMember = "TYPECODE";
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            string tj = " SET PAYDATE='" + dtp.Value.ToString("yyyy-MM-dd") + "' WHERE FSYEAR=" + DateTime.Now.Year.ToString();
            string sqlstr = "";
            string batch = "null";
            if (cmbbatch.Text != null && cmbbatch.Text != "")
            {
                batch = cmbbatch.SelectedValue.ToString();
            }
            if (cmbCycle.SelectedValue.ToString() == "3")
            {
                tj += " AND OFFSET='" + cmbbatch.SelectedValue.ToString() + "'";
            }
            if (cmbCycle.SelectedValue.ToString() == "4")
            {
                tj += " AND BATCHCODE='" + cmbbatch.SelectedValue.ToString() + "'";
            }
            if (lbselect.Items.Count > 0)
            {
                for (int i = 0; i < this.lbselect.Items.Count; i++)
                {
                    lbselect.SelectedIndex = i;
                    sqlstr = sqlstr + "," + lbselect.SelectedValue.ToString();
                }
                sqlstr = sqlstr.Substring(1);
                tj += " AND  TYPECODE IN (" + sqlstr + ")";
            }
            if (MessageBox.Show(this, "发放日期：" + dtp.Value.ToString("yyyy-MM-dd") + ", 批次/月份：" + batch + "，补贴类型:" + sqlstr + ",", "确认以下更新条件吗？", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                bool flag = B_btdj.Upff(tj);
                if (flag)
                {
                    MessageBox.Show("更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnDz_Click(object sender, EventArgs e)
        {
            Model.BASEOBJECT dz = new Model.BASEOBJECT();
            bool flag = b_base.UpdateHOMEADDRESS(dz);
            if (flag)
            {
                MessageBox.Show("信息修改成功", "提交提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            bool flag = b_base.UP15to18("");
            if (flag)
            {
                {
                    MessageBox.Show("升级18位成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}