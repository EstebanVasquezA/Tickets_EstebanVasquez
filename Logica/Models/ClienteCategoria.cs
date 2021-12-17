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
        public int IDClienteCategoria { get; set; }

        private string clienteCategoriaDescripcion;
        public string ClienteCategoriaDescripcion
        {
            get { return clienteCategoriaDescripcion; }
            set { clienteCategoriaDescripcion = value; }
        }
        
        public DataTable Listar()
        {
            DataTable R = new DataTable();

            return R;
        }



    }
}
