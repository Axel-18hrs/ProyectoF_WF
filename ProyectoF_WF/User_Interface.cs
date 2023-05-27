using AxWMPLib;
using ProyectoF_WF.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProyectoF_WF
{
    public partial class User_Interface : Form
    {
        private OpenFileDialog openFileDialog;
        private Client _client;
        private Administrator _administrator;
        private Size originalPictureBoxSize;
        private Point originalPictureBoxLocation;
        private int currentImageIndex = 0;
        private bool disableDoubleClickEvent = false;
        private List<string> imagePaths;
        private List<string> videoPaths;
        private Form formBase1;
        public Form FormBase1 { get { return formBase1; } set { formBase1 = value; } }
        public User_Interface()
        {
            InitializeComponent();

            FormBase1 = new Form();
            openFileDialog = new OpenFileDialog();
            imagePaths = new List<string>();
            videoPaths = new List<string>();
            if (ClientManager.ClientInstance != null)
            {
                _client = ClientManager.ClientInstance;

                _client.RefreshPaths();

                // Obtener las rutas de imágenes
                
                imagePaths = _client.ImagePaths;
                // Obtener las rutas de videos
                videoPaths = _client.VideoPaths;
            }
            if (ClientManager.AdministratorInstance != null)
            {
                _administrator = ClientManager.AdministratorInstance;
                _administrator.RefreshPaths();
                // Obtener las rutas de imágenes
                imagePaths = _administrator.ImagePaths;
                // Obtener las rutas de videos
                videoPaths = _administrator.VideoPaths;
            }
            FormBase1 = new Form();
            openFileDialog = new OpenFileDialog();
            imagePaths = new List<string>();
            videoPaths = new List<string>();
           
           
            CargarVideos();
            CargarImagenes();

            int x = (this.Width - pbCargarImagenes.Width) / 2;
            int y = (this.Height - pbCargarImagenes.Height) / 2;
            pbCargarImagenes.Location = new Point(x, y);

            originalPictureBoxSize = pbCargarImagenes.Size;
            originalPictureBoxLocation = pbCargarImagenes.Location;

            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            pbCargarImagenes.SizeMode = PictureBoxSizeMode.Zoom;
            pbCargarImagenes.Anchor = AnchorStyles.None;
            pbCargarImagenes.Location = new Point((this.ClientSize.Width - pbCargarImagenes.Width) / 2, (this.ClientSize.Height - pbCargarImagenes.Height) / 2);
        }

        ~User_Interface()
        {
            ClientManager.InitializeCliente(null);
        }
    
        private void CargarVideos()
        {
            // Limpiar el control de reproducción de video
            axWindowsMediaPlayer1.URL = null;

            // Verificar si hay rutas de videos disponibles
            if (videoPaths == null || videoPaths.Count == 0)
            {
                MessageBox.Show("No se encontraron videos.");
                return;
            }

            // Obtener la primera ruta de video
            string videoPath = videoPaths[0];

            // Asignar la ruta del video al control axWindowsMediaPlayer1
            axWindowsMediaPlayer1.URL = videoPath;
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
        private void CargarImagenes()
        {
            // Limpiar el PictureBox
            pbCargarImagenes.Image = null;

            // Verificar si hay rutas de imágenes disponibles
            if (imagePaths == null || imagePaths.Count == 0)
            {
                MessageBox.Show("No images found.");
                return;
            }

            // Obtener la primera ruta de imagen
            string imagePath = imagePaths[0];
               
            // Cargar la imagen en el PictureBox
            try
            {
                using (var image = Image.FromFile(imagePath))
                {
                    pbCargarImagenes.Image = new Bitmap(image);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }
        private void User_Interface_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.Visible = false;
            pbCargarImagenes.Visible = false;
        }

        private void escogerArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Video files|*.mp4;*.mov;*.avi;*.wmv;*.mkv"; 
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string selectedFile = openFileDialog.FileName;
            if (ClientManager.ClientInstance != null)
            {
                // Llamar al método MoveFile de la instancia de Client y pasarle el archivo seleccionado
                _client.MoveFile(selectedFile);
                _client.RefreshPaths();

                // Obtener las rutas de imágenes
                imagePaths = _client.ImagePaths;
                // Obtener las rutas de videos
                videoPaths = _client.VideoPaths;
            }
            if(ClientManager.AdministratorInstance != null)
            {
                // Llamar al método MoveFile de la instancia de Client y pasarle el archivo seleccionado
                _administrator.MoveFile(selectedFile);
                _administrator.RefreshPaths();

                // Obtener las rutas de imágenes
                imagePaths = _administrator.ImagePaths;
                // Obtener las rutas de videos
                videoPaths = _administrator.VideoPaths;
            }

            if (videoPaths.Count > 0)
            {
                // Seleccionar la primera ruta de video
                string videoPath = videoPaths[0];

                // Asignar la ruta del video al control axWindowsMediaPlayer1
                axWindowsMediaPlayer1.URL = videoPath;
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
            else if (imagePaths.Count > 0)
            {
                // Seleccionar la primera ruta de imagen
                string imagePath = imagePaths[0];

                // Actualizar el control pbCargarImagenes con la imagen correspondiente
                pbCargarImagenes.Image = Image.FromFile(imagePath);
            }
            else
            {
                // No hay rutas de video o imágenes disponibles
                MessageBox.Show("No se encontraron videos o imágenes.");
            }
           
        }

        private void axWindowsMediaPlayer1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (videoPaths == null || videoPaths.Count == 0)
                return; // No hay videos cargados

            switch (e.KeyCode)
            {
                case Keys.Left:
                    // Cambiar al video anterior
                    int currentIndex = videoPaths.IndexOf(axWindowsMediaPlayer1.URL);
                    int previousIndex = (currentIndex - 1 + videoPaths.Count) % videoPaths.Count;
                    string previousVideoPath = videoPaths[previousIndex];
                    axWindowsMediaPlayer1.URL = previousVideoPath;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    Console.WriteLine("Left!");
                    break;

                case Keys.Right:
                    // Cambiar al siguiente video
                    currentIndex = videoPaths.IndexOf(axWindowsMediaPlayer1.URL);
                    int nextIndex = (currentIndex + 1) % videoPaths.Count;
                    string nextVideoPath = videoPaths[nextIndex];
                    axWindowsMediaPlayer1.URL = nextVideoPath;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    Console.WriteLine("Right!");
                    break;

                default:
                    // No hacer nada para otras teclas
                    break;
            }
        }
       
        private void imagenesDelUsuarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.Visible == true)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.Visible = false;
            }
            pbCargarImagenes.Focus();
            pbCargarImagenes.Visible = true;
        }

        private void videosDelUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1 == null)
            {
                return;
            }
            if (pbCargarImagenes.Visible == true)
            {
                pbCargarImagenes.Visible = false;
            }
            axWindowsMediaPlayer1.Focus();
            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void User_Interface_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            formBase1.Location = this.Location;
            formBase1.Show();
            this.Close();
        }

        private void Log_OutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            formBase1.Location = this.Location;
            formBase1.Show();
            this.Close();
        }

        private void User_Interface_KeyDown(object sender, KeyEventArgs e)
        {
            if (pbCargarImagenes.Focus())
            {
                // Código para el PictureBox (navegación de imágenes)
                if (imagePaths == null || imagePaths.Count == 0)
                    return; // No hay imágenes cargadas

                switch (e.KeyCode)
                {
                    case Keys.Space:
                        this.WindowState = FormWindowState.Normal;
                        this.FormBorderStyle = FormBorderStyle.Sizable; 
                        panel1.Visible = true; 
                        disableDoubleClickEvent = false;
                        // Ajustar el tamaño de la imagen dentro del PictureBox
                        pbCargarImagenes.Size = originalPictureBoxSize;
                        pbCargarImagenes.SizeMode = PictureBoxSizeMode.Zoom;
                        pbCargarImagenes.Location = originalPictureBoxLocation;
                        break;
                    case Keys.Left:
                        // Cambiar a la imagen anterior     
                        currentImageIndex = (currentImageIndex - 1 + imagePaths.Count) % imagePaths.Count;
                        string previousImagePath = imagePaths[currentImageIndex];
                        pbCargarImagenes.Image = Image.FromFile(previousImagePath);
                        break;
                    case Keys.Right:
                        // Cambiar a la siguiente imagen
                        currentImageIndex = (currentImageIndex + 1) % imagePaths.Count;
                        string nextImagePath = imagePaths[currentImageIndex];
                        pbCargarImagenes.Image = Image.FromFile(nextImagePath);
                        break;
                    default:
                        // No hacer nada para otras teclas
                        break;
                }
            }
        }

        private void pbCargarImagenes_DoubleClick(object sender, EventArgs e)
        {
            if (disableDoubleClickEvent) return;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            panel1.Visible = false;
            disableDoubleClickEvent = true;
            // Calcular el tamaño y la posición del PictureBox
            int pictureBoxWidth = this.ClientSize.Width;
            int pictureBoxHeight = this.ClientSize.Height;
            int pictureBoxX = (this.ClientSize.Width - pictureBoxWidth) / 2;
            int pictureBoxY = (this.ClientSize.Height - pictureBoxHeight) / 2;
            pbCargarImagenes.Size = new Size(pictureBoxWidth, pictureBoxHeight);
            pbCargarImagenes.Location = new Point(pictureBoxX, pictureBoxY);
        }
    }
}