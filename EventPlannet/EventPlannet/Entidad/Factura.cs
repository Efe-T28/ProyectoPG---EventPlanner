using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Factura
    {
        public Factura() { }
        public int idFactura { get; set; }
        public int idReserva { get; set; }
        public string cliente { get; set; }
        public int horas { get; set; }
        public double TotalAPagar { get; set; }
        public string estado { get; set; }

        public Factura(int idFactura, int idReserva, string cliente, int horas,double totalpagar,string estado )
        {
            this.idFactura = idFactura;
            this.idReserva = idReserva;
            this.cliente = cliente;
            this.horas = horas;
            this.TotalAPagar = totalpagar;
            this.estado = estado;
        }

        public const string ESTADO1 = "Pendiente";
        public const string ESTADO2 = "Pagado";
    }
}
