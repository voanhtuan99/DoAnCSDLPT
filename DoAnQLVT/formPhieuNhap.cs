using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnQLVT
{
    public partial class formPhieuNhap : Form
    {
        int vitri = 0;
        string loai = "";
        string manv = "";
        string feat = "";
        string MaPN = "";
        string MaVT = "";
        string SoLuong = "";
        string DonGia = "";
        public formPhieuNhap()
        {
            InitializeComponent();
        }

        private void phieuNhapBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPhieuNhap.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void formPhieuNhap_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.CTPN' table. You can move, or remove it, as needed.
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

            // TODO: This line of code loads data into the 'dS.PhieuNhap' table. You can move, or remove it, as needed.
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS.CTPN);
            cmbTenCN.DataSource = Program.bds_dspm;
            cmbTenCN.DisplayMember = "TENCN";
            cmbTenCN.ValueMember = "TENSERVER";
            cmbTenCN.SelectedIndex = Program.mChinhanh;
            if (Program.Group == "CONGTY")
            {
                cmbTenCN.Enabled = true;

            }
            else cmbTenCN.Enabled = false;
            switch (Program.Group)
            {
                case "CONGTY":
                    barbtnThem.Enabled = false;
                    barbtnGhi.Enabled = false;
                    barbtnXoa.Enabled = false;
                    barbtnReload.Enabled = barbtnAddCTPN.Enabled = barbtnDelCTPN.Enabled = false;
                    groupBox4.Enabled = false;
                    break;
                case "CHINHANH":
                    barbtnThem.Enabled = false;
                    barbtnGhi.Enabled = false;
                    barbtnXoa.Enabled = false;
                    barbtnReload.Enabled = barbtnAddCTPN.Enabled = barbtnDelCTPN.Enabled = false;
                    groupBox4.Enabled = false;
                    break;
                default:
                    barbtnThem.Enabled = true;
                    barbtnGhi.Enabled = true;
                    barbtnXoa.Enabled = true;
                    barbtnReload.Enabled = true;
                    break;
            }
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
            else
            {
                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Fill(this.DS.CTPN);
            }
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loai = "PN";
            feat = "add";
            vitri = bdsPhieuNhap.Position;
            groupBox4.Enabled = true;
            bdsPhieuNhap.AddNew();
            manv = Program.userName;
            cmbMaNV.Text = manv.ToString();
            cmbMaNV.Enabled = false;
            barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = false;
            cmbMaNV.Enabled = txtSoLuong.Enabled = txtDonGia.Enabled = false;
            gridCPhieuNhap.Enabled = false;
            gridCCTPN.Enabled = false;
        }

        private void barbtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (loai == "PN")
            {
                if (txtMaPN.Text.Trim() == "")
                {
                    MessageBox.Show("Mã Phiếu nhập không được để trống", "Lỗi");
                    txtMaPN.Focus();
                    return;
                }

                if (DENgay.Text.Trim() == "")
                {
                    MessageBox.Show("Ngày không được để trống", "Lỗi");
                    DENgay.Focus();
                    return;
                }

                if (txtMaSoDDH.Text.Trim() == "")
                {
                    MessageBox.Show("Nhà cung cấp không được để trống", "Lỗi");
                    txtMaSoDDH.Focus();
                    return;
                }
                if (cmbMaNV.Text.Trim() == "")
                {
                    MessageBox.Show("Mã NV không được để trống", "Lỗi");
                    cmbMaNV.Focus();
                    return;
                }

                string sp = "exec SP_KTMAPN '" + txtMaPN.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(sp);
                Program.myReader.Read();
                if (Program.myReader.HasRows == true)
                {
                    MessageBox.Show("Mã phiếu nhập đã tồn tại");
                    barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTPN.Enabled = false;
                    return;
                }
                Program.myReader.Close();
                
                try
                {
                    bdsPhieuNhap.EndEdit();
                    bdsPhieuNhap.ResetCurrentItem();
                    this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuNhapTableAdapter.Update(this.DS.PhieuNhap);

                    if (feat == "del")
                    {
                        MessageBox.Show("Xóa thành công");
                    }
                    else if (feat == "add")
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                    barbtnThem.Enabled = true;
                    barbtnGhi.Enabled = true;
                    barbtnXoa.Enabled = true;
                    barbtnReload.Enabled = true;
                    barbtnThoat.Enabled = true;
                    barbtnThem.Enabled = barbtnXoa.Enabled = barbtnGhi.Enabled = barbtnReload.Enabled = barbtnThoat.Enabled
                    = barbtnAddCTPN.Enabled = barbtnDelCTPN.Enabled = true;
                    gridCCTPN.Enabled = gridCPhieuNhap.Enabled = true;
                    txtMaPN.Enabled = DENgay.Enabled = txtMaSoDDH.Enabled = txtDonGia.Enabled = txtMaVT.Enabled =
                    txtSoLuong.Enabled = cmbMaNV.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi chi tiết phiếu nhập", ex.Message);
                }


            }
            else if (loai == "CTPN")
            {
                if (txtMaPN.Text.Trim() == "")
                {
                    MessageBox.Show("Mã số đơn đặt hàng không được để trống", "Lỗi");
                    txtMaPN.Focus();
                    return;
                }

                if (txtMaVT.Text.Trim() == "")
                {
                    MessageBox.Show("Mã VT không được để trống", "Lỗi");
                    txtMaVT.Focus();
                    return;
                }

                if (txtSoLuong.Text.Trim() == "")
                {
                    MessageBox.Show("Số lượng không được để trống", "Lỗi");
                    txtSoLuong.Focus();
                    return;
                }
                if (txtDonGia.Text.Trim() == "")
                {
                    MessageBox.Show("Đơn giá không được để trống", "Lỗi");
                    txtDonGia.Focus();
                    return;
                }

                string sp = "exec SP_KTMAPN '" + txtMaPN.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(sp);
                Program.myReader.Read();
                if (Program.myReader.HasRows == false)
                {
                    MessageBox.Show("Mã phiếu nhập không tồn tại");
                    barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTPN.Enabled = false;
                    return;
                }
                Program.myReader.Close();
                sp = "exec SP_KTMAVATTU '" + txtMaVT.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(sp);
                Program.myReader.Read();
                if (Program.myReader.HasRows == false)
                {
                    MessageBox.Show("Mã vật tư không tồn tại");
                    return;
                }
                Program.myReader.Close();
                try
                {
                    MaPN = txtMaPN.Text.Trim();
                    MaVT = txtMaVT.Text.Trim();
                    SoLuong = txtSoLuong.Text.Trim();
                    DonGia = txtDonGia.Text.Trim();
                    string stradd = "exec dbo.sp_AddPN '" + MaPN + "','" + MaVT + "','" + SoLuong + "','" + DonGia + "'";
                    Program.myReader = Program.ExecSqlDataReader(stradd);
                    Program.myReader.Read();
                    Program.myReader.Close();
                    string stradd1 = "exec dbo.SP_NHAPHANG '" + MaVT + "','" + SoLuong + "'";
                    Program.myReader = Program.ExecSqlDataReader(stradd1);
                    Program.myReader.Read();
                    Program.myReader.Close();
                    bdsCTPN.EndEdit();
                    MessageBox.Show("Thêm thành công");
                    barbtnThem.Enabled = true;
                    barbtnGhi.Enabled = true;
                    barbtnXoa.Enabled = true;
                    barbtnReload.Enabled = true;
                    barbtnThoat.Enabled = true;
                    gridCPhieuNhap.Enabled = gridCCTPN.Enabled = true;
                    barbtnThem.Enabled = barbtnXoa.Enabled = barbtnGhi.Enabled = barbtnReload.Enabled = barbtnThoat.Enabled
                    = barbtnAddCTPN.Enabled = barbtnDelCTPN.Enabled = true;
                    gridCCTPN.Enabled = gridCPhieuNhap.Enabled = true;
                    txtMaPN.Enabled = DENgay.Enabled = txtMaSoDDH.Enabled = txtDonGia.Enabled = txtMaVT.Enabled =
                    txtSoLuong.Enabled = cmbMaNV.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi chi tiết phiếu nhập", ex.Message);
                }
            }
            else if (loai == "delCTPN")
            {

                try
                {
                    MaPN = txtMaPN.Text.Trim();
                    MaVT = txtMaVT.Text.Trim();
                    SoLuong = txtSoLuong.Text.Trim();
                    DonGia = txtDonGia.Text.Trim();
                    MessageBox.Show(MaPN + "+++" + MaVT + "+++" + SoLuong + "+++" + DonGia);
                    string stradd = "exec dbo.sp_delCTPN '" + MaPN + "','" + MaVT + "','" + SoLuong + "','" + DonGia + "'";
                    Program.myReader = Program.ExecSqlDataReader(stradd);
                    Program.myReader.Read();
                    Program.myReader.Close();
                    
                    string stradd1 = "exec dbo.sp_XUATHANG '" + MaVT + "','" + SoLuong + "'";
                    Program.myReader = Program.ExecSqlDataReader(stradd1);
                    Program.myReader.Read();
                    Program.myReader.Close();
                    bdsCTPN.EndEdit();
                    MessageBox.Show("Xóa thành công");
                    
                    barbtnThem.Enabled = true;
                    barbtnGhi.Enabled = true;
                    barbtnXoa.Enabled = true;
                    barbtnReload.Enabled = true;
                    barbtnThoat.Enabled = true;
                    gridCPhieuNhap.Enabled = gridCCTPN.Enabled = true;
                    barbtnThem.Enabled = barbtnXoa.Enabled = barbtnGhi.Enabled = barbtnReload.Enabled = barbtnThoat.Enabled
                    = barbtnAddCTPN.Enabled = barbtnDelCTPN.Enabled = true;
                    gridCCTPN.Enabled = gridCPhieuNhap.Enabled = true;
                    txtMaPN.Enabled = DENgay.Enabled = txtMaSoDDH.Enabled = txtDonGia.Enabled = txtMaVT.Enabled =
                    txtSoLuong.Enabled = cmbMaNV.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi chi tiết phiếu nhập", ex.Message);
                }
            }

        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsCTPN.Count>0)
            {
                MessageBox.Show("Không thể xóa phiếu này vì có CTPN ở trong");
                return;
            }
            barbtnGhi.Enabled = true;
            loai = "PN";
            feat = "del";
            vitri = bdsPhieuNhap.Position;
            bdsPhieuNhap.RemoveAt(vitri);
            barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTPN.Enabled = false;
            groupBox1.Enabled = groupBox2.Enabled = false;
            gridCPhieuNhap.Enabled = false;
            gridCCTPN.Enabled = false;
        }

        private void barbtnAddCTPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loai = "CTPN";
            vitri = bdsCTPN.Position;
            bdsCTPN.AddNew();
            manv = Program.userName;
            cmbMaNV.Text = manv.ToString();
            cmbMaNV.Enabled = false;
            barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTPN.Enabled = false;
            DENgay.Enabled = txtMaSoDDH.Enabled = cmbMaNV.Enabled = false;
            gridCCTPN.Enabled = false;
            gridCPhieuNhap.Enabled = false;
        }

        private void barbtnDelCTPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loai = "delCTPN";
            vitri = bdsCTPN.Position;
//            bdsCTPN.RemoveAt(vitri);
            manv = Program.userName;
            cmbMaNV.Text = manv.ToString();
            cmbMaNV.Enabled = false;
            barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTPN.Enabled = false;
            DENgay.Enabled = txtMaSoDDH.Enabled = cmbMaNV.Enabled = false;
            gridCCTPN.Enabled = false;
            gridCPhieuNhap.Enabled = false;
        }
        private void refreshTableAdapter()
        {
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS.CTPN);
            //MessageBox.Show(Program.mGroup);
            if (Program.Group == "CONGTY")
            {
                cmbTenCN.Enabled = true;
                groupBox1.Enabled = false;
                barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTPN.Enabled = barbtnDelCTPN.Enabled = false;
            }
            else
            {
                cmbTenCN.Enabled = false;
                barbtnGhi.Enabled  = false;
            }
        }
        private void barbtnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Đưa BindingSource của nhân viên về mặc định

                bdsCTPN.RemoveFilter();
                bdsPhieuNhap.RemoveFilter();
                refreshTableAdapter();
                gridCPhieuNhap.Enabled = true;
                gridCCTPN.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}", "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
