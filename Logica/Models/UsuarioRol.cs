using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class UsuarioRol : ICrudBase
    {
        public int IDUsuarioRol { get; set; }

        public string UsuarioRolDescripcion { get; set; }

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

        bool ConsultarPorID()
        {
            bool R = false;

            return R;     
        }

        bool ConsultarPorNombre()
        {
            bool R = false;

            return R;
        }

        public DataTable Listar()
        {
            DataTable R = new DataTable();

            Conexion MiConexion = new Conexion();

            R = MiConexion.DMLSelect("SPUsuarioRolListar");

            return R;
        }

    }
}
