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
    public partial class formPhieuXuat : Form
    {
        int vitri = 0;
        string loai = "";
        string manv = "";
        string feat = "";
        string MaPX = "";
        string MaVT = "";
        string SoLuong = "";
        string DonGia = "";
        public formPhieuXuat()
        {
            InitializeComponent();
        }

        private void phieuXuatBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPhieuXuat.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void formPhieuXuat_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

            // TODO: This line of code loads data into the 'dS.CTPX' table. You can move, or remove it, as needed.
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS.CTPX);
            // TODO: This line of code loads data into the 'dS.PhieuXuat' table. You can move, or remove it, as needed.
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
                    barbtnReload.Enabled = barbtnAddCTPX.Enabled = barbtnDelCTPX.Enabled = false;
                    groupBox4.Enabled = false;
                    break;
                case "CHINHANH":
                    barbtnThem.Enabled = false;
                    barbtnGhi.Enabled = false;
                    barbtnXoa.Enabled = false;
                    barbtnReload.Enabled = barbtnAddCTPX.Enabled = barbtnDelCTPX.Enabled = false;
                    groupBox4.Enabled = false;
                    break;
                default:
                    barbtnThem.Enabled = true;
                    barbtnGhi.Enabled = true;
                    barbtnXoa.Enabled = true;
                    barbtnReload.Enabled = false;
                    break;
            }

        }

        private void dONGIATextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sOLUONGTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void mAVTTextEdit_EditValueChanged(object sender, EventArgs e)
        {

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
                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);
                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Fill(this.DS.CTPX);
            }
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loai = "PX";
            feat = "add";
            vitri = bdsPhieuXuat.Position;
            groupBox4.Enabled = true;
            bdsPhieuXuat.AddNew();
            manv = Program.userName;
            cmbMaNV.Text = manv.ToString();
            cmbMaNV.Enabled = false;
            barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = false;
            cmbMaNV.Enabled = txtSoLuong.Enabled = txtDonGia.Enabled = txtMaVT.Enabled = false;
            gridCPhieuXuat.Enabled = false;
            gridCCTPX.Enabled = false;
        }

        private void barbtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (loai == "PX")
            {
                if (txtMaPX.Text.Trim() == "")
                {
                    MessageBox.Show("Mã Phiếu nhập không được để trống", "Lỗi");
                    txtMaPX.Focus();
                    return;
                }

                if (DENgay.Text.Trim() == "")
                {
                    MessageBox.Show("Ngày không được để trống", "Lỗi");
                    DENgay.Focus();
                    return;
                }

                if (txtHoTenKH.Text.Trim() == "")
                {
                    MessageBox.Show("Nhà cung cấp không được để trống", "Lỗi");
                    txtHoTenKH.Focus();
                    return;
                }
                if (cmbMaNV.Text.Trim() == "")
                {
                    MessageBox.Show("Mã NV không được để trống", "Lỗi");
                    cmbMaNV.Focus();
                    return;
                }
                string sp = "exec SP_KTMAPX '" + txtMaPX.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(sp);
                Program.myReader.Read();
                if (Program.myReader.HasRows == true)
                {
                    MessageBox.Show("Mã phiếu xuất đã tồn tại");
                    barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTPX.Enabled = false;
                    return;
                }
                Program.myReader.Close();

               
                try
                {
                    bdsPhieuXuat.EndEdit();
                    bdsPhieuXuat.ResetCurrentItem();
                    this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuXuatTableAdapter.Update(this.DS.PhieuXuat);

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
                    = barbtnAddCTPX.Enabled = barbtnDelCTPX.Enabled = true;
                    gridCCTPX.Enabled = gridCPhieuXuat.Enabled = true;
                    txtMaPX.Enabled = DENgay.Enabled = txtHoTenKH.Enabled = txtDonGia.Enabled = txtMaVT.Enabled = 
                    txtSoLuong.Enabled = cmbMaNV.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi đơn đặt hàng", ex.Message);
                }


            }
            else if (loai == "CTPX")
            {
                if (txtMaPX.Text.Trim() == "")
                {
                    MessageBox.Show("Mã số đơn đặt hàng không được để trống", "Lỗi");
                    txtMaPX.Focus();
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

                string sp = "exec SP_KTMAPX '" + txtMaPX.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(sp);
                Program.myReader.Read();                
                if (Program.myReader.HasRows==false)
                {
                    MessageBox.Show("Mã phiếu xuất không tồn tại");
                    barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTPX.Enabled = false;
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
                sp = "exec SP_KIEMTRASOLUONGVT '" + txtMaVT.Text.Trim() + "','" + txtSoLuong.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(sp);
                Program.myReader.Read();
                if (Program.myReader.HasRows == false)
                {
                    MessageBox.Show("SỐ LƯỢNG HÀNG TRONG KHO KHÔNG ĐỦ");
                    barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTPX.Enabled = false;
                    return;
                }
                Program.myReader.Close();
                try
                {
                    MaPX = txtMaPX.Text.Trim();
                    MaVT = txtMaVT.Text.Trim();
                    SoLuong = txtSoLuong.Text.Trim();
                    DonGia = txtDonGia.Text.Trim();
                    string stradd = "exec dbo.sp_AddCTPX '" + MaPX + "','" + MaVT + "','" + SoLuong + "','" + DonGia + "'";
                    Program.myReader = Program.ExecSqlDataReader(stradd);
                    Program.myReader.Read();
                    Program.myReader.Close();
                    stradd = "exec dbo.sp_XUATHANG '" + MaVT + "','" + SoLuong + "'";
                    Program.myReader = Program.ExecSqlDataReader(stradd);
                    Program.myReader.Read();
                    Program.myReader.Close();
                    bdsCTPX.EndEdit();
                    MessageBox.Show("Thêm thành công");
                    barbtnThem.Enabled = true;
                    barbtnGhi.Enabled = true;
                    barbtnXoa.Enabled = true;
                    barbtnReload.Enabled = true;
                    barbtnThoat.Enabled = true;
                    gridCPhieuXuat.Enabled = gridCCTPX.Enabled = true;
                    barbtnThem.Enabled = barbtnXoa.Enabled = barbtnGhi.Enabled = barbtnReload.Enabled = barbtnThoat.Enabled
                    = barbtnAddCTPX.Enabled = barbtnDelCTPX.Enabled = true;
                    txtMaPX.Enabled = DENgay.Enabled = txtHoTenKH.Enabled = txtDonGia.Enabled = txtMaVT.Enabled =
                    txtSoLuong.Enabled = cmbMaNV.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi chi tiết đơn đặt hàng", ex.Message);
                }
            }
            else if (loai == "delCTPX")
            {

                try
                {
                    MaPX = txtMaPX.Text.Trim();
                    MaVT = txtMaVT.Text.Trim();
                    SoLuong = txtSoLuong.Text.Trim();
                    DonGia = txtDonGia.Text.Trim();
                    string stradd = "exec dbo.sp_delCTPX '" + MaPX + "','" + MaVT + "','" + SoLuong + "','" + DonGia + "'";
                    Program.myReader = Program.ExecSqlDataReader(stradd);
                    Program.myReader.Read();
                    Program.myReader.Close();
                    stradd = "exec dbo.SP_NHAPHANG '" + MaVT + "','" + SoLuong + "'";
                    Program.myReader = Program.ExecSqlDataReader(stradd);
                    Program.myReader.Read();
                    Program.myReader.Close();
                    MessageBox.Show("Xóa thành công");
                    bdsCTPX.EndEdit();
                    barbtnThem.Enabled = true;
                    barbtnGhi.Enabled = true;
                    barbtnXoa.Enabled = true;
                    barbtnReload.Enabled = true;
                    barbtnThoat.Enabled = true;
                    gridCPhieuXuat.Enabled = gridCCTPX.Enabled = true;
                    barbtnThem.Enabled = barbtnXoa.Enabled = barbtnGhi.Enabled = barbtnReload.Enabled = barbtnThoat.Enabled
                    = barbtnAddCTPX.Enabled = barbtnDelCTPX.Enabled = true;
                    txtMaPX.Enabled = DENgay.Enabled = txtHoTenKH.Enabled = txtDonGia.Enabled = txtMaVT.Enabled =
                    txtSoLuong.Enabled = cmbMaNV.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi chi tiết đơn đặt hàng", ex.Message);
                }
            }
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsCTPX.Count>0)
            {
                MessageBox.Show("CT phiếu xuất tồn tại trong phiếu xuất nên không thể xóa");
                return;
            }
            barbtnGhi.Enabled = true;
            loai = "PX";
            feat = "del";
            vitri = bdsPhieuXuat.Position;
            bdsPhieuXuat.RemoveAt(vitri);
            barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTPX.Enabled = false;
            groupBox1.Enabled = groupBox2.Enabled = false;
            gridCPhieuXuat.Enabled = false;
            gridCCTPX.Enabled = false;
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void refreshTableAdapter()
        {
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS.CTPX);
            //MessageBox.Show(Program.mGroup);
            if (Program.Group == "CONGTY")
            {
                cmbTenCN.Enabled = true;
                groupBox1.Enabled = false;
                barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTPX.Enabled = barbtnDelCTPX.Enabled = false;
            }
            else
            {
                cmbTenCN.Enabled = false;
                barbtnGhi.Enabled = false;
            }
        }
        private void barbtnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Đưa BindingSource của nhân viên về mặc định

                bdsCTPX.RemoveFilter();
                bdsPhieuXuat.RemoveFilter();
                refreshTableAdapter();
                gridCPhieuXuat.Enabled = true;
                gridCPhieuXuat.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}", "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barbtnAddCTPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loai = "CTPX";
            vitri = bdsCTPX.Position;
            bdsCTPX.AddNew();
            manv = Program.userName;
            cmbMaNV.Text = manv.ToString();
            cmbMaNV.Enabled = false;
            barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTPX.Enabled = false;
            DENgay.Enabled = txtHoTenKH.Enabled = cmbMaNV.Enabled = false;
            barbtnGhi.Enabled = true;
            gridCCTPX.Enabled = false;
            gridCPhieuXuat.Enabled = false;
        }

        private void barbtnDelCTPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loai = "delCTPX";
            vitri = bdsCTPX.Position;
            //bdsCTPX.RemoveAt(vitri);
            manv = Program.userName;
            cmbMaNV.Text = manv.ToString();
            cmbMaNV.Enabled = false;
            barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTPX.Enabled = false;
            DENgay.Enabled = txtHoTenKH.Enabled = cmbMaNV.Enabled = false;
            gridCCTPX.Enabled = false;
            gridCPhieuXuat.Enabled = false;
        }
    }
}
