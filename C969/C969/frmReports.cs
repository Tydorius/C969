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
    public partial class frmReports : Form
    {
        // Create binding sources.
        BindingList<List<string>> lstResult = new BindingList<List<string>>();
        BindingSource resultSource = new BindingSource();
        DataTable dtblReport = new DataTable();

        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(frmReports_FormClosing);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            closeForm();
        }

        private void btnLogins_Click(object sender, EventArgs e)
        {
            // Clear the report.
            dtblReport = new DataTable();

            // Add columns.
            dtblReport.Columns.Add("UserId");
            dtblReport.Columns.Add("Username");
            dtblReport.Columns.Add("Login DateTime");

            string[] tblLogins = System.IO.File.ReadAllLines(FileTree.strLogFile);

            // If empty ...
            if (tblLogins.Length == 1) { return; }

            // Skip first row.
            tblLogins = tblLogins.Skip(1).ToArray();

            // Populate the report.
            foreach (string line in tblLogins)
            {
                // Split
                string[] row = line.Split(',');

                // Populate our data table.
                dtblReport.Rows.Add(row[0], row[1], row[2]);
            }

            // Attach our data.
            resultSource.DataSource = dtblReport;
            dgvReportOutput.DataSource = resultSource;

            // That's it.

        }

        public void frmReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeForm();
        }

        public void closeForm()
        {
            // Show calendar form.
            MainSession.frmCalendar.Show();

            // Dispose of this form.
            this.Dispose();
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            // Clear the report.
            dtblReport = new DataTable();

            string strQuery = "SELECT a.start, a.end, b.userName, c.customerName FROM appointment a LEFT JOIN user b ON a.userId = b.userId LEFT JOIN customer c ON a.customerId = c.customerId WHERE a.start >= CURDATE() ORDER BY b.userName,a.start;";

            // Run the query.
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

            // Add columns.
            dtblReport.Columns.Add("Start");
            dtblReport.Columns.Add("End");
            dtblReport.Columns.Add("Consultant");
            dtblReport.Columns.Add("Customer");

            string[] tblLogins = System.IO.File.ReadAllLines(FileTree.strLogFile);

            int offset = Convert.ToInt32(DateTimeOffset.Now.Offset.Hours);

            // If empty ...
            if (lstResult.Count == 1) { return; }

            // Populate the report.
            foreach (List<string> line in lstResult)
            {
                DateTime Start = DateTime.Parse(line[0]);
                string strStart = Start.AddHours(offset).ToString();
                DateTime End = DateTime.Parse(line[1]);
                string strEnd = End.AddHours(offset).ToString();

                // Populate our data table.
                dtblReport.Rows.Add(strStart, strEnd, line[2], line[3]);
            }

            // Attach our data.
            resultSource.DataSource = dtblReport;
            dgvReportOutput.DataSource = resultSource;

            // That's it.


        }

        private void btnTypes_Click(object sender, EventArgs e)
        {
            // Clear the report.
            dtblReport = new DataTable();

            string strQuery = "SELECT MONTHNAME(start) as Month, YEAR(start) as Year, type, COUNT(type) AS Count FROM appointment GROUP BY Year,Month,type ORDER BY Year,Month,type;";

            // Run the query.
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

            // Add columns.
            dtblReport.Columns.Add("Month");
            dtblReport.Columns.Add("Year");
            dtblReport.Columns.Add("Type");
            dtblReport.Columns.Add("Count");

            string[] tblLogins = System.IO.File.ReadAllLines(FileTree.strLogFile);

            int offset = Convert.ToInt32(DateTimeOffset.Now.Offset.Hours);

            // If empty ...
            if (lstResult.Count == 1) { return; }

            // Populate the report.
            foreach (List<string> line in lstResult)
            {
                // Populate our data table.
                dtblReport.Rows.Add(line[0], line[1], line[2], line[3]);
            }

            // Attach our data.
            resultSource.DataSource = dtblReport;
            dgvReportOutput.DataSource = resultSource;

            // That's it.

        }
    }
}
