using MandalLibrary;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PrivateMandal
{
    public partial class MemberList : Form
    {
        public DataRow dtRow;
        DataSet dstMember=new DataSet();
        public MemberList()
        {
            InitializeComponent();
        }

        private void MemberList_Load(object sender, EventArgs e)
        {            
            LoadMemberList();
            txtSearch.Focus();
        }

        private void LoadMemberList()
        {
            try
            {
                Member _obj = new Member();
                dstMember = _obj.GetMemberList("LOV");
                dgvMember.DataSource = dstMember.Tables[0];
                SetDataGridProperties();
            }
            catch(Exception ex)
            {
                LogError.LogEvent("LoadMemberList", ex.Message, "LoadMemberList");
            }
        }

        private void SetDataGridProperties()
        {
            dgvMember.Columns["MEMBER_ID"].Visible = false;

            dgvMember.Columns["MEMBER_NAME"].HeaderText = "Member Name";
            dgvMember.Columns["MEMBER_NAME"].DisplayIndex = 0;
            dgvMember.Columns["MEMBER_NAME"].Width = 250;

            dgvMember.Columns["MEMBER_VILLAGE"].HeaderText = "Village";
            dgvMember.Columns["MEMBER_VILLAGE"].Width = 120;
            dgvMember.Columns["MEMBER_VILLAGE"].DisplayIndex = 1;

            Font font = new Font("Segoe UI Semibold", 10);
            dgvMember.ColumnHeadersDefaultCellStyle.Font = font;
        }

        private void dgvMember_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)
            {
                string strMemberId = dgvMember.Rows[dgvMember.CurrentCell.RowIndex].Cells["MEMBER_ID"].Value.ToString();
                string strMemberName = dgvMember.Rows[dgvMember.CurrentCell.RowIndex].Cells["MEMBER_NAME"].Value.ToString();
                string strVillageName = dgvMember.Rows[dgvMember.CurrentCell.RowIndex].Cells["MEMBER_VILLAGE"].Value.ToString();

                dtRow["MEMBER_ID"] = strMemberId;
                dtRow["MEMBER_NAME"] = strMemberName;
                dtRow["VILLAGE_NAME"] = strVillageName;
                this.Close();
            }
            else if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dstMember.Tables[0].DefaultView.RowFilter = "MEMBER_NAME LIKE '%" + txtSearch.Text.Trim() + "%' OR MEMBER_VILLAGE like '%" + txtSearch.Text.Trim() + "%'";
            dgvMember.DataSource = (dstMember.Tables[0].DefaultView).ToTable();
        }
    }
}
