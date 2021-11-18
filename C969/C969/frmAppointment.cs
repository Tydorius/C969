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
    public partial class frmAppointment : Form
    {
        // Create binding sources.
        BindingList<Customer> customers = new BindingList<Customer>();
        BindingSource customerSource = new BindingSource();
        DataTable dtblCustomers = new DataTable();

        // Create Appointment
        Appointment tmpAppointment = new Appointment();

        // Validation
        bool valid = false;
        bool saved = true;
        int cCust = -1;
        int appointmentId = -1;

        public frmAppointment(int id)
        {
            // If it's not a new appointment, we need to load the selected appointment.
            if (id != -1)
            {
                InitializeComponent();

                appointmentId = id;

                tmpAppointment = tmpAppointment.lookupAppointment(id);

                BindingList<Customer> customers = new BindingList<Customer>();

                customers = MainSession.csession.customerList.loadCustomers();

                foreach (Customer tmpCust in customers)
                {
                    if (tmpAppointment.customerId == tmpCust.customerId)
                    {
                        txtbxCustomer.Text = tmpCust.customerName;
                        cCust = tmpCust.customerId;
                        break;
                    }
                }

                txtbxTitle.Text = tmpAppointment.title;
                datetimeStart.Value = tmpAppointment.start;
                datetimeEnd.Value = tmpAppointment.end;
                txtbxDescription.Text = tmpAppointment.description;
                txtbxLocation.Text = tmpAppointment.location;
                txtbxContact.Text = tmpAppointment.contact;
                txtbxType.Text = tmpAppointment.type;
                txtbxURL.Text = tmpAppointment.url;
            }
        }

        private void frmAppointment_Load(object sender, EventArgs e)
        {
            loadCustomers();
            updateLanguage();
            changedText();
            saved = true;
            this.FormClosing += new FormClosingEventHandler(frmAppointment_FormClosing);
        }

        private void dgvCustomers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            loadSelected();
        }
        private void frmAppointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeForm();
        }

        private void updateLanguage()
        {
            if (MainSession.csession.Language == "en")
            {
                // Do nothing because it's English by default
                return;
            }
            // If we make it here, it's es.
            lblTitle.Text = "Título";
            lblStart.Text = "Comienzo";
            lblEnd.Text = "Fin";
            lblDescription.Text = "Descripción";
            btnSave.Text = "Ahorrar";
            btnExit.Text = "Salida";
            lblLocation.Text = "Localización";
            lblCustomer.Text = "Cliente";
            lblContact.Text = "Contacto";
            lblType.Text = "Escribe";
            btnSelect.Text = "Seleccionar cliente";
        }
        private void closeForm()
        {
            // If we have not saved our changes ... 
            if (saved == false)
            {
                string msg = "You have unsaved changes, are you sure you wish to close this form?";
                string header = "Confirm Lose Changes";
                if (MainSession.csession.Language == "es")
                {
                    msg = "Tiene cambios sin guardar, ¿está seguro de que desea cerrar este formulario?";
                    header = "Confirmar perder cambios";
                }

                DialogResult result = MessageBox.Show(msg, header, MessageBoxButtons.YesNo);

                // If no ...
                if (result == DialogResult.No)
                {
                    //Do nothing
                    return;
                }
            }

            // Show calendar form.
            MainSession.frmCalendar.Show();

            // Dispose of this form.
            this.Dispose();
        }
        private void loadCustomers()
        {
            // Clear the table.
            dtblCustomers = new DataTable();

            customers = MainSession.csession.customerList.loadCustomers();

            // Add columns to data tables.
            dtblCustomers.Columns.Add("ID");
            dtblCustomers.Columns.Add("Customer Name");
            dtblCustomers.Columns.Add("Status");
            dtblCustomers.Columns.Add("Phone");
            dtblCustomers.Columns.Add("Address");
            dtblCustomers.Columns.Add("Address 2");
            dtblCustomers.Columns.Add("City");
            dtblCustomers.Columns.Add("Postal");
            dtblCustomers.Columns.Add("Country");

            // Process our customer list.
            foreach (Customer tmpCust in customers)
            {
                // Determine status
                string strStatus = "Active";
                if (tmpCust.active == "False")
                {
                    strStatus = "Inactive";
                }
                // Add our row.
                dtblCustomers.Rows.Add(tmpCust.customerId, tmpCust.customerName, strStatus, tmpCust.address.phone, tmpCust.address.address, tmpCust.address.address2, tmpCust.address.city.city, tmpCust.address.postalCode, tmpCust.address.city.country);
            }

            // Attach our data.
            customerSource.DataSource = dtblCustomers;
            dgvCustomers.DataSource = customerSource;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            closeForm();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            tmpAppointment.checkConflicts(datetimeStart.Value, datetimeEnd.Value, 1, 2, -1);
        }

        private void txtbxTitle_TextChanged(object sender, EventArgs e)
        {
            changedText();
        }
        private void changedText()
        {
            saved = false;

            txtbxTitle.BackColor = Color.White;
            datetimeStart.BackColor = Color.White;
            datetimeEnd.BackColor = Color.White;
            txtbxDescription.BackColor = Color.White;
            txtbxLocation.BackColor = Color.White;
            txtbxContact.BackColor = Color.White;
            txtbxType.BackColor = Color.White;
            txtbxURL.BackColor = Color.White;
            txtbxCustomer.BackColor = Color.White;

            if(cCust == -1)
            {
                txtbxCustomer.BackColor = Color.Salmon;
            }
            if (txtbxType.Text == null || txtbxType.Text == "")
            {
                txtbxType.BackColor = Color.Salmon;
            }
            if (txtbxURL.Text == null || txtbxURL.Text == "")
            {
                txtbxURL.BackColor = Color.Salmon;
            }
            if (datetimeStart.Value > datetimeEnd.Value)
            {
                datetimeStart.CalendarTitleBackColor = Color.Salmon;
                datetimeEnd.CalendarTitleBackColor = Color.Salmon;
            }
        }
        private bool validate()
        {
            // Bool for validated, starts true.
            valid = true;
            // Pull language for case so we're not constnatly calling the MainSession.
            int lng = 0;

            // Initialie error string.
            string strError = "";

            // Update string accordingly.
            if (MainSession.csession.Language == "es") { lng = 1; }

            // First line of error string.
            switch (lng)
            {
                case 0:
                    strError = "Please fix the following:";
                    break;
                case 1:
                    strError = "Corrija lo siguiente:";
                    break;
            }

            txtbxTitle.BackColor = Color.White;
            datetimeStart.BackColor = Color.White;
            datetimeEnd.BackColor = Color.White;
            txtbxDescription.BackColor = Color.White;
            txtbxLocation.BackColor = Color.White;
            txtbxContact.BackColor = Color.White;
            txtbxType.BackColor = Color.White;
            txtbxURL.BackColor = Color.White;
            txtbxCustomer.BackColor = Color.White;

            if (cCust == -1)
            {
                
                switch (lng)
                {
                    case 0:
                        strError += "\nSelect a customer.";
                        break;
                    case 1:
                        strError += "\nSeleccionar un cliente.";
                        break;
                }
                valid = false;
            }
            if (txtbxType.Text == null || txtbxType.Text == "")
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nType is required.";
                        break;
                    case 1:
                        strError += "\nSe requiere el tipo.";
                        break;
                }
                valid = false;
            }
            if (txtbxType.Text.Contains("\\") || txtbxType.Text.Contains("\""))
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nType name contains invalid characters (\\ or \").";
                        break;
                    case 1:
                        strError += "\nEl nombre del tipo contiene caracteres no válidos (\\ o \").";
                        break;
                }
                valid = false;
            }
            if (txtbxURL.Text == null || txtbxURL.Text == "")
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nURL is required.";
                        break;
                    case 1:
                        strError += "\nSe requiere URL.";
                        break;
                }
                valid = false;
            }
            if (txtbxType.Text.Contains("\\") || txtbxType.Text.Contains("\""))
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nURL contains invalid characters (\\ or \").";
                        break;
                    case 1:
                        strError += "\nURL contiene caracteres no válidos (\\ o \").";
                        break;
                }
                valid = false;
            }
            if (datetimeStart.Value > datetimeEnd.Value)
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nStart time must be earlier than end time.";
                        break;
                    case 1:
                        strError += "\nLa hora de inicio debe ser anterior a la hora de finalización.";
                        break;
                }
                valid = false;
            }
            if (datetimeStart.Value.Hour < 8 || datetimeEnd.Value.Hour > 17)
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nMust be scheduled between 8 a.m. and 5 p.m. local time.";
                        break;
                    case 1:
                        strError += "\nDebe programarse entre las 8 a.m. y las 5 p.m. hora local.";
                        break;
                }
                valid = false;
            }

            TimeSpan duration = datetimeEnd.Value.Subtract(datetimeStart.Value);

            if (Convert.ToInt32(duration) > 9)
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nEvents can not be longer than one business day.";
                        break;
                    case 1:
                        strError += "\nLos eventos no pueden durar más de un día hábil.";
                        break;
                }
                valid = false;
            }
            if (valid == false)
            {
                MessageBox.Show(strError);
            }

            return valid;
        }

        public void loadSelected()
        {
            // If we have not saved our changes ... 
            if (saved == false)
            {
                string msg = "You have unsaved changes, are you sure you wish to load another customer?";
                string header = "Confirm Lose Changes";
                if (MainSession.csession.Language == "es")
                {
                    msg = "Tiene cambios sin guardar, ¿está seguro de que desea cargar otro cliente? ";
                    header = "Confirmar perder cambios";
                }

                DialogResult result = MessageBox.Show(msg, header, MessageBoxButtons.YesNo);

                // If no ...
                if (result == DialogResult.No)
                {
                    //Do nothing
                    return;
                }
            }

            // Identify our customer.
            int selectedRowCount = dgvCustomers.CurrentCell.RowIndex;

            cCust = Convert.ToInt32(dgvCustomers.Rows[selectedRowCount].Cells[0].Value);

            txtbxCustomer.Text = Convert.ToString(dgvCustomers.Rows[selectedRowCount].Cells[1].Value);

            changedText();
            saved = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            loadSelected();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(validate() == false)
            {
                return;
            }
            tmpAppointment.userId = MainSession.csession.user.userId;
            tmpAppointment.customerId = cCust;
            tmpAppointment.title = "Not part of requirements.";
            tmpAppointment.description = "Not part of requirements.";
            tmpAppointment.location = "Not part of requirements.";
            tmpAppointment.contact = "Not part of requirements.";
            tmpAppointment.type = txtbxType.Text;
            tmpAppointment.url = txtbxURL.Text;
            tmpAppointment.start = datetimeStart.Value.ToUniversalTime();
            tmpAppointment.end = datetimeEnd.Value.ToUniversalTime();

            if (tmpAppointment.checkConflicts(tmpAppointment.start, tmpAppointment.end, tmpAppointment.customerId, tmpAppointment.userId, appointmentId) == true)
            {
                if (MainSession.csession.Language == "en")
                {
                    MessageBox.Show("The select time is in conflict. Please update and try again.");
                }
                if (MainSession.csession.Language == "es")
                {
                    MessageBox.Show("El tiempo seleccionado está en conflicto. Actualice y vuelva a intentarlo.");
                }
                return;
            }

            tmpAppointment.saveAppointment(tmpAppointment, appointmentId);

            saved = true;
        }
    }
}
