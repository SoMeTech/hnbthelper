using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
namespace hnbthelper
{
    public partial class frmExport : Common.DockContent
    {
        BLL.BLL_BTLX B_BTLX = new BLL.BLL_BTLX();
        BLL.BLL_FSREGISTRATION B_sjdc = new BLL.BLL_FSREGISTRATION();
        BLL.BLL_BASEOBJECTCOMPANY B_town = new BLL.BLL_BASEOBJECTCOMPANY();
        BLL.BLL_BTDJTEMP B_bank = new BLL.BLL_BTDJTEMP();
        public frmExport()
        {
            InitializeComponent();
        }
        private void frmExport_Load(object sender, EventArgs e)
        {
            if (Common.BasicData.UserPower.Length > 6)
            {
                MessageBox.Show("你无权导出银行发放数据！");
                btnExpHz.Visible = false;
                btnToEx.Visible = false;
            }

            if (Common.BasicData.UserPower == "431106")
            {
            }
            else
            {
                btnExport.Visible = false;
            }
            B_sjdc.DeleteCurr("");
            cmbCycle.DataSource = Common.BasicData.collection;
            cmbCycle.DisplayMember = "name";
            cmbCycle.ValueMember = "id";
            cmbCycle.SelectedIndex = 0;
            cmbBank.DataSource = B_bank.GetBank("").Tables[0];
            cmbBank.DisplayMember = "bankname";
            cmbBank.ValueMember = "bankcode";
            cmbBank.SelectedIndex = 0;
            label6.Text = "";
            cmbbatch.Enabled = false;
            if (cmbCycle.SelectedValue.ToString() == "3" || cmbCycle.SelectedValue.ToString() == "4")
            {
                if (cmbCycle.SelectedValue.ToString() == "3")
                {
                    label10.Text = "月份";
                    cmbbatch.Enabled = true;
                    cmbbatch.DataSource = Common.BasicData.GetMonths();
                }
                if (cmbCycle.SelectedValue.ToString() == "4")
                {
                    label10.Text = "批次名称";
                    cmbbatch.Enabled = true;
                }
            }
            else
            {
                cmbbatch.Enabled = false;
            }
            
        }
        private void cmbCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cmbCycle.SelectedValue.ToString();
            //解决“设置datasource属性后无法修改项集合”问题
            if (lbselect.Items.Count > 0)
            {
                lbselect.DataSource = null;
                lbselect.Items.Clear();
            }
            if (id.Length != 1)
            {
                id = "0";
            }
            try
            {
                LBType.DataSource = B_BTLX.GetList(" AND LSSUECYCLE=" + id.ToString()).Tables[0];
                LBType.DisplayMember = "TYPENAME";
                LBType.ValueMember = "TYPECODE";
                LBType.SelectedIndex = 0;
                for (int i = lbselect.Items.Count - 1; i >= 0; i--)
                {
                    lbselect.Items.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(LBType.SelectedValue!=null)
            {label6.Text = "你当前选中的是：" + LBType.SelectedValue.ToString(); }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.Move(LBType, lbselect);
            lbselect.DisplayMember = "TYPENAME";
            lbselect.ValueMember = "TYPECODE";
            if (lbselect.Items.Count > 0)
            {
                lbselect.SelectedIndex = 0;
                lbselect_SelectedIndexChanged(this,e);
            }
        }
        private void LBType_MouseDoubleClick(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.Move(LBType, lbselect);
            lbselect.DisplayMember = "TYPENAME";
            lbselect.ValueMember = "TYPECODE";
            if (lbselect.Items.Count > 0)
            {
                lbselect.SelectedIndex = 0;
                lbselect_SelectedIndexChanged(this, e);
            }
        }
        private void lbselect_MouseDoubleClick(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.Move(lbselect, LBType);
            LBType.DisplayMember = "TYPENAME";
            LBType.ValueMember = "TYPECODE";
        }
        private void btnmoveAll_Click(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.MoveAll(LBType, lbselect);
            lbselect.DisplayMember = "TYPENAME";
            lbselect.ValueMember = "TYPECODE";
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.Move(lbselect, LBType);
            LBType.DisplayMember = "TYPENAME";
            LBType.ValueMember = "TYPECODE";
        }
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            Common.LstCtrlMove_Mgr<DataRow>.MoveAll(lbselect, LBType);
            LBType.DisplayMember = "TYPENAME";
            LBType.ValueMember = "TYPECODE";
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            B_sjdc.DeleteCurr("");
            string Cycle = "";
            string town = "";
            string townn = "";
            string group = " group by A.OBJECTCODE,A.ACCOUNTNUM,a.SSSSOBJECTNAME,d.GH,a.SSSSIDCARDNUM order by A.ACCOUNTNUM DESC,d.GH";
            string batch = "null";
            string bank = cmbBank.SelectedValue.ToString();
            if (cmbbatch.Text != null && cmbbatch.Text != "")
            {
                batch = cmbbatch.SelectedValue.ToString();
            }
            if (checkBox1.Checked)
            {
                town = "  and  instr(c.OBJECTCODE,'" + cmbTown.SelectedValue.ToString() + "')>0 ";
                townn = "乡镇：" + cmbTown.Text.ToString();
            }
            if (cmbCycle.SelectedValue.ToString() == "3")
            {
                Cycle = " and c.OFFSET='" + cmbbatch.SelectedValue.ToString() + "'";
            }
            if (cmbCycle.SelectedValue.ToString() == "4")
            {
                Cycle = " and c.batchcode='" + cmbbatch.SelectedValue.ToString() + "'";
            }
            if (lbselect.Items.Count > 0)
            {
                string sqlstr = string.Empty;
                string strwhere = string.Empty;
                for (int i = 0; i < this.lbselect.Items.Count; i++)
                {
                    lbselect.SelectedIndex = i;
                    sqlstr = sqlstr + "," + lbselect.SelectedValue.ToString();
                }
                sqlstr = sqlstr.Substring(1);
                DataTable dt = B_sjdc.Currentpay(" AND C.TYPECODE IN (" + sqlstr + ")" + Cycle.ToString() + " AND C.FSYEAR=" + DateTime.Now.Year + town.ToString() + " AND C.BANKCODE='" + bank.ToString() + "'" + group.ToString()).Tables[0];
                ArrayList SQLStringList = new ArrayList();
                string str = "INSERT INTO COUNTYDATA.CURRENTPAY(OBJECTCODE,ACCOUNTNUM,SSSSOBJECTNAME,GH,SSSSIDCARDNUM,REGMONEY)  VALUES(";
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {                                                                   
                        strwhere = "'" + dt.Rows[i][0].ToString() + "','" + dt.Rows[i][1].ToString() + "','" + dt.Rows[i][2].ToString() + "'," + dt.Rows[i][3].ToString() + ",'" + dt.Rows[i][4].ToString() + "'," + dt.Rows[i][5].ToString()+")";
                        SQLStringList.Add(str+strwhere); 
                    }
                    DBUtility.DbHelperOra.ExecuteSqlTran(SQLStringList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                DataView dv = B_sjdc.Export(" order by accountnum").Tables[0].DefaultView;
                if (MessageBox.Show(this, "批次/月份：" + batch + "，补贴类型:" + sqlstr + "," + townn + "", "确认以下条件吗？", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string fn = "cdp0" + lbselect.SelectedValue.ToString();
                    Common.DataProces.ExportToTxt(fn, dv);
                    label4.Text = "共导出" + dv.Count.ToString() + "条记录！";
                }
             }
            else
            {
                MessageBox.Show("请选择补贴类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                cmbTown.Enabled = true;
                cmbTown.DataSource = B_town.GetList(" instr(CATEGORYCODE,'"+Common.BasicData.UserPower+"')>0 and length(categorycode)=9 order by CATEGORYCODE").Tables[0];
                cmbTown.DisplayMember = "CATEGORYNAME";
                cmbTown.ValueMember = "CATEGORYCODE";
            }
            else
            {
                cmbTown.Enabled = false;
            }
        }
        private void btnCacle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExpHz_Click(object sender, EventArgs e)
        {
            B_sjdc.DeleteCurr("");
            string Cycle = "";
            string town = "";
            string townn = "";
            string group = " group by A.OBJECTCODE,A.ACCOUNTNUM,a.SSSSOBJECTNAME,d.GH,a.SSSSIDCARDNUM order by A.ACCOUNTNUM DESC,d.GH";
            string batch = "null";
            string bank = cmbBank.SelectedValue.ToString();
            if (cmbbatch.Text != null && cmbbatch.Text != "")
            {
                batch = cmbbatch.SelectedValue.ToString();
            }
            if (checkBox1.Checked)
            {
                town = "  and  instr(c.OBJECTCODE,'" + cmbTown.SelectedValue.ToString() + "')>0 ";
                townn = "乡镇：" + cmbTown.Text.ToString();
            }
            if (cmbCycle.SelectedValue.ToString() == "3")
            {
                Cycle = " and c.OFFSET='" + cmbbatch.SelectedValue.ToString() + "'";
            }
            if (cmbCycle.SelectedValue.ToString() == "4")
            {
                Cycle = " and c.batchcode='" + cmbbatch.SelectedValue.ToString() + "'";
            }
            if (lbselect.Items.Count > 0)
            {
                string sqlstr = string.Empty;
                string strwhere = string.Empty;
                for (int i = 0; i < this.lbselect.Items.Count; i++)
                {
                    lbselect.SelectedIndex = i;
                    sqlstr = sqlstr + "," + lbselect.SelectedValue.ToString();
                }
                sqlstr = sqlstr.Substring(1);
                DataTable dt = B_sjdc.Currentpay(" and c.TYPECODE in (" + sqlstr + ")" + Cycle.ToString() + " and c.FSYEAR=" + DateTime.Now.Year + town.ToString() + " and c.bankcode='" + bank.ToString() + "'" + group.ToString()).Tables[0];
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strwhere = "'" + dt.Rows[i][0].ToString() + "','" + dt.Rows[i][1].ToString() + "','" + dt.Rows[i][2].ToString() + "'," + dt.Rows[i][3].ToString() + ",'" + dt.Rows[i][4].ToString() + "'," + dt.Rows[i][5].ToString();
                        B_sjdc.imptcurr(strwhere);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                DataView dv = B_sjdc.GetHz("").Tables[0].DefaultView;
                if (MessageBox.Show(this, "批次/月份：" + batch + "，补贴类型:" + sqlstr + "," + townn + "", "确认以下条件吗？", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string fn = "cdp0" + lbselect.SelectedValue.ToString();
                    Common.DataProces.ExportToTxt(fn, dv);
                    label4.Text = "共导出" + dv.Count.ToString() + "条记录！";
                }
            }
            else
            {
                MessageBox.Show("请选择补贴类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void lbselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCycle.SelectedValue.ToString() == "3" || cmbCycle.SelectedValue.ToString() == "4")
            {
                if (cmbCycle.SelectedValue.ToString() == "3")
                {
                    label10.Text = "月份";
                    cmbbatch.Enabled = true;
                    cmbbatch.DataSource = Common.BasicData.GetMonths();
                }
                if (cmbCycle.SelectedValue.ToString() == "4")
                {
                    label10.Text = "批次名称";
                    cmbbatch.Enabled = true;
                    cmbbatch.DataSource = B_sjdc.GetBatch(" and year=" + DateTime.Now.ToString("yyyy") + " and typecode='" + lbselect.SelectedValue.ToString() + "'").Tables[0];
                    cmbbatch.DisplayMember = "description";
                    cmbbatch.ValueMember = "batchcode";
                }
            }
            else
            {
                cmbbatch.Enabled = false;
            }
        }
        private void btnToEx_Click(object sender, EventArgs e)
        {
            string Cycle = string.Empty;
            string town = string.Empty;
            string townn = string.Empty;
            string group = " group by a.ACCOUNTNUM,a.SSSSOBJECTNAME,d.GH,a.SSSSIDCARDNUM order by a.ACCOUNTNUM DESC,d.GH";
            string batch = "null";
            string bank = cmbBank.SelectedValue.ToString();
            if (cmbbatch.Text != null && cmbbatch.Text != "")
            {
                batch = cmbbatch.SelectedValue.ToString();
            }
            if (checkBox1.Checked)
            {
                town = "  AND INSTR(c.OBJECTCODE,'" + cmbTown.SelectedValue.ToString() + "')>0";
                townn = "乡镇：" + cmbTown.Text.ToString();
            }
            if (cmbCycle.SelectedValue.ToString() == "3")
            {
                Cycle = " and c.OFFSET='" + cmbbatch.SelectedValue.ToString() + "'";
            }
            if (cmbCycle.SelectedValue.ToString() == "4")
            {
                Cycle = " and c.batchcode='" + cmbbatch.SelectedValue.ToString() + "'";
            }
            if (lbselect.Items.Count > 0)
            {
                string sqlstr = string.Empty;
                for (int i = 0; i < this.lbselect.Items.Count; i++)
                {
                    lbselect.SelectedIndex = i;
                    sqlstr = sqlstr + "," + lbselect.SelectedValue.ToString();
                }
                sqlstr = sqlstr.Substring(1);
                DataTable dv = Common.DataProces.OutPutTable(B_sjdc.ExpToEx(" and c.TYPECODE in (" + sqlstr + ")" + Cycle.ToString() + " and c.FSYEAR=" + DateTime.Now.Year + town.ToString() + " and bankcode='" + bank.ToString() + "'" + group.ToString()).Tables[0]);
                Common.DataProces toexcel = new Common.DataProces();
                    toexcel.DataTableToExcel(dv, true);
                    label4.Text = "共导出" + dv.Rows.Count.ToString() + "条记录！";
            }
            else
            {
                MessageBox.Show("请选择补贴类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
