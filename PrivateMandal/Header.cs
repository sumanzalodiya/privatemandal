using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrivateMandal
{
    public partial class Header : UserControl
    {
        private readonly string formName;

        public Header(string formName)
        {
            InitializeComponent();
            this.formName = formName;
        }

        private void Header_Load(object sender, EventArgs e)
        {
            rectangleShape1.Width = this.Parent.Width;
            lblMandalName.Text = MandalDetails.MandalName;
            lblUserName.Text = UserDetaills.UserName;
            lblFormName.Text = formName;
        }
    }
}
