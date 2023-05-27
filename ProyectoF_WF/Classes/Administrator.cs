using Newtonsoft.Json;
using ProyectoF_WF.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoF_WF.Classes
{
    public class Administrator : User
    {
        private readonly List<string> _imageExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
        private readonly List<string> _videoExtensions = new List<string> { ".mp4", ".mov", ".avi", ".wmv", ".mkv" };
        private List<string> _imagePaths = new List<string>();
        private List<string> _videoPaths = new List<string>();

        // Gets the list of image file paths associated with the client.
        public List<string> ImagePaths
        {
            get { return _imagePaths; }
        }

        // Gets the list of video file paths associated with the client.
        public List<string> VideoPaths
        {
            get { return _videoPaths; }
        }
        public Administrator() 
        {
            IsAdmin = true;
        }
        public void MoveFile(string file)
        {
            Administrator _admin = ClientManager.AdministratorInstance;

            // Check if the selected file is a valid image or video fileetA
            if (!(_imageExtensions.Union(_videoExtensions).Contains(Path.GetExtension(file).ToLower())))
            {
                MessageBox.Show("The selected file is not a valid image or video file.");
                return;
            }

            string rootFolder = ClientManager.AdministratorFolderPath;
            string userFolder = Path.Combine(rootFolder, _admin.Name);

            // Create the user folder if it doesn't exist
            if (!Directory.Exists(userFolder))
            {
                Directory.CreateDirectory(userFolder);
            }

            // Create the image folder inside the user folder if it doesn't exist
            string imageFolder = Path.Combine(userFolder, "Images");
            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }

            // Create the video folder inside the user folder if it doesn't exist
            string videoFolder = Path.Combine(userFolder, "Videos");
            if (!Directory.Exists(videoFolder))
            {
                Directory.CreateDirectory(videoFolder);
            }

            // Move the file to the corresponding folder based on its extension
            string destinationFolder;
            if (_imageExtensions.Contains(Path.GetExtension(file).ToLower()))
            {
                destinationFolder = imageFolder;
            }
            else
            {
                destinationFolder = videoFolder;
            }

            string fileName = Path.GetFileName(file);

            if (!string.IsNullOrEmpty(destinationFolder) && !string.IsNullOrEmpty(fileName))
            {
                string destinationPath = Path.Combine(destinationFolder, fileName);
                try
                {
                    File.Move(file, destinationPath);
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("Error: File not found - " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while moving the file: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error combining the destination file path.");
            }
        }

    
        // Refreshes the file paths associated with the client.
        public void RefreshPaths()
        {
            Administrator _admi = ClientManager.AdministratorInstance;
            // Clear the existing file path lists
            _imagePaths.Clear();
            _videoPaths.Clear();

            // Get the user folder path
            string rootFolder = ClientManager.AdministratorFolderPath;
            string userFolder = Path.Combine(rootFolder, ClientManager.AdministratorInstance.Name);

            // Get the file paths of all files in the user folder and its subfolders
            string[] imageFiles = Directory.GetFiles(userFolder, "*.*", SearchOption.AllDirectories)
                                          .Where(file => _imageExtensions.Contains(Path.GetExtension(file)))
                                          .ToArray();

            string[] videoFiles = Directory.GetFiles(userFolder, "*.*", SearchOption.AllDirectories)
                                          .Where(file => _videoExtensions.Contains(Path.GetExtension(file)))
                                          .ToArray();

            // Add the file paths to the corresponding lists
            _imagePaths.AddRange(imageFiles);
            _videoPaths.AddRange(videoFiles);
        }
    }
}
