using BajrangTextBox;
using MandalLibrary;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PrivateMandal
{
    public partial class NewLoan : Form
    {
        public int intAppId = 0;
        public NewLoan()
        {
            InitializeComponent();
        }

        #region Page Load Event
        private void NewLoanApplication_Load(object sender, EventArgs e)
        {
            Header header = new Header("ADD NEW LOAN");
            this.Controls.Add(header);
            header.Left = 0;
            header.Top = 0;
            header.Width = this.Width;
            GetMandalAmount();
            GetLoanApplicationList();
            LoadEMINumber();
        }
        #endregion

        #region Private Events

        private void txtEvidenceNumber_Enter(object sender, EventArgs e)
        {
            if (!txtNumber.Text.Trim().Equals(""))
            {
                SelectMember(txtEvidenceNumber, txtEvidenceName);
            }
        }

        private void txtEvidenceNumber2_Enter(object sender, EventArgs e)
        {
            if (!txtNumber.Text.Trim().Equals(""))
            {
                SelectMember(txtEvidenceNumber2, txtEvidenceName2);
            }
        }

        private void dgvLoanList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strMemberId = dgvLoanList.Rows[dgvLoanList.CurrentCell.RowIndex].Cells["MEMBER_ID"].Value.ToString();
            string strMemberName = dgvLoanList.Rows[dgvLoanList.CurrentCell.RowIndex].Cells["MEMBER_NAME"].Value.ToString();
            string strVillageName = dgvLoanList.Rows[dgvLoanList.CurrentCell.RowIndex].Cells["MEMBER_VILLAGE"].Value.ToString();
            intAppId = Convert.ToInt32(dgvLoanList.Rows[dgvLoanList.CurrentCell.RowIndex].Cells["APP_ID"].Value.ToString());

            txtNumber.Text = strMemberId;
            txtName.Text = strMemberName;
            txtVillage.Text = strVillageName;
            btnSave.Enabled = true;
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (txtAmount.Text.Trim().Equals(""))
            {
                txtAmount.Text = "0";
            }
            else if (Convert.ToDecimal(txtAmount.Text.Trim()) > Convert.ToDecimal(txtBalance.Text.Trim()))
            {
                txtAmount.Text = "0";
                MessageBox.Show("Can not give loan more than current balance", "Cannot exceed current balance", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            CalculateInterest();
        }

        private void cmbEmi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmi.Text != "")
            {
                CalculateInterest();
            }
            else
            {
                txtEMIAmount.Text = string.Empty;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvLoanList.ClearSelection();
            txtNumber.Text = string.Empty;
            txtName.Text = string.Empty;
            txtVillage.Text = string.Empty;
            dtpLoanDate.Value = DateTime.Today;
            txtAmount.Text = string.Empty;
            cmbEmi.SelectedIndex = -1;
            txtEMIAmount.Text = string.Empty;
            txtInterest.Text = string.Empty;
            txtEvidenceName.Text = string.Empty;
            txtEvidenceName2.Text = string.Empty;
            txtEvidenceNumber.Text = string.Empty;
            txtEvidenceNumber2.Text = string.Empty;
            btnSave.Enabled = false;
            intAppId = 0;
            GetMandalAmount();
            GetLoanApplicationList();
            dgvLoanList.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text.Trim().Equals(""))
            {
                MessageBox.Show("Select application from application list", "Select application", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dgvLoanList.Focus();
            }
            else if (txtAmount.Text.Trim().Equals("") || txtAmount.Text.Trim().Equals("0"))
            {
                MessageBox.Show("Enter loan amount", "Enter loan amount", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtAmount.Focus();
            }
            else if (cmbEmi.SelectedIndex == -1)
            {
                MessageBox.Show("Select number of loan EMI count", "Loan EMI count", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbEmi.Focus();
            }
            else if (txtEvidenceNumber.Text.Trim().Equals("") || txtEvidenceNumber2.Text.Trim().Equals(""))
            {
                MessageBox.Show("Select both guarantor", "Select both guarantor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (!txtEvidenceNumber.Text.Trim().Equals("") && !txtEvidenceNumber2.Text.Trim().Equals("") && txtEvidenceNumber.Text.Trim().Equals(txtEvidenceNumber2.Text.Trim()))
            {
                MessageBox.Show("Both guarantor should be different", "Both Guarantor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                try
                {
                    Loan _obj = new Loan();
                    if (_obj.CheckLoanRunning(Convert.ToInt32(txtNumber.Text.Trim())))
                    {
                        MessageBox.Show("Old loan is still running for member", "Old loan is still running", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        string strXML = CreateInsertXML();
                        bool blnSuccess = false;
                        string strPaymentId = string.Empty;
                        int loanId = 0;
                        blnSuccess = _obj.AddNewLoan(strXML, Convert.ToInt32(cmbEmi.Text.Trim()) + 4, out loanId, out strPaymentId);
                        if (blnSuccess)
                        {
                            MessageBox.Show("New loan added successfully!", "New loan added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoanApplicationForm loanApplication = new LoanApplicationForm(loanId);
                            loanApplication.ShowDialog();
                            PaymentReceipt receipt = new PaymentReceipt(strPaymentId);
                            receipt.ShowDialog();
                            btnClear_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Transaction failed. Try again later", "Transaction failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed. Try again later", "Transaction failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LogError.LogEvent("", ex.Message, "Add New Loan");
                }
            }
        }

        #endregion

        #region Private Methods

        private void LoadEMINumber()
        {
            try
            {
                string strUrl = string.Empty;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "\\Configuration.xml");
                //xmlDoc.Load(@"D:\Rakesh\Mandal\PrivateMandal\Configuration.xml");
                XmlNode xmlNode = xmlDoc.SelectSingleNode("CONFIG");
                string strEMICount = xmlNode.Attributes["EMI_COUNT"].Value;
                string[] EMI = strEMICount.Split(',');
                foreach (var emi in EMI)
                {
                    cmbEmi.Items.Add(emi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SelectMember(BajrangTextbox numberBox, BajrangTextbox nameBox)
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
                if (dtRow["MEMBER_ID"].ToString() == txtNumber.Text.Trim())
                {
                    MessageBox.Show("Member can not be self guarantor", "Self Guarantor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    numberBox.Text = dtRow["MEMBER_ID"].ToString();
                    nameBox.Text = dtRow["MEMBER_NAME"].ToString();
                }

            }
            else
            {
                numberBox.Text = string.Empty;
                nameBox.Text = string.Empty;
            }
        }

        private void GetMandalAmount()
        {
            Common _obj = new Common();
            decimal dcmlBalance = 0;

            dcmlBalance = _obj.GetMandalBalance(DateTime.Today.Month, DateTime.Today.Year);
            txtBalance.Text = dcmlBalance.ToString();
        }

        private void GetLoanApplicationList()
        {
            Loan _obj = new Loan();
            DataSet dstLoanList = new DataSet();
            dgvLoanList.DataSource = null;

            dstLoanList = _obj.GetLoanApplicationList(DateTime.Today.Month, DateTime.Today.Year, "YES");

            dgvLoanList.DataSource = dstLoanList.Tables[0];
            if (dgvLoanList.Rows.Count > 0)
            {
                dgvLoanList.Visible = true;
                dgvLoanList.Columns["MEMBER_NAME"].HeaderText = "Member Name";
                dgvLoanList.Columns["MEMBER_NAME"].Width = 338;
                dgvLoanList.Columns["MEMBER_VILLAGE"].Visible = false;
                dgvLoanList.Columns["MEMBER_ID"].Visible = false;
                dgvLoanList.Columns["APP_ID"].Visible = false;
                System.Drawing.Font font = new System.Drawing.Font("Segoe UI Semibold", 11);
                dgvLoanList.ColumnHeadersDefaultCellStyle.Font = font;
            }
            else
            {
                dgvLoanList.Visible = false;
                MessageBox.Show("No pending loan application for current month", "No loan application", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void CalculateInterest()
        {
            if (txtAmount.Text.Trim().Equals("0") || cmbEmi.SelectedIndex == -1)
            {
                txtInterest.Text = string.Empty;
                txtEMIAmount.Text = string.Empty;
            }
            else
            {
                decimal dcmlAmount = Convert.ToDecimal(txtAmount.Text.Trim());
                decimal dcmlRateOfInterest = MandalDetails.RateOfInterest;
                decimal intMonth = Convert.ToDecimal(cmbEmi.Text.Trim());

                txtEMIAmount.Text = Math.Round(dcmlAmount / intMonth, 0).ToString();

                decimal dcmlInterest = decimal.Round((dcmlAmount * intMonth * dcmlRateOfInterest) / 100, 0);
                txtInterest.Text = dcmlInterest.ToString();
            }

        }

        private string CreateInsertXML()
        {
            StringBuilder strXML = new StringBuilder("");
            strXML.Append("<ROOT><LOAN_DETAIL ");
            strXML.Append("APP_ID='" + intAppId.ToString() + "' ");
            strXML.Append("MEMBER_ID='" + txtNumber.Text.Trim() + "' ");
            strXML.Append("START_DATE='" + dtpLoanDate.Text + "' ");
            strXML.Append("LOAN_AMOUNT='" + txtAmount.Text.Trim() + "' ");
            strXML.Append("EMI_COUNT='" + cmbEmi.Text.Trim() + "' ");
            strXML.Append("LOAN_INTEREST='" + txtInterest.Text.Trim() + "' ");
            strXML.Append("EMI_AMOUNT='" + txtEMIAmount.Text.Trim() + "' ");
            strXML.Append("EVIDENCE1='" + txtEvidenceNumber.Text.Trim() + "' ");
            strXML.Append("EVIDENCE2='" + txtEvidenceNumber2.Text.Trim() + "' ");
            strXML.Append("CRT_UID='" + UserDetaills.UserId + "' ");
            strXML.Append("/></ROOT>");
            return strXML.ToString();
        }

        #endregion

        private void NewLoan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
