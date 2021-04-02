using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MandalLibrary;

namespace PrivateMandal
{
    public partial class Expense : Form
    {
        int intPaymentId = 0;
        public Expense()
        {
            InitializeComponent();
        }

        private void Expense_Load(object sender, EventArgs e)
        {
            Header header = new Header("MISCELLANEOUS EXPENSE");
            this.Controls.Add(header);
            header.Left = 0;
            header.Top = 0;
            header.Width = this.Width;
            dtpDate.MaxDate = DateTime.Today;
            lblType.Text = "Mode : New Entry";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Today;
            txtAmount.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDetails.Text = string.Empty;
            intPaymentId = 0;
            lblType.Text = "Mode : New Entry";
            dtpDate.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtAmount.Text.Trim().Equals("") || txtAmount.Text.Trim().Equals("0"))
            {
                MessageBox.Show("Enter Expense Amount", "Expense Amount", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtAmount.Focus();
            }
            else if(txtDetails.Text.Trim().Equals(""))
            {
                MessageBox.Show("Enter Expense Details", "Expense Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtDetails.Focus();
            }
            else
            {
                try
                {
                    string strInsertXML = CreateExpenseXML();
                    Common _obj = new Common();
                    bool blnSuccess = _obj.AddNewExpense(strInsertXML);
                    if(blnSuccess)
                    {
                        MessageBox.Show(intPaymentId==0 ? "Expense Added Successfully" : "Expense Updated Successfully", intPaymentId == 0 ? "Expense Added" : "Expense Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClear_Click(sender, e);
                        if(dgvExpense.Rows.Count>0)
                        {
                            btnSearchExpense_Click(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Transaction failed. Try again later", "Transaction failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Transaction failed. Try again later", "Transaction failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LogError.LogEvent("", ex.Message, "SaveExpense");
                }
            }
        }

        private string CreateExpenseXML()
        {
            StringBuilder strXML = new StringBuilder();
            strXML.Append("<ROOT><EXPENSE ");
            strXML.Append("ME_ID='" + intPaymentId.ToString() + "' ");
            strXML.Append("EX_DATE='" + dtpDate.Text.Trim() + "' ");
            strXML.Append("EX_AMOUNT='" + txtAmount.Text.Trim() + "' ");
            strXML.Append("EX_DETAIL='" + txtDetails.Text.Trim() + "' ");
            strXML.Append("EX_PERSON='" + txtName.Text.Trim() + "' ");
            strXML.Append("EX_USER='" + UserDetaills.UserId + "' ");
            strXML.Append("/></ROOT>");
            return strXML.ToString();
        }

        private void Expense_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnSearchExpense_Click(object sender, EventArgs e)
        {
            DataSet dstExpense = new DataSet();
            MandalLibrary.Report _obj = new MandalLibrary.Report();
            dstExpense = _obj.GetExpenseReport(dtpSearchFromDate.Text, dtpSearchToDate.Text);
            dgvExpense.DataSource = dstExpense.Tables[0];
            SetDataGridProperties();
        }

        private void SetDataGridProperties()
        {
            dgvExpense.Columns["EXPENSE_DATE"].Visible = false;

            dgvExpense.Columns["ME_DETAILS"].HeaderText = "Expense Details";
            dgvExpense.Columns["ME_DETAILS"].DisplayIndex = 0;
            dgvExpense.Columns["ME_DETAILS"].Width = 260;

            dgvExpense.Columns["ME_AMOUNT"].HeaderText = "Expense Amount";
            dgvExpense.Columns["ME_AMOUNT"].Width = 150;
            dgvExpense.Columns["ME_AMOUNT"].DisplayIndex = 1;

            dgvExpense.Columns["PERSON_NAME"].Visible = false;
            dgvExpense.Columns["ME_ID"].Visible = false;

            Font font = new Font("Segoe UI Semibold", 12);
            dgvExpense.ColumnHeadersDefaultCellStyle.Font = font;
        }

        private void dgvExpense_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            intPaymentId = Convert.ToInt32(dgvExpense.Rows[dgvExpense.CurrentCell.RowIndex].Cells["ME_ID"].Value.ToString());
            dtpDate.Text = dgvExpense.Rows[dgvExpense.CurrentCell.RowIndex].Cells["EXPENSE_DATE"].Value.ToString();
            txtAmount.Text = dgvExpense.Rows[dgvExpense.CurrentCell.RowIndex].Cells["ME_AMOUNT"].Value.ToString();
            txtDetails.Text = dgvExpense.Rows[dgvExpense.CurrentCell.RowIndex].Cells["ME_DETAILS"].Value.ToString();
            txtName.Text = dgvExpense.Rows[dgvExpense.CurrentCell.RowIndex].Cells["PERSON_NAME"].Value.ToString();
            lblType.Text = "Mode : Update Entry";
        }
    }
}
