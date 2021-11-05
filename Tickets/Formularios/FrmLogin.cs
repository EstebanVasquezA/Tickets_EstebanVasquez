using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //salimos de la aplicación 

            Application.Exit();

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = true;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {

            //TODO: hay que validar que el usuario y la contraseña sean 
            //sean correctos antes de mostrar el Frm Principal 

            //muestro el objeto global del FrmMain
            Commons.ObjetosGlobales.MiFormPrincipal.Show();

            //oculto (no destruyo) el frm de Login
            this.Hide();

        }
    }
}
