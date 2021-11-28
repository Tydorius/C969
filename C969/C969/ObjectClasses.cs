using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace C969
{
    public class User
    {
        public int userId;
        public string userName;
        public string password;
        public int active;

        // Ignore. Starting at the Day level.

        public Month loadMonth(DateTime selectedDate)
        {
            var firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            return null;
        }

        public Week loadWeek(DateTime selectedWeek)
        {
            return null;
        }
    }

    public class Calendar
    {
        public Month selectedMonth;
    }

    public class Month
    {
        public int startingWeekDay;
        public int weekCount;
        public BindingList<Day> DayList;
    }

    public class Week
    {
        public BindingList<Day> Sunday;
        public BindingList<Day> Monday;
        public BindingList<Day> Tuesday;
        public BindingList<Day> Wednesday;
        public BindingList<Day> Thursday;
        public BindingList<Day> Friday;
        public BindingList<Day> Saturday;
    }

    public class Day
    {
        public DateTime Date;
        public BindingList<Appointment> AppointmentList = new BindingList<Appointment>();
        public int offset = Convert.ToInt32(DateTimeOffset.Now.Offset.Hours);

        public int loadAppointments(DateTime selectedDay, int userId)
        {
            int revoffset = (offset * -1);

            string strStart = selectedDay.ToUniversalTime().ToString("yyyy-MM-dd");
            string strEnd = selectedDay.AddDays(1).ToUniversalTime().ToString("yyyy-MM-dd");

            string strQuery = "SELECT customerId,title,description,location,contact,type,url,start,end,appointmentId FROM appointment WHERE userId = " + Convert.ToString(userId) + " AND start >= DATE_ADD(CAST('" + strStart + " 00:00:00' AS datetime), interval " + Convert.ToString(revoffset) + " hour) AND end < DATE_ADD(CAST('" + strEnd + " 00:00:00' AS datetime), interval " + Convert.ToString(revoffset) + " hour);";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

            if(lstResult.Count == 0)
            {
                return 0;
            }

            BindingList<Appointment> result = new BindingList<Appointment>();

            foreach (List<string> line in lstResult)
            {
                Appointment tmpAppointment = new Appointment();
                
                tmpAppointment.appointmentId = Convert.ToInt32(line[9]);
                tmpAppointment.customerId = Convert.ToInt32(line[0]);
                tmpAppointment.title = line[1];
                tmpAppointment.description = line[2];
                tmpAppointment.location = line[3];
                tmpAppointment.contact = line[4];
                tmpAppointment.type = line[5];
                tmpAppointment.url = line[6];

                // Use Lambda to convert our times.
                tmpAppointment.start = MainSession.csession.UTCToLocal(DateTime.Parse(line[7]));
                tmpAppointment.end = MainSession.csession.UTCToLocal(DateTime.Parse(line[8]));

                result.Add(tmpAppointment);

            }

            AppointmentList = result;
            return lstResult.Count;
        }
    }

    public class Appointment
    {
        public int appointmentId;
        public int customerId;
        public int userId;
        public string title;
        public string description;
        public string location;
        public string contact;
        public string type;
        public string url;
        public DateTime start;
        public DateTime end;
        public DateTime createDate;
        public string createdBy;
        public DateTime lastUpdate;
        public string lastUpdateBy;

        int offset = Convert.ToInt32(DateTimeOffset.Now.Offset.Hours);

        public void deleteAppointment(int appointmentId)
        {
            string strQuery = "DELETE FROM appointment WHERE appointmentId = " + Convert.ToString(appointmentId) + ";";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);
        }

        public bool checkConflicts(DateTime start, DateTime end, int customerId, int userId, int AppointmentId)
        {
            // Update our date times using our Lambda. Convert to strings for SQL check.
            string strStart = MainSession.csession.LocalToUTC(start).ToString("yyyy-MM-ddTHH:mm:ss");
            string strEnd = MainSession.csession.LocalToUTC(end).ToString("yyyy-MM-ddTHH:mm:ss");

            // Since AppointmentId is -1 for new events, this still works with no modifications.
            // Otherwise, it pulls all events other than our current event that potentially conflict.
            string strQuery = "SELECT * FROM appointment WHERE appointmentId != " + Convert.ToString(AppointmentId) + " AND ((CAST('" + strStart + "' AS datetime) > start AND CAST('" + strStart + "' AS datetime) < end) OR (CAST('" + strEnd + "' AS datetime) > start AND CAST('" + strEnd + "' AS datetime) < end) OR (CAST('" + strStart + "' AS datetime) < start AND CAST('" + strEnd + "' AS datetime) > end)) AND (customerId = " + Convert.ToString(customerId) + " OR userId = " + Convert.ToString(userId) + ");";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

            // If our result is greater than 0...
            if(lstResult.Count > 0)
            {
                // There's a conflict.
                return true;
            }
            // Otherwise, there isn't.
            return false;
        }

        public Appointment lookupAppointment(int AppointmentId)
        {
            // Create new appointment.
            Appointment result = new Appointment();

            // Query to lookup by appointment ID.
            // Returning specific fields instead of * so that we know the order even if it changes in the database later.
            string strQuery = "SELECT customerId, title, description, location, contact, type, url, start, end FROM appointment WHERE appointmentId = " + Convert.ToString(AppointmentId) + ";";

            // Run the query.
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

            // Populate appointment properties.
            result.appointmentId = AppointmentId;
            result.customerId = Convert.ToInt32(lstResult[0][0]);
            result.title = lstResult[0][1];
            result.description = lstResult[0][2];
            result.location = lstResult[0][3];
            result.contact = lstResult[0][4];
            result.type = lstResult[0][5];
            result.url = lstResult[0][6];

            // Use Lambda to convert from UTC to Local for looking up the appointment.
            result.start = MainSession.csession.UTCToLocal(DateTime.Parse(lstResult[0][7]));
            result.end = MainSession.csession.UTCToLocal(DateTime.Parse(lstResult[0][8]));

            // Return our appointment result.
            return result;
        }

        public int saveAppointment(Appointment newAppointment, int AppointmentId)
        {
            // Convert our date times.
            newAppointment.start = MainSession.csession.LocalToUTC(newAppointment.start);
            newAppointment.end = MainSession.csession.LocalToUTC(newAppointment.end);

            // Generate strings for SQL.
            string strStart = newAppointment.start.ToString("yyyy-MM-ddTHH:mm:ss");
            string strEnd = newAppointment.end.ToString("yyyy-MM-ddTHH:mm:ss");

            // We need to get our timestamp first.
            string strCreatedDate = DateTime.UtcNow.ToString("o");

            // We want to trim off everything including and after the "." so it matches our format in SQL.
            int i = strCreatedDate.IndexOf(".");
            if (i >= 0)
            {
                strCreatedDate = strCreatedDate.Substring(0, i);
            }
            // Get the username.
            string strUser = MainSession.csession.user.userName;
            
            // Initialize empty string query.
            string strQuery = "";

            // New appointment
            if (AppointmentId == -1)
            {
                strQuery = "INSERT INTO appointment(customerId,userId,type,url,start,end,createDate,createdBy,lastUpdate,lastUpdateBy,title,description,location,contact) VALUES(" + Convert.ToString(newAppointment.customerId) + ", " + Convert.ToString(newAppointment.userId) + ", '" + newAppointment.type + "', '" + newAppointment.url + "', CAST('" + strStart + "' AS datetime), CAST('" + strEnd + "' AS datetime), CAST('" + strCreatedDate + "' AS datetime), '" + strUser + "', CAST('" + strCreatedDate + "' AS datetime), '" + strUser + "','title','description','location','contact');";

                // Run the query.
                List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

                // Return the appointment ID.
                strQuery = "SELECT appointmentId FROM appointment WHERE customerId = " + Convert.ToString(newAppointment.customerId) + " AND  userId = " + Convert.ToString(newAppointment.userId) + " AND  type = '" + newAppointment.type + "' AND url = '" + newAppointment.url + "' AND start = CAST('" + strStart + "' AS datetime) AND end = CAST('" + strEnd + "' AS datetime);";
                lstResult = MainSession.csession.conn.TryQuery(strQuery);
                int result =  Convert.ToInt32(lstResult[0][0]);

                // Feedback.
                MessageBox.Show("Appointment ID " + Convert.ToString(result) + " saved!");

                return result;
            }

            // Update appointment
            if (AppointmentId != -1)
            {
                strQuery = "UPDATE appointment SET customerId = " + Convert.ToString(newAppointment.customerId) + ", userId = " + Convert.ToString(newAppointment.userId) + ", type = '" + newAppointment.type + "', url = '" + newAppointment.url + "', start = CAST('" + strStart + "' AS datetime), end = CAST('" + strEnd + "' AS datetime), lastUpdate = CAST('" + strCreatedDate + "' AS datetime), lastUpdateBy = '" + strUser + "' WHERE AppointmentId = " + Convert.ToString(AppointmentId) + ";";

                // Run the query.
                List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

                // Feedback.
                MessageBox.Show("Appointment ID " + Convert.ToString(AppointmentId) + " updated!");

                // Return the ID.
                return AppointmentId;
            }

            MessageBox.Show("Error. saveAppointment did not trigger either if function.");
            return AppointmentId;
        }

    }

    public class customerList
    {
        public BindingList<Customer> customers = new BindingList<Customer>();

        public void deleteCustomer(int custID)
        {
            string strQuery = "DELETE FROM Customer WHERE CustomerId = " + Convert.ToString(custID) + ";";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);
        }

        public int createCustomer(Customer newCust)
        {
            // Get the country ID.
            string strQuery = "SELECT countryId FROM country WHERE country = '" + newCust.address.city.country + "';";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

            newCust.address.city.countryId = Convert.ToInt32(lstResult[0][0]);

            // See if the city exists. If not, create it.
            int cityExists = newCust.address.city.lookupCity(newCust.address.city);
            if (cityExists == -1)
            {
                newCust.address.cityId = newCust.address.city.createCity(newCust.address.city);
                newCust.address.city.cityId = newCust.address.cityId;
            }
            if (cityExists != -1)
            {
                newCust.address.cityId = cityExists;
                newCust.address.city.cityId = cityExists;
            }

            // The address should ALWAYS be new, because two customers can exist at the same address.
            newCust.addressId = newCust.address.createAddress(newCust.address);
            newCust.address.addressId = newCust.addressId;

            // We need to get our timestamp first.
            // We want to trim off everything including and after the ".".
            string strCreatedDate = DateTime.UtcNow.ToString("o");
            int i = strCreatedDate.IndexOf(".");
            if (i >= 0)
            {
                strCreatedDate = strCreatedDate.Substring(0, i);
            }
            string strUser = MainSession.csession.user.userName;

            // Create customer.
            strQuery = "INSERT INTO customer(customerName,addressId,active,createDate,createdBy,lastUpdate,lastUpdateBy) VALUES('" + newCust.customerName + "'," + newCust.addressId + "," + newCust.active + ", CAST('" + strCreatedDate + "' AS datetime), '" + strUser + "', CAST('" + strCreatedDate + "' AS datetime), '" + strUser + "');";
            lstResult = MainSession.csession.conn.TryQuery(strQuery);

            // Select our new ID and return it.
            strQuery = "SELECT customerId FROM customer WHERE customerName = '" + newCust.customerName + "' AND addressId = " + newCust.addressId + " AND active = " + newCust.active + " AND createDate = CAST('" + strCreatedDate + "' AS datetime) AND createdBy = '" + strUser + "';";
            lstResult = MainSession.csession.conn.TryQuery(strQuery);

            int result = Convert.ToInt32(lstResult[0][0]);

            return result;
        }

        public void updateCustomer(int custID, Customer newCust, Customer original)
        {

            int addressID = newCust.address.updateAddress(newCust.addressId, newCust.address, original.address);

            // We need to get our timestamp first.
            // We want to trim off everything including and after the ".".
            string strCreatedDate = DateTime.UtcNow.ToString("o");
            int i = strCreatedDate.IndexOf(".");
            if (i >= 0)
            {
                strCreatedDate = strCreatedDate.Substring(0, i);
            }
            string strUser = MainSession.csession.user.userName;

            string strQuery = "UPDATE customer SET customerName = '" + newCust.customerName + "', addressId = " + Convert.ToString(addressID) + ", active = " + newCust.active + ", lastUpdate = CAST('" + strCreatedDate + "' AS datetime), lastUpdateBy = '" + strUser + "' WHERE customerId = " + Convert.ToString(custID) + ";";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

        }

        public BindingList<Customer> loadCustomers()
        {

            customers = new BindingList<Customer>();

            string strQuery = "SELECT a.customerId, a.customerName, a.active, b.addressId, b.address, b.address2, c.cityId, b.postalCode, b.phone, c.city, d.countryId, d.country FROM customer a LEFT JOIN address b ON a.addressId = b.addressId LEFT JOIN city c ON b.cityId = c.cityId LEFT JOIN country d ON c.countryId = d.countryid";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

            // Validate our results

            foreach(List<string> lineResult in lstResult)
            {
                Customer tmpCust = new Customer();
                Address tmpAddr = new Address();
                City tmpCity = new City();
                tmpCust.customerId = Convert.ToInt32(lineResult[0]);
                tmpCust.customerName = lineResult[1];
                tmpCust.active = lineResult[2];
                tmpCust.addressId = Convert.ToInt32(lineResult[3]);
                tmpAddr.addressId = Convert.ToInt32(lineResult[3]);
                tmpAddr.address = lineResult[4];
                tmpAddr.address2 = lineResult[5];
                tmpAddr.cityId = Convert.ToInt32(lineResult[6]);
                tmpCity.cityId = Convert.ToInt32(lineResult[6]);
                tmpAddr.postalCode = lineResult[7];
                tmpAddr.phone = lineResult[8];
                tmpCity.city = lineResult[9];
                tmpCity.countryId = Convert.ToInt32(lineResult[10]);
                tmpCity.country = lineResult[11];
                tmpAddr.city = tmpCity;
                tmpCust.address = tmpAddr;

                customers.Add(tmpCust);
            }
            return customers;
        }
    }

    public class Customer
    {
        public int customerId;
        public string customerName;
        public int addressId;
        public string active;
        public Address address;
    }

    public class Address
    {
        public int addressId;
        public string address;
        public string address2;
        public int cityId;
        public string postalCode;
        public string phone;
        public City city;

        public int updateAddress(int addressID, Address newAddress, Address oldaddress)
        {
            // Update the city first.
            int newCityID = newAddress.city.updateCity(newAddress.city.cityId, newAddress.city, oldaddress.city);

            // Set the new ID, in the event that updateCity created a new city instead.
            newAddress.cityId = newCityID;

            // Look up the current address. This only returns if the exact address matches. We've included phone updates here just for the sake of simplicity.
            int isOldAddress = lookupAddress(newAddress, true);

            if (isOldAddress != -1)
            {
                // If the address hasn't changed, we're done.
                return newAddress.addressId;
            }
            // We need to get our timestamp first.
            // We want to trim off everything including and after the ".".
            string strCreatedDate = DateTime.UtcNow.ToString("o");
            int i = strCreatedDate.IndexOf(".");
            if (i >= 0)
            {
                strCreatedDate = strCreatedDate.Substring(0, i);
            }
            string strUser = MainSession.csession.user.userName;

            // If the address has changed, we need to actually update the address.
            string strQuery = "UPDATE address SET address = '" + newAddress.address + "', address2 = '" + newAddress.address2 + "', cityId = " + Convert.ToString(newAddress.cityId) + ", postalCode = '" + newAddress.postalCode + "', phone = '" + newAddress.phone + "', lastUpdate = CAST('" + strCreatedDate + "' AS datetime), lastUpdateBy = '" + strUser + "' WHERE addressId = " + Convert.ToString(newAddress.addressId) + ";";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

            return addressID;
        }

        public int createAddress(Address newAddress)
        {
            // This should only happen for new customers.

            // We need to get our timestamp first.
            // We want to trim off everything including and after the ".".
            string strCreatedDate = DateTime.UtcNow.ToString("o");
            int i = strCreatedDate.IndexOf(".");
            if (i >= 0)
            {
                strCreatedDate = strCreatedDate.Substring(0, i);
            }
            string strUser = MainSession.csession.user.userName;

            // Create our string.
            string strQuery = "INSERT INTO address (address,address2,cityId,postalCode,phone,createDate,createdBy,lastUpdate,lastUpdateBy) VALUES ('" + newAddress.address + "', '" + newAddress.address2 + "', " + Convert.ToString(newAddress.cityId) + ", '" + newAddress.postalCode + "', '" + newAddress.phone + "', CAST('" + strCreatedDate + "' AS datetime), '" + strUser + "', CAST('" + strCreatedDate + "' AS datetime), '" + strUser + "');";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

            // Now we pull our new address's ID
            strQuery = "SELECT addressId FROM address WHERE address = '" + newAddress.address + "' AND address2 = '" + newAddress.address2 + "' AND cityId = " + Convert.ToString(newAddress.cityId) + " AND postalCode = '" + newAddress.postalCode + "';";
            lstResult = MainSession.csession.conn.TryQuery(strQuery);

            int result = Convert.ToInt32(lstResult[0][0]);

            return result;
        }

        public int lookupAddress(Address tmpAddress, bool updatePhone)
        {
            // Returns the address ID if it's found.
            // Set our initial result. This is -1. If it returns -1, then we are telling the calling method that the address was not found.
            int result = -1;

            // Build our query to find our address.
            string strQuery = "SELECT addressId FROM address WHERE addressId = " + Convert.ToString(tmpAddress.addressId) + " AND address = '" + tmpAddress.address + "' AND address2 = '" + tmpAddress.address2 + "' AND cityId = " + Convert.ToString(tmpAddress.cityId) + " AND postalCode = '" + tmpAddress.postalCode + "';";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

            // If we get only one result, we know we're good to go. But if we get 0, we know there's an issue.
            if(lstResult.Count != 1)
            {
                if(lstResult.Count > 1 )
                {
                    // If we get more than one result, there's an error.
                    MainSession.csession.csError(2);
                    // We want to abort any database action in this event.
                    Environment.Exit(0);
                }
                // If we get no results, we return -1.
                return -1;
            }

            // If we make it here, we have a match.
            result = Convert.ToInt32(lstResult[0][0]);

            // Otherwise, does the phone number match and need to be updated?
            if(updatePhone == false)
            {
                // Just return if we don't care to update the phone number.
                return result;
            }
            // We need to get our timestamp first.
            // We want to trim off everything including and after the ".".
            string strCreatedDate = DateTime.UtcNow.ToString("o");
            int i = strCreatedDate.IndexOf(".");
            if (i >= 0)
            {
                strCreatedDate = strCreatedDate.Substring(0, i);
            }
            string strUser = MainSession.csession.user.userName;

            strQuery = "UPDATE address SET phone = '" + tmpAddress.phone + "', lastUpdate = CAST('" + strCreatedDate + "' AS datetime), lastUpdateBy = '" + strUser + "' WHERE addressId = " + Convert.ToString(tmpAddress.addressId) + ";";
            lstResult = MainSession.csession.conn.TryQuery(strQuery);

            return result;
        }
    }

    public class City
    {
        public int cityId;
        public string city;
        public int countryId;
        public string country;

        public int updateCity(int cityID, City newCity, City oldCity)
        {

            if(lookupCity(newCity) != -1)
            {
                // If it's not new, we don't need to do anyting else.
                return lookupCity(newCity);
            }
            // If it's new ...
            int newCityId = createCity(newCity);

            // Return city ID
            return newCityId;
        }

        public string lookupCountryID(City tmpCity)
        {
            // Create our string.
            string strQuery = "SELECT countryId from country where country = '" + tmpCity.country + "';";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

            return lstResult[0][0];
        }

        public int createCity(City tmpCity)
        {
            // We need to get our timestamp first.
            // We want to trim off everything including and after the ".".
            string strCreatedDate = DateTime.UtcNow.ToString("o");
            int i = strCreatedDate.IndexOf(".");
            if (i >= 0)
            {
                strCreatedDate = strCreatedDate.Substring(0, i);
            }
            string strUser = MainSession.csession.user.userName;
            string strCountryID = tmpCity.lookupCountryID(tmpCity);

            // Create our string.
            string strQuery = "INSERT INTO city (city,countryId,createDate,createdBy,lastUpdate,lastUpdateBy) VALUES ('" + tmpCity.city + "', " + strCountryID + ", CAST('" + strCreatedDate + "' AS datetime), '" + strUser + "', CAST('" + strCreatedDate + "' AS datetime), '" + strUser + "');";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

            // Now we pull our new city's ID
            strQuery = "SELECT cityId FROM city WHERE city = '" + tmpCity.city + "' AND countryId = " + strCountryID + ";";
            lstResult = MainSession.csession.conn.TryQuery(strQuery);

            int result = Convert.ToInt32(lstResult[0][0]);

            return result;
        }

        public int lookupCity(City tmpCity)
        {
            // Return false if the city is not found, aka if it's a new city.

            // First, check that the country ID matches. If it doesn't, that's a clear indication.
            string strQuery = "SELECT countryId from country where country = '" + tmpCity.country + "';";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);

            // If we only have one line (Our header), we know it's false.
            if (lstResult.Count != 1)
            {
                return -1;
            }

            // If the country matches, check to see if the city itself matches in its current form.
            strQuery = "SELECT cityId from city where city = '" + tmpCity.city + "' AND countryId = " + tmpCity.countryId + ";";
            lstResult = MainSession.csession.conn.TryQuery(strQuery);

            // If we only have one line (Our header), we know it's false.
            if (lstResult.Count != 1)
            {
                return -1;
            }

            // If we make it here, this is an old city.
            return Convert.ToInt32(lstResult[0][0]);
        }
    }

}
