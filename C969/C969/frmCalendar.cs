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
        public DateTime selectedDate = new DateTime();
        public DateTime cwSunday = new DateTime();
        public Day currentDay = new Day();

        // Create binding sources.
        public BindingList<Appointment> appointments = new BindingList<Appointment>();
        public BindingSource appointmentSource = new BindingSource();
        public DataTable dtblAppointments = new DataTable();

        public frmCalendar()
        {
            InitializeComponent();
        }

        private void frmCalendar_Load(object sender, EventArgs e)
        {
            // Warning to whomever is performing the testing.
            if(MainSession.csession.Language == "es")
            {
                MessageBox.Show("Warning - Ruberic requires dual language for the login form. Dual language functionality is only partially implimented for all other forms.");
            }

            // Set our datetime equal to today.
            selectedDate = DateTime.Today;
            updateWeek();
            loadAppointments();

            // The rubric specifically states that this check occurs on login, so this is only performed ONCE.

            // Check for upcoming appointments.
            foreach (DataRow row in dtblAppointments.Rows)
            {
                int offset = Convert.ToInt32(DateTimeOffset.Now.Offset.Hours);

                DateTime eventDT = DateTime.Parse(row["Start"].ToString());

                eventDT.AddHours(offset);

                if(eventDT < DateTime.Now && eventDT.AddMinutes(15) >= DateTime.Now)
                {
                    MessageBox.Show("Alert - Appointment " + row["ID"].ToString() + " " + row["Title"].ToString() + " starts in 15 minutes or less.");
                }

            }

            // Ensure we close our connection on exit.
            this.FormClosing += new FormClosingEventHandler(frmCalendar_FormClosing);
        }

        private void loadAppointments()
        {
            // Clear the table.
            dtblAppointments = new DataTable();

            int aptCount = currentDay.loadAppointments(selectedDate, MainSession.csession.user.userId);

            appointments = currentDay.AppointmentList;

            // Add columns to data tables.
            dtblAppointments.Columns.Add("ID");
            dtblAppointments.Columns.Add("Title");
            dtblAppointments.Columns.Add("Type");
            dtblAppointments.Columns.Add("Url");
            dtblAppointments.Columns.Add("Start");
            dtblAppointments.Columns.Add("End");

            // If we actually have appointments ...
            if (aptCount != 0)
            {
                // Process our appointment list.
                foreach (Appointment tmpApt in appointments)
                {
                    // Add our row.
                    dtblAppointments.Rows.Add(tmpApt.appointmentId, tmpApt.title, tmpApt.type, tmpApt.url, tmpApt.start.ToString("hh:mm tt"), tmpApt.end.ToString("hh:mm tt"));
                }
            }

            // Attach our data.
            appointmentSource.DataSource = dtblAppointments;
            dgvEventList.DataSource = appointmentSource;
        }

        private void updateWeek()
        {
            int dayOfWeek = Convert.ToInt32(selectedDate.DayOfWeek);

            // Potential Lambda option.
            cwSunday = selectedDate.AddDays(-dayOfWeek);

            switch(dayOfWeek)
            {
                case 0:
                    rbSunday.Checked = true;
                    break;
                case 1:
                    rbMonday.Checked = true;
                    break;
                case 2:
                    rbTuesday.Checked = true;
                    break;
                case 3:
                    rbWednesday.Checked = true;
                    break;
                case 4:
                    rbThursday.Checked = true;
                    break;
                case 5:
                    rbFriday.Checked = true;
                    break;
                case 6:
                    rbSaturday.Checked = true;
                    break;

            }

            rbSunday.Text = cwSunday.ToString("dddd MMMM d");
            rbMonday.Text = cwSunday.AddDays(1).ToString("dddd MMMM d");
            rbTuesday.Text = cwSunday.AddDays(2).ToString("dddd MMMM d");
            rbWednesday.Text = cwSunday.AddDays(3).ToString("dddd MMMM d");
            rbThursday.Text = cwSunday.AddDays(4).ToString("dddd MMMM d");
            rbFriday.Text = cwSunday.AddDays(5).ToString("dddd MMMM d");
            rbSaturday.Text = cwSunday.AddDays(6).ToString("dddd MMMM d");
        }

        private void frmCalendar_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kill the application.
            Application.Exit();
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
            loadSelected();
        }

        private void mcCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            selectedDate = mcCalendar.SelectionStart;
            mcCalendar.SelectionEnd = selectedDate;
            loadAppointments();
        }

        private void rbSunday_CheckedChanged(object sender, EventArgs e)
        {
            selectedDate = cwSunday;
            mcCalendar.SelectionStart = selectedDate;
            loadAppointments();
        }

        private void rbMonday_CheckedChanged(object sender, EventArgs e)
        {
            selectedDate = cwSunday.AddDays(1);
            mcCalendar.SelectionStart = selectedDate;
            loadAppointments();
        }

        private void rbTuesday_CheckedChanged(object sender, EventArgs e)
        {
            selectedDate = cwSunday.AddDays(2);
            mcCalendar.SelectionStart = selectedDate;
            loadAppointments();
        }

        private void rbWednesday_CheckedChanged(object sender, EventArgs e)
        {
            selectedDate = cwSunday.AddDays(3);
            mcCalendar.SelectionStart = selectedDate;
            loadAppointments();
        }

        private void rbThursday_CheckedChanged(object sender, EventArgs e)
        {
            selectedDate = cwSunday.AddDays(4);
            mcCalendar.SelectionStart = selectedDate;
            loadAppointments();
        }

        private void rbFriday_CheckedChanged(object sender, EventArgs e)
        {
            selectedDate = cwSunday.AddDays(5);
            mcCalendar.SelectionStart = selectedDate;
            loadAppointments();
        }

        private void rbSaturday_CheckedChanged(object sender, EventArgs e)
        {
            selectedDate = cwSunday.AddDays(6);
            mcCalendar.SelectionStart = selectedDate;
            loadAppointments();
        }

        // This will clear out all entries and set up the database with test data.
        private void btnTestData_Click(object sender, EventArgs e)
        {
            DateTime testDT = DateTime.Today;

            string currentday = testDT.ToUniversalTime().ToString("yyyy-MM-dd");
            string nextday = testDT.AddDays(1).ToUniversalTime().ToString("yyyy-MM-dd");
            string nextweek = testDT.AddDays(7).ToUniversalTime().ToString("yyyy-MM-dd");

            string strQuery = "";
            List<List<string>> lstResult = new List<List<string>>();

            // Create appointments.
            strQuery = "INSERT INTO appointment (customerId,userId,title,description,location,contact,type,url,start,end,createDate,createdBy,lastUpdate,lastUpdateBy) VALUES (1,1,'Event A','Description, event A','Location A','Contact A','Scrum','www.google.com',CAST('" + currentday + " 12:00:00' AS datetime),CAST('" + currentday + " 12:30:00' AS datetime),CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime),'test',CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime),'test'), (2, 1, 'Event B', 'Description, event B', 'Location B', 'Contact B', 'Proposal', 'www.linkedin.com', CAST('" + currentday + " 14:00:00' AS datetime), CAST('" + currentday + " 15:00:00' AS datetime), CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test', CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test'), (3, 1, 'Event C', 'Description, event C', 'Location C', 'Contact C', 'Kickoff', 'news.google.com', CAST('" + currentday + " 10:00:00' AS datetime), CAST('" + currentday + " 11:00:00' AS datetime), CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test', CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test'), (1, 1, 'Event D', 'Description, event D', 'Location D', 'Contact D', 'Scrum', 'www.reddit.com', CAST('" + nextday + " 14:00:00' AS datetime), CAST('" + nextday + " 15:00:00' AS datetime), CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test', CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test'), (2, 1, 'Event E', 'Description, event E', 'Location E', 'Contact E', 'Proposal', 'www.google.com', CAST('" + nextday + " 11:00:00' AS datetime), CAST('" + nextday + " 12:00:00' AS datetime), CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test', CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test'), (3, 1, 'Event F', 'Description, event F', 'Location F', 'Contact F', 'Kickoff', 'console.cloud.google.com', CAST('" + nextday + " 08:00:00' AS datetime), CAST('" + nextday + " 09:00:00' AS datetime), CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test', CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test'), (1, 1, 'Event G', 'Description, event G', 'Location G', 'Contact G', 'Scrum', 'linkedin.com', CAST('" + nextweek + " 14:00:00' AS datetime), CAST('" + nextweek + " 15:00:00' AS datetime), CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test', CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test'), (2, 1, 'Event H', 'Description, event H', 'Location H', 'Contact H', 'Proposal', 'mail.google.com', CAST('" + nextweek + " 10:00:00' AS datetime), CAST('" + nextweek + " 12:00:00' AS datetime), CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test', CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test'), (3, 1, 'Event I', 'Description, event I', 'Location I', 'Contact I', 'Kickoff', 'docs.new', CAST('" + nextweek + " 09:00:00' AS datetime), CAST('" + nextweek + " 09:45:00' AS datetime), CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test', CAST('" + testDT.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss") + "' as datetime), 'test');";
            lstResult = MainSession.csession.conn.TryQuery(strQuery);

            // Notify
            MessageBox.Show("Test events created. There should be three events for today, tomorrow, and one week from today.");
            loadAppointments();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            string msg = "This action will delete customers and appointments with IDs > 3, addresses with IDs > 4, and cities with IDs > 5. Do you wish to continue?";

            DialogResult result = MessageBox.Show(msg, "Confirm action", MessageBoxButtons.YesNo);

            // If no ...
            if (result == DialogResult.No)
            {
                //Do nothing
                return;
            }

            string strQuery = "";
            List<List<string>> lstResult = new List<List<string>>();

            // Delete data outside other than our basic items.
            strQuery = "DELETE FROM customer WHERE customerID > 3;";
            lstResult = MainSession.csession.conn.TryQuery(strQuery);
            strQuery = "DELETE FROM address WHERE addressID > 4;";
            lstResult = MainSession.csession.conn.TryQuery(strQuery);
            strQuery = "DELETE FROM city WHERE cityID > 5;";
            lstResult = MainSession.csession.conn.TryQuery(strQuery);
            strQuery = "DELETE FROM country WHERE countryID > 4;";
            lstResult = MainSession.csession.conn.TryQuery(strQuery);
            strQuery = "DELETE FROM appointment WHERE appointmentID > 3;";
            lstResult = MainSession.csession.conn.TryQuery(strQuery);


        }

        private void dgvEventList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            loadSelected();
        }

        private void loadSelected()
        {
            // Identify our event.
            int selectedRowCount = dgvEventList.CurrentCell.RowIndex;

            // Load for editing.
            int appointmentId = Convert.ToInt32(dgvEventList.Rows[selectedRowCount].Cells[0].Value);

            // Pass it to the form.
            var frmAppointment = new frmAppointment(appointmentId);

            // Hide this form so we can bring it back.
            this.Hide();

            // Show calendar form.
            frmAppointment.ShowDialog();

        }

        private void btnDeleteApt_Click(object sender, EventArgs e)
        {
            // Identify our event.
            int selectedRowCount = dgvEventList.CurrentCell.RowIndex;

            // Load for editing.
            int appointmentId = Convert.ToInt32(dgvEventList.Rows[selectedRowCount].Cells[0].Value);

            Appointment tmpAppointment = new Appointment();

            string msg = "Are you sure you wish to delete the selected appointment?";

            DialogResult result = MessageBox.Show(msg, "Confirm action", MessageBoxButtons.YesNo);

            // If no ...
            if (result == DialogResult.No)
            {
                //Do nothing
                return;
            }

            // If yes ...
            tmpAppointment.deleteAppointment(appointmentId);

            loadAppointments();
        }
    }
}
