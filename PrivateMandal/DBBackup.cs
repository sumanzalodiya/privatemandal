using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrivateMandal
{
    public partial class DBBackup : Form
    {
        public DBBackup()
        {
            InitializeComponent();
        }

        private void DBBackup_Load(object sender, EventArgs e)
        {
            try
            {
                MandalLibrary.Report _obj = new MandalLibrary.Report();
                bool blnSuccess = false;
                blnSuccess = _obj.TakeDBBackup();
                if (blnSuccess)
                {
                    MessageBox.Show("Database Backup has been taken and saved it at specified location", "Backup Taken");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro Occured During Taking Database backup. Please Try Again");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
    }
}
