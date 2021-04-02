using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MandalLibrary;

namespace PrivateMandal
{
    public partial class ChangeEMIAmount : Form
    {
        public ChangeEMIAmount()
        {
            InitializeComponent();
        }

        private void ChangeEMIAmount_Load(object sender, EventArgs e)
        {
            Header header = new Header("CHANGE EMI AMOUNT");
            this.Controls.Add(header);
            header.Left = 0;
            header.Top = 0;
            header.Width = this.Width;
            cmbYear.Items.Add(DateTime.Today.Year.ToString());
            cmbYear.Items.Add(DateTime.Today.AddYears(1).Year.ToString());
            cmbYear.SelectedIndex = -1;
            LoadEMIHistory();
        }

        private void LoadEMIHistory()
        {
            Member _obj =new Member();
            DataSet dstLoanList = new DataSet();
            dgvEMIHistory.DataSource = null;
                dstLoanList = _obj.GetEMIHistory();

            dgvEMIHistory.DataSource = dstLoanList.Tables[0];
            if (dgvEMIHistory.Rows.Count > 0)
            {
                dgvEMIHistory.Visible = true;
                dgvEMIHistory.Columns["EMI_DATE"].HeaderText = "Emi From";
                dgvEMIHistory.Columns["EMI_DATE"].Width = 150;
                dgvEMIHistory.Columns["EMI_AMOUNT"].HeaderText = "Emi Amount";
                dgvEMIHistory.Columns["EMI_AMOUNT"].Width = 150;
                System.Drawing.Font font = new System.Drawing.Font("Segoe UI Semibold", 11);
                dgvEMIHistory.ColumnHeadersDefaultCellStyle.Font = font;
            }
            else
            {
                dgvEMIHistory.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cmbMonth.SelectedIndex==-1) { MessageBox.Show("Select Month", "Select Month", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); cmbMonth.Focus(); }
            else if(cmbYear.SelectedIndex==-1) { MessageBox.Show("Select Year", "Select Year", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); cmbYear.Focus(); }
            else if(txtEMI.Text.Trim().Equals("") || txtEMI.Text.Trim().Equals("0")) { MessageBox.Show("Enter Amount", "Enter Amount", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); txtEMI.Focus(); }
            else
            {
                try
                {
                    Member _obj = new Member();
                    int intResult = _obj.ChangeEMImount(cmbMonth.SelectedIndex + 1, Convert.ToInt32(cmbYear.Text), Convert.ToDecimal(txtEMI.Text.Trim()));
                    if(intResult==1)
                    {
                        MessageBox.Show("New EMI inserted successfully", "New EMI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEMIHistory();
                        cmbMonth.SelectedIndex = -1;
                        cmbYear.SelectedIndex = -1;
                        txtEMI.Text = string.Empty;
                        cmbMonth.Focus();
                    }
                    else
                    {
                        MessageBox.Show("EMI already configured for greater than given date", "EMI Configured", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch(Exception ex)
                {
                    LogError.LogEvent("", ex.Message, "ChangeEMI Save");
                }
            }
        }

        private void grouper1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
