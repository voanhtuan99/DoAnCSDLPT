using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DoAnQLVT.Rpform
{
    public partial class ReportDSVT : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportDSVT()
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Fill();
        }

    }
}
