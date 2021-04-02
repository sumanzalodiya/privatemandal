using MandalLibrary;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace PrivateMandal
{
    public partial class PendingLoanAndPaymentList : Form
    {
        public string strReportName;
        public int intMonth;
        public int intYear;
        public string fromDate;
        public string toDate;
        public string type;
        public PendingLoanAndPaymentList()
        {
            InitializeComponent();
        }

        private void PendingLoanList_Load(object sender, EventArgs e)
        {
            DataSet dst = new DataSet();
            MandalLibrary.Report _obj = new MandalLibrary.Report();
            Payment _objPayment = new Payment();
            string strTableName = string.Empty;
            this.Text = strReportName;

            if (strReportName == "Pending Loan List")
            {
                dst = _obj.GetPendingLoanList();
                strTableName = "PENDING_LOAN_LIST";
            }
            else if (strReportName == "All Pending Payment List")
            {
                dst = _objPayment.GetPendingPayments(0, 0);
                strTableName = "ALL_PENDING_PAYMENT";
            }
            else if (strReportName.Contains("- Payment List"))
            {
                dst = _obj.GetMonthlyPaymentList(intMonth, intYear);
                strTableName = "MONTHLY_PAYMENT_LIST";
            }
            else if (strReportName.Equals("Payment Report"))
            {
                dst = _obj.GetPaymentReport(fromDate, toDate, type);
                strTableName = "PAYMENT_REPORT";
            }
            else if (strReportName.Equals("Expense Report"))
            {
                dst = _obj.GetExpenseReport(fromDate, toDate);
                strTableName = "EXPENSE_REPORT";
            }
            else if(strReportName.Contains("Monthly Summary"))
            {
                dst = _obj.GetMonthlySummaryReport(intMonth, intYear);
                strTableName = "MONTHLY_SUMMARY_1";
                dst.Tables[1].TableName = "MONTHLY_SUMMARY_2";
            }
            else if(strReportName.Contains("Yearly Summary Report"))
            {
                dst = _obj.GetYearlySummaryReport(intYear);
                strTableName = "YEARLY_SUMMARY";
            }
            else if(strReportName.Contains("Pending Loan Application"))
            {
                dst = _obj.GetPendingLoanApplicationList();
                strTableName = "PENDING_LOAN_APPLICATION";
            }
            dst.Tables[0].TableName = strTableName;

            ReportDataSource dataSource = new ReportDataSource();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.DataSources.Clear();

            dataSource.Name = "dstAllReport";
            dataSource.Value = dst.Tables[strTableName];

            reportViewer1.LocalReport.DataSources.Add(dataSource);

            ReportParameter param1 = new ReportParameter("MANDAL_NAME", MandalDetails.MandalName);
            ReportParameter reportName = new ReportParameter("REPORT_NAME", strReportName);
            

            if (strReportName == "Pending Loan List")
            {
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\" + "RPT_PendingLoanList.rdlc";
                //reportViewer1.LocalReport.ReportPath = @"D:\Rakesh\Mandal\PrivateMandal\Report\RPT_PendingLoanList.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param1, reportName });
            }
            else if (strReportName == "All Pending Payment List")
            {
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\" + "RPT_AllPendingPayment.rdlc";
                //reportViewer1.LocalReport.ReportPath = @"D:\Rakesh\Mandal\PrivateMandal\Report\RPT_AllPendingPayment.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param1, reportName });
            }
            else if (strReportName.Contains(" - Payment List"))
            {
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\" + "RPT_MonthlyPaymentList.rdlc";
                //reportViewer1.LocalReport.ReportPath = @"D:\Rakesh\Mandal\PrivateMandal\Report\RPT_MonthlyPaymentList.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param1, reportName });
            }
            else if (strReportName.Equals("Payment Report"))
            {
                ReportParameter paramFromDate = new ReportParameter("FROM_DATE", fromDate);
                ReportParameter paramToDate = new ReportParameter("TO_DATE", toDate);
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\" + "RPT_PaymentReport.rdlc";
                //reportViewer1.LocalReport.ReportPath = @"D:\Rakesh\Mandal\PrivateMandal\Report\RPT_PaymentReport.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param1, reportName, paramFromDate, paramToDate });
            }
            else if (strReportName.Equals("Expense Report"))
            {
                ReportParameter paramFromDate = new ReportParameter("FROM_DATE", fromDate);
                ReportParameter paramToDate = new ReportParameter("TO_DATE", toDate);
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\" + "RPT_ExpenseReport.rdlc";
                //reportViewer1.LocalReport.ReportPath = @"D:\Rakesh\Mandal\PrivateMandal\Report\RPT_ExpenseReport.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param1, reportName, paramFromDate, paramToDate });
            }
            else if(strReportName.Contains("Monthly Summary"))
            {
                ReportDataSource dataSource1 = new ReportDataSource();

                dataSource1.Name = "dstAllReport1";
                dataSource1.Value = dst.Tables["MONTHLY_SUMMARY_2"];

                reportViewer1.LocalReport.DataSources.Add(dataSource1);

                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\" + "RPT_MonthlySummary.rdlc";
                //reportViewer1.LocalReport.ReportPath = @"D:\Rakesh\Mandal\PrivateMandal\Report\RPT_MonthlySummary.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param1, reportName });
            }
            else if (strReportName.Equals("Yearly Summary Report"))
            {
                ReportParameter paramYear = new ReportParameter("YEAR", intYear.ToString());
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\" + "RPT_YearlyReport.rdlc";
                //reportViewer1.LocalReport.ReportPath = @"D:\Rakesh\Mandal\PrivateMandal\Report\RPT_YearlyReport.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param1, paramYear });
            }
            else if (strReportName.Equals("Pending Loan Application"))
            {
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\" + "RPT_PendingLoanApplication.rdlc";
                //reportViewer1.LocalReport.ReportPath = @"D:\Rakesh\Mandal\PrivateMandal\Report\RPT_PendingLoanApplication.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param1, reportName });
            }

            this.reportViewer1.ZoomMode = ZoomMode.FullPage;
            this.reportViewer1.RefreshReport();
        }

        private void PendingLoanAndPaymentList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
