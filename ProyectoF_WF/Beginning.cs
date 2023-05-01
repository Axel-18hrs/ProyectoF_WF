using System;
using System.Drawing;
using System.Windows.Forms;
using NAudio;
using LibVLCSharp;
using LibVLCSharp.Shared;
using System.Reflection.Emit;

namespace ProyectoF_WF
{
    public partial class fmBeginning : Form
    {
        // Uso de rutas relativas en lugar de las absolutas para una mejor practica
        public fmBeginning()
        {
            InitializeComponent();
            // Alineamiento del panel respecto al tamaño del formulario
            pnlBEGLoginOrSignIn.BackColor = Color.FromArgb(150, Color.Violet);
            pnlBEGLoginOrSignIn.Location = new Point((this.ClientSize.Width - pnlBEGLoginOrSignIn.Width) / 2, (this.ClientSize.Height - pnlBEGLoginOrSignIn.Height) / 2);

            // Posicionamiento del picturebox respecto al panel
            pbBEGAvatarIco.Anchor = AnchorStyles.None;
            pbBEGAvatarIco.Dock = DockStyle.Top;
            pbBEGAvatarIco.Width = 200;
            pbBEGAvatarIco.AutoSize = true;
            pbBEGAvatarIco.Margin = new Padding((pnlBEGLoginOrSignIn.ClientSize.Width - pbBEGAvatarIco.Width) / 2, 10, 0, 0);

            // Posición del label debajo del picturebox y a su vez el textbox
            lblBEGNameOfUser.Top = pbBEGAvatarIco.Bottom + 10;
            lblBEGNameOfUser.Left = (pnlBEGLoginOrSignIn.Width - lblBEGNameOfUser.Width) / 2;

            txtBEGNameOfUser.Top = lblBEGNameOfUser.Bottom + 10;
            txtBEGNameOfUser.Left = (pnlBEGLoginOrSignIn.Width - txtBEGNameOfUser.Width) / 2;

            // mismo patron pero debajo del textbox inicialmente
            lblBEGPassword.Top = txtBEGNameOfUser.Bottom + 10;
            lblBEGPassword.Left = (pnlBEGLoginOrSignIn.Width - lblBEGPassword.Width) / 2;

            txtBEGPassword.Top = lblBEGPassword.Bottom + 10;
            txtBEGPassword.Left = (pnlBEGLoginOrSignIn.Width - txtBEGPassword.Width) / 2;

            // Boton de inicio
            btnBEGbeginning.Top = txtBEGPassword.Bottom + 10;
            btnBEGbeginning.Left = (pnlBEGLoginOrSignIn.Width - btnBEGbeginning.Width) / 2;

            lnklblBEGAccessAsAdministrator.Top = btnBEGbeginning.Bottom + 8;
            lnklblBEGAccessAsAdministrator.Left = (pnlBEGLoginOrSignIn.Width - lnklblBEGAccessAsAdministrator.Width) / 2;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
        // Evento del link label por donde ocultaremos este formulario y mostraremos otro
        private void lnklblBEGAccessAsAdministrator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            DataOfUser dataOfUser = new DataOfUser();
            dataOfUser.StartPosition = FormStartPosition.Manual;
            dataOfUser.Location = this.Location;
            dataOfUser.ShowDialog();

            
        }
    }
}
