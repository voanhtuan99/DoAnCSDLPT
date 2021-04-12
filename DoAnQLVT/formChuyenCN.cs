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
    public partial class formChuyenCN : Form
    {
        public formChuyenCN()
        {
            InitializeComponent();
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = this.CheckExists(typeof(formDSNV));
            if (frm != null) frm.Activate();
            else
            {
                formDSNV f = new formDSNV();
               // f.MdiParent = this;
                f.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CN = radCN1.Checked ? "CN1" : "CN2";
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Mã NV không được để trống");
                txtMaNV.Focus();
                return;
            }
            if (txtMaNVNew.Text.Trim() == "")
            {
                MessageBox.Show("Mã NV mới không được để trống");
                txtMaNV.Focus();
                return;
            }
            string sp = "exec SP_KIEMTRAMANVMOI '" + txtMaNVNew.Text.Trim() + "'";
            Program.myReader = Program.ExecSqlDataReader(sp);
            Program.myReader.Read();
            if(Program.myReader.HasRows == true)
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại bên" + CN);
                return;
            }
            Program.myReader.Close();
            MessageBox.Show(txtMaNV.Text+"-----"+txtMaNVNew.Text+"--------"+CN);
            try
            {
                sp = "exec SP_CHUYENCHINHANH1 '" + int.Parse(txtMaNV.Text.Trim()) + "','" + CN.Trim() + "','" + int.Parse(txtMaNVNew.Text.Trim()) + "'";
                Program.myReader = Program.ExecSqlDataReader(sp);
                Program.myReader.Read();
                Program.myReader.Close();
                MessageBox.Show("Chuyển chi nhánh thành công");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Chuyển chi nhánh không thành công", ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formChuyenCN_Load(object sender, EventArgs e)
        {
            if(Program.mChinhanh == 0)
            {
                radCN1.Enabled = false;
                RadCN2.Enabled = true;
            }
            else if (Program.mChinhanh == 1)
            {
                RadCN2.Enabled = false;
                radCN1.Enabled = true;
            }
        }
    }
}
