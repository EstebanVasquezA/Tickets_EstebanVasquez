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

        //estas funciones deben cumplir con el contrar escrito en la interface ICrudBase
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

        //Las siguientes funciones son las específicas de la clase que NO están en ICrudBase
        //O sea, no son comunes para más de una clase. 

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

            //SEQ: SDUsuarioRolListar paso 2.1 y 2.2
            Conexion MiConexion = new Conexion();

            //paso 2.3
            R = MiConexion.DMLSelect("SPUsuarioRolListar");

            //paso 2.4
            return R;
        }

    }
}
