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
    public partial class formDSNV : Form
    {
        public formDSNV()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNhanVien.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void formDSNV_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
            cmbTenCN.DataSource = Program.bds_dspm;
            cmbTenCN.DisplayMember = "TENCN";
            cmbTenCN.ValueMember = "TENSERVER";
            cmbTenCN.SelectedIndex = Program.mChinhanh;
            if(Program.Group == "CHINHANH")
            {
                cmbTenCN.Enabled = false;
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
        }

        private void gridCDSNV_MouseCaptureChanged(object sender, EventArgs e)
        {
            if(Program.maForm == 1)
            {
                Program.formAddAccount.txtUserNameA.Text = ((DataRowView)bdsNhanVien.Current)["MANV"].ToString();
                this.Close();
            }
            else if(Program.maForm == 2)
            {
                Program.formXoaTaiKhoan.txtMaNV.Text = ((DataRowView)bdsNhanVien.Current)["MANV"].ToString();
                this.Close();
            }
            else if (Program.maForm == 3)
            {
                Program.formChuyenCN.txtMaNV.Text = ((DataRowView)bdsNhanVien.Current)["MANV"].ToString();
                this.Close();
            }
            else if (Program.maForm == 4)
            {
                Program.rpHDNV.txtMaNV.Text = ((DataRowView)bdsNhanVien.Current)["MANV"].ToString();
                this.Close();
            }
        }
    }
}
