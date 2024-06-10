using Dato.Archivo;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicioFactura
    {
        private readonly RepositorioReserva repositorioReserva;
        private readonly RepositorioFactura repositorioFactura;

        public ServicioFactura()
        {
            repositorioReserva = new RepositorioReserva();
            repositorioFactura = new RepositorioFactura();
        }

        public string Crear(Reserva reserva)
        {

            Factura factura = new Factura(reserva.idReserva, reserva.idReserva, reserva.cliente.cedula, NumHoras(reserva), TotalReserva(reserva), Factura.ESTADO1);
            if (repositorioFactura.Crear(factura))
            {
                return "Factura generada";
            }
            else
            {
                return "error al generar la factura";
            }
        }
        public Factura buscarFactura(int factura)
        {
            //return repositorioFactura.buscarFactura(factura);
            return repositorioFactura.BuscarFactura(factura);
        }
        public List<Factura> listaFacturas()
        {
            //return repositorioFactura.listaFacturas();
            return repositorioFactura.ListaFacturas();
        }
        public List<Factura> facturas(int indice)
        {
            List<Factura> lista = new List<Factura>();
            foreach (Factura f in listaFacturas())
            {
                if (indice == 1)
                {
                    if (f.estado == Factura.ESTADO2)
                    {
                        lista.Add(f);
                    }
                }
                else
                {
                    if (f.estado == Factura.ESTADO1)
                    {
                        lista.Add(f);
                    }
                }
            }
            return lista;
        }
        public string Modificar(Factura factura)
        {
            if (factura.estado == Factura.ESTADO2)
            {
                return "Esta factura ya esta pagada";
            }
            else
            {
                factura.estado = Factura.ESTADO2;
                if (repositorioFactura.Modificar(factura))
                {
                    return "Factura pagada";
                }
                else
                    return "Error al pagar";
            }

        }
        public double totalFactura(int idFactura)
        {

            double total = 0;
            foreach (Factura factura in listaFacturas())
            {
                if (factura.idFactura == idFactura)
                {
                    Reserva reserva = repositorioReserva.buscarReserva(factura.idReserva);
                    total = Reserva.precio * TotalReserva(reserva);
                }
            }
            return total;
        }

        public double TotalReserva(Reserva r)
        {
            double valor;
            double num = (double)NumHoras(r);
            valor = (double)(num * Reserva.ValorHora);

            return valor;
        }

        private int NumHoras(Reserva r)
        {
            double Num = (r.horaFin - r.horaInicio).TotalHours;
            int horas = (int)Math.Round(Num);
            return horas;
        }

        private int indiceFactura()
        {
            int indice = listaFacturas().Count;
            return indice;
        }
    }
}
