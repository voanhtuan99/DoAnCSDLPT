using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnQLVT.Rpform;
using DevExpress.XtraReports.UI;

namespace DoAnQLVT.Rp
{
    public partial class rpCTNhap : Form
    {
        public rpCTNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rpCTNhap_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbTenCN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string LoaiPhieu = radPX.Checked ? "PX" : "PN";
            string begin, end;
            begin = DTBegin.Text;
            end = DTEnd.Text;
            rpformChiTietSL1 rpt = new rpformChiTietSL1(Program.Group, DTBegin.Text, DTEnd.Text, LoaiPhieu);
            rpt.lbChiTietSL.Text = "CHI TIẾT PHIẾU " + LoaiPhieu;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
