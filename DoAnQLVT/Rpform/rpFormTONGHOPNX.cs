using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DoAnQLVT.Rpform
{
    public partial class rpFormTONGHOPNX : DevExpress.XtraReports.UI.XtraReport
    {
        public rpFormTONGHOPNX(string begin, string end)
        {
            InitializeComponent();
            this.sqlDataSource1.Queries[0].Parameters[0].Value = begin;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = end;
        }

        private void rpFormTONGHOPNX_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
