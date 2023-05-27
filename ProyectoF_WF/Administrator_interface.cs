using Newtonsoft.Json;
using ProyectoF_WF.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ProyectoF_WF
{
    public partial class Administrator_interface : Form
    {
        private Form formBase;
        public Form FormBase2 { get { return formBase; } set { formBase = value; } }
        public Administrator_interface()
        {
            InitializeComponent();
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvUsers.AllowUserToResizeRows = false;

            string jsonFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoF_WF");

            List<User> userDataList = new List<User>();

            foreach (string jsonFilePath in Directory.EnumerateFiles(jsonFolderPath, "*.json", SearchOption.AllDirectories))
            {
                // Leer el contenido del archivo JSON
                string json = File.ReadAllText(jsonFilePath);

                // Deserializar el JSON y agregar los datos a la listaA
                ConcreteUser userData = JsonConvert.DeserializeObject<ConcreteUser>(json);
                userDataList.Add(userData);
            }

            // Configurar el DataGridView
            dgvUsers.AutoGenerateColumns = false;

            // Agregar las columnas al DataGridView
            dgvUsers.Columns.Add("IdColumn", "ID");
            dgvUsers.Columns.Add("IsAdminColumn", "Admin");
            dgvUsers.Columns.Add("NameColumn", "Name");
            dgvUsers.Columns.Add("PasswordColumn", "Password");
            dgvUsers.Columns.Add("RegistrationDateColumn", "Registration Date");
            dgvUsers.Columns.Add("ProfileImageColumn", "Profile Image");

            // Asignar las propiedades de cada columna
            dgvUsers.Columns["IdColumn"].DataPropertyName = "Id";
            dgvUsers.Columns["IsAdminColumn"].DataPropertyName = "IsAdmin";
            dgvUsers.Columns["NameColumn"].DataPropertyName = "Name";
            dgvUsers.Columns["PasswordColumn"].DataPropertyName = "Password";
            dgvUsers.Columns["RegistrationDateColumn"].DataPropertyName = "Registration_Date";
            dgvUsers.Columns["ProfileImageColumn"].DataPropertyName = "Profile_Image";

            // Asignar la lista de datos al DataGridView
            dgvUsers.DataSource = userDataList;
        }

        private void Administrator_interface_Load(object sender, EventArgs e)
        {
         
        }
        private void Administrator_interface_FormClosed(object sender, FormClosedEventArgs e)
        {
            formBase.Location = this.Location;
            formBase.Show();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                bool anyAdminSelected = false;

                foreach (DataGridViewRow dataGridViewRow in dgvUsers.SelectedRows)
                {
                    bool isAdmin = Convert.ToBoolean(dataGridViewRow.Cells["IsAdminColumn"].Value);

                    if (isAdmin)
                    {
                        anyAdminSelected = true;
                        continue;
                    }

                    string username = dataGridViewRow.Cells["NameColumn"].Value.ToString();

                    DialogResult result = MessageBox.Show("Are you sure you want to delete the user " + username + "?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string jsonFolderPath = ClientManager.UserFolderPath;
                        string userFolderPath = Path.Combine(jsonFolderPath, username);

                        if (Directory.Exists(userFolderPath))
                        {
                            Directory.Delete(userFolderPath, true);
                            MessageBox.Show("User " + username + " has been deleted.");
                        }
                        else
                        {
                            MessageBox.Show("The user has already been deleted.");
                        }
                    }
                }

                if (anyAdminSelected)
                {
                    MessageBox.Show("Administrators cannot be deleted.");
                }
            }
        }
    }
}