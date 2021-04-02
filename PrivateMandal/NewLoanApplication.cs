using BajrangTextBox;
using System;
using System.Data;
using System.Windows.Forms;
using MandalLibrary;
using System.Text;
using System.Threading.Tasks;

namespace PrivateMandal
{
    public partial class NewLoanApplication : Form
    {
        public NewLoanApplication()
        {
            InitializeComponent();
        }

        #region Page Load Event
        private void NewLoanApplication_Load(object sender, EventArgs e)
        {
            Header header = new Header("NEW LOAN APPLICATION");
            this.Controls.Add(header);
            header.Left = 0;
            header.Top = 0;
            header.Width = this.Width;
            cmbYear.Items.Add(DateTime.Today.Year.ToString());
            cmbYear.Items.Add(DateTime.Today.AddYears(1).Year.ToString());
            cmbYear.SelectedIndex = 0;
            cmbMonth.SelectedIndex = DateTime.Today.Month - 1;
            //GetMandalAmount();
            //GetLoanApplicationList();
        }
        #endregion

        #region Private Events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SelectMember(txtNumber, txtName, txtVillage);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text.Trim().Equals(""))
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                try
                {
                    bool blnSuccess = false;
                    Loan _obj = new Loan();
                    string strXML = CreateNewXML();
                    blnSuccess = _obj.AddNewLoanApplication(strXML);
                    if (blnSuccess)
                    {
                        MessageBox.Show("New loan application added successfully!", "New loan application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClear_Click(sender, e);
                        GetLoanApplicationList();
                    }
                    else
                    {
                        MessageBox.Show("Transaction failed. Try again later","Transaction failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed. Try again later", "Transaction failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LogError.LogEvent("", ex.Message, "AddNewLoanApplication");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNumber.Text = string.Empty;
            txtName.Text = string.Empty;
            txtVillage.Text = string.Empty;
            dtpApplicationDate.Value = DateTime.Today;
            cmbYear.SelectedIndex = 0;
            cmbMonth.SelectedIndex = DateTime.Today.Month - 1;
            chkEmergency.Checked = false;
            btnSave.Enabled = false;
            btnSearch.Focus();
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMandalAmount();
            GetLoanApplicationList();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMandalAmount();
            GetLoanApplicationList();
        }
        #endregion

        #region Private Methods
        private void SelectMember(BajrangTextbox numberBox, BajrangTextbox nameBox, BajrangTextbox villageBox)
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
                nameBox.Text = dtRow["MEMBER_NAME"].ToString();
                if (villageBox != null)
                {
                    villageBox.Text = dtRow["VILLAGE_NAME"].ToString();
                }
                btnSave.Enabled = true;
            }
            else
            {
                numberBox.Text = string.Empty;
                nameBox.Text = string.Empty;
                if (villageBox != null)
                {
                    villageBox.Text = string.Empty;
                }
            }
        }

        private string CreateNewXML()
        {
            StringBuilder strXML = new StringBuilder("");
            strXML.Append("<ROOT><LOAN ");
            strXML.Append("APP_MEMBER_ID='" + txtNumber.Text.Trim() + "' ");
            strXML.Append("APP_DATE='" + dtpApplicationDate.Text + "' ");
            strXML.Append("APP_MONTH='" + (cmbMonth.SelectedIndex + 1).ToString() + "' ");
            strXML.Append("APP_YEAR='" + cmbYear.Text.Trim() + "' ");
            strXML.Append("APP_EMERGENCY='" + (chkEmergency.Checked ? "1" : "0") + "' ");
            strXML.Append("/></ROOT>");
            return strXML.ToString();
        }

        private void GetMandalAmount()
        {
            Common _obj = new Common();
            decimal dcmlBalance = 0;
            try
            {
                dcmlBalance = _obj.GetMandalBalance(cmbMonth.SelectedIndex+1,Convert.ToInt32(cmbYear.Text.Trim()));
            }
            catch
            {
                dcmlBalance = _obj.GetMandalBalance(DateTime.Today.Month, DateTime.Today.Year);
            }
            txtBalance.Text = dcmlBalance.ToString();
        }

        private void GetLoanApplicationList()
        {
            Loan _obj = new Loan();
            DataSet dstLoanList = new DataSet();
            dgvLoanList.DataSource = null;
            try
            {
                dstLoanList = _obj.GetLoanApplicationList(cmbMonth.SelectedIndex + 1, Convert.ToInt32(cmbYear.Text.Trim()),"YES");
            }
            catch
            {
                dstLoanList = _obj.GetLoanApplicationList(DateTime.Today.Month, DateTime.Today.Year,"YES");
            }

            dgvLoanList.DataSource = dstLoanList.Tables[0];
            if(dgvLoanList.Rows.Count>0)
            {
                dgvLoanList.Visible = true;
                dgvLoanList.Columns["MEMBER_NAME"].HeaderText = "Member Name";
                dgvLoanList.Columns["MEMBER_NAME"].Width = 275;
                dgvLoanList.Columns["MEMBER_VILLAGE"].Visible = false;
                dgvLoanList.Columns["MEMBER_ID"].Visible = false;
                dgvLoanList.Columns["APP_ID"].Visible = false;
                System.Drawing.Font font = new System.Drawing.Font("Segoe UI Semibold", 11);
                dgvLoanList.ColumnHeadersDefaultCellStyle.Font = font;
            }
            else
            {
                dgvLoanList.Visible = false;
            }
        }
        #endregion

        private void NewLoanApplication_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
