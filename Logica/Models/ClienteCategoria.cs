using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class ClienteCategoria
    {
        //hay varias de usar los atributos de una clase, esta es 
        //auto implementación
        public int IDClienteCategoria { get; set; }

        //Esta otra forma es la "normal" muy usada en por ejemplo java.
        //full 
        private string clienteCategoriaDescripcion;
        public string ClienteCategoriaDescripcion
        {
            get { return clienteCategoriaDescripcion; }
            set { clienteCategoriaDescripcion = value; }
        }

        //luego de escribir los attribs, seguimos con las funciones y métodos
        
        public DataTable Listar()
        {
            DataTable R = new DataTable();

            //acá la funcionalidad para obtener la data desde la BD por medio
            //se un SP

            return R;
        }



    }
}
