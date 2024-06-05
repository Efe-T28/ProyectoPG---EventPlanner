using Entidades.Modelos;
using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPG
{
    public partial class MenuPrincipal : Form
    {
        Cliente p;
        public MenuPrincipal()
        {
            InitializeComponent();
            p = new Cliente(100, "braulio", "Barrios", "3012", "123456");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void labelTitulodeformulario_Click(object sender, EventArgs e)
        {

        }

        private void panelTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegistrarEventos_Click(object sender, EventArgs e)
        {
          //OpenFileDialog ofd = new OpenFileDialog();    
          tabControl.SelectedIndex = 0;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnEventos_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void btnRegistrarClientes_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }

        private void btnFacruras_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 4;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel8_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel9_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCargarLista_Click(object sender, EventArgs e)
        {

        }

        private void texcodigo_Click(object sender, EventArgs e)
        {

        }

        private void texNombre_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalaPagar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (texcodigo.Text=="100")
            {
                texNombre.Text = p.Nombre;
              
            }
            else
            {
                MessageBox.Show("Este Cliente no existe");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion();
            conexion.abrir();
        }
    }
}
