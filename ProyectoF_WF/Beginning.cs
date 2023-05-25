using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ProyectoF_WF.Classes;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Newtonsoft.Json;
using ProyectoF_WF.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

namespace ProyectoF_WF
{
    public partial class Beginning : Form
    {
        private UserManager _userManager;
        private Administrator _administrator;

        public Beginning()
        {
            InitializeComponent();
            // Alignment of the panel relative to the form size
            _userManager = new UserManager();
            // Leer los archivos JSON y cargar los usuarios
            _userManager.LoadUsers();
            pnlBEGLogin.BackColor = Color.FromArgb(150, Color.Violet);
            pnlBEGLogin.Location = new Point((this.ClientSize.Width - pnlBEGLogin.Width) / 2, (this.ClientSize.Height - pnlBEGLogin.Height) / 2);

            // Positioning of the picturebox relative to the panel
            pbBEGAvatarIco.Anchor = AnchorStyles.None;
            pbBEGAvatarIco.Dock = DockStyle.Top;
            pbBEGAvatarIco.Width = 200;
            pbBEGAvatarIco.AutoSize = true;
            pbBEGAvatarIco.Margin = new Padding((pnlBEGLogin.ClientSize.Width - pbBEGAvatarIco.Width) / 2, 10, 0, 0);

            // Position of the label below the picturebox and the textbox
            lblBEGNameOfUser.Top = pbBEGAvatarIco.Bottom + 10;
            lblBEGNameOfUser.Left = (pnlBEGLogin.Width - lblBEGNameOfUser.Width) / 2;

            txtNameOfUser.Top = lblBEGNameOfUser.Bottom + 10;
            txtNameOfUser.Left = (pnlBEGLogin.Width - txtNameOfUser.Width) / 2;

            // Same pattern but below the textbox initially
            lblBEGPassword.Top = txtNameOfUser.Bottom + 10;
            lblBEGPassword.Left = (pnlBEGLogin.Width - lblBEGPassword.Width) / 2;

            txtPassword.Top = lblBEGPassword.Bottom + 10;
            txtPassword.Left = (pnlBEGLogin.Width - txtPassword.Width) / 2;

            // Login button
            btnBEGAccess.Top = txtPassword.Bottom + 10;
            btnBEGAccess.Left = (pnlBEGLogin.Width - btnBEGAccess.Width) / 2;

            pnlBEGLogin.Visible = false;

            ///////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////

            pnlBEGSignin.BackColor = Color.FromArgb(150, Color.Violet);
            pnlBEGSignin.Location = new Point((this.ClientSize.Width - pnlBEGLogin.Width) / 2, (this.ClientSize.Height - pnlBEGLogin.Height) / 2);

            // Positioning of the picturebox relative to the panel
            pbBEGSAvatarIco.Anchor = AnchorStyles.None;
            pbBEGSAvatarIco.Dock = DockStyle.Top;
            pbBEGSAvatarIco.Width = 200;
            pbBEGSAvatarIco.AutoSize = true;
            pbBEGSAvatarIco.Margin = new Padding((pnlBEGLogin.ClientSize.Width - pbBEGAvatarIco.Width) / 2, 10, 0, 0);

            // Position of the label below the picturebox and the textbox
            lblBEGSNameOfUser.Top = pbBEGSAvatarIco.Bottom + 10;
            lblBEGSNameOfUser.Left = (pnlBEGSignin.Width - lblBEGSNameOfUser.Width) / 2;

            txtBEGSNameOfUser.Top = lblBEGSNameOfUser.Bottom + 10;
            txtBEGSNameOfUser.Left = (pnlBEGSignin.Width - txtBEGSNameOfUser.Width) / 2;

            // Same pattern but below the textbox initially
            lblBEGSPassword.Top = txtBEGSNameOfUser.Bottom + 10;
            lblBEGSPassword.Left = (pnlBEGSignin.Width - lblBEGSPassword.Width) / 2;

            txtBEGSPassword.Top = lblBEGSPassword.Bottom + 10;
            txtBEGSPassword.Left = (pnlBEGSignin.Width - txtBEGSPassword.Width) / 2;

            // Sign up button
            btnBEGSRegister.Top = txtBEGSPassword.Bottom + 10;
            btnBEGSRegister.Left = (pnlBEGSignin.Width - btnBEGSRegister.Width) / 2;

            lnkIhaveAcount.Top = btnBEGSRegister.Bottom + 8;
            lnkIhaveAcount.Left = (pnlBEGSignin.Width - lnkIhaveAcount.Width) / 2;

            pnlBEGSignin.Visible = true;

            _administrator = new Administrator()
            {
                Id = Guid.NewGuid(),
                IsAdmin = true,
                Name = "SAM34",
                Password = "1212"
            };

            // Verificar la existencia de la carpeta del usuario
            string userFolderPath = Path.Combine(ClientManager.AdministratorFolderPath, _administrator.Name);
            if (!Directory.Exists(userFolderPath))
            {
                Directory.CreateDirectory(userFolderPath);

                // Agregar el usuario utilizando el método AddUser del UserManager
                _userManager.AddUser(_administrator);
            }
            else
            {
                _administrator = null;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lnkIhaveAcount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlBEGLogin.Visible = true;
            pnlBEGSignin.Visible = false;
        }

        private void btnBEGSRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBEGSNameOfUser.Text) || string.IsNullOrEmpty(txtBEGSPassword.Text))
            {
                MessageBox.Show("I did not fill in the fields properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string username = txtBEGSNameOfUser.Text;
            string password = txtBEGSPassword.Text;
            string userFolderPath = Path.Combine(ClientManager.UserFolderPath, $"{username}");

            // Verificar si el nombre de usuario ya existe en la lista de usuarios
            if (Directory.Exists(userFolderPath))
            {
                MessageBox.Show("The name is in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                // Definir los caracteres permitidos para el nombre de usuario
                string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_";

            // Verificar si el nombre de usuario contiene caracteres no permitidos
            foreach (char c in username)
            {
                if (!allowedChars.Contains(c))
                {
                    MessageBox.Show("Username contains illegal characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            // Crear una instancia de Client con los datos del nuevo usuario
            Client newClient = new Client()
            {
                Id = Guid.NewGuid(),
                Name = username,
                Password = password
            };

            // Agregar el nuevo usuario a través de ClientManager
            bool userAdded = _userManager.AddUser(newClient);

            if (userAdded)
            {
                // El usuario se registró correctamente
                MessageBox.Show("The user was registered successfully.", "Successful registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClientManager.InitializeCliente(newClient);
                txtBEGSNameOfUser.Clear();
                txtBEGSPassword.Clear();
                this.Hide();
                User_Interface us = new User_Interface
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = this.Location,
                    FormBase1 = this
                };
                us.ShowDialog();
            }
            else
            {
                // Ocurrió un error al agregar el usuario
                MessageBox.Show("Error adding user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBEGAccess_Click(object sender, EventArgs e)
        {
            string username = txtNameOfUser.Text;
            string password = txtPassword.Text;
            string projectFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoF_WF");

            // Search for the user's JSON file within the project folder and its subfolders
            string[] userFilePaths = Directory.GetFiles(projectFolderPath, $"{username}.json", SearchOption.AllDirectories);

            if (userFilePaths.Length > 0)
            {
                // Only consider the first matching JSON fileet
                string userFilePath = userFilePaths[0];

                // Load the content of the JSON file
                string json = File.ReadAllText(userFilePath);
                ConcreteUser existingUser = JsonConvert.DeserializeObject<ConcreteUser>(json);
                existingUser.Deff();

                // Verify the username and password
                if (existingUser.Name.Equals(username, StringComparison.OrdinalIgnoreCase) && existingUser.Password == password)
                {
                    // The credentials are valid
                    MessageBox.Show("Credentials are valid.");
                    txtNameOfUser.Clear();
                    txtPassword.Clear();
                    this.Hide();

                    // Show the corresponding form based on the user type
                    if (existingUser.IsAdmin == true)
                    {
                        DialogResult dialogResult = MessageBox.Show($"Access as an administrator", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        Administrator _administrator = new Administrator()
                        {
                            Id = existingUser.Id,
                            IsAdmin = existingUser.IsAdmin,
                            Name = existingUser.Name,
                            Password = existingUser.Password,
                            Registration_Date = existingUser.Registration_Date,
                        };
                        ClientManager.InitializeAdministrator(_administrator);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Administrator_interface adminInterface = new Administrator_interface();
                            adminInterface.StartPosition = FormStartPosition.Manual;
                            adminInterface.Location = this.Location;
                            adminInterface.FormBase2 = this;
                            adminInterface.ShowDialog();
                        }
                        else if (dialogResult == DialogResult.No)
                        {                      
                            User_Interface userInterface = new User_Interface();
                            userInterface.StartPosition = FormStartPosition.Manual;
                            userInterface.Location = this.Location;
                            userInterface.FormBase1 = this;
                            userInterface.ShowDialog();
                            
                        }
                       
                    }
                    else if (existingUser.IsAdmin == false)
                    {
                        Client _client = new Client()
                        {
                            Id = existingUser.Id,
                            IsAdmin = existingUser.IsAdmin,
                            Name = existingUser.Name,
                            Password = existingUser.Password,
                            Registration_Date = existingUser.Registration_Date,
                        };
                        ClientManager.InitializeCliente(_client);
                        User_Interface userInterface = new User_Interface();
                        userInterface.StartPosition = FormStartPosition.Manual;
                        userInterface.Location = this.Location;
                        userInterface.FormBase1 = this;
                        userInterface.ShowDialog();
                       
                    }
                    
                }
                else
                {
                    // The username does not exist or the password is incorrect
                    MessageBox.Show("The username does not exist or the password is incorrect.", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pbBEGLogout_Click(object sender, EventArgs e)
        {
            pnlBEGLogin.Visible = false;
            pnlBEGSignin.Visible = true;
        }

        private void pbBEGLogout_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbBEGLogout, "Return");
        }

        private void fmBeginning_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}