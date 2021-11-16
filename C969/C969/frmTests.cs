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
    public partial class frmTests : Form
    {
        public Address testLookupAddress = new Address();
        public City testLookupCity = new City();
        public Address testOldAddress = new Address();
        public City testOldCity = new City();

        public frmTests()
        {
            InitializeComponent();
        }

        private void btncreateAddress_Click(object sender, EventArgs e)
        {
            testLookupCity.city = "New York";
            testLookupCity.cityId = 1;
            testLookupCity.country = "US";
            testLookupCity.countryId = 1;

            testLookupAddress.city = testLookupCity;
            testLookupAddress.cityId = 1;
            testLookupAddress.address = "Address 234";
            testLookupAddress.address2 = "New data";
            testLookupAddress.addressId = 1;
            testLookupAddress.phone = "1-234-555-1142";
            testLookupAddress.postalCode = "25743";

            MessageBox.Show(Convert.ToString(testLookupAddress.createAddress(testLookupAddress)));
        }

        private void btnupdateAddress_Click(object sender, EventArgs e)
        {
            testLookupCity.city = "New York";
            testLookupCity.cityId = 1;
            testLookupCity.country = "US";
            testLookupCity.countryId = 1;

            testOldAddress.city = testLookupCity;
            testOldAddress.cityId = 1;
            testOldAddress.address = "456 Main";
            testOldAddress.address2 = "New data";
            testOldAddress.addressId = 13;
            testOldAddress.phone = "555-1142";
            testOldAddress.postalCode = "12345";

            testLookupAddress.city = testLookupCity;
            testLookupAddress.cityId = 1;
            testLookupAddress.address = "123 Main";
            testLookupAddress.address2 = "New data";
            testLookupAddress.addressId = 13;
            testLookupAddress.phone = "555-1142";
            testLookupAddress.postalCode = "12345";

            MessageBox.Show(Convert.ToString(testLookupAddress.updateAddress(testLookupAddress.addressId, testLookupAddress, testOldAddress)));
        }

        private void btnlookupAddress_Click(object sender, EventArgs e)
        {
            testLookupCity.city = "New York";
            testLookupCity.cityId = 1;
            testLookupCity.country = "US";
            testLookupCity.countryId = 1;

            testLookupAddress.city = testLookupCity;
            testLookupAddress.cityId = 1;
            testLookupAddress.address = "123 Main";
            testLookupAddress.address2 = "";
            testLookupAddress.addressId = 1;
            testLookupAddress.phone = "555-1212";
            testLookupAddress.postalCode = "11111";

            MessageBox.Show(Convert.ToString(testLookupAddress.lookupAddress(testLookupAddress, false)));

        }

        private void frmTests_Load(object sender, EventArgs e)
        {

        }

        private void btnlookupCountryID_Click(object sender, EventArgs e)
        {
            testLookupCity.city = "New York";
            testLookupCity.cityId = 1;
            testLookupCity.country = "US";
            testLookupCity.countryId = 1;

            MessageBox.Show(Convert.ToString(testLookupCity.lookupCountryID(testLookupCity)));
        }

        private void btnlookupCity_Click(object sender, EventArgs e)
        {
            testLookupCity.city = "New York";
            testLookupCity.cityId = 1;
            testLookupCity.country = "US";
            testLookupCity.countryId = 1;

            MessageBox.Show(Convert.ToString(testLookupCity.lookupCity(testLookupCity)));
        }

        private void btnupdateCity_Click(object sender, EventArgs e)
        {
            testLookupCity.city = "Indianapolis";
            testLookupCity.cityId = 1;
            testLookupCity.country = "US";
            testLookupCity.countryId = 1;

            testOldCity.city = "New York";
            testOldCity.cityId = 1;
            testOldCity.country = "US";
            testOldCity.countryId = 1;

            MessageBox.Show(Convert.ToString(testLookupCity.updateCity(testLookupCity.cityId, testLookupCity, testOldCity)));
        }

        private void btncreateCity_Click(object sender, EventArgs e)
        {
            testLookupCity.city = "OmNomNom";
            testLookupCity.cityId = 6;
            testLookupCity.country = "Norway";
            testLookupCity.countryId = 3;

            MessageBox.Show(Convert.ToString(testLookupCity.createCity(testLookupCity)));
        }
    }
}
