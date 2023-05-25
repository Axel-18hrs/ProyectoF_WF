using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProyectoF_WF.Interfaces;

namespace ProyectoF_WF.Classes
{
    // The UserManager class is responsible for managing user data and operations.
    public class UserManager : IUserManager
    {
        // private readonly string _userFolderPath;
        private List<string> _jsonFilePaths;
        private readonly List<User> _users;

        // Initializes a new instance of the UserManager class.
        public UserManager()
        {
            _users = new List<User>();
            
        }
        // Loads the users from JSON files.
        public void LoadUsers()
        {
            // Set the user folder path
            string _userFolderPath = ClientManager.UserFolderPath;
            string _adminFolderPath = ClientManager.AdministratorFolderPath;

            // Create the user folder if it doesn't exist
            if (!Directory.Exists(_userFolderPath))
            {
                Directory.CreateDirectory(_userFolderPath);
            }

            if (!Directory.Exists(_adminFolderPath))
            {
                Directory.CreateDirectory(_adminFolderPath);
            }

            // Get the JSON file paths in the user folder
            _jsonFilePaths = Directory.EnumerateFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoF_WF"), "*.json").ToList();

            // Read the JSON files and populate the list of users
            foreach (string jsonFilePath in _jsonFilePaths)
            {
                string json = File.ReadAllText(jsonFilePath);
                User user = JsonConvert.DeserializeObject<User>(json);
                _users.Add(user);

                Console.WriteLine($"Usuario cargado: {user.Name}");
            }
        }

        // Adds a new user to the UserManager.
        public bool AddUser(User user)
        {
            // Add the user to the appropriate list and write user data to a JSON file
            if (user.IsAdmin == false)
            {
                _users.Add((Client)user);
                WriteUserFile(user);
            }
            else if (user.IsAdmin == true)
            {
                _users.Add((Administrator)user);
                WriteUserFile(user);
            }

            return true;
        }

        // Writes user data to a JSON file.
        private void WriteUserFile(User user)
        {
            if (user.IsAdmin == false) 
            {
                string userFolderPath = Path.Combine(ClientManager.UserFolderPath, $"{user.Name}");
                // Check if the user type subfolder exists, create it if not
                if (!Directory.Exists(userFolderPath))
                {
                    Directory.CreateDirectory(userFolderPath);
                }

                string userFilePath = Path.Combine(userFolderPath, $"{user.Name}.json");
                string json = JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(userFilePath, json);
            }
            else if (user.IsAdmin == true)
            {
                string admiFolderPath = Path.Combine(ClientManager.AdministratorFolderPath, $"{user.Name}");
                // Check if the user type subfolder exists, create it if not
                if (!Directory.Exists(admiFolderPath))
                {
                    Directory.CreateDirectory(admiFolderPath);
                }

                string admiFilePath = Path.Combine(admiFolderPath , $"{user.Name}.json");
                string json = JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(admiFilePath, json);
            }
        
        }
    }
}