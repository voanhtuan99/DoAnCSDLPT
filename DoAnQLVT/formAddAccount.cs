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
    public partial class formAddAccount : Form
    {
        String macn = "";
        public formAddAccount()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void formAddAccount_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.NhanVien' table. You can move, or remove it, as needed.
            DS.EnforceConstraints = false;
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
            if (Program.Group == "USER")
            {
                groupBox1.Enabled = false;
                MessageBox.Show("USER không được quyền tạo tài khoản","Thông báo!!");
                return;
            }
            else if(Program.Group == "CHINHANH")
            {
                groupBox1.Enabled = true;
                radCtyA.Enabled = false;
                radChiNhanhA.Enabled = radUserA.Enabled = true;
                
            }
            else if(Program.Group == "CONGTY")
            {
                groupBox1.Enabled = true;
                radCtyA.Enabled = true;
                radChiNhanhA.Enabled = radUserA.Enabled = false;
                
            }
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNhanVien.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void radUser_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtLoginName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radChiNhanh_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void mANVLabel_Click(object sender, EventArgs e)
        {

        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radCty_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Click_1(object sender, EventArgs e)
        {
            String role = radCtyA.Checked ? "CONGTY" : (radChiNhanhA.Checked ? "CHINHANH" : "USER");
            if (txtLoginNameA.Text.Trim() == "")
            {
                MessageBox.Show("Login name không được để trống", "Lỗi");
                txtLoginNameA.Focus();
                return;
            }
            if (txtPassA.Text.Trim() == "")
            {
                MessageBox.Show("Pass không được để trống", "Lỗi");
                txtPassA.Focus();
                return;
            }
            if (txtConfirmPassA.Text.Trim() == "")
            {
                MessageBox.Show("ConfirmPass không được để trống", "Lỗi");
                txtConfirmPassA.Focus();
                return;
            }
            if (txtUserNameA.Text.Trim() == "")
            {
                MessageBox.Show("UserName không được để trống", "Lỗi");
                txtUserNameA.Focus();
                return;
            }
            if (!txtPassA.Text.Equals(txtConfirmPassA.Text))
            {
                MessageBox.Show("Vui lòng nhập pass và confirmpass giống nhau", "Lỗi");
                return;
            }
            if (role.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn nhóm quyền", "Lỗi");
            }
            try
            {

                string stradd = "exec dbo.sp_TaoTaiKhoan '" + txtLoginNameA.Text.Trim() + "','" + txtPassA.Text.Trim() + "','" + txtUserNameA.Text.Trim() + "','" + role.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(stradd);
                Program.myReader.Read();
                Program.myReader.Close();
                MessageBox.Show("Tạo tài khoản thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tạo tài khoản không thành công", ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
