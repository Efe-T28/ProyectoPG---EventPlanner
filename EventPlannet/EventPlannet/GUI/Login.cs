using Entidad;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : Form
    {
        private readonly ServicioAdministrador servicioAdministrador;
        public Login()
        {
            InitializeComponent();
            servicioAdministrador = new ServicioAdministrador();
        }

        private void bntAcceder_Click(object sender, EventArgs e)
        {
            string usuario = textBox2.Text;
            string contraseña = textBox1.Text;

            Administrador administrador = servicioAdministrador.ValidarAdministrador(usuario, contraseña);
            if (administrador != null)
            {
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                this.Hide();
                menuPrincipal.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }

            //MenuPrincipal menuPrincipal = new MenuPrincipal();
            //this.Hide();
            //menuPrincipal.Show();
        }

        private void BtCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
