using Dato;
using Entidad;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MenuPrincipal : Form
    {
        static ServicioReserva servicioReserva = new ServicioReserva();
        static ServicioCliente servicioCliente = new ServicioCliente();
        static ServicioFactura servicioFactura = new ServicioFactura();
        public MenuPrincipal()
        {
            InitializeComponent();
            LlenarTablaCliente();
            LlenarTablaReservas(servicioReserva.listaReservas());
            LlenarTablaFacturas(servicioFactura.listaFacturas());
            //LlenarTablaFacturas(servicioFactura.ListaFacturas());
            cmbEstado.SelectedIndex = 0;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void BtnRegistrarCliente_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void BtnGestionServicios_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void BtnRegistrarEvento_Click(object sender, EventArgs e)
        { tabControl.SelectedIndex = 1;

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                cedula = txtCedula.Text,
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                //telefono = int.Parse(txtTelefono.Text),
                telefono = txtTelefono.Text,
                cuenta = 0
            };
            //Cliente cliente = new Cliente();
            //cliente.cedula = txtCedula.Text;
            //cliente.nombre = txtNombre.Text;
            //cliente.apellido = txtApellido.Text;
            ////cliente.telefono = int.Parse(txtTelefono.Text);
            //cliente.telefono = txtTelefono.Text;
            //cliente.cuenta = 00;

            MessageBox.Show(servicioCliente.Crear(cliente));
            LlenarTablaCliente();

        }
        private void LlenarTablaCliente()
        {
            tblClientes.Rows.Clear();
            foreach (Cliente cliente in servicioCliente.listaClientes())
            {
                tblClientes.Rows.Add(cliente.cedula, cliente.nombre, cliente.apellido, cliente.telefono);
            }
            //tblClientes.Rows.Clear();
            //foreach (Cliente cliente in servicioCliente.listaClientes())
            //{
            //    tblClientes.Rows.Add(cliente.cedula, cliente.nombre, cliente.apellido, cliente.telefono);
            //}
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Cliente cliente = new Cliente();
            //cliente.cedula = txtCedula.Text;
            //cliente.nombre = txtNombre.Text;
            //cliente.apellido = txtApellido.Text;
            ////cliente.telefono = int.Parse(txtTelefono.Text);
            //cliente.telefono= txtTelefono.Text;
            //cliente.cuenta = 00;
            MessageBox.Show(servicioCliente.Eliminar(txtCedula.Text));
            LlenarTablaCliente();
        }

        private void tblClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var fila = tblClientes.Rows[e.RowIndex];

            if (fila.Cells[1].Value == null || fila.Cells[2].Value == null || fila.Cells[3].Value == null)
            {
                MessageBox.Show("Este campo es obligatorio");
                tblClientes.Rows.Clear();
                LlenarTablaCliente();
            }
            else
            {
                Cliente cliente = new Cliente
                {

                    cedula = fila.Cells[0].Value.ToString(),
                    nombre = fila.Cells[1].Value.ToString(),
                    apellido = fila.Cells[2].Value.ToString(),
                    //telefono = (int)long.Parse(fila.Cells[3].Value.ToString())
                    telefono = fila.Cells[3].Value.ToString(),

                };
                txtCedula.Text = cliente.cedula.ToString();
                txtNombre.Text = cliente.nombre.ToString();
                txtApellido.Text = cliente.apellido.ToString();
                txtTelefono.Text = cliente.telefono.ToString(); 
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                cedula = txtCedula.Text,
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                //telefono = int.Parse(txtTelefono.Text),
                telefono = txtTelefono.Text,
                cuenta = 0
            };
            //Cliente cliente = new Cliente();
            //cliente.cedula = txtCedula.Text;
            //cliente.nombre = txtNombre.Text;
            //cliente.apellido = txtApellido.Text;
            ////cliente.telefono = int.Parse(txtTelefono.Text);
            //cliente.telefono = txtTelefono.Text;
            //cliente.cuenta = 00;
            MessageBox.Show(servicioCliente.Modificar(cliente));
            LlenarTablaCliente();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 3;

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        private bool ValidarVacios()
        {
            if (txtCliente.Text == string.Empty)
            {
                return true;
            }
            return false;
        }
        private void btnCrearReserva_Click(object sender, EventArgs e)
        {

            if (ValidarVacios())
            {
                MessageBox.Show("Falta el campo de cedula cliente");
            }
            else
            {
                DateTime inicio;
                DateTime fin;

                Reserva reserva = new Reserva();
                reserva.idReserva = int.Parse(txtIdReserva.Text);
                reserva.fecha = DateTime.Parse(txtFecha.Text);

                inicio = DateTime.Parse(dateTimeHoraInicio.Text);
                fin = DateTime.Parse(dateTimeHoraFin.Text);

                TimeSpan tiempoInicio = inicio.TimeOfDay;
                TimeSpan tiempoFin = fin.TimeOfDay;

                reserva.horaInicio = tiempoInicio;
                reserva.horaFin = tiempoFin;
                reserva.cliente = servicioCliente.buscarCliente(txtCliente.Text);
                reserva.tipoEvento = cmbTipoEvento.Text;
                reserva.observaciones = txtObservaciones.Text;

                MessageBox.Show(servicioReserva.Crear(reserva));
               
                LlenarTablaFacturas(servicioFactura.listaFacturas());
                //LlenarTablaFacturas(servicioFactura.ListaFacturas());

            }
            LlenarTablaReservas(servicioReserva.listaReservas());
            

        }
        //Lista reservas
        private void LlenarTablaReservas(List<Reserva> lista)
        {
            tblReservas.Rows.Clear();
            foreach (Reserva reserva in lista)
            {
                if (reserva != null && reserva.cliente != null)
                {
                    tblReservas.Rows.Add(reserva.idReserva, reserva.fecha.ToString("d"), formato(reserva.horaInicio), formato(reserva.horaFin), reserva.cliente.cedula, reserva.tipoEvento, reserva.estado);
                }
                else
                {
                    MessageBox.Show("Error: La reserva o el cliente es null.");
                }
            }
            //tblReservas.Rows.Clear(); 
            //foreach (Reserva reserva in lista)
            //{
            //    tblReservas.Rows.Add(reserva.idReserva, reserva.fecha.ToString("d"), formato(reserva.horaInicio), formato(reserva.horaFin), reserva.cliente.cedula, reserva.tipoEvento, reserva.estado);
            //}

        }
        private string formato(TimeSpan hora)
        {
            return $"{(int)hora.TotalHours:D2}:{hora.Minutes:D2}";
        }

        private void cmbTipoEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTipoEvento.Items.Clear();


            ConexionSQL conexionSQL = new ConexionSQL();


            string query = "SELECT CodigoTipoEvento FROM TipoEvento";

            try
            {
                using (SqlConnection conn = conexionSQL.GetConnection())
                {

                    conn.Open();


                    SqlCommand cmd = new SqlCommand(query, conn);


                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbTipoEvento.Items.Add(reader["CodigoTipoEvento"].ToString());
                    }


                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los tipos de evento: {ex.Message}");
            }
            //if (cmbTipoEvento.Text == "Seleccionar")
            //{
            //    LlenarTablaReservas(servicioReserva.listaReservas());
            //}
            //LlenarTablaReservas(servicioReserva.FiltroTipoEvento(cmbTipoEvento.Text));
        }

        private void cmbTipoEvento_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmbTipoEvento.Items.Clear();


            ConexionSQL conexionSQL = new ConexionSQL();


            string query = "SELECT CodigoTipoEvento FROM TipoEvento";

            try
            {
                using (SqlConnection conn = conexionSQL.GetConnection())
                {

                    conn.Open();


                    SqlCommand cmd = new SqlCommand(query, conn);


                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbTipoEvento.Items.Add(reader["CodigoTipoEvento"].ToString());
                    }


                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los tipos de evento: {ex.Message}");
            }
            //if (cmbTipoEvento.Text == "Seleccionar")
            //{
            //    LlenarTablaReservas(servicioReserva.listaReservas());
            //}
            //else
            //    LlenarTablaReservas(servicioReserva.FiltroTipoEvento(cmbTipoEvento.Text));
        }

        // Lista Facturas
        private void LlenarTablaFacturas(List<Factura> lista)
        {
            tblFacturas.Rows.Clear();

            foreach (Factura factura in lista)
            {
                Reserva r = servicioReserva.buscarReserva(factura.idFactura);
                tblFacturas.Rows.Add(factura.idFactura, factura.idReserva, factura.cliente, r.tipoEvento, Reserva.ValorHora ,factura.horas, factura.TotalAPagar,factura.estado);
            }

        }
      

        private void btbPagar_Click(object sender, EventArgs e)
        {
          
            if (txtFactura.Text == string.Empty)
            {
                MessageBox.Show("Seleccione la factura a pagar");
            }
            else
            {
                int id = int.Parse(txtFactura.Text);
                Factura factura = servicioFactura.buscarFactura(id);
                //Factura factura = servicioFactura.BuscarFactura(id);
                DialogResult resultado = MessageBox.Show("¿Desea Pagar la factura " + factura.idFactura + " ?", "Confirmación de Pagar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    MessageBox.Show(servicioFactura.Modificar(factura));
                    LlenarTablaFacturas(servicioFactura.listaFacturas());
                    //LlenarTablaFacturas(servicioFactura.ListaFacturas());
                    txtFactura.Text = string.Empty;
                }
            }
        }

        private void tblFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var fila = tblFacturas.Rows[e.RowIndex];


            Factura factura = new Factura
            {
                idFactura = int.Parse(fila.Cells[0].Value.ToString()),
                idReserva = int.Parse(fila.Cells[1].Value.ToString()),
                cliente = fila.Cells[2].Value.ToString(),
                horas = int.Parse(fila.Cells[5].Value.ToString()),
                TotalAPagar = double.Parse(fila.Cells[6].Value.ToString()),
                estado = fila.Cells[7].Value.ToString(),
            };
            txtFactura.Text = factura.idFactura.ToString();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cmbEstado.SelectedIndex;
            if (indice == 0)
            {
                LlenarTablaFacturas(servicioFactura.listaFacturas());
                //LlenarTablaFacturas(servicioFactura.ListaFacturas());
            }
            else
            {
                LlenarTablaFacturas(servicioFactura.facturas(indice));
                //LlenarTablaFacturas(servicioFactura.Facturas(indice));
            }
        }
    }
}
