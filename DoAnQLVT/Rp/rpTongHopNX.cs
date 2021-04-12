using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnQLVT.Rpform;
using DevExpress.XtraReports.UI;

namespace DoAnQLVT.Rp
{
    public partial class rpTongHopNX : Form
    {
        public rpTongHopNX()
        {
            InitializeComponent();
        }

        private void cmbTenCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenCN.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            try
            {
                Program.servername = cmbTenCN.SelectedValue.ToString();
            }
            catch (Exception)
            {
            };

            if (cmbTenCN.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0) MessageBox.Show("Lỗi kết nối về chi nhánh mới!", "", MessageBoxButtons.OK);
        }

        private void BTNTHOAT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rpTongHopNX_Load(object sender, EventArgs e)
        {
            cmbTenCN.DataSource = Program.bds_dspm;
            cmbTenCN.DisplayMember = "TENCN";
            cmbTenCN.ValueMember = "TENSERVER";
            cmbTenCN.SelectedIndex = Program.mChinhanh;
            if (Program.Group == "CHINHANH")
            {
                cmbTenCN.Enabled = false;
            }
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            string begin, end;
            begin = DEBegin.Text;
            end = DEEnd.Text;
            rpFormTONGHOPNX rpt = new rpFormTONGHOPNX(begin,end);
            rpt.label1.Text = "TỔNG HỢP NHẬP XUẤT";
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}
