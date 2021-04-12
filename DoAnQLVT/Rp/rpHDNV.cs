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
    public partial class rpHDNV : Form
    {
        public rpHDNV()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string LoaiPhieu = rad1.Checked ? "PN" : (rad2.Checked ? "PX" : "DH");
            string begin, end, MaNV;
            begin = DEBegin.Text;
            end = DEEnd.Text;
            MaNV = txtMaNV.Text.Trim();
            rpFormHDNV rpt = new rpFormHDNV(MaNV, DEBegin.Text, DEEnd.Text, LoaiPhieu);
            rpt.label1.Text = "HOẠT ĐỘNG " + LoaiPhieu;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
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

        private void rpHDNV_Load(object sender, EventArgs e)
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
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        private void btnGoiY_Click(object sender, EventArgs e)
        {
            Form frm = this.CheckExists(typeof(formDSNV));
            if (frm != null) frm.Activate();
            else
            {
                formDSNV f = new formDSNV();
                //f.MdiParent = this;
                f.Show();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
