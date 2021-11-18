using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace C969
{
    static class MainSession
    {
        // Initialize session and make it globally available.
        public static CurrentSession csession = new CurrentSession();
        public static frmCalendar frmCalendar = new frmCalendar();
        public static int offset = Convert.ToInt32(DateTimeOffset.Now.Offset.Hours);

    }
    // FileTree stores our static file names for the application. These are static global variables.
    static class FileTree
    {
        // Obtain the current directory.
        public static string strHomeDirectory = AppDomain.CurrentDomain.BaseDirectory;
        // Our inventory list CSV file.
        public static string strLogFile = strHomeDirectory + "\\access.log";
    }
    public class CurrentSession
    {
        public User user = new User();
        public TimeZone ctz = System.TimeZone.CurrentTimeZone;
        public Connection conn = new Connection();
        public customerList customerList = new customerList();

        // Detect current language.
        public string Language = CultureInfo.CurrentCulture.Name;   

        // Dual-language error messages.
        public void csError(int code)
        {
            string strErr = "";
            if(Language == "en")
            {
                switch(code)
                {
                    case 0:
                        strErr = "Error. Unable to connect to user list.";
                        break;
                    case 1:
                        strErr = "Wrong username or password.";
                        break;
                    case 2:
                        strErr = "Error. Too many results. Contact database administrator.";
                        break;
                    case 3:
                        strErr = "User is inactive. Contact database administrator.";
                        break;
                    case 4:
                        strErr = "Both fields are required.";
                        break;
                    case 5:
                        strErr = "Item not found in database. Can not update.";
                        break;
                }
            }
            if(Language == "es")
            {
                switch (code)
                {
                    case 0:
                        strErr = "Error.No se puede conectar a la lista de usuarios.";
                        break;
                    case 1:
                        strErr = "Nombre de usuario o contraseña incorrectos.";
                        break;
                    case 2:
                        strErr = "Error. Demasiados resultados. Póngase en contacto con el administrador de la base de datos.";
                        break;
                    case 3:
                        strErr = "El usuario está inactivo. Póngase en contacto con el administrador de la base de datos.";
                        break;
                    case 4:
                        strErr = "Ambos campos son obligatorios.";
                        break;
                    case 5:
                        strErr = "Elemento no encontrado en la base de datos. No se puede actualizar.";
                        break;
                }
            }
            MessageBox.Show(strErr);
            return;
        }
    }
    public class Connection
    {
        // Create our global connection.
        public MySql.Data.MySqlClient.MySqlConnection conn;
        // MySQL Connection String.
        public string myConnectionString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";

        // Open our connection.
        public Boolean TryConnect()
        {
            try
            {
                // Reset our existing connection.
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                // Add our connection string.
                conn.ConnectionString = myConnectionString;
                // Open
                conn.Open();
                // Return success.
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                // Catch our error.
                MessageBox.Show(ex.Message);
                // Return failure.
                return false;
            }
        }

        // Method to process a query.
        public List<List<string>> TryQuery(string strQuery)
        {
            try
            {
                // Build our command and reader.
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Get our results into a list.
                List<List<string>> lstResult = new List<List<string>>();

                // Count our columns.
                int intFieldCount = rdr.FieldCount;

                int i = 0;

                // Read our results into our list.
                while (rdr.Read())
                {
                    List<string> strRow = new List<string>();
                    i = 0;
                    while (i < intFieldCount)
                    {
                        strRow.Add(rdr.GetString(i));
                        i++;
                    }
                    lstResult.Add(strRow);
                }
                rdr.Close();
                return lstResult;
            }
            catch (Exception ex)
            {
                // Catch errors.
                MessageBox.Show(ex.Message);
                // Return error status.
                return null;
            }
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
