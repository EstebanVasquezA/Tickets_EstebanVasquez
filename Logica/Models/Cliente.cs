using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Logica.Models
{
    public class Cliente : ICrudBase, IPersona
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        public bool Agregar()
        {
            bool R = false;

            return R;
        }

        public bool Editar()
        {
            bool R = false;

            return R;
        }

        public bool Eliminar()
        {
            bool R = false;

            return R;
        }

        public int IDCliente { get; set; }
        public string Direccion { get; set; }

        public bool EnviarPromos { get; set; }

        public ClienteCategoria MiCategoria { get; set; }

        public Cliente()
        {
            MiCategoria = new ClienteCategoria();
        }

        bool ConsultarPorID(int ID)
        {
            bool R = false;

            return R;
        }


        bool ConsultarPorCedula(string Cedula)
        {
            bool R = false;

            return R;
        }

        public DataTable ListarActivos(string filtro = "")
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@filtro", filtro));

            R = MiCnn.DMLSelect("SPClienteBuscar");

            return R;            
        }

        public DataTable ListarInactivos()
        {
            DataTable R = new DataTable();

            return R;
        }

    }
}
