using MandalLibrary;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PrivateMandal
{
    public partial class UpdateMember : Form
    {
        private readonly int intMemberId;
        string strPhotoName = "";
        public UpdateMember(int intMemberId)
        {
            InitializeComponent();
            this.intMemberId = intMemberId;
        }

        #region Page Load Event
        private void UpdateMember_Load(object sender, EventArgs e)
        {
            DataSet dstDetails = new DataSet();
            Member _obj = new Member();
            dstDetails = _obj.GetMemberDetails(intMemberId);

            dstDetails.Tables[0].TableName = "MEMBER_FORM";
            if(dstDetails.Tables[0].Rows.Count>0)
            {
                DataRow dtRow = dstDetails.Tables[0].Rows[0];
                txtMemberName.Text = dtRow["MEMBER_NAME"].ToString();
                txtAddress.Text = dtRow["MEMBER_ADDRESS"].ToString();
                txtVillageName.Text = dtRow["MEMBER_VILLAGE"].ToString();
                txtTaluka.Text = dtRow["MEMBER_TALUKA"].ToString();
                txtDistrict.Text = dtRow["MEMBER_DISTRICT"].ToString();
                txtMobileNumber.Text = dtRow["MEMBER_MOBILE"].ToString();
                txtEducation.Text = dtRow["MEMBER_EDUCATION"].ToString();
                txtReferenceNumber.Text = dtRow["MEMBER_REFERENCE_NO"].ToString() == "0" ? "" : dtRow["MEMBER_REFERENCE_NO"].ToString();
                txtReferenceName.Text = dtRow["MEMBER_REFERENCE"].ToString() == "-" ? "" : dtRow["MEMBER_REFERENCE"].ToString();
                cmbGender.Text= dtRow["MEMBER_GENDER"].ToString();
                dtpJoiningDate.Text = dtRow["MEMBER_DOJ"].ToString();
                string strDOB = dtRow["MEMBER_DOB"].ToString();
                if(strDOB=="-")
                {
                    dtpDOB.Enabled = false;
                    picNo.Visible = true;
                    picYes.Visible = false;
                }
                else
                {
                    dtpDOB.Enabled = true;
                    dtpDOB.Text = strDOB;
                    picNo.Visible = false;
                    picYes.Visible = true;
                }

                if(dtRow["MEMBER_PHOTO"]!=DBNull.Value)
                {
                    MemoryStream ms = new MemoryStream((byte[])dtRow["MEMBER_PHOTO"]);
                    pbPhoto.BackgroundImage = new Bitmap(ms);
                }
                
            }
        }
        #endregion

        #region Private Events
        private void UpdateMember_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtReferenceNumber_Enter(object sender, EventArgs e)
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
                txtReferenceNumber.Text = dtRow["MEMBER_ID"].ToString();
                txtReferenceName.Text = dtRow["MEMBER_NAME"].ToString();
            }
            else
            {
                txtReferenceNumber.Text = string.Empty;
                txtReferenceName.Text = string.Empty;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool blnValid = false;
            bool blnSuccess = false;
            blnValid = ValidateInputs();

            if (blnValid)
            {
                string strXML = CreateInsertXML();
                try
                {
                    Member _obj = new Member();

                    byte[] bytes = null;
                    if (!strPhotoName.Equals(string.Empty))
                    {
                        bytes = File.ReadAllBytes(fdPhoto.FileName);
                    }

                    blnSuccess = _obj.UpdateMemberDetails(strXML, bytes);
                    if (blnSuccess)
                    {
                        ShowMesage("Member details upudated successfully", "Member details updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Transaction failed. Try again later", "Transaction failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed. Try again later", "Transaction failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LogError.LogEvent("Update Member Details", ex.Message, "Save Button Click Event");
                }
            }
        }

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
        #endregion

        #region Private Methods
        private string CreateInsertXML()
        {
            StringBuilder strXML = new StringBuilder("");
            strXML.Append("<ROOT><MEMBER ");
            strXML.Append("MEMBER_ID='" + intMemberId.ToString() + "' ");
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
            strXML.Append("CRT_UID='" + UserDetaills.UserId + "' ");
            strXML.Append("/></ROOT>");
            return strXML.ToString();
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
            else if(intMemberId.ToString() == txtReferenceNumber.Text.Trim())
            {
                ShowMesage("Member can not be self reference", "Self reference", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtReferenceNumber.Focus();
                return false;
            }
            return true;
        }

        private void ShowMesage(string strMessage, string strCaption, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            MessageBox.Show(strMessage, strCaption, messageBoxButtons, messageBoxIcon);
        }
        #endregion
    }
}
