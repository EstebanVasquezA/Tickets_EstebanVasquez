using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Ticket
    {
        public int IDTicket { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }

        public string TicketTitulo { get; set; }

        public string TicketDescripcion { get; set; }

        public int CantidadTiempo { get; set; }

        public bool Pagado { get; set; }

        public bool Activo { get; set; }

        public Ticket()
        {
            CantidadTiempo = 0;

            MiCategoria = new TicketCategoria();
            MiCliente = new Cliente();
            MiListaDeUsuarios = new List<UsuarioTicket>();

        }

        public TicketCategoria MiCategoria { get; set; }

        public Cliente MiCliente { get; set; }

        public List<UsuarioTicket> MiListaDeUsuarios { get; set; }

        public bool Agregar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDCliente", this.MiCliente.IDCliente));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDCategoria", this.MiCategoria.IDTicketCategoria));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Titulo", this.TicketTitulo));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Descripcion", this.TicketDescripcion));

            Object i = MiCnn.DMLConRetornoEscalar("SPTicketAgregar");

            if (i != null)
            {
                this.IDTicket = Convert.ToInt32(i.ToString());

                R = true;
            }

            return R;
        }

        public bool Eliminar()
        {
            bool R = false;

            return R;
        }

        public bool IniciarTicket()
        {
            bool R = false;

            return R;
        }

        public bool FinalizarTicket()
        {
            bool R = false;

            return R;
        }

        public bool EstablecerPagado()
        {
            bool R = false;

            return R;
        }

        public ReportDocument Imprimir(ReportDocument reporte)
        {
            ReportDocument R = reporte;

            Crystal OCrystal = new Crystal(R);

            DataTable Datos = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDTicket", this.IDTicket));

            Datos = MiCnn.DMLSelect("SPTicketReporte");

            if (Datos != null && Datos.Rows.Count > 0)
            {
                OCrystal.Datos = Datos;

                R = OCrystal.GenerarReporte();
            }
            return R;
        }
    }
}
