using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969
{
    public partial class frmCalendar : Form
    {
        private bool monthly = true;

        public frmCalendar()
        {
            InitializeComponent();
        }

        private void frmCalendar_Load(object sender, EventArgs e)
        {
            // Ensure we close our connection on exit.
            this.FormClosing += new FormClosingEventHandler(frmCalendar_FormClosing);
        }

        private void frmCalendar_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kill the application.
            Application.Exit();
        }

        private void calendarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if(monthly == true)
            {
                
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            // Pass it to the form.
            var frmAccount = new frmAccount();

            // Show calendar form.
            frmAccount.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            // Pass it to the form.
            var frmUsers = new frmUsers();

            // Show calendar form.
            frmUsers.ShowDialog();

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            // Pass it to the form.
            var frmCustomers = new frmCustomers();

            // Hide this form so we can bring it back.
            this.Hide();

            // Show calendar form.
            frmCustomers.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            // Pass it to the form.
            var frmReports = new frmReports();

            // Hide this form so we can bring it back.
            this.Hide();

            // Show calendar form.
            frmReports.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Restart the application and exit the current one.
            // This closes connections and resets all forms.
            Application.Restart();
            Environment.Exit(0);
        }

        private void btnNewApt_Click(object sender, EventArgs e)
        {
            // Pass it to the form.
            var frmAppointment = new frmAppointment(-1);

            // Hide this form so we can bring it back.
            this.Hide();

            // Show calendar form.
            frmAppointment.ShowDialog();
        }

        private void btnEditApt_Click(object sender, EventArgs e)
        {
            // Pass it to the form.
            var frmAppointment = new frmAppointment(7);

            // Hide this form so we can bring it back.
            this.Hide();

            // Show calendar form.
            frmAppointment.ShowDialog();
        }
    }
}
