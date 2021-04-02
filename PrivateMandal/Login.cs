using MandalLibrary;
using System;
using System.Data;
using System.Windows.Forms;

namespace PrivateMandal
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            Home _obj = new Home();
            _obj.Show();
            this.Hide();
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                Application.Exit();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                DoLogin();
            }
        }

        private void DoLogin()
        {
            if (txtUserName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please Enter User Name", "User Name", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtUserName.Focus();
            }
            else if (txtPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please Enter Password", "Password", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtPassword.Focus();
            }
            else
            {
                try
                {
                    Member _obj = new Member();
                    DataSet dstLogin = _obj.ValidateUser(txtUserName.Text.Trim(), CryptoEngine.Encrypt(txtPassword.Text.Trim(), true));
                    if (dstLogin.Tables.Count > 0)
                    {
                        if (dstLogin.Tables[0].Rows.Count > 0)
                        {
                            LoginDetails.userID = dstLogin.Tables[0].Rows[0]["USER_ID"].ToString();
                            LoginDetails.userName = dstLogin.Tables[0].Rows[0]["USER_NAME"].ToString();
                            Home _objHome = new Home();
                            _objHome.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid User Name or Password", "Invalid User Name or Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Invalid User Name or Password", "Invalid User Name or Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
