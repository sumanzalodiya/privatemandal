using MandalLibrary;
using System;
using System.Data;
using System.Windows.Forms;

namespace PrivateMandal
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Common _obj = new Common();
            DataSet dstDetails = _obj.GetMandalDetails();
            MandalDetails.MandalName = dstDetails.Tables[0].Rows[0]["MANDAL_NAME"].ToString();
            MandalDetails.MandalStartDate = Convert.ToDateTime(dstDetails.Tables[0].Rows[0]["MANDAL_START_DATE"].ToString());
            MandalDetails.RateOfInterest = Convert.ToDecimal(dstDetails.Tables[0].Rows[0]["MANDAL_INTEREST_RATE"].ToString());
            UserDetaills.UserId = "suman";
            UserDetaills.UserName = "Suman Zalodiya";
            GetDashboardData();
        }

        private void GetDashboardData()
        {
            Common _obj = new Common();
            DataSet dstData = new DataSet();
            dstData = _obj.GetDashboardData();
            lblMemberNumber.Text = dstData.Tables[0].Rows[0]["MEMBER"].ToString();
            lblCurrentBalance.Text = dstData.Tables[0].Rows[0]["CURRENT_BALANCE"].ToString();
            lblTotalBalance.Text = dstData.Tables[0].Rows[0]["TOTAL_BALANCE"].ToString();
            CommonUtility.ConvertToThousandChange(lblCurrentBalance);
            CommonUtility.ConvertToThousandChange(lblTotalBalance);
        }

        private void NewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewMember _obj = new AddNewMember();
            _obj.ShowDialog();
            GetDashboardData();
        }

        private void MonthlyAndLoanPaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MonthlyPayment payment = new MonthlyPayment();
            payment.strFormName = "MONTHLY AND LOAN EMI PAYMENT";
            payment.ShowDialog();
            GetDashboardData();
        }

        private void AdvanceLoanPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyPayment payment = new MonthlyPayment();
            payment.strFormName = "ADVANCE LOAN PAYMENT";
            payment.ShowDialog();
            GetDashboardData();
        }

        private void PendingLoanListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PendingLoanAndPaymentList pendingLoan = new PendingLoanAndPaymentList();
            pendingLoan.strReportName = "Pending Loan List";
            pendingLoan.ShowDialog();
        }

        private void AllPendingPaymentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PendingLoanAndPaymentList pendingPayment = new PendingLoanAndPaymentList();
            pendingPayment.strReportName = "All Pending Payment List";
            pendingPayment.ShowDialog();
        }

        private void NewLoanApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLoanApplication loan = new NewLoanApplication();
            loan.ShowDialog();
        }

        private void NewLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLoan loanApplication = new NewLoan();
            loanApplication.ShowDialog();
            GetDashboardData();
        }

        private void MiscellaneousExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expense _obj = new Expense();
            _obj.ShowDialog();
            GetDashboardData();
        }

        private void CurrentMonthEMIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyList _obj = new MonthlyList();
            _obj.strReportName = "Current Month EMI List";
            _obj.ShowDialog();
        }

        private void Home_KeyUp(object sender, KeyEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close applcation?", "Want to close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DBBackup backup = new DBBackup();
                backup.ShowDialog();
                Application.Exit();
            }
            //if (e.KeyCode == Keys.Escape)
            //    this.Close();
        }

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    if (MessageBox.Show("Do you really want to exit?", "Really want to exit?", MessageBoxButtons.YesNo) == DialogResult.No)
        //    {
        //        e.Cancel = true;
        //    }
        //}

        private void rectangleShape1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExpenseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyList monthlyList = new MonthlyList();
            monthlyList.strReportName = "Expense Report";
            monthlyList.ShowDialog();
        }

        private void PaymentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyList monthlyList = new MonthlyList();
            monthlyList.strReportName = "Payment Report";
            monthlyList.ShowDialog();
        }

        private void MonthlySummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyList monthlyList = new MonthlyList();
            monthlyList.strReportName = "Monthly Summary";
            monthlyList.ShowDialog();
        }
        
        private void MemberListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditMember _obj = new EditMember();
            _obj.ShowDialog();
        }
        
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePwd _obj = new ChangePwd();
            _obj.ShowDialog();
        }

        private void changeEMIAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeEMIAmount _OBJ = new ChangeEMIAmount();
            _OBJ.ShowDialog();
        }

        private void reportTillDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyList _obj = new MonthlyList();
            _obj.strReportName = "Yearly Summary Report";
            _obj.ShowDialog();
        }

        private void balanceReportTillDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PendingLoanAndPaymentList _obj = new PendingLoanAndPaymentList();
            _obj.strReportName = "Pending Loan Application";
            _obj.ShowDialog();
        }
    }
}
