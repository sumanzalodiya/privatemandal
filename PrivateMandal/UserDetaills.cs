using System.Windows.Forms;

namespace PrivateMandal
{
    public static class UserDetaills
    {
        public static string UserId { get; set; }
        public static string UserName { get; set; }
    }

    public static class CommonUtility
    {
        public static void ConvertToThousandChange(Label txtChange)
        {
            string value = txtChange.Text.Replace(",", "");
            ulong ul;
            if (ulong.TryParse(value, out ul))
            {
                txtChange.Text = string.Format("{0:#,#}", ul);
            }
        }
    }
}
