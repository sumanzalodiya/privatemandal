using System;
using System.Windows.Forms;
using MandalLibrary;

namespace PrivateMandal
{
    public partial class ChangePwd : Form
    {
        public ChangePwd()
        {
            InitializeComponent();
        }

        private void ChangePwd_Load(object sender, EventArgs e)
        {
            txtUserId.Text = LoginDetails.userID;
            txtUserName.Text = LoginDetails.userName;
            txtOldPwd.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strXML = string.Empty;
            if (txtUserName.Text.Trim().Equals("")) { MessageBox.Show("Please Enter User Name", "Enter User Name"); }
            else if (txtUserId.Text.Trim().Equals("")) { MessageBox.Show("Please Enter User ID", "Enter User ID"); }
            else if (txtOldPwd.Text.Trim().Equals("")) { MessageBox.Show("Please Enter Old Password", "Enter Old Password"); }
            else if (txtNewPwd.Text.Trim().Equals("")) { MessageBox.Show("Please Enter Password", "Enter Password"); }
            else if (txtReNewPwd.Text.Trim().Equals("")) { MessageBox.Show("Please Enter Re-Password", "Enter Re-Password"); }
            else if (!txtNewPwd.Text.Trim().Equals(txtReNewPwd.Text.Trim())) { MessageBox.Show("Both Password Doesn't Match", "Password Doesn't Match"); }
            else
            {
                strXML = CreateInsertXML();
                InsertNewUser(strXML);
            }
        }

        private string CreateInsertXML()
        {
            string strXML = string.Empty;
            strXML += "<ROOT><USER_DETAIL ";
            strXML += "USER_ID='" + txtUserId.Text.Trim() + "' ";
            strXML += "OLD_PASSWORD='" + CryptoEngine.Encrypt(txtOldPwd.Text.Trim(), true) + "' ";
            strXML += "PASSWORD='" + CryptoEngine.Encrypt(txtNewPwd.Text.Trim(), true) + "' ";
            strXML += "CRT_UID='" + LoginDetails.userID + "' ";
            strXML += " /></ROOT>";
            return strXML;
        }

        private void InsertNewUser(string strXML)
        {
            int intNoOfRows = 0;
            try
            {
                Member _obj = new Member();
                intNoOfRows = _obj.ChangeUserPassword(strXML);
                if (intNoOfRows == 2)
                {
                    MessageBox.Show("Password Has Been Changed Successfully", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (intNoOfRows == 1)
                {
                    MessageBox.Show("Ivalid Old Password", "Invalid Old Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error in Transaction", "Error in Transaction");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
