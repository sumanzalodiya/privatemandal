using System;
using System.Data;
using System.Windows.Forms;
using MandalLibrary;
using Microsoft.Reporting.WinForms;

namespace PrivateMandal
{
    public partial class MembershipForm : Form
    {
        private readonly int intMemberId;

        public MembershipForm(int intMemberId)
        {
            InitializeComponent();
            this.intMemberId = intMemberId;
        }

        private void MembershipForm_Load(object sender, EventArgs e)
        {
            DataSet dstDetails = new DataSet();
            Member _obj = new Member();
            dstDetails = _obj.GetMemberDetails(intMemberId);

            dstDetails.Tables[0].TableName = "MEMBER_FORM";

            ReportDataSource dataSource = new ReportDataSource();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.DataSources.Clear();

            dataSource.Name = "dstAllReport";
            dataSource.Value = dstDetails.Tables["MEMBER_FORM"];

            reportViewer1.LocalReport.DataSources.Add(dataSource);

            ReportParameter param1 = new ReportParameter("MANDAL_NAME", MandalDetails.MandalName);
            reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\" + "RPT_MembershipForm.rdlc";
            //reportViewer1.LocalReport.ReportPath = @"D:\Rakesh\Mandal\PrivateMandal\Report\RPT_MembershipForm.rdlc";

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param1 });
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            this.reportViewer1.RefreshReport();
        }
    }
}
