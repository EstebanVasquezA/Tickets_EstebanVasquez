using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public static class Bitacora
    {
        public static void GuardarAccionEnBitacora(int IDUsuario, string Accion)
        {
            Logica.Models.Conexion MiCnn = new Models.Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDUsuario", IDUsuario));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Accion", Accion));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@FechaHora", DateTime.Now));

             MiCnn.DMLUpdateDeleteInsert("SPBitacoraInsertar");
        }
    }
}
