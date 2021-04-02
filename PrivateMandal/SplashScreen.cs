using System;
using System.Windows.Forms;

namespace PrivateMandal
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
        Timer tmr;

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            tmr = new Timer();
            tmr.Interval = 5000;
            tmr.Start();
            tmr.Tick += new EventHandler(tmr_Tick);
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            Login form = new Login();
            form.Show();
            this.Hide();
        }
    }
}
