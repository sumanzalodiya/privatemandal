using MandalLibrary;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PrivateMandal
{
    public partial class MonthlyPayment : Form
    {
        int intTotalRow = 0;
        public string strFormName;
        public MonthlyPayment()
        {
            InitializeComponent();
        }

        private void MonthlyPayment_Load(object sender, EventArgs e)
        {
            Header header = new Header(strFormName);
            this.Controls.Add(header);
            header.Left = 0;
            header.Top = 0;
            header.Width = this.Width;
            LoadBlankList();

        }

        private void SetDataGridProperties()
        {
            if (dgvPayment.Columns["chkColumn"] != null)
            {
                dgvPayment.Columns.RemoveAt(0);
            }

            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.HeaderText = "";
            chkColumn.Width = 25;
            chkColumn.Name = "chkColumn";
            dgvPayment.Columns.Insert(0, chkColumn);
            dgvPayment.Columns["PAYMENT_ID"].Visible = false;
            dgvPayment.Columns["PAYMENT_MEMBER"].Visible = false;
            dgvPayment.Columns["MEMBER_NAME"].Visible = false;
            dgvPayment.Columns["DUE_DATE"].DisplayIndex = 1;
            dgvPayment.Columns["DUE_DATE"].ReadOnly = true;
            dgvPayment.Columns["DUE_DATE"].HeaderText = "Due Date";
            dgvPayment.Columns["DUE_DATE"].Width = 120;
            dgvPayment.Columns["PAYMENT_DETAILS"].HeaderText = "Payment Details";
            dgvPayment.Columns["PAYMENT_DETAILS"].DisplayIndex = 2;
            dgvPayment.Columns["PAYMENT_DETAILS"].Width = 250;
            dgvPayment.Columns["PAYMENT_DETAILS"].ReadOnly = true;
            dgvPayment.Columns["PAYMENT_AMOUNT"].HeaderText = "EMI Amount";
            dgvPayment.Columns["PAYMENT_AMOUNT"].DisplayIndex = 3;
            dgvPayment.Columns["PAYMENT_AMOUNT"].Width = 120;
            dgvPayment.Columns["PAYMENT_AMOUNT"].ReadOnly = true;
            dgvPayment.Columns["PANELTY"].HeaderText = "Penalty";
            dgvPayment.Columns["PANELTY"].Width = 110;
            dgvPayment.Columns["PANELTY"].DisplayIndex = 4;
            dgvPayment.Columns["PANELTY"].ReadOnly = true;
            dgvPayment.Columns["LOAN_ID"].Visible = false;
            dgvPayment.Columns["TOTAL"].HeaderText = "Total Amount";
            dgvPayment.Columns["TOTAL"].Width = 100;
            dgvPayment.Columns["TOTAL"].DisplayIndex = 5;
            dgvPayment.Columns["TOTAL"].ReadOnly = true;
            dgvPayment.Columns["PAYMENT_AMOUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPayment.Columns["PANELTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPayment.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPayment.Columns["DUE_DATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            System.Drawing.Font font = new System.Drawing.Font("Segoe UI Semibold", 11);
            dgvPayment.ColumnHeadersDefaultCellStyle.Font = font;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool blnSelected = false;
            foreach (DataGridViewRow dgvRow in dgvPayment.Rows)
            {
                bool isSelected = Convert.ToBoolean(dgvRow.Cells["chkColumn"].Value);
                if (isSelected)
                {
                    blnSelected = true;
                    break;
                }

            }
            if (!blnSelected)
            {
                MessageBox.Show("Select at least one row for payment", "Select row", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                try
                {
                    string strXML = CreatePaymentXML();
                    string strPaymentId = string.Empty;
                    Payment _obj = new Payment();
                    bool blnSuccess = _obj.AddPayment(strXML, intTotalRow, out strPaymentId);
                    if(blnSuccess)
                    {
                        MessageBox.Show("Payment saved successfully", "Payment saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PaymentReceipt receipt = new PaymentReceipt(strPaymentId);
                        receipt.ShowDialog();
                        btnClear_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Payment failed. Try again later", "Payment failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Payment failed. Try again later", "Payment failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LogError.LogEvent("SavePayment", ex.Message, "Save Payment");
                }
            }
        }

        private string CreatePaymentXML()
        {
            StringBuilder strXML = new StringBuilder("<ROOT>");
            strXML.Append("<USER_DETAIL MEMBER_ID='" + txtNumber.Text.Trim() + "' USER_ID='" + UserDetaills.UserId + "' PAYMENT_DATE='" + dtpPayment.Text.ToString() + "' />");
            intTotalRow = 2;
            foreach (DataGridViewRow dgvRow in dgvPayment.Rows)
            {
                bool isSelected = Convert.ToBoolean(dgvRow.Cells["chkColumn"].Value);
                if (isSelected)
                {
                    strXML.Append("<PAYMENT PAYMENT_ID='" + dgvRow.Cells["PAYMENT_ID"].Value.ToString() + "' ");
                    strXML.Append("PAYMENT_AMOUNT='" + dgvRow.Cells["PAYMENT_AMOUNT"].Value.ToString() + "' ");
                    strXML.Append("LOAN_ID='" + dgvRow.Cells["LOAN_ID"].Value.ToString() + "' ");
                    strXML.Append("PAYMENT_DETAILS='" + dgvRow.Cells["PAYMENT_DETAILS"].Value.ToString() + "' ");
                    strXML.Append("/>");
                    intTotalRow++;
                    if (Convert.ToDecimal(dgvRow.Cells["PANELTY"].Value.ToString()) > 0)
                    {
                        strXML.Append("<PAYMENT PAYMENT_ID='0' ");
                        strXML.Append("PAYMENT_AMOUNT='" + dgvRow.Cells["PANELTY"].Value.ToString() + "' ");
                        strXML.Append("LOAN_ID='" + dgvRow.Cells["LOAN_ID"].Value.ToString() + "' ");
                        strXML.Append("PAYMENT_DETAILS='" + dgvRow.Cells["PAYMENT_DETAILS"].Value.ToString() + " Penalty' ");
                        strXML.Append("/>");
                        intTotalRow++;
                    }

                    if (Convert.ToInt32(dgvRow.Cells["LOAN_ID"].Value.ToString()) > 0)
                    {
                        intTotalRow++;
                    }
                }
            }
            strXML.Append("</ROOT>");
            return strXML.ToString();
        }

        private void LoadBlankList()
        {
            DataTable dtbl = new DataTable();
            dgvPayment.DataSource = null;
            dtbl.Columns.Add("PAYMENT_ID", typeof(string));
            dtbl.Columns.Add("PAYMENT_MEMBER", typeof(string));
            dtbl.Columns.Add("MEMBER_NAME", typeof(string));
            dtbl.Columns.Add("DUE_DATE", typeof(string));
            dtbl.Columns.Add("PAYMENT_DETAILS", typeof(string));
            dtbl.Columns.Add("PAYMENT_AMOUNT", typeof(string));
            dtbl.Columns.Add("PANELTY", typeof(string));
            dtbl.Columns.Add("LOAN_ID", typeof(string));
            dtbl.Columns.Add("TOTAL", typeof(string));
            dgvPayment.DataSource = dtbl;
            SetDataGridProperties();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add(new DataColumn("MEMBER_ID"));
            dtbl.Columns.Add(new DataColumn("MEMBER_NAME"));
            dtbl.Columns.Add(new DataColumn("VILLAGE_NAME"));
            DataRow dtRow = dtbl.NewRow();
            dtRow["MEMBER_ID"] = "";
            dtRow["MEMBER_NAME"] = "";
            dtRow["VILLAGE_NAME"] = "";
            dtbl.Rows.Add(dtRow);
            MemberList cust = new MemberList();
            cust.dtRow = dtRow;
            cust.ShowDialog();
            if (dtRow["MEMBER_ID"].ToString() != "")
            {
                txtNumber.Text = dtRow["MEMBER_ID"].ToString();
                txtName.Text = dtRow["MEMBER_NAME"].ToString();
                txtVillage.Text = dtRow["VILLAGE_NAME"].ToString();
                LoadPendingPayments();
            }
            else
            {
                txtNumber.Text = string.Empty;
                txtName.Text = string.Empty;
                txtVillage.Text = string.Empty;
            }
        }

        private void LoadPendingPayments()
        {
            try
            {
                Payment _obj = new Payment();
                DataSet dstPayment = _obj.GetPendingPayments(Convert.ToInt32(txtNumber.Text.Trim()),(strFormName.Equals("MONTHLY AND LOAN EMI PAYMENT") ? 0 : 1));
                dstPayment.Tables[0].Columns.Add("TOTAL", typeof(string));
                decimal dcmlTotal = 0;
                foreach (DataRow row in dstPayment.Tables[0].Rows)
                {
                    dcmlTotal += Convert.ToDecimal(row["PAYMENT_AMOUNT"].ToString()) + Convert.ToDecimal(row["PANELTY"].ToString());
                    row["TOTAL"] = (Convert.ToDecimal(row["PAYMENT_AMOUNT"].ToString()) + Convert.ToDecimal(row["PANELTY"].ToString())).ToString();
                }

                dgvPayment.DataSource = dstPayment.Tables[0];
                SetDataGridProperties();
                lblAmount.Text = dcmlTotal.ToString() + "/-";
                btnSearch.Enabled = false;
                lblAmountLabel.Visible = true;
                lblAmount.Visible = true;
                btnClear.Enabled = true;
                if (dgvPayment.Rows.Count > 0)
                {
                    btnSave.Enabled = true;
                    lblPayment.Visible = true;
                    dtpPayment.Visible = true;
                }
                else
                {
                    MessageBox.Show("No amount due for selected member", "No amount due", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogError.LogEvent("Get Pending Payments", ex.Message, "Get Pending Payments");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtNumber.Text = string.Empty;
            txtVillage.Text = string.Empty;
            LoadBlankList();
            btnSearch.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            lblAmount.Visible = false;
            lblAmountLabel.Visible = false;
            lblPayment.Visible = false;
            dtpPayment.Visible = false;
            intTotalRow = 0;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MonthlyPayment_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
