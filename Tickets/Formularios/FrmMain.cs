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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            TmrHora.Enabled = true;

            LblUsuarioLogueado.Text = Commons.ObjetosGlobales.MiUsuarioDeSistema.Email;
        }

        private void TmrHora_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gestiónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commons.ObjetosGlobales.FormularioGestionDeUsuarios = new FrmUsuarioGestion();

            Commons.ObjetosGlobales.FormularioGestionDeUsuarios.Show();
        }

        private void creaciónDeTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commons.ObjetosGlobales.FormCrearTicket = new FrmTicketCrear();
            Commons.ObjetosGlobales.FormCrearTicket.Show();
        }

        private void soluciónDeTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commons.ObjetosGlobales.FormAtencion = new FrmAtencionDeTickets();
            Commons.ObjetosGlobales.FormAtencion.Show();
        }

    }
}
