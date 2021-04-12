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
    public partial class formKhoHang : Form
    {
        string macn = "";
        int vitri = 0;
        public formKhoHang()
        {
            InitializeComponent();
        }

        private void khoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void formKhoHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.Kho' table. You can move, or remove it, as needed.
            DS.EnforceConstraints = false;
            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DS.Kho);          
            macn = ((DataRowView)bdsKho[0])["MACN"].ToString();
            cmbTenCN.DataSource = Program.bds_dspm;
            cmbTenCN.DisplayMember = "TENCN";
            cmbTenCN.ValueMember = "TENSERVER";
            cmbTenCN.SelectedIndex = Program.mChinhanh;
            if (cmbTenCN.Text == "Chi Nhánh Hà Nội")
            {
                txtMaCN.Text = "CN1";
            }
            else if (cmbTenCN.Text == "Chi Nhánh Cần Thơ")
            {
                txtMaCN.Text = "CN2";
            }
            if (Program.Group == "CONGTY")
            {
                cmbTenCN.Enabled = true;

            }
            else cmbTenCN.Enabled = false;
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
                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.DS.Kho);

                macn = cmbTenCN.SelectedText.ToString();
            }
            if (cmbTenCN.Text == "Chi Nhánh Hà Nội")
            {
                txtMaCN.Text = "CN1";
            }
            else if (cmbTenCN.Text == "Chi Nhánh Cần Thơ")
            {
                txtMaCN.Text = "CN2";
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void barbtnThem(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barbtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sp = "exec SP_KIEMTRAMAKHO '" + txtMaKho.Text.Trim() + "'";
            Program.myReader = Program.ExecSqlDataReader(sp);
            Program.myReader.Read();
            if (Program.myReader.HasRows == true)
            {
                MessageBox.Show("Mã KHO đã tồn tại");
                barbtnAdd.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = false;
                return;
            }
            Program.myReader.Close();
            if (txtMaKho.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Lỗi");
                txtMaKho.Focus();
                return;
            }

            if (txtTenKho.Text.Trim() == "")
            {
                MessageBox.Show("Họ không được để trống", "Lỗi");
                txtTenKho.Focus();
                return;
            }

            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Tên không được để trống", "Lỗi");
                txtDiaChi.Focus();
                return;
            }

            if (txtMaCN.Text.Trim() == "")
            {
                MessageBox.Show("Mã chi nhánh không được để trống", "Lỗi");
                txtMaCN.Focus();
                return;
            }

            try
            {
                bdsKho.EndEdit();
                bdsKho.ResetCurrentItem();
                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Update(this.DS.Kho);
                txtDiaChi.Enabled = txtMaCN.Enabled = txtMaKho.Enabled = txtTenKho.Enabled = true;
                gridCKho.Enabled = true;
                barbtnAdd.Enabled = barbtnXoa.Enabled = barbtnGhi.Enabled = barbtnUndo.Enabled = barbtnReload.Enabled = barbtnThoat.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi kho", ex.Message);
            }
        }

        private void barbtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKho.Position;
            groupBox2.Enabled = true;
            bdsKho.AddNew();
            txtMaCN.Text = macn;
            txtMaCN.Enabled = false;
            barbtnAdd.Enabled = barbtnUndo.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = false;
            gridCKho.Enabled = false;
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnGhi.Enabled = true;
            vitri = bdsKho.Position;
            groupBox3.Enabled = true;
            bdsKho.RemoveAt(vitri);
            barbtnAdd.Enabled = barbtnUndo.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = false;
            gridCKho.Enabled = false;
        }
        private void refreshTableAdapter()
        {
            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DS.Kho);
            //MessageBox.Show(Program.mGroup);
            if (Program.Group == "CONGTY")
            {
                cmbTenCN.Enabled = true;
                groupBox1.Enabled = false;
                barbtnAdd.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnUndo.Enabled = barbtnGhi.Enabled = false;
            }
            else
            {
                cmbTenCN.Enabled = false;
                barbtnGhi.Enabled = barbtnUndo.Enabled = false;
            }
        }
        private void barbtnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Đưa BindingSource của nhân viên về mặc định

                bdsKho.RemoveFilter();
                refreshTableAdapter();
                gridCKho.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}", "Cập nhật không thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
