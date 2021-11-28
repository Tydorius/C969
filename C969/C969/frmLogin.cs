using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace C969
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        { 

            // Set initial language.
            if (MainSession.csession.Language =="en")
            {
                MessageBox.Show("English detected as environment language. Setting to English. Additionally, your timezone offset has been detected as " + Convert.ToString(MainSession.offset));
            }
            if(MainSession.csession.Language == "es")
            {
                MessageBox.Show("El español detectado como lengua ambiental. Configuración al español. Tenga en cuenta que la rúbrica solo cubre el español para el formulario de inicio de sesión. No es totalmente compatible con el resto de la aplicación. Además, la diferencia de zona horaria se ha detectado como " + Convert.ToString(MainSession.offset));

                btnLanguage.Text = "English";
                lblPassword.Text = "Contraseña:";
                lblUsername.Text = "Usuario:";
                btnLogin.Text = "Acceso";
                btnExit.Text = "Salida";
                this.Text = "C969 | Acceso";
                MainSession.csession.Language = "es";

            }
            // If an unknown language is detected, we display an error in both English and Spanish.
            if(MainSession.csession.Language != "en" && MainSession.csession.Language != "es")
            {
                MessageBox.Show("Unknown language detected. Defaulting to English.\nSe detectó un idioma desconocido.Por defecto al inglés.");
                MainSession.csession.Language = "en";
            }

            // Initialize connection.
            MainSession.csession.conn.TryConnect();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Ensure both fields are completed.
            if(txtbxUsername.Text == "" || mtxtbxPassword.Text == "")
            {
                MainSession.csession.csError(4);
                return;
            }

            // Query our user list.
            string strQuery = "SELECT * FROM user where userName = '" + txtbxUsername.Text + "' AND password = '" + mtxtbxPassword.Text + "'";
            List<List<string>> lstResult = MainSession.csession.conn.TryQuery(strQuery);
            
            // Exception code. There will always be 2 results, because the first one is the column headers.
            // If there are NOT two results, we have either too many or there's an issue with the database.
            // Added null check as well.
            if(lstResult == null)
            {
                MainSession.csession.csError(0);
                return;
            }
            if (lstResult.Count == 0)
            {
                MainSession.csession.csError(1);
                return;
            }
            if (lstResult.Count > 1)
            {
                MainSession.csession.csError(2);
                return;
            }
            // Lastly, check if the user is active
            if (lstResult[0][3] == "0")
            {
                MainSession.csession.csError(3);
                return;
            }

            // If we make it here, then the login was successful because we have one exact match on username and password.
            // Create our user object.

            MainSession.csession.user.userId = Convert.ToInt32(lstResult[0][0]);
            MainSession.csession.user.userName = lstResult[0][1];

            // If the parts CSV file does not exist ...
            if (File.Exists(FileTree.strLogFile) != true)
            {
                // ... Create a new file.
                using (FileStream fs = File.Create(FileTree.strLogFile))
                {
                    //Add our headers
                    Byte[] headers = new UTF8Encoding(true).GetBytes("UserId,Username,Login DateTime");
                    fs.Write(headers, 0, headers.Length);
                    fs.Dispose();
                }                                               
            }

            // Build log line.
            string loginLog = lstResult[0][0] + "," + txtbxUsername.Text + "," + DateTime.Now;
            // Implement append.
            StreamWriter sw = File.AppendText(FileTree.strLogFile);
            // Append.
            sw.WriteLine(loginLog);

            sw.Dispose();

            // Show calendar form.
            MainSession.frmCalendar.Show();

            // Hide this form.
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Ensures we close our connection and exit.
            MainSession.csession.conn.conn.Close();
            Environment.Exit(0);
            
        }
        private void btnLanguage_Click(object sender, EventArgs e)
        {
            // Run the change language method.
            changeLanguage();
        }

        public void changeLanguage()
        {
            // Flip based upon the language.
            if (MainSession.csession.Language == "en")
            {
                btnLanguage.Text = "English";
                lblPassword.Text = "Contraseña:";
                lblUsername.Text = "Usuario:";
                btnLogin.Text = "Acceso";
                btnExit.Text = "Salida";
                this.Text = "C969 | Acceso";
                MainSession.csession.Language = "es";
                return;
            }
            if (MainSession.csession.Language == "es")
            {
                btnLanguage.Text = "Español";
                lblPassword.Text = "Password:";
                lblUsername.Text = "Username:";
                btnLogin.Text = "Login";
                btnExit.Text = "Exit";
                this.Text = "C969 | Login";
                MainSession.csession.Language = "en";
                return;
            }

        }

    }
}
