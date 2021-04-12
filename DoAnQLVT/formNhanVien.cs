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
    public partial class formNhanVien : Form
    {
        string macn = "";
        int vitri = 0;
        string ttx = "0";
        public formNhanVien()
        {
            InitializeComponent();
        }

        private void formNhanVien_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);

            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS.DatHang);

            // TODO: This line of code loads data into the 'dS.PhieuNhap' table. You can move, or remove it, as needed.
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

            // TODO: This line of code loads data into the 'dS.PhieuXuat' table. You can move, or remove it, as needed.
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);
            // TODO: This line of code loads data into the 'dS.PhieuXuat' table. You can move, or remove it, as needed.


            macn = ((DataRowView)bdsNhanVien[0])["MACN"].ToString();
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
                    barbtnUndo.Enabled = false;
                    barbtnReload.Enabled = false;
                    
                    break;
                case "CHINHANH":
                    barbtnThem.Enabled = true;
                    barbtnGhi.Enabled = true;
                    barbtnXoa.Enabled = true;
                    barbtnUndo.Enabled = true;
                    barbtnReload.Enabled = true;
                    break;
                default:
                    barbtnThem.Enabled = true;
                    barbtnGhi.Enabled = true;
                    barbtnXoa.Enabled = true;
                    barbtnUndo.Enabled = true;
                    barbtnReload.Enabled = true;
                    break;
            }
        }


        private void mACNLabel_Click(object sender, EventArgs e)
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
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.DS.NhanVien);

                macn = cmbTenCN.SelectedText.ToString();
            }
            macn = Program.servername;
        }

        private void nhanVienBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnGhi.Enabled = true;
            vitri = bdsNhanVien.Position;
            groupBox3.Enabled = true;
            bdsNhanVien.RemoveAt(vitri);
            barbtnThem.Enabled = barbtnUndo.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = false;
            gridCNhanVien.Enabled = false;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTTXoa.Text = ttx;
            barbtnGhi.Enabled = true;
            vitri = bdsNhanVien.Position;
            groupBox3.Enabled = true;
            bdsNhanVien.AddNew();
            txtMaCN.Text = macn;
            barbtnThem.Enabled = barbtnUndo.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = false;
            gridCNhanVien.Enabled = false;
            
        }
        private void refreshTableAdapter()
        {
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
            //MessageBox.Show(Program.mGroup);
            if (Program.Group == "CONGTY")
            {
                cmbTenCN.Enabled = true;
                groupBox1.Enabled = false;
                barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnUndo.Enabled = barbtnGhi.Enabled  = false;
            }
            else
            {
                cmbTenCN.Enabled = false;
                barbtnGhi.Enabled = barbtnUndo.Enabled = false;
            }
        }
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                bdsNhanVien.RemoveFilter();
                refreshTableAdapter();
                gridCNhanVien.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}", "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sp = "exec SP_KIEMTRAMANV '" + txtMaNV.Text.Trim() + "'";
            Program.myReader = Program.ExecSqlDataReader(sp);
            Program.myReader.Read();
            if (Program.myReader.HasRows == true)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại");
                barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = false;
                return;
            }
            Program.myReader.Close();
            if (txtMaNV.Text.Trim()== "")
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Lỗi");
                txtMaNV.Focus();
                return;
            }

            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ không được để trống", "Lỗi");
                txtHo.Focus();
                return;
            }

            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên không được để trống", "Lỗi");
                txtTen.Focus();
                return;
            }

            if (txtMaCN.Text.Trim() == "")
            {
                MessageBox.Show("Mã chi nhánh không được để trống", "Lỗi");
                txtMaCN.Focus();
                return;
            }
            if (DENgaySinh.Text.Trim() == "")
            {
                MessageBox.Show("Ngày sinh không được để trống", "Lỗi");
                DENgaySinh.Focus();
                return;
            }

            if (txtLuong.Text.Trim() == "" || int.Parse(txtLuong.Text.Trim()) <1000000)
            {
                MessageBox.Show("Lương không hợp lệ", "Lỗi");
                txtLuong.Focus();
                return;
            }
            if(txtTTXoa.Text.Trim() == "" || int.Parse(txtTTXoa.Text)!=0 || int.Parse(txtTTXoa.Text) != 1)
            {
                MessageBox.Show("Trạng thái xóa không hợp lệ", "Lỗi");
                txtTTXoa.Focus();
                return;
            }
            

            try
            {
                bdsNhanVien.EndEdit();
                bdsNhanVien.ResetCurrentItem();
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Update(this.DS.NhanVien);
                barbtnThem.Enabled = barbtnXoa.Enabled = barbtnGhi.Enabled = barbtnUndo.Enabled = barbtnReload.Enabled = true;
                gridCNhanVien.Enabled = true;
                txtMaNV.Enabled = txtHo.Enabled = txtLuong.Enabled = txtMaCN.Enabled = txtMaNV.Enabled = txtTen.Enabled = txtTTXoa.Enabled = true;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên", ex.Message);
            }
            
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barbtnChuyenCN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
    }
}
