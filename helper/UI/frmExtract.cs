using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hnbthelper
{
    public partial class frmExtract : Common.DockContent
    {
        BLL.BLL_BTLX B_BTLX = new BLL.BLL_BTLX();
        BLL.BLL_BASEOBJECTCOMPANY B_town = new BLL.BLL_BASEOBJECTCOMPANY();
        BLL.BLL_FSREGISTRATION b_fsregistration = new BLL.BLL_FSREGISTRATION();
        string from = " FROM COUNTYDATA.FSREGISTRATION WHERE FSYEAR="+DateTime.Now.Year.ToString();
        public frmExtract()
        {
            InitializeComponent();
        }
        List<Common.BasicData.Cycle> coll = Common.BasicData.collection;

        private void frmExtract_Load(object sender, EventArgs e)
        {

            cmbCycle.DataSource = coll;
            cmbCycle.DisplayMember = "name";
            cmbCycle.ValueMember = "id";
            cmbCycle.SelectedIndex = 0;
            cmbCy.DataSource = coll.ToArray();
            cmbCy.DisplayMember = "name";
            cmbCy.ValueMember = "id";
            cmbCy.SelectedIndex = 0;
            cmbBtlx.DataSource = B_BTLX.GetList("").Tables[0];
            cmbBtlx.DisplayMember = "TYPENAME";
            cmbBtlx.ValueMember = "TYPECODE";
            cmbBtlx.SelectedIndex = 0;
            cmbLx.DataSource = B_BTLX.GetList("").Tables[0].Copy();
            cmbLx.DisplayMember = "TYPENAME";
            cmbLx.ValueMember = "TYPECODE";
            cmbLx.SelectedIndex = 0;
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
                    label4.Text = "月份";
                    cmbbatchmonth.Enabled = true;
                    cmbbatchmonth.DataSource = null;
                    cmbbatchmonth.Items.Clear();
                    cmbbatchmonth.DataSource = Common.BasicData.GetMonths();
                    from += " AND OFFSET='" + cmbbatchmonth.SelectedValue.ToString()+"'";
                }
                if (cmbCycle.SelectedValue.ToString() == "4")
                {
                    label4.Text = "批次名称";
                    cmbbatchmonth.Enabled = true;
                    cmbbatchmonth.DataSource = b_fsregistration.GetBatch(" and typecode='" + cmbBtlx.SelectedValue.ToString() + "'").Tables[0];
                    cmbbatchmonth.DisplayMember = "description";
                    cmbbatchmonth.ValueMember = "batchcode";
                    from += " AND BATCHCODE='" + cmbbatchmonth.SelectedValue.ToString() + "' AND TYPECODE='" + cmbBtlx.SelectedValue.ToString() + "'";
                }
            }
            else
            {
                cmbbatchmonth.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                cmbTown.Enabled = true;
                cmbTown.DataSource = B_town.GetList(" length(categorycode)=9 and instr(CATEGORYCODE,'" + Common.BasicData.UserPower.ToString() + "')>0 order by CATEGORYCODE").Tables[0];
                cmbTown.DisplayMember = "CATEGORYNAME";
                cmbTown.ValueMember = "CATEGORYCODE";
                
            }
            else
            {
                cmbTown.Enabled = false;
            }
        }

        private void cmbCy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cmbCy.SelectedValue.ToString();
            if (id.Length != 1)
            {
                id = "0";
            }
            try
            {
                cmbLx.DataSource = B_BTLX.GetList(" AND LSSUECYCLE=" + id.ToString()).Tables[0];
                cmbLx.DisplayMember = "TYPENAME";
                cmbLx.ValueMember = "TYPECODE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            if (cmbCy.SelectedValue.ToString() == "3" || cmbCy.SelectedValue.ToString() == "4")
            {
                if (cmbCy.SelectedValue.ToString() == "3")
                {
                    label6.Text = "月份";
                    cmbBat.Enabled = true;
                    cmbBat.DataSource = null;
                    cmbBat.Items.Clear();
                    cmbBat.DataSource = Common.BasicData.GetMonths();
                }
                if (cmbCy.SelectedValue.ToString() == "4")
                {
                    label6.Text = "批次名称";
                    cmbBat.Enabled = true;
                    cmbBat.DataSource = b_fsregistration.GetBatch(" and typecode='" + cmbLx.SelectedValue.ToString() + "'").Tables[0];
                    cmbBat.DisplayMember = "description";
                    cmbBat.ValueMember = "batchcode";
                    cmbBat.Tag = "batchid";
                }
            }
            else
            {
                cmbBat.Enabled = false;
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            string strWhere = " AND A.FSYEAR=" + DateTime.Now.Year.ToString() + " AND A.TYPECODE='" + cmbBtlx.SelectedValue.ToString() + "' AND A.LSSUECYCLE=" + cmbCycle.SelectedValue.ToString();
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
                strWhere += " AND INSTR(A.OBJECTCODE,'" + cmbTown.SelectedValue.ToString() + "')>0";
            }
            DataTable dt = b_fsregistration.GetExtQuery(strWhere + group).Tables[0];
            dgvPre.DataSource = dt;
        }

        private void btnExt_Click(object sender, EventArgs e)
        {
            string lssuecycle = cmbCy.SelectedValue.ToString();
            string batchid = string.Empty;
            string offset = string.Empty;
            string batchcode = string.Empty;
            string paydate = string.Empty;
            string flowid =string.Empty;
            DataTable dt = (DataTable)dgvPre.DataSource;
            DataTable strdt = new DataTable();
            string town = " AND FSYEAR=" + DateTime.Now.Year.ToString();
            if (cmbCy.SelectedValue.ToString() == "3" || cmbCy.SelectedValue.ToString() == "4")
            {
                if (cmbCy.SelectedValue.ToString() == "3")
                {
                    offset = cmbBat.SelectedValue.ToString();
                    
                }
                if (cmbCy.SelectedValue.ToString() == "4")
                {
                    batchcode = cmbBat.SelectedValue.ToString();
                    batchid = cmbBat.Tag.ToString();
                }
            }
            else
            {

            }
            
            if(checkBox2.Checked)
            {
                flowid = cmbFlow.SelectedValue.ToString();
            }
            if (checkBox1.Checked)
            {
                from += " AND INSTR(OBJECTCODE,'" + cmbTown.SelectedValue.ToString() + "')>0 AND TYPECODE='" + cmbBtlx.SelectedValue.ToString() + "'";
                town += " AND INSTR(OBJECTCODE,'" + cmbTown.SelectedValue.ToString() + "')>0 AND TYPECODE='" + cmbLx.SelectedValue.ToString() +"'";
            }
            else
            {
                from += " AND TYPECODE='" + cmbBtlx.SelectedValue.ToString() + "'";
                town += " AND TYPECODE='" + cmbLx.SelectedValue.ToString() + "'";
            }
            string NULLSTR = "'','','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("yyyyMMddhhmmssfff")+"',1";
            string imstr = string.Empty;
            string strwhere = string.Empty;
            int to = int.Parse(b_fsregistration.GetExsCount(town).ToString());
            ArrayList SQLStringList = new ArrayList();
            string str = "INSERT INTO COUNTYDATA.FSREGISTRATION(REGID,OBJECTID,CATEGORYCODE,SSSSOBJECTNAME,SSSSIDCARDNUM,OBJECTCODE,BANKCODE,ACCOUNTNUM,COUNTYCODE,FSYEAR,PAYCOMPANY,LOGICCODE,IMPORTDATE,PAYADDRESS,REMARK,LSSUETYPE,PAYTYPE,RECEIVEDATE,IMPORTTME,NOTICEDATE,NOTICENO,EDIUSRCODE,EXPORTDATE,ISEFFECT,EXPORTTME,GENRECORDID,GENERATEID,AMOUNT,STANDARD,REGMONEY,TYPEID,TYPECODE,PAYDATE,BATCHID,BATCHCODE,EDIDATE,EDITIME,REGDATE,LOGICTIME,STATE,OFFSET,LSSUECYCLE,FLOWID) SELECT SYS_GUID(),OBJECTID,CATEGORYCODE,SSSSOBJECTNAME,SSSSIDCARDNUM,OBJECTCODE,BANKCODE,ACCOUNTNUM,COUNTYCODE,FSYEAR,PAYCOMPANY,LOGICCODE,IMPORTDATE,PAYADDRESS,REMARK,LSSUETYPE,PAYTYPE,RECEIVEDATE,IMPORTTME,NOTICEDATE,NOTICENO,EDIUSRCODE,EXPORTDATE,ISEFFECT,EXPORTTME,GENRECORDID,GENERATEID,AMOUNT,STANDARD,REGMONEY,'";
            if (dt.Rows.Count > 0 && to <= 0)
            {
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        from += " AND REGID='" + dt.Rows[i]["REGID"].ToString() + "'";
                        strdt = B_BTLX.GetTownLxID("AND TYPECODE='" + cmbLx.SelectedValue.ToString() + "' AND CATEGORYCODE='" + dt.Rows[i]["OBJECTCODE"].ToString().Substring(0, 9) + "'").Tables[0];
                        imstr = strdt.Rows[0]["TYPEID"].ToString() + "','" + strdt.Rows[0]["TYPECODE"].ToString() + "','" + paydate + "','" + batchid + "','" + batchcode + "'," + NULLSTR + ",'" + offset + "','" + lssuecycle + "','" + flowid + "'";
                        SQLStringList.Add(str + imstr + from);
                    }
                    DBUtility.DbHelperOra.ExecuteSqlTran(SQLStringList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("请先预览数据或该条件下没有源数据或已存在目标数据", "提示");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                cmbFlow.Enabled = true;
                cmbFlow.DataSource = B_BTLX.GetFlow(" AND FSYEAR=" + DateTime.Now.Year.ToString() + " AND STATE<3 AND SUBSTR(FLOWNAME,1,4)='" + cmbLx.SelectedValue.ToString() + "'").Tables[0];
                cmbFlow.DisplayMember = "FLOWNAME";
                cmbFlow.ValueMember = "FLOWID";
            }
            else
            {
                cmbFlow.Enabled = false;
            }
        }




    }
}
