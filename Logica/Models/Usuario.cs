using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Usuario : ICrudBase, IPersona
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        public bool Agregar()
        {
            bool R = false;

            //1.6.1 y 1.6.2 
            Conexion MiCnnAdd = new Conexion();

            //agregar los parámetros para el SP 
            MiCnnAdd.ListadoDeParametros.Add(new SqlParameter("@Cedula", this.Cedula));
            MiCnnAdd.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiCnnAdd.ListadoDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));
            MiCnnAdd.ListadoDeParametros.Add(new SqlParameter("@Email", this.Email));
            //TODO: Encriptar contraseña 
            MiCnnAdd.ListadoDeParametros.Add(new SqlParameter("@Contrasennia", this.Contrasennia));

            //debemos enviar el valor del id del rol, usando la composición de la clase UsuarioRol
            MiCnnAdd.ListadoDeParametros.Add(new SqlParameter("@IdRol", this.MiRol.IDUsuarioRol));
  
            //1.6.3 y 1.6.4
            int resultado = MiCnnAdd.DMLUpdateDeleteInsert("SPUsuarioAgregar");

            //1.6.5
            if (resultado > 0)
            {
                R = true;
            }

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

        //adicionales
        public int IDUsuario { get; set; }
        public string CodigoRecuperacion { get; set; }

        public string Contrasennia { get; set; }

        //composición del rol del usuario 
        public UsuarioRol MiRol  { get; set; }

        //constructor
        public Usuario()
        {
            MiRol = new UsuarioRol();
        }

        //funciones adicionales
        public bool Agregar(string cedula, string nombre, string telefono, string email, string contrasennia)
        {
            bool R = false;

            return R;
        }

        public Usuario ConsultarPorID(int ID)
        {
            Usuario R = new Usuario();

            return R;
        }

        public bool ConsultarPorCedula(string cedula)
        {
            bool R = false;

            //paso 1.3.1 y 1.3.2
            Conexion MiConexion = new Conexion();

            //En este caso y de forma didactica se decidió implementar un parámetro para la cédula
            //este valor debe agregarse como parámetro que debe llegar hasta el SP. 
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Cedula", cedula));
            
            //paso 1.3.3 y 1.3.4
            DataTable retorno = MiConexion.DMLSelect("SPUsuarioConsultarPorCedula");

            //paso 1.3.5
            if (retorno != null && retorno.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }

        public bool ConsultarPorEmail()
        {
            bool R = false;

            //paso 1.4.1 y 1.42
            Conexion MiCnn = new Conexion();

            //agregar el parámetro que debe llegar con el valor del email a consultar
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Email", this.Email));

            // 1.4.3 y 1.4.4
            DataTable resultado = MiCnn.DMLSelect("SPUsuarioConsultarPorEmail");

            //1.4.5
            if (resultado != null && resultado.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }

        public DataTable Listar(bool VerActivos = true)
        {
            DataTable R = new DataTable();

            return R;
        }

        public bool EnviarCodigoRecuperacion()
        {
            bool R = false;

            return R;
        }

        public bool CambiarPassword(int iD, string nuevaContrasennia)
        {
            bool R = false;

            return R;
        }

    }
}
