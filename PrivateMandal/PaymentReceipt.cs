using MandalLibrary;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace PrivateMandal
{
    public partial class PaymentReceipt : Form
    {
        private readonly string paymentReceiptNo;

        public PaymentReceipt(string paymentReceiptNo)
        {
            InitializeComponent();
            this.paymentReceiptNo = paymentReceiptNo;
        }

        private void PaymentReceipt_Load(object sender, EventArgs e)
        {
            DataSet dstDetails = new DataSet();
            Payment _obj = new Payment();
            dstDetails = _obj.GetPaymentReceipt(paymentReceiptNo);

            dstDetails.Tables[0].TableName = "PAYMENT_RECEIPT_1";
            dstDetails.Tables[1].TableName = "PAYMENT_RECEIPT_2";

            
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource dataSource = new ReportDataSource();
            dataSource.Name = "dstAllReport";
            dataSource.Value = dstDetails.Tables["PAYMENT_RECEIPT_1"];

            ReportDataSource dataSource1 = new ReportDataSource();
            dataSource1.Name = "dstAllReport1";
            dataSource1.Value = dstDetails.Tables["PAYMENT_RECEIPT_2"];

            reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.LocalReport.DataSources.Add(dataSource1);

            ReportParameter param1 = new ReportParameter("MANDAL_NAME", MandalDetails.MandalName);
            reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\" + "RPT_PaymentReceipt.rdlc";
            //reportViewer1.LocalReport.ReportPath = @"D:\Rakesh\Mandal\PrivateMandal\Report\RPT_PaymentReceipt.rdlc";

            //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param1 });
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
        }
    }
}
