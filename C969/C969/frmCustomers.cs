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
    public partial class frmCustomers : Form
    {
        // Create binding sources.
        BindingList<Customer> customers = new BindingList<Customer>();
        BindingSource customerSource = new BindingSource();
        DataTable dtblCustomers = new DataTable();

        // Current customer ID.
        int cCust = -1;

        // Validation
        bool valid = false;
        bool saved = true;

        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            loadCustomers();
            updateLanguage();
            changedText();
            saved = true;
            this.FormClosing += new FormClosingEventHandler(frmCustomers_FormClosing);
        }
        private void frmCustomers_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeForm();
        }

        private void changedText()
        {
            // Saved is now falses.
            saved = false;

            // Reset colors.
            txtbxCustomerName.BackColor = Color.White;
            mtxtbxPhone.BackColor = Color.White;
            txtbxAddress1.BackColor = Color.White;
            txtbxAddress2.BackColor = Color.White;
            txtbxPostal.BackColor = Color.White;
            txtbxCity.BackColor = Color.White;
            cbCountry.BackColor = Color.White;
            cbStatus.BackColor = Color.White;

            // General check and highlighting.
            // If customer name is null ...
            if (txtbxCustomerName.Text == null || txtbxCustomerName.Text == "")
            {
                txtbxCustomerName.BackColor = Color.Salmon;
            }
            // If customer name contains invalid characters ...
            if (txtbxCustomerName.Text.Contains("\\") || txtbxCustomerName.Text.Contains("\""))
            {
                txtbxCustomerName.BackColor = Color.Salmon;
            }
            // Customer name should not be capable of being too long. Skipping.
            // If status is not selected ...
            if (cbStatus.SelectedIndex == -1)
            {
                cbStatus.BackColor = Color.Salmon;
            }
            // If phone number is not completed ...
            if (mtxtbxPhone.MaskCompleted == false)
            {
                mtxtbxPhone.BackColor = Color.Salmon;
            }
            // If the address is blank ...
            if (txtbxAddress1.Text == null || txtbxAddress1.Text == "")
            {
                txtbxAddress1.BackColor = Color.Salmon;
            }
            // Check for invalid characters.
            if (txtbxAddress1.Text.Contains("\\") || txtbxAddress1.Text.Contains("\""))
            {
                txtbxAddress1.BackColor = Color.Salmon;
            }
            // If the second address line is NOT blank ...
            if (txtbxAddress2.Text != null || txtbxAddress2.Text != "")
            {
                // Check for invalid characters.
                if (txtbxAddress2.Text.Contains("\\") || txtbxAddress2.Text.Contains("\""))
                {
                    txtbxAddress2.BackColor = Color.Salmon;
                }
            }
            // If the city is blank ...
            if (txtbxCity.Text == null || txtbxCity.Text == "")
            {
                txtbxCity.BackColor = Color.Salmon;
            }
            // Check for invalid characters.
            if (txtbxCity.Text.Contains("\\") || txtbxCity.Text.Contains("\""))
            {
                txtbxCity.BackColor = Color.Salmon;
            }
            // If the postal code is blank ...
            if (txtbxPostal.Text == null || txtbxPostal.Text == "")
            {
                txtbxPostal.BackColor = Color.Salmon;
            }
            // Check for invalid characters.
            if (txtbxPostal.Text.Contains("\\") || txtbxPostal.Text.Contains("\""))
            {
                txtbxPostal.BackColor = Color.Salmon;
            }
            // Check for country.
            if (cbCountry.SelectedIndex == -1)
            {
                cbCountry.BackColor = Color.Salmon;
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

            // If customer name is null ...
            if (txtbxCustomerName.Text == null || txtbxCustomerName.Text == "")
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nCustomer name can't be blank.";
                        break;
                    case 1:
                        strError += "\nEl nombre del cliente no puede dejarse en blanco.";
                        break;
                }
                valid = false;
            }
            // If customer name contains invalid characters ...
            if (txtbxCustomerName.Text.Contains("\\") || txtbxCustomerName.Text.Contains("\""))
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nCustomer name contains invalid characters (\\ or \").";
                        break;
                    case 1:
                        strError += "\nEl nombre del cliente contiene caracteres no válidos(\\ o \").";
                        break;
                }
                valid = false;
            }
            // Customer name should not be capable of being too long. Skipping.
            // If status is not selected ...
            if (cbStatus.SelectedIndex == -1)
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nMust select a status.";
                        break;
                    case 1:
                        strError += "\nDebe seleccionar un estado.";
                        break;
                }
                valid = false;
            }
            // If phone number is not completed ...
            if(mtxtbxPhone.MaskCompleted == false)
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nEnter phone number, including area code.";
                        break;
                    case 1:
                        strError += "\nIngrese el número de teléfono, incluido el código de área.";
                        break;
                }
                valid = false;
            }
            // If the address is blank ...
            if(txtbxAddress1.Text == null || txtbxAddress1.Text == "")
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nAddress first can not be blank.";
                        break;
                    case 1:
                        strError += "\nLa dirección primero no puede estar en blanco.";
                        break;
                }
                valid = false;

            }
            // Check for invalid characters.
            if (txtbxAddress1.Text.Contains("\\") || txtbxAddress1.Text.Contains("\""))
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nAddress first line name contains invalid characters (\\ or \").";
                        break;
                    case 1:
                        strError += "\nEl nombre de la primera línea de la dirección contiene caracteres no válidos (\\ o \").";
                        break;
                }
                valid = false;
            }
            // If the second address line is NOT blank ...
            if (txtbxAddress2.Text != null || txtbxAddress2.Text != "")
            {
                // Check for invalid characters.
                if (txtbxAddress2.Text.Contains("\\") || txtbxAddress2.Text.Contains("\""))
                {
                    switch (lng)
                    {
                        case 0:
                            strError += "\nAddress second line name contains invalid characters (\\ or \").";
                            break;
                        case 1:
                            strError += "\nEl nombre de la segunda línea de la dirección contiene caracteres no válidos (\\ o \").";
                            break;
                    }
                    valid = false;
                }
            }
            // If the city is blank ...
            if (txtbxCity.Text == null || txtbxCity.Text == "")
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nCity can not be blank.";
                        break;
                    case 1:
                        strError += "\nLa ciudad no puede estar en blanco.";
                        break;
                }
                valid = false;

            }
            // Check for invalid characters.
            if (txtbxCity.Text.Contains("\\") || txtbxCity.Text.Contains("\""))
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nCity contains invalid characters (\\ or \").";
                        break;
                    case 1:
                        strError += "\nLa ciudad contiene caracteres no válidos (\\ o \").";
                        break;
                }
                valid = false;
            }
            // If the postal code is blank ...
            if (txtbxPostal.Text == null || txtbxPostal.Text == "")
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nPostal code can not be blank.";
                        break;
                    case 1:
                        strError += "\nEl código postal no puede dejarse en blanco.";
                        break;
                }
                valid = false;

            }
            // Check for invalid characters.
            if (txtbxPostal.Text.Contains("\\") || txtbxPostal.Text.Contains("\""))
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nPostal code contains invalid characters (\\ or \").";
                        break;
                    case 1:
                        strError += "\nEl código postal contiene caracteres no válidos (\\ o \").";
                        break;
                }
                valid = false;
            }
            // Check for country.
            if(cbCountry.SelectedIndex == -1)
            {
                switch (lng)
                {
                    case 0:
                        strError += "\nPlease select a country.";
                        break;
                    case 1:
                        strError += "\nPor favor seleccione un país.";
                        break;
                }
                valid = false;
            }

            if(valid == false)
            {
                MessageBox.Show(strError);
            }

            return valid;
        }

        private void updateLanguage()
        {
            if(MainSession.csession.Language == "en")
            {
                // Do nothing because it's English by default
                return;
            }
            // If we make it here, it's es.
            lblName.Text = "Nombre del cliente";
            lblStatus.Text = "Estado";
            cbStatus.Items.Clear();
            cbStatus.Items.Add("Activo");
            cbStatus.Items.Add("Inactivo");
            lblPhone.Text = "Número de teléfono";
            lblAddress.Text = "Dirección";
            btnSave.Text = "Ahorrar";
            btnExit.Text = "Salida";
            btnUpdate.Text = "Actualizar";
            btnDelete.Text = "Borrar";
            btnAdd.Text = "Agregar";
            lblAddress2.Text = "Dirección (Opcional)";
            lblCity.Text = "Ciudad";
            lblCountry.Text = "País";
            lblPostal.Text = "Código postal";
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
                if(tmpCust.active == "False")
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // If we have not saved our changes ... 
            if (saved == false)
            {
                string msg = "You have unsaved changes, are you sure you wish to reset the form?";
                string header = "Confirm Lose Changes";
                if (MainSession.csession.Language == "es")
                {
                    msg = "Tiene cambios sin guardar, ¿está seguro de que desea restablecer el formulario? ";
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

            cCust = -1;

            txtbxCustomerName.Text = "";
            cbStatus.SelectedIndex = -1;
            mtxtbxPhone.Text = "";
            txtbxAddress1.Text = "";
            txtbxAddress2.Text = "";
            txtbxPostal.Text = "";
            txtbxCity.Text = "";
            cbCountry.SelectedIndex = -1;
        }

        // Adding changedText() to all boxes.
        private void txtbxCustomerName_TextChanged(object sender, EventArgs e)
        {
            changedText();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            closeForm();
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

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedText();
        }

        private void mtxtbxPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            changedText();
        }

        private void txtbxAddress1_TextChanged(object sender, EventArgs e)
        {
            changedText();
        }

        private void txtbxAddress2_TextChanged(object sender, EventArgs e)
        {
            changedText();
        }

        private void txtbxPostal_TextChanged(object sender, EventArgs e)
        {
            changedText();
        }

        private void txtbxCity_TextChanged(object sender, EventArgs e)
        {
            changedText();
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedText();
        }

        private void dgvCustomers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            loadSelected();
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

            txtbxCustomerName.Text = Convert.ToString(dgvCustomers.Rows[selectedRowCount].Cells[1].Value);
            string strStatus = Convert.ToString(dgvCustomers.Rows[selectedRowCount].Cells[2].Value);
            if (strStatus == "Active")
            {
                cbStatus.SelectedIndex = 0;
            }
            if (strStatus == "Inactive")
            {
                cbStatus.SelectedIndex = 1;
            }
            string strTmpPhone = Convert.ToString(dgvCustomers.Rows[selectedRowCount].Cells[3].Value);

            // PadLeft has made this way easier than the original solution.
            strTmpPhone = strTmpPhone.Replace("(", "").Replace(")", "").Replace("-", "").Replace("+", "").PadLeft(13, '0');

            mtxtbxPhone.Text = strTmpPhone;

            txtbxAddress1.Text = Convert.ToString(dgvCustomers.Rows[selectedRowCount].Cells[4].Value);
            txtbxAddress2.Text = Convert.ToString(dgvCustomers.Rows[selectedRowCount].Cells[5].Value);
            txtbxCity.Text = Convert.ToString(dgvCustomers.Rows[selectedRowCount].Cells[6].Value);
            txtbxPostal.Text = Convert.ToString(dgvCustomers.Rows[selectedRowCount].Cells[7].Value);
            cbCountry.SelectedItem = Convert.ToString(dgvCustomers.Rows[selectedRowCount].Cells[8].Value);

            changedText();
            saved = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            loadSelected();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Confirm our action
            string msg = "Are you certain you wish to delete the selected customer? This can not be undone.";
            string header = "Confirm Delete Customer";
            if (MainSession.csession.Language == "es")
            {
                msg = "¿Está seguro de que desea eliminar el cliente seleccionado? Esto no se puede deshacer.";
                header = "Confirmar eliminar cliente";
            }

            DialogResult result = MessageBox.Show(msg, header, MessageBoxButtons.YesNo);

            // If no ...
            if (result == DialogResult.No)
            {
                //Do nothing
                return;
            }

            // Identify our customer.
            int selectedRowCount = dgvCustomers.CurrentCell.RowIndex;

            int deleteCustomerId = Convert.ToInt32(dgvCustomers.Rows[selectedRowCount].Cells[0].Value);

            MainSession.csession.customerList.deleteCustomer(deleteCustomerId);

            // Reload our list.
            loadCustomers();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // If not valid, do nothing.
            if (validate() == false)
            {
                return;
            }

            // Create our customer object.
            Customer tmpCustomer = new Customer();
            Address tmpAddress = new Address();
            City tmpCity = new City();

            tmpCustomer.customerName = txtbxCustomerName.Text;
            if (cbStatus.SelectedIndex == 0)
            {
                tmpCustomer.active = "True";
            }
            if (cbStatus.SelectedIndex == 1)
            {
                tmpCustomer.active = "False";
            }
            tmpAddress.address = txtbxAddress1.Text;
            tmpAddress.address2 = txtbxAddress2.Text;
            tmpAddress.postalCode = txtbxPostal.Text;
            tmpAddress.phone = mtxtbxPhone.Text;
            tmpCity.city = txtbxCity.Text;
            tmpCity.country = cbCountry.Text;

            tmpAddress.city = tmpCity;

            tmpCustomer.address = tmpAddress;

            // -1 indicates it's a new customer.
            if(cCust == -1)
            {
                MessageBox.Show("New");
                // We know this is a new customer.

                tmpCustomer.addressId = -1;
                tmpCustomer.address.addressId = -1;
                tmpCustomer.address.cityId = -1;
                tmpCustomer.address.city.cityId = -1;
                tmpCustomer.address.city.countryId = -1;

                cCust = MainSession.csession.customerList.createCustomer(tmpCustomer);

                // Reload our list.
                loadCustomers();
                saved = true;
                return;
            }
            if (cCust != -1)
            {
                MessageBox.Show("Updating");
                // We need to gather the rest of our values.
                // Pull the original customer from our list for comparison.
                Customer original = new Customer();

                bool found = false;

                foreach (Customer tmpCust in customers)
                {
                    if (cCust == tmpCust.customerId)
                    {
                        original = tmpCust;
                        found = true;
                        break;
                    }
                }

                // Throw error if we don't find it and can't update them.
                if (found == false)
                {
                    MainSession.csession.csError(5);
                    return;
                }

                // Update our IDs.
                tmpCustomer.addressId = original.addressId;
                tmpCustomer.address.addressId = original.address.addressId;
                tmpCustomer.address.cityId = original.address.cityId;
                tmpCustomer.address.city.cityId = original.address.city.cityId;
                tmpCustomer.address.city.countryId = original.address.city.countryId;
                                
                // Save our customer object.
                MainSession.csession.customerList.updateCustomer(cCust, tmpCustomer, original);

                // Reload our list.
                loadCustomers();
                saved = true;
                return;
            }

        }
    }
}
