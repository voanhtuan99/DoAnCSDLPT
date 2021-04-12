using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Data;
using System.Data.SqlClient;
using DoAnQLVT.Rp;

namespace DoAnQLVT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///
        public static SqlConnection conn = new SqlConnection();
        // Chuỗi kết nối 
        public static String connstr;
        public static SqlDataReader myReader;
        public static DataTable myTable;
        // Tên SQL Server
        public static String servername = "";
        public static String userID = "";

        // Các thông tin lấy từ LoginForm
        public static String mlogin = "";
        public static String password = "";

        // Tên database
        public static String database = "QLVT_DATHANG";
        // Acc hỗ trợ kết nối từ xa
        public static String remotelogin = "HTKN";
        public static String remotepassword = "123456";
        public static String mloginDN = "";
        public static String passwordDN = "";
        // Phân nhóm để phân quyền
        public static String userRole = "";
        // Người làm việc hiện tại
        public static String userName = "";
        public static int mChinhanh = 0;
        public static formMain formChinh;
        public static formDangNhap frmDN;
        public static formNhanVien formNV;
        // Họ tên
        public static String mHoten = "";
        public static String Group = "";
        public static BindingSource bds_dspm = new BindingSource();

        public static formAddAccount formAddAccount;
        public static formXoaTaiKhoan formXoaTaiKhoan;
        public static formChuyenCN formChuyenCN;
        public static rpHDNV rpHDNV;
        public static int maForm = 0;
        public static formMain formMain;

        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open)
                Program.conn.Close();
            try
            {
                Program.connstr = "Data Source=" + Program.servername + ";Initial Catalog=" +
                      Program.database + ";User ID=" +
                      Program.mlogin + ";password=" + Program.password;
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Kết nối thất bại !" + e.Message, "Lỗi kết nối cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader();
                return myreader;

            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                //MessageBox.Show(ex.Number.ToString());
                //MessageBox.Show(ex.Message);
                if (ex.Number.ToString().Trim() == "15151")
                    return myReader;
                return null;
            }
        }
        public static DataTable ExecSqlDataTable(String cmd, string connstr)
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public static int ExecSqlNonQuery(String strlenh)
        {
            SqlCommand Sqlcmd = new SqlCommand(strlenh, conn);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut 
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery(); conn.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Error converting data type varchar to int"))
                    MessageBox.Show("Bạn format Cell lại cột \"Ngày Thi\" qua kiểu Number hoặc mở File Excel.");
                else MessageBox.Show(ex.Message);
                conn.Close();
                return ex.State; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmDN = new formDangNhap();
            formChinh = new formMain();    
            Application.Run(formChinh);
            
        }
    }
}
