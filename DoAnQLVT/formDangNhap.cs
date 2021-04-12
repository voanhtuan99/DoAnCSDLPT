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
    public partial class formDangNhap : Form
    {
        public formDangNhap()
        {
            InitializeComponent();
        }

        private void formDangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVT_DHDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVT_DATHANGDataSet.V_DS_PHANMANH);
            tENCNComboBox.SelectedIndex = 1; //tự động chọn dòng số 2
            tENCNComboBox.SelectedIndex = 0; //tự động chọn dòng số 1
            // muốn không cho gõ chữ thì vào chọn DropDowList (ban đầu là dropdown)

        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void tENCNComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tENCNComboBox.SelectedValue != null)
            {
                Program.servername = tENCNComboBox.SelectedValue.ToString();
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản đăng nhập không được rỗng", "Báo lỗi đăng nhập", MessageBoxButtons.OK);
                txtLogin.Focus();
                return;
            }
            else if (txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu đăng nhập không được rỗng. Kiểm tra lại !", "Báo lỗi đăng nhập", MessageBoxButtons.OK);
                txtPass.Focus();
                return;
            }
            else
            {
                Program.mlogin = txtLogin.Text;
                Program.password = txtPass.Text;
                if (Program.KetNoi() == 0) return;
                // MessageBox.Show("Đăng nhập thành công", "", MessageBoxButtons.OK);
                // khi đăng nhập thành công thì chạy form main và ẩn form đăng nhập và khi tắt chương trình nhớ tắt cả form main và login
                
                Program.mChinhanh = tENCNComboBox.SelectedIndex;// Lấy tên chi nhánh hiện đang nhận bên form đăng nhập
                // Program.frmDN.Hide();
                SqlDataReader myReader;
                //   Program.mChinhanh;
                Program.bds_dspm = bdsDSPM;
                //MessageBox.Show(Program.bds_dspm.ToString());
                Program.mloginDN = Program.mlogin;
                Program.passwordDN = Program.password;
                String strLenh = "EXEC SP_DANGNHAP '" + Program.mlogin + "'";
                myReader = Program.ExecSqlDataReader(strLenh);
                if (myReader == null) return;
                myReader.Read(); // đọc 1 dòng , khi có nhiều dòng thì để trong vòng lặp bằng TRUE là đọc thành công, bằng FALSE là hết dòng.
                // => while(myReader.Read()==true) {}
                Program.userName = myReader.GetString(0);

                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK);               

                //đọc dữ liệu cột đầu tiên
                if (Convert.IsDBNull(Program.userName))
                {
                    MessageBox.Show("LogiN bạn nhập không có quyền truy cập dữ liệu. \n Bạn xem lại.");
                    
                    return;
                }
                Program.mHoten = myReader.GetString(1);
                Program.Group = myReader.GetString(2).Trim();
                if (Program.Group == "USER")
                {
                    Program.formChinh.btnRPDSNV.Enabled = Program.formChinh.BTNRPDSVT.Enabled = Program.formChinh.btnRPCTP.Enabled =
                        Program.formChinh.btnRPDDHCPN.Enabled = Program.formChinh.btnChuyenCN.Enabled = Program.formChinh.btnTaoTK.Enabled = 
                        Program.formChinh.btnXoaTK.Enabled = Program.formChinh.btnHDNV.Enabled = Program.formChinh.btnTHNX.Enabled = false;
                    Program.formChinh.btnNV.Enabled = Program.formChinh.btnVattu.Enabled = Program.formChinh.btnKho.Enabled
                        = Program.formChinh.btnDangXuat.Enabled = Program.formChinh.btnDatHang.Enabled = Program.formChinh.btnPhieuNhap.Enabled
                        = Program.formChinh.btnPhieuXuat.Enabled = true;
                }
                else if(Program.Group == "CHINHANH" || Program.Group == "CONGTY")
                {
                    Program.formChinh.btnRPDSNV.Enabled = Program.formChinh.BTNRPDSVT.Enabled = Program.formChinh.btnRPCTP.Enabled =
                        Program.formChinh.btnRPDDHCPN.Enabled = Program.formChinh.btnChuyenCN.Enabled = Program.formChinh.btnTaoTK.Enabled =
                        Program.formChinh.btnXoaTK.Enabled = Program.formChinh.btnHDNV.Enabled = Program.formChinh.btnTHNX.Enabled = true;
                    Program.formChinh.btnNV.Enabled = Program.formChinh.btnVattu.Enabled = Program.formChinh.btnKho.Enabled
                        = Program.formChinh.btnDangXuat.Enabled = Program.formChinh.btnDatHang.Enabled = Program.formChinh.btnPhieuNhap.Enabled
                        = Program.formChinh.btnPhieuXuat.Enabled = true;
                }
                myReader.Close();
                Program.conn.Close();
                Program.formChinh.MaMV.Text = "Mã NV: "+Program.userName;
                Program.formChinh.HOTEN.Text = "Họ Tên: " + Program.mHoten;
                Program.formChinh.NHOM.Text = "Group: " + Program.Group;
                this.Hide();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Program.formChinh.Close();
        }
    }
}
