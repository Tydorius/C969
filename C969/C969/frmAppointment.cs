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

        // Appointment form. Pass an appointment ID to auto populate existing appointments. Pass -1 to load a blank form.
        public frmAppointment(int id)
        {
            InitializeComponent();
            // If it's not a new appointment, we need to load the selected appointment.
            if (id != -1)
            {
                // Set the appointment ID variable.
                appointmentId = id;

                // Lookup the appointment and update the tmpAppointment.
                tmpAppointment = tmpAppointment.lookupAppointment(id);

                // Initiate a list of customers.
                BindingList<Customer> customers = new BindingList<Customer>();

                // Load a list of customers.
                customers = MainSession.csession.customerList.loadCustomers();

                // Populate the current customer for the loaded appointment.
                foreach (Customer tmpCust in customers)
                {
                    if (tmpAppointment.customerId == tmpCust.customerId)
                    {
                        txtbxCustomer.Text = tmpCust.customerName;
                        cCust = tmpCust.customerId;
                        break;
                    }
                }

                // Update the appointment form text.
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
            // Load the customer list.
            loadCustomers();
            // Update the language. NOTE - Not fully implemented.
            updateLanguage();
            // Check our text and validate.
            changedText();
            // Saved is ALWAYS true on initial load - We either have nothing to save (new) or we loaded an already saved state (Existing).
            saved = true;
            // Ensure we check save status on close.
            this.FormClosing += new FormClosingEventHandler(frmAppointment_FormClosing);
        }

        private void dgvCustomers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Double clicking a customer loads that customer as selected.
            loadSelected();
        }
        private void frmAppointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Saving space with a single method for form closing and exiting.
            closeForm();
        }

        private void updateLanguage()
        {
            // Again, note that this is not 100% implemented for the entire application.
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
                // Warn the user, ask them if they wish to save.
                string msg = "You have unsaved changes, are you sure you wish to close this form?";
                string header = "Confirm Lose Changes";
                // Update string for es if needed.
                if (MainSession.csession.Language == "es")
                {
                    msg = "Tiene cambios sin guardar, ¿está seguro de que desea cerrar este formulario?";
                    header = "Confirmar perder cambios";
                }

                // Show message, get feedback.
                DialogResult result = MessageBox.Show(msg, header, MessageBoxButtons.YesNo);

                // If no ...
                if (result == DialogResult.No)
                {
                    //Do nothing
                    return;
                }
            }

            // If yes, we make it here.

            // Show calendar form.
            MainSession.frmCalendar.Show();

            // Dispose of this form.
            this.Dispose();
        }
        private void loadCustomers()
        {
            // Clear the table.
            dtblCustomers = new DataTable();

            // Load the data fresh.
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
            // Saving lines with a single close form method.
            closeForm();
        }

        private void txtbxTitle_TextChanged(object sender, EventArgs e)
        {
            // Any time text changes, we want to verify the information.
            changedText();
        }
        private void changedText()
        {
            // This method only highlights validation issues, but it is not the full validation check.

            // Set saved to false any time text changes.
            saved = false;

            // Note that while I started including items for non-required fields, I stopped.
            // The rubric only cares about customer, type, URL, and date/times. As such, validation only touches these fields.
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

            // Reset form colors.
            txtbxTitle.BackColor = Color.White;
            datetimeStart.BackColor = Color.White;
            datetimeEnd.BackColor = Color.White;
            txtbxDescription.BackColor = Color.White;
            txtbxLocation.BackColor = Color.White;
            txtbxContact.BackColor = Color.White;
            txtbxType.BackColor = Color.White;
            txtbxURL.BackColor = Color.White;
            txtbxCustomer.BackColor = Color.White;

            // All validation checks will append the corresponding message on a new line depending upon the language.
            // Note that secondary language is not 100% implemented across the entire application.

            // Ensure that we must select a customer.
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
            // Ensure type is not null.
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
            // Ensure type does not contain dangerous SQL characters.
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
            // Ensure URL is not null.
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
            // Ensure URL does not contain dangerous SQL characters.
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
            // Ensure start time is not greater than end time.
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
            // Ensure the appointment is within business hours.
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

            // Measure the timespan.
            TimeSpan duration = datetimeEnd.Value.Subtract(datetimeStart.Value);

            // It's easier to check the duration of the timespan, since we know a full workday can only be 9 hours and there are more than 9 hours between the end and start of each day.
            if (Convert.ToInt32(duration.Hours) > 9)
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
            // If any of our validations failed, show the error messages.
            if (valid == false)
            {
                MessageBox.Show(strError);
            }
            // Return the validity status.
            return valid;
        }

        public void loadSelected()
        {
            // Identify our customer.
            int selectedRowCount = dgvCustomers.CurrentCell.RowIndex;

            // Set the customer ID.
            cCust = Convert.ToInt32(dgvCustomers.Rows[selectedRowCount].Cells[0].Value);

            // Update customer name text.
            txtbxCustomer.Text = Convert.ToString(dgvCustomers.Rows[selectedRowCount].Cells[1].Value);

            // Run validation.
            changedText();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Load the selected line item.
            loadSelected();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // If running the validation item returns false, we do nothing.
            // The error message displays through validate() so there is no additional feedback needed.
            if(validate() == false)
            {
                return;
            }
            // Because the rubric only requires a handful of items, some fields are being populated with filler text.
            tmpAppointment.userId = MainSession.csession.user.userId;
            tmpAppointment.customerId = cCust;
            tmpAppointment.title = "Not part of requirements.";
            tmpAppointment.description = "Not part of requirements.";
            tmpAppointment.location = "Not part of requirements.";
            tmpAppointment.contact = "Not part of requirements.";
            tmpAppointment.type = txtbxType.Text;
            tmpAppointment.url = txtbxURL.Text;
            tmpAppointment.start = datetimeStart.Value;
            tmpAppointment.end = datetimeEnd.Value;

            // Once we have our appointment, we check for conflicts.
            if (tmpAppointment.checkConflicts(tmpAppointment.start, tmpAppointment.end, tmpAppointment.customerId, tmpAppointment.userId, appointmentId) == true)
            {
                // If checking for conflicts is true, we know there is a conflict and display the corresponding error.
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

            // If we make it here, we didn't trigger the return and save our appointment.
            // We also update the tmpAppointment.appointmentId to the new one. This may be the existing ID or it may be a new one, which is why this is important.
            tmpAppointment.appointmentId = tmpAppointment.saveAppointment(tmpAppointment, appointmentId);

            appointmentId = tmpAppointment.appointmentId;

            // We've saved, so we set saved to true so we don't trigger a warning on exit.
            saved = true;
        }
    }
}
