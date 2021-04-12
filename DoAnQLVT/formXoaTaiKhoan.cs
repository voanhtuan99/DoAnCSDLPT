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
    public partial class formXoaTaiKhoan : Form
    {
        public formXoaTaiKhoan()
        {
            InitializeComponent();
        }

        private void cmbTenCN_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();

        }

        private void formXoaTaiKhoan_Load(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Phải nhập mã nhân viên!", "Lỗi!!");
                return;
            }
            try
            {

                string stradd = "exec dbo.sp_XoaTaiKhoan '" + txtMaNV.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(stradd);
                Program.myReader.Read();
                Program.myReader.Close();
                MessageBox.Show("Xóa tài khoản thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa tài khoản không thành công", ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
