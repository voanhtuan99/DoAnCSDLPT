using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DoAnQLVT.Rpform
{
    public partial class rpformChiTietSL1 : DevExpress.XtraReports.UI.XtraReport
    {
        public rpformChiTietSL1(string group, string begin, string end, string LoaiPhieu)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = group;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = begin;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = end;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = LoaiPhieu;
        }

    }
}
