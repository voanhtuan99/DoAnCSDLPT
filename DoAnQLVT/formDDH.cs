using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DoAnQLVT
{
    public partial class formDDH : Form
    {
        string loai;
        string MaDDH = "";
        string MaVT = "";
        string SoLuong = "";
        string DonGia = "";
        string manv = "";
        int vitri = 0;
        public formDDH()
        {
            InitializeComponent();
            loai = "";
        }
        
        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDatHang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void formDDH_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;


            // TODO: This line of code loads data into the 'dS.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS.DatHang);
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);
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
                    barbtnReload.Enabled = false;
                    break;
                case "CHINHANH":
                    barbtnThem.Enabled = false;
                    barbtnGhi.Enabled = false;
                    barbtnXoa.Enabled = false;
                    barbtnReload.Enabled = false;
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

        private void barbtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (loai == "DDH")
            {
                if(txtMSDDH.Text.Trim() == "")
                {
                    MessageBox.Show("Mã số đơn đặt hàng không được để trống", "Lỗi");
                    txtMSDDH.Focus();
                    return;
                }

                if (DENgay.Text.Trim() == "")
                {
                    MessageBox.Show("Ngày không được để trống", "Lỗi");
                    DENgay.Focus();
                    return;
                }

                if (txtNhaCC.Text.Trim() == "")
                {
                    MessageBox.Show("Nhà cung cấp không được để trống", "Lỗi");
                    txtNhaCC.Focus();
                    return;
                }
                if (cmbMaNV.Text.Trim() == "")
                {
                    MessageBox.Show("Mã NV không được để trống", "Lỗi");
                    cmbMaNV.Focus();
                    return;
                }
                
                string sp = "exec SP_KTMADDH '" + txtMSDDH.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(sp);
                Program.myReader.Read();
                if(Program.myReader.HasRows == true)
                {
                    MessageBox.Show("Mã đơn đặt hàng đã tồn tại");
                    return;
                }
                
                Program.myReader.Close();
                
                try
                {
                    bdsDatHang.EndEdit();
                    bdsDatHang.ResetCurrentItem();
                    this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.datHangTableAdapter.Update(this.DS.DatHang);
                    barbtnThem.Enabled = barbtnXoa.Enabled = barbtnGhi.Enabled = barbtnReload.Enabled = barbtnThoat.Enabled
                    = barbtnAddCTDDH.Enabled = barbtnDelCTDDH.Enabled = true;
                    gridCCTDDH.Enabled = gridCDatHang.Enabled = true;                    
                    txtMSDDH.Enabled = DENgay.Enabled = txtNhaCC.Enabled = txtDonGia.Enabled = txtMaVT.Enabled =
                    txtSoLuong.Enabled = cmbMaNV.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi đơn đặt hàng", ex.Message);
                }

            }
            else if(loai == "CTDDH")
            {
                if (txtMSDDH.Text.Trim() == "")
                {
                    MessageBox.Show("Mã số đơn đặt hàng không được để trống", "Lỗi");
                    txtMSDDH.Focus();
                    return;
                }

                if (txtMaVT.Text.Trim() == "")
                {
                    MessageBox.Show("Mã VT không được để trống", "Lỗi");
                    txtMaVT.Focus();
                    return;
                }

                if (txtSoLuong.Text.Trim() == "" || int.Parse(txtSoLuong.Text.Trim()) <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ", "Lỗi");
                    txtSoLuong.Focus();
                    return;
                }
                if (txtDonGia.Text.Trim() == "" || int.Parse(txtDonGia.Text.Trim()) <= 0)
                {
                    MessageBox.Show("Đơn giá không hợp lệ", "Lỗi");
                    txtDonGia.Focus();
                    return;
                }
                string sp = "exec SP_KTMADDH '" + txtMSDDH.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(sp);
                Program.myReader.Read();
                if (Program.myReader.HasRows == false)
                {
                    MessageBox.Show("Mã đơn đặt hàng không tồn tại");
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
                    MaDDH = txtMSDDH.Text.Trim();
                    MaVT = txtMaVT.Text.Trim();
                    SoLuong = txtSoLuong.Text.Trim();
                    DonGia = txtDonGia.Text.Trim();
                    MessageBox.Show(MaDDH + "=" + MaVT + "=" + SoLuong + "=" + DonGia);
                    string stradd = "exec dbo.sp_addctddh '" + MaDDH + "','" + MaVT + "','" + SoLuong + "','" + DonGia + "'";
                    Program.myReader = Program.ExecSqlDataReader(stradd);
                    Program.myReader.Read();
                    Program.myReader.Close();
                    bdsCTDDH.EndEdit();
                    barbtnThem.Enabled = barbtnXoa.Enabled = barbtnGhi.Enabled = barbtnReload.Enabled = barbtnThoat.Enabled
                    = barbtnAddCTDDH.Enabled = barbtnDelCTDDH.Enabled = true;
                    gridCCTDDH.Enabled = gridCDatHang.Enabled = true;
                    txtMSDDH.Enabled = DENgay.Enabled = txtNhaCC.Enabled = txtDonGia.Enabled = txtMaVT.Enabled =
                    txtSoLuong.Enabled = cmbMaNV.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi chi tiết đơn đặt hàng", ex.Message);
                }
            }
            else if (loai == "delCTDDH")
            {


                try
                {
                    bdsCTDDH.EndEdit();
                    bdsCTDDH.ResetCurrentItem();
                    this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTDDHTableAdapter.Update(this.DS.CTDDH);
                    barbtnThem.Enabled = barbtnXoa.Enabled = barbtnGhi.Enabled = barbtnReload.Enabled = barbtnThoat.Enabled
                    = barbtnAddCTDDH.Enabled = barbtnDelCTDDH.Enabled = true;
                    gridCCTDDH.Enabled = gridCDatHang.Enabled = true;
                    txtMSDDH.Enabled = DENgay.Enabled = txtNhaCC.Enabled = txtDonGia.Enabled = txtMaVT.Enabled =
                    txtSoLuong.Enabled = cmbMaNV.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi chi tiết đơn đặt hàng", ex.Message);
                }
            }
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loai = "DDH";              
            vitri = bdsDatHang.Position;
            groupBox3.Enabled = true;
            bdsDatHang.AddNew();
            manv = Program.userName;
            cmbMaNV.Text = manv.ToString();
            cmbMaNV.Enabled = false;
            barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = false;
            cmbMaNV.Enabled = txtSoLuong.Enabled = txtDonGia.Enabled= txtMaVT.Enabled = false;
            gridCDatHang.Enabled = false;
            gridCCTDDH.Enabled = false;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loai = "CTDDH";
            vitri = bdsCTDDH.Position;
            bdsCTDDH.AddNew();
            manv = Program.userName;
            cmbMaNV.Text = manv.ToString();
            cmbMaNV.Enabled = false;
            barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTDDH.Enabled = false;
            DENgay.Enabled = txtNhaCC.Enabled = cmbMaNV.Enabled = false;
            gridCDatHang.Enabled = false;
            gridCCTDDH.Enabled = false;
            
            
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
                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.DS.DatHang);
                this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTDDHTableAdapter.Fill(this.DS.CTDDH);

            }
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsCTDDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa phiếu này vì có CTPN ở trong");
                return;
            }
            barbtnGhi.Enabled = true;
            loai = "DDH";
            vitri = bdsDatHang.Position;
            bdsDatHang.RemoveAt(vitri);
            barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTDDH.Enabled = false;
            groupBox1.Enabled = groupBox2.Enabled = false;
            gridCDatHang.Enabled = false;
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loai = "delCTDDH";
            vitri = bdsCTDDH.Position;
            bdsCTDDH.RemoveAt(vitri);
            manv = Program.userName;
            cmbMaNV.Text = manv.ToString();
            cmbMaNV.Enabled = false;
            barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTDDH.Enabled = false;
            DENgay.Enabled = txtNhaCC.Enabled = cmbMaNV.Enabled = false;
            gridCDatHang.Enabled = false;
            gridCCTDDH.Enabled = false;
        }
        private void refreshTableAdapter()
        {
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS.DatHang);
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);
            //MessageBox.Show(Program.mGroup);
            if (Program.Group == "CONGTY")
            {
                cmbTenCN.Enabled = true;
                groupBox1.Enabled = false;
                barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnAddCTDDH.Enabled = barbtnDelCTDDH.Enabled = false;
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

                bdsDatHang.RemoveFilter();
                bdsCTDDH.RemoveFilter();
                refreshTableAdapter();
                gridCDatHang.Enabled = true;
                gridCCTDDH.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}", "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
