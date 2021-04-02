using MandalLibrary;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace PrivateMandal
{
    public partial class LoanApplicationForm : Form
    {
        private readonly int intLoanId;

        public LoanApplicationForm(int intLoanId)
        {
            InitializeComponent();
            this.intLoanId = intLoanId;
        }

        private void LoanApplicationForm_Load(object sender, EventArgs e)
        {
            DataSet dstDetails = new DataSet();
            Loan _obj = new Loan();
            dstDetails = _obj.GetLoanDetails(intLoanId);

            dstDetails.Tables[0].TableName = "LOAN_FORM";

            ReportDataSource dataSource = new ReportDataSource();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.DataSources.Clear();

            dataSource.Name = "dstAllReport";
            dataSource.Value = dstDetails.Tables["LOAN_FORM"];

            reportViewer1.LocalReport.DataSources.Add(dataSource);

            ReportParameter param1 = new ReportParameter("MANDAL_NAME", MandalDetails.MandalName);
            reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\" + "RPT_LoanApplicationForm.rdlc";
            //reportViewer1.LocalReport.ReportPath = @"D:\Rakesh\Mandal\PrivateMandal\Report\RPT_LoanApplicationForm.rdlc";

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param1 });
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            this.reportViewer1.RefreshReport();
        }
    }
}
