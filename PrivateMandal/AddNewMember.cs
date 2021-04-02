using BajrangTextBox;
using MandalLibrary;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PrivateMandal
{
    public partial class AddNewMember : Form
    {
        AutoCompleteStringCollection villageCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection talukaCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection distCollection = new AutoCompleteStringCollection();
        string strPhotoName = "";
        public AddNewMember()
        {
            InitializeComponent();
        }

        #region Page Load Event
        private void AddNewMember_Load(object sender, EventArgs e)
        {
            Header header = new Header("ADD NEW MEMBER");
            this.Controls.Add(header);
            header.Left = 0;
            header.Top = 0;
            header.Width = this.Width;
            dtpJoiningDate.MaxDate = DateTime.Today;
            dtpDOB.MaxDate = DateTime.Today;
            txtAmount.Text = "0";
            txtAmountPaid.Text = "0";
            txtPending.Text = "0";
            VisibleInvisibleInterestComponent(false);
            LoadAutoSuggestData("VLG");
            LoadAutoSuggestData("TLK");
            LoadAutoSuggestData("DST");
            txtVillageName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVillageName.AutoCompleteCustomSource = villageCollection;
            txtTaluka.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTaluka.AutoCompleteCustomSource = talukaCollection;
            txtDistrict.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDistrict.AutoCompleteCustomSource = distCollection;
            LoadEMINumber();
        }
        #endregion

        #region Private Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool blnValid = false;
            bool blnSuccess = false;
            int intMemberNum = 0;
            int intLoanId = 0;
            blnValid = ValidateInputs();

            if (blnValid)
            {
                string strXML = CreateInsertXML();
                try
                {
                    Member _obj = new Member();
                    string strPaymentId = string.Empty;
                    byte[] bytes = null;
                    if (!strPhotoName.Equals(string.Empty))
                    {
                        bytes = File.ReadAllBytes(fdPhoto.FileName);
                    }

                    blnSuccess = _obj.AddNewMember(strXML, out intMemberNum, bytes, out intLoanId,out strPaymentId);
                    if (blnSuccess)
                    {
                        ShowMesage("New member added successfully", "New member added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MembershipForm _form = new MembershipForm(intMemberNum);
                        _form.ShowDialog();
                        if (intLoanId != 0)
                        {
                            LoanApplicationForm applicationForm = new LoanApplicationForm(intLoanId);
                            applicationForm.ShowDialog();
                        }
                        PaymentReceipt receipt = new PaymentReceipt(strPaymentId);
                        receipt.ShowDialog();
                        ClearAllControls();
                    }
                    else
                    {
                        MessageBox.Show("Transaction failed. Try again later", "Transaction failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed. Try again later", "Transaction failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LogError.LogEvent("Create New Member", ex.Message, "Save Button Click Event");
                }
            }
        }

        private void picNo_Click(object sender, EventArgs e)
        {
            picNo.Visible = false;
            picYes.Visible = true;
            dtpDOB.Enabled = true;
        }

        private void picYes_Click(object sender, EventArgs e)
        {
            picNo.Visible = true;
            picYes.Visible = false;
            dtpDOB.Enabled = false;
        }

        private void cmbEmi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmi.SelectedIndex != -1)
            {
                decimal dcmlMonth = Convert.ToDecimal(cmbEmi.Text.Trim());
                txtEMIAmount.Text = Math.Round(Convert.ToDecimal(txtPending.Text) / dcmlMonth, 0).ToString();
                VisibleInvisibleInterestComponent(true);
                decimal dcmlInterest = decimal.Round((Convert.ToDecimal(txtPending.Text.Trim()) * Convert.ToDecimal(cmbEmi.Text) * MandalDetails.RateOfInterest) / 100, 0);
                txtInterest.Text = dcmlInterest.ToString();
            }
            else
            {
                VisibleInvisibleInterestComponent(false);
                txtEMIAmount.Text = string.Empty;
                txtInterest.Text = string.Empty;
                txtEvidenceName.Text = string.Empty;
                txtEvidenceName2.Text = string.Empty;
                txtEvidenceNumber.Text = string.Empty;
                txtEvidenceNumber2.Text = string.Empty;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllControls();
        }

        private void txtReferenceNumber_Enter(object sender, EventArgs e)
        {
            SelectMember(txtReferenceNumber, txtReferenceName);
        }

        private void txtEvidenceNumber_Enter(object sender, EventArgs e)
        {
            SelectMember(txtEvidenceNumber, txtEvidenceName);
        }

        private void txtEvidenceNumber2_Enter(object sender, EventArgs e)
        {
            SelectMember(txtEvidenceNumber2, txtEvidenceName2);
        }
        #endregion

        #region Private Methods

        private void LoadAutoSuggestData(string p)
        {
            try
            {
                Member _obj = new Member();
                DataSet dstAuto = _obj.GetAutoSuggestData(p);
                if (dstAuto.Tables.Count > 0)
                {
                    if (dstAuto.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dstAuto.Tables[0].Rows)
                        {
                            if (p.Equals("VLG"))
                                villageCollection.Add(dr[0].ToString());
                            else if (p.Equals("TLK"))
                                talukaCollection.Add(dr[0].ToString());
                            else
                                distCollection.Add(dr[0].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidateInputs()
        {
            if (txtMemberName.Text.Trim().Equals(""))
            {
                ShowMesage("Enter member name", "Member Name", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtMemberName.Focus();
                return false;
            }
            else if (txtAddress.Text.Trim().Equals(""))
            {
                ShowMesage("Enter current address", "Current address", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtAddress.Focus();
                return false;
            }
            else if (txtVillageName.Text.Trim().Equals(""))
            {
                ShowMesage("Enter village name", "Village name", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtVillageName.Focus();
                return false;
            }
            else if (txtTaluka.Text.Trim().Equals(""))
            {
                ShowMesage("Enter taluka name", "Taluka name", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtTaluka.Focus();
                return false;
            }
            else if (txtDistrict.Text.Trim().Equals(""))
            {
                ShowMesage("Enter district name", "District name", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtDistrict.Focus();
                return false;
            }
            else if (txtMobileNumber.Text.Trim().Equals(""))
            {
                ShowMesage("Enter mobile number", "Mobile number", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtMobileNumber.Focus();
                return false;
            }
            else if (cmbGender.SelectedIndex == -1)
            {
                ShowMesage("Select gender", "Member gender", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbGender.Focus();
                return false;
            }
            else if (txtEducation.Text.Trim().Equals(""))
            {
                ShowMesage("Enter education", "Member education", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtEducation.Focus();
                return false;
            }
            else if(txtAmount.Text.Trim().Equals("") || txtAmount.Text.Trim().Equals(""))
            {
                ShowMesage("Enter payable amount", "Payable Amount", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtAmount.Focus();
                return false;
            }
            else if (Convert.ToDecimal(txtPending.Text.Trim()) > 0)
            {
                if (cmbEmi.SelectedIndex == -1)
                {
                    MessageBox.Show("Select number of loan EMI count", "Loan EMI count", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    cmbEmi.Focus();
                    return false;
                }
                else if (txtEvidenceNumber.Text.Trim() == "" || txtEvidenceNumber2.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Select both guarantor", "Select both guarantor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtEvidenceNumber.Focus();
                    return false;
                }
                else if (!txtEvidenceNumber.Text.Trim().Equals("") && !txtEvidenceNumber2.Text.Trim().Equals("") && txtEvidenceNumber.Text.Trim().Equals(txtEvidenceNumber2.Text.Trim()))
                {
                    MessageBox.Show("Both guarantor should be different", "Both Guarantor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtEvidenceNumber2.Focus();
                    return false;
                }
            }
            return true;
        }

        private void ShowMesage(string strMessage, string strCaption, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            MessageBox.Show(strMessage, strCaption, messageBoxButtons, messageBoxIcon);
        }

        private void VisibleInvisibleInterestComponent(bool v)
        {
            lblEvidence2.Visible = v;
            txtEvidenceName2.Visible = v;
            txtEvidenceNumber2.Visible = v;
            lblEvidence.Visible = v;
            txtEvidenceName.Visible = v;
            txtEvidenceNumber.Visible = v;
            lblInterest.Visible = v;
            txtInterest.Visible = v;
            lblEMIAmount.Visible = v;
            txtEMIAmount.Visible = v;
            
            
            if (!v)
            {
                txtInterest.Text = string.Empty;
                txtEMIAmount.Text = string.Empty;
                txtEvidenceName.Text = string.Empty;
                txtEvidenceName2.Text = string.Empty;
                txtEvidenceNumber.Text = string.Empty;
                txtEvidenceNumber2.Text = string.Empty;
            }
        }

        private void ClearAllControls()
        {
            txtMemberName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtVillageName.Text = string.Empty;
            txtTaluka.Text = string.Empty;
            txtDistrict.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            dtpJoiningDate.Value = DateTime.Today;
            cmbGender.SelectedIndex = -1;
            txtReferenceName.Text = string.Empty;
            txtReferenceNumber.Text = string.Empty;
            txtEvidenceName.Text = string.Empty;
            txtEvidenceNumber.Text = string.Empty;
            txtEvidenceName2.Text = string.Empty;
            txtEvidenceNumber2.Text = string.Empty;
            dtpDOB.Value = DateTime.Today;
            picNo.Visible = true;
            picYes.Visible = false;
            dtpDOB.Enabled = false;
            txtAmountPaid.Text = "0";
            cmbEmi.SelectedIndex = -1;
            txtEducation.Text = string.Empty;
            strPhotoName = string.Empty;
            pbPhoto.BackgroundImage = null;
            txtAmount.Text = "0";
            txtPending.Text = "0";
            cmbEmi.Visible = false;
            lblEMICount.Visible = false;
            loanNo.Visible = true;
            loanYes.Visible = false;
            VisibleInvisibleInterestComponent(false);
            txtMemberName.Focus();
        }

        private string CreateInsertXML()
        {
            StringBuilder strXML = new StringBuilder("");
            strXML.Append("<ROOT><MEMBER ");
            strXML.Append("MEMBER_NAME='" + txtMemberName.Text.Trim() + "' ");
            strXML.Append("CUR_ADDRESS='" + txtAddress.Text.Trim() + "' ");
            strXML.Append("PER_VILLAGE='" + txtVillageName.Text.Trim() + "' ");
            strXML.Append("PER_TALUKO='" + txtTaluka.Text.Trim() + "' ");
            strXML.Append("PER_DISTRICT='" + txtDistrict.Text.Trim() + "' ");
            strXML.Append("MEMBER_MOBILE='" + txtMobileNumber.Text.Trim() + "' ");
            strXML.Append("MEMBER_DOJ='" + dtpJoiningDate.Text.Trim() + "' ");
            strXML.Append("GENDER='" + cmbGender.Text + "' ");
            strXML.Append("MEMBER_DOB='" + (dtpDOB.Enabled ? dtpDOB.Text.Trim() : "") + "' ");
            strXML.Append("EDUCATION='" + txtEducation.Text.Trim() + "' ");
            strXML.Append("REFERENCE='" + txtReferenceNumber.Text.Trim() + "' ");
            strXML.Append("MEMBERSHIP_PAID='" + txtAmountPaid.Text.Trim() + "' ");
            strXML.Append("LOAN_AMOUNT='" + txtPending.Text.Trim() + "' ");
            strXML.Append("EMI_COUNT='" + (cmbEmi.Visible ? cmbEmi.Text.Trim() : "0") + "' ");
            strXML.Append("EMI_AMOUNT='" + (cmbEmi.Visible ? txtEMIAmount.Text.Trim() : "0") + "' ");
            strXML.Append("LOAN_INTEREST_PAID='" + (cmbEmi.Visible ? txtInterest.Text.Trim() : "0") + "' ");
            strXML.Append("EVIDENCE1='" + txtEvidenceNumber.Text.Trim() + "' ");
            strXML.Append("EVIDENCE2='" + txtEvidenceNumber2.Text.Trim() + "' ");
            strXML.Append("CRT_UID='" + UserDetaills.UserId + "' ");
            strXML.Append("/></ROOT>");
            return strXML.ToString();
        }

        private void SelectMember(BajrangTextbox numberBox, BajrangTextbox nameNox)
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
                numberBox.Text = dtRow["MEMBER_ID"].ToString();
                nameNox.Text = dtRow["MEMBER_NAME"].ToString();
            }
            else
            {
                numberBox.Text = string.Empty;
                nameNox.Text = string.Empty;
            }
        }

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
                foreach(var emi in EMI)
                {
                    cmbEmi.Items.Add(emi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        OpenFileDialog fdPhoto = new OpenFileDialog();
        private void btnPhoto_Click(object sender, EventArgs e)
        {
            fdPhoto.Filter = "image files|*.png;";
            DialogResult dres1 = fdPhoto.ShowDialog();
            if (dres1 == DialogResult.Abort)
            {
                return;
            }

            if (dres1 == DialogResult.Cancel)
            {
                return;
            }

            Image img = System.Drawing.Image.FromFile(fdPhoto.FileName);
            strPhotoName = fdPhoto.FileName;
            pbPhoto.BackgroundImage = new Bitmap(fdPhoto.FileName);
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (txtAmount.Text.Trim().Equals("") || txtAmount.Text.Trim().Equals("0"))
            {
                ShowMesage("Enter payable amount", "Payable amount", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtAmount.Focus();
            }
            else
            {
                if (loanNo.Visible)
                {
                    txtAmountPaid.Text = txtAmount.Text.Trim();
                    txtPending.Text = "0";
                }
                else
                {
                    txtAmountPaid.Text = "0";
                    txtPending.Text = txtAmount.Text.Trim();
                }
            }
        }

        private void loanNo_Click(object sender, EventArgs e)
        {
            loanYes.Visible = true;
            loanNo.Visible = false;
            txtAmountPaid.Text = "0";
            txtPending.Text = txtAmount.Text.Trim();
            VisibleInvisibleInterestComponent(false);
            cmbEmi.SelectedIndex = -1;
            cmbEmi.Visible = true;
            lblEMICount.Visible = true;
        }

        private void loanYes_Click(object sender, EventArgs e)
        {
            loanYes.Visible = false;
            loanNo.Visible = true;
            txtAmountPaid.Text = txtAmount.Text.Trim();
            txtPending.Text = "0";
            VisibleInvisibleInterestComponent(false);
            cmbEmi.SelectedIndex = -1;
            cmbEmi.Visible = false;
            lblEMICount.Visible = false;
        }

        private void AddNewMember_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        
    }
}
