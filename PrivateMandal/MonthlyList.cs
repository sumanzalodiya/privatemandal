using System;
using System.Windows.Forms;

namespace PrivateMandal
{
    public partial class MonthlyList : Form
    {
        public string strReportName;
        public MonthlyList()
        {
            InitializeComponent();
        }

        private void MonthlyList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtYear.Text.Trim().Length < 4)
            {
                MessageBox.Show("Enter currect year", "Enter year", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                PendingLoanAndPaymentList _obj = new PendingLoanAndPaymentList();
                string reportName = string.Empty;
                if (strReportName.Equals("Current Month EMI List"))
                {
                    reportName = cmbMonth.Text + " " + txtYear.Text.Trim() + " - Payment List";
                }
                else if(strReportName.Equals("Monthly Summary"))
                {
                    reportName = cmbMonth.Text + " " + txtYear.Text.Trim() + " - Monthly Summary";
                }
                else
                {
                    reportName = strReportName;
                
                }
                _obj.strReportName = reportName;
                _obj.intMonth = cmbMonth.SelectedIndex + 1;
                _obj.intYear = Convert.ToInt32(txtYear.Text.Trim());
                _obj.fromDate = dtpFromDate.Text.Trim();
                _obj.toDate = dtpToDate.Text.Trim();
                _obj.type = cmbPaymentList.Text.Trim();
                _obj.ShowDialog();
                this.Close();
            }
        }

        private void MonthlyList_Load(object sender, EventArgs e)
        {
            this.Height = 327;
            groupBox1.Height = 270;
            button1.Top = 209;

            this.Text = strReportName;

            if(strReportName.Equals("Yearly Summary Report"))
            {
                cmbMonth.Visible = false;
                label13.Text = "Year";
                label1.Visible = false;
                txtYear.Visible = true;
                txtYear.Top = 68;
                button1.Top = 120;
                groupBox1.Height = 210;
                this.Height = 270;
            }
            else if (!strReportName.Equals("Current Month EMI List") && !strReportName.Equals("Monthly Summary"))
            {
                cmbMonth.Visible = false;
                txtYear.Visible = false;
                label13.Text = "From Date";
                label1.Text = "To Date";
                dtpFromDate.Visible = true;
                dtpToDate.Visible = true;
                if (strReportName.Equals("Payment Report"))
                {
                    lblPayment.Visible = true;
                    cmbPaymentList.Visible = true;
                    this.Height = 437;
                    groupBox1.Height = 380;
                    button1.Top = 319;
                }
            }

            if (DateTime.Today.Day > 15)
            {
                cmbMonth.SelectedIndex = (DateTime.Today.Month==12? 0 : DateTime.Today.Month);
                if (DateTime.Today.Month == 12)
                {
                    txtYear.Text = (DateTime.Today.Year + 1).ToString();
                }
                else
                {
                    txtYear.Text = DateTime.Today.Year.ToString();
                }
            }
            else
            {
                cmbMonth.SelectedIndex = DateTime.Today.Month - 1;
                txtYear.Text = DateTime.Today.Year.ToString();
            }
            cmbPaymentList.SelectedIndex = 0;
            dtpFromDate.MaxDate = DateTime.Today;
            dtpToDate.MaxDate = DateTime.Today;
        }
    }
}
