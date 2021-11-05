using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets.Commons
{
    public static class ObjetosGlobales
    {
        //Formularios de uso recurrente en el sistema 
        //Si el formulario deberiá verse SOLO UNA VEZ por sesión lo más 
        //conveniente es defirlo de forma estática, y no dinámica. 

        public static Form MiFormPrincipal = new Formularios.FrmMain();

        public static Formularios.FrmUsuarioGestion FormularioGestionDeUsuarios = new Formularios.FrmUsuarioGestion();

        //se definen los objetos (basados en clases) que deben ser accesibles desde cualquier lugar de la app
        public static Logica.Models.Usuario MiUsuarioDeSistema = new Logica.Models.Usuario();

    }
}
