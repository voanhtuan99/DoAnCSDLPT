using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DoAnQLVT.Rp;
using DoAnQLVT.Rpform;
using DevExpress.XtraReports.UI;

namespace DoAnQLVT
{
    public partial class formMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public formMain()
        {
            InitializeComponent();
            if(Program.Group == "USER"){
                btnTaoTK.Enabled = btnXoaTK.Enabled = btnChuyenCN.Enabled = false;
            }

        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void btnDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(formDangNhap));
            if (frm != null) frm.Activate();
            else
            {
                 formDangNhap f = new formDangNhap();
                 f.MdiParent = this;
                 f.Show();
            }
            
        }

        private void btnNV_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Program.formNV.groupBox1.Enabled = true;
            //Program.formNV.gridCNhanVien.Enabled = true;
            //Program.formNV.barbtnGhi.Enabled = true;
            //Program.formNV.barbtnReload.Enabled = true;
            //Program.formNV.barbtnThem.Enabled = true;
            //Program.formNV.barbtnThoat.Enabled = true;
            //Program.formNV.barbtnUndo.Enabled = true;
            //Program.formNV.barbtnXoa.Enabled = true;
            Form frm = this.CheckExists(typeof(formNhanVien));
            if (frm != null) frm.Activate();
            else
            {
                formNhanVien f = new formNhanVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            Form frm = this.CheckExists(typeof(formDangNhap));
            if (frm != null) frm.Activate();
            else
            {
                formDangNhap f = new formDangNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.formChinh.MaMV.Text = "Mã NV   ";
            Program.formChinh.HOTEN.Text = "Họ Tên   ";
            Program.formChinh.NHOM.Text = "Nhóm   ";
            int a = 0;
            a=Program.KetNoi();
            Form frm = this.CheckExists(typeof(formDangNhap));
            if (frm != null)
            {
                frm.Activate();
                frm.Show();
            }
            else
            {
                formDangNhap f = new formDangNhap();
                f.MdiParent = this;
                f.Show();
            }
            Program.formChinh.btnRPDSNV.Enabled = Program.formChinh.BTNRPDSVT.Enabled = Program.formChinh.btnRPCTP.Enabled = 
                Program.formChinh.btnRPDDHCPN.Enabled = Program.formChinh.btnChuyenCN.Enabled = Program.formChinh.btnTaoTK.Enabled = 
                Program.formChinh.btnXoaTK.Enabled = Program.formChinh.btnHDNV.Enabled = Program.formChinh.btnTHNX.Enabled =false;
            Program.formChinh.btnNV.Enabled = Program.formChinh.btnVattu.Enabled = Program.formChinh.btnKho.Enabled
                        = Program.formChinh.btnDangXuat.Enabled = Program.formChinh.btnDatHang.Enabled = Program.formChinh.btnPhieuNhap.Enabled
                        = Program.formChinh.btnPhieuXuat.Enabled = false;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(formVattu));
            if (frm != null) frm.Activate();
            else
            {
                formVattu f = new formVattu();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(formKhoHang));
            if (frm != null) frm.Activate();
            else
            {
                formKhoHang f = new formKhoHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(formDDH));
            if (frm != null) frm.Activate();
            else
            {
                formDDH f = new formDDH();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(formPhieuNhap));
            if (frm != null) frm.Activate();
            else
            {
                formPhieuNhap f = new formPhieuNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(formPhieuXuat));
            if (frm != null) frm.Activate();
            else
            {
                formPhieuXuat f = new formPhieuXuat();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.maForm = 1;
            Form frm = this.CheckExists(typeof(formAddAccount));
            if (frm != null) frm.Activate();
            else
            {
                Program.formAddAccount = new formAddAccount();
                Program.formAddAccount.MdiParent = this;
                Program.formAddAccount.Show();
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(rpDSNV));
            if (frm != null) frm.Activate();
            else
            {
                rpDSNV f = new rpDSNV();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem8_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            ReportDSVT rpt = new ReportDSVT();
            rpt.labelDSVT.Text = "DANH SÁCH VẬT TƯ ";
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.maForm = 2;
            Form frm = this.CheckExists(typeof(formXoaTaiKhoan));
            if (frm != null) frm.Activate();
            else
            {
                Program.formXoaTaiKhoan = new formXoaTaiKhoan();
                Program.formXoaTaiKhoan.MdiParent = this;
                Program.formXoaTaiKhoan.Show();
            }

        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(rpCTNhap));
            if (frm != null) frm.Activate();
            else
            {
                rpCTNhap f = new rpCTNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            rpformDSDDHChuaCoPN rpt = new rpformDSDDHChuaCoPN();
            rpt.labelNotPN.Text = "DANH SÁCH ĐƠN ĐẶT HÀNG CHƯA CÓ PHIẾU NHẬP ";
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.maForm = 3;
            Form frm = this.CheckExists(typeof(formChuyenCN));
            if (frm != null) frm.Activate();
            else
            {
                Program.formChuyenCN = new formChuyenCN();
                Program.formChuyenCN.MdiParent = this;
                Program.formChuyenCN.Show();
            }
        }

        private void barButtonItem7_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Program.maForm = 4;
            Form frm = this.CheckExists(typeof(rpHDNV));
            if (frm != null) frm.Activate();
            else
            {
                Program.rpHDNV = new rpHDNV();
                Program.rpHDNV.MdiParent = this;
                Program.rpHDNV.Show();
            }
        }

        private void barButtonItem8_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(rpTongHopNX));
            if (frm != null) frm.Activate();
            else
            {
                rpTongHopNX f = new rpTongHopNX();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}