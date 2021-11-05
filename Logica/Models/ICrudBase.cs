using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public interface ICrudBase
    {
        //esta Interface obliga a las clases que la implementen a cumplir el contrato de 
        //estructura acá escrito 

        bool Agregar();
        bool Editar();
        bool Eliminar();

    }
}
