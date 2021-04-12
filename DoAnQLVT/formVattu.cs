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
    public partial class formVattu : Form
    {
        string macn = "";
        int vitri = 0;
        public formVattu()
        {
            InitializeComponent();
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVattu.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void formVattu_Load(object sender, EventArgs e)
        {
            
            DS.EnforceConstraints = false;
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);
            // TODO: This line of code loads data into the 'DS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);
            // TODO: This line of code loads data into the 'DS.CTPN' table. You can move, or remove it, as needed.
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS.CTPN);
            // TODO: This line of code loads data into the 'DS.CTPX' table. You can move, or remove it, as needed.
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS.CTPX);

            cmbTenCN.DataSource = Program.bds_dspm;
            cmbTenCN.DisplayMember = "TENCN";
            cmbTenCN.ValueMember = "TENSERVER";
            cmbTenCN.SelectedIndex = Program.mChinhanh;
            cmbTenCN.Enabled = false;

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



        private void cmbTenCN_SelectedIndexChanged_1(object sender, EventArgs e)
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
                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Fill(this.DS.Vattu);

                macn = cmbTenCN.SelectedText.ToString();
            }
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnGhi.Enabled = true;
            vitri = bdsVattu.Position;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            bdsVattu.AddNew();
            barbtnThem.Enabled = barbtnUndo.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = false;
            gridCVattu.Enabled = false;
        }

        private void barbtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sp = "exec SP_KTMAVATTU '" + txtMaVT.Text.Trim() + "'";
            Program.myReader = Program.ExecSqlDataReader(sp);
            Program.myReader.Read();
            if (Program.myReader.HasRows == true)
            {
                MessageBox.Show("Mã vật tư đã tồn tại");
                return;
            }
            Program.myReader.Close();
            if (txtMaVT.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Lỗi");
                txtMaVT.Focus();
                return;
            }

            if (txtTenVT.Text.Trim() == "")
            {
                MessageBox.Show("Họ không được để trống", "Lỗi");
                txtTenVT.Focus();
                return;
            }

            if (txtDVT.Text.Trim() == "")
            {
                MessageBox.Show("Tên không được để trống", "Lỗi");
                txtDVT.Focus();
                return;
            }
            Program.myReader.Close();

            try
            {
                bdsVattu.EndEdit();
                bdsVattu.ResetCurrentItem();
                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Update(this.DS.Vattu);
                MessageBox.Show("GHI VẬT TƯ THÀNH CÔNG");
                txtDVT.Enabled = txtMaVT.Enabled = txtSoLuongTon.Enabled = txtTenVT.Enabled = true;
                barbtnThem.Enabled = barbtnXoa.Enabled = barbtnGhi.Enabled = barbtnUndo.Enabled = barbtnReload.Enabled = true;
                gridCVattu.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi vật tư", ex.Message);
            }
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnGhi.Enabled = true;
            vitri = bdsVattu.Position;
            groupBox2.Enabled = true;
            bdsVattu.RemoveAt(vitri);
            barbtnThem.Enabled = barbtnUndo.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled =false;
            gridCVattu.Enabled = false;
        }
        private void refreshTableAdapter()
        {
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);
            //MessageBox.Show(Program.mGroup);
            if (Program.Group == "CONGTY")
            {
                cmbTenCN.Enabled = true;
                groupBox1.Enabled = false;
                barbtnThem.Enabled = barbtnXoa.Enabled = barbtnReload.Enabled = barbtnUndo.Enabled = barbtnGhi.Enabled = false;
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

                bdsVattu.RemoveFilter();
                refreshTableAdapter();
                gridCVattu.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}", "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
