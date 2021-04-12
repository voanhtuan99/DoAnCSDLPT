using DevExpress.XtraReports.UI;
using DoAnQLVT.Rpform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnQLVT.Rp
{
    public partial class rpDSNV : Form
    {
        public rpDSNV()
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

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {


        }

        private void rpDSNV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.NhanVien' table. You can move, or remove it, as needed.
            cmbTenCN.DataSource = Program.bds_dspm;
            cmbTenCN.DisplayMember = "TENCN";
            cmbTenCN.ValueMember = "TENSERVER";
            cmbTenCN.SelectedIndex = Program.mChinhanh;
            if (Program.Group == "CHINHANH")
            {
                cmbTenCN.Enabled = false;
            }
            else cmbTenCN.Enabled = true;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            ReportDSNV rpt = new ReportDSNV();
            rpt.labeNhanVien.Text = "DANH SÁCH NHÂN VIÊN " + cmbTenCN.Text.ToUpper();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}
