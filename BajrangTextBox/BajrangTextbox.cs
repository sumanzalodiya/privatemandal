using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace BajrangTextBox
{
    public partial class BajrangTextbox : TextBox
    {
        public bool IsNumeric { get; set; }

        public enum TextDecoration
        {
            Capitalize = 0,
            Uppercase = 1,
            Lowercase = 2,
            None = 3,
        }

        public BajrangTextbox()
        {
            base.Font = new Font("Segoe UI Semibold", 10);
            base.BackColor = Color.White;
            base.BorderStyle = BorderStyle.FixedSingle;
        }

        public TextDecoration TextTransform { get; set; }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (IsNumeric)
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || (e.KeyChar == '.' && this.Text.Trim().IndexOf('.')==-1)))
                { e.Handled = true; }

            }
            base.OnKeyPress(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.FindForm().Close();
            }
            base.OnKeyUp(e);
        }
        protected override void OnEnter(EventArgs e)
        {
            base.BackColor = Color.WhiteSmoke;
            base.ForeColor = Color.Black;
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.BackColor = Color.White;
            base.ForeColor = Color.Black;
            base.OnLeave(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            int currentpos = base.SelectionStart;
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            if (TextTransform == TextDecoration.Capitalize)
                base.Text = ti.ToTitleCase(base.Text);
            else if (TextTransform == TextDecoration.Lowercase)
                base.Text = ti.ToLower(base.Text);
            else if (TextTransform == TextDecoration.Uppercase)
                base.Text = ti.ToUpper(base.Text);
            else
                base.Text = base.Text;
            base.SelectionStart = currentpos;
            base.SelectionLength = 0;
            base.OnTextChanged(e);
        }
    }
}
