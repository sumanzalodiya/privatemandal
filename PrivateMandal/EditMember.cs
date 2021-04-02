using MandalLibrary;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PrivateMandal
{
    public partial class EditMember : Form
    {
        DataSet dstMember = new DataSet();
        public EditMember()
        {
            InitializeComponent();
        }

        private void EditMember_Load(object sender, EventArgs e)
        {
            Header header = new Header("MEMBER'S LIST");
            this.Controls.Add(header);
            header.Left = 0;
            header.Top = 0;
            header.Width = this.Width;
            LoadMemberList();
        }

        private void LoadMemberList()
        {
            try
            {
                Member _obj = new Member();
                dstMember = _obj.GetMemberList("");
                dgvMember.DataSource = dstMember.Tables[0];
                SetDataGridProperties();
            }
            catch (Exception ex)
            {
                LogError.LogEvent("LoadMemberList", ex.Message, "LoadMemberList");
            }
        }

        private void SetDataGridProperties()
        {
            dgvMember.Columns["MEMBER_ID"].Visible = false;

            dgvMember.Columns["MEMBER_NAME"].HeaderText = "Member Name";
            dgvMember.Columns["MEMBER_NAME"].DisplayIndex = 0;
            dgvMember.Columns["MEMBER_NAME"].Width = 300;

            dgvMember.Columns["MEMBER_GENDER"].HeaderText = "Gender";
            dgvMember.Columns["MEMBER_GENDER"].Width = 120;
            dgvMember.Columns["MEMBER_GENDER"].DisplayIndex = 1;

            dgvMember.Columns["MEMBER_VILLAGE"].HeaderText = "Village Name";
            dgvMember.Columns["MEMBER_VILLAGE"].Width = 200;
            dgvMember.Columns["MEMBER_VILLAGE"].DisplayIndex = 2;

            dgvMember.Columns["MEMBER_TALUKA"].HeaderText = "Taluka";
            dgvMember.Columns["MEMBER_TALUKA"].Width = 200;
            dgvMember.Columns["MEMBER_TALUKA"].DisplayIndex = 3;

            dgvMember.Columns["MEMBER_DISTRICT"].HeaderText = "District";
            dgvMember.Columns["MEMBER_DISTRICT"].Width = 200;
            dgvMember.Columns["MEMBER_DISTRICT"].DisplayIndex = 4;

            dgvMember.Columns["MEMBER_MOBILE"].HeaderText = "Mobile Number";
            dgvMember.Columns["MEMBER_MOBILE"].Width = 200;
            dgvMember.Columns["MEMBER_MOBILE"].DisplayIndex = 5;            

            Font font = new Font("Segoe UI Semibold", 14);            
            dgvMember.ColumnHeadersDefaultCellStyle.Font = font;
        }

        private void dgvMember_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                int intMemberId = Convert.ToInt32(dgvMember.Rows[dgvMember.CurrentCell.RowIndex].Cells["MEMBER_ID"].Value.ToString());
                UpdateMember updateMember = new UpdateMember(intMemberId);
                updateMember.ShowDialog();
                LoadMemberList();
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();
            else if(e.KeyCode==Keys.F1)
            {
                int intMemberId = Convert.ToInt32(dgvMember.Rows[dgvMember.CurrentCell.RowIndex].Cells["MEMBER_ID"].Value.ToString());
                MembershipForm updateMember = new MembershipForm(intMemberId);
                updateMember.ShowDialog();
            }
        }

        private void EditMember_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
