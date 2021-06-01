using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;
using AccesoDatos;

namespace Presentacion
{
    public partial class PantallaRegistrar : Form
    {
        public PantallaRegistrar()
        {
            InitializeComponent();
        }
        Verificadores verificadores = new Verificadores();
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void jThinButton1_Click(object sender, EventArgs e)
        {
            GestorUsuarios usuario = new GestorUsuarios(new Data());

            Usuario usuario1 = new Usuario();

            if (txtCedula.Text == null || txtcontraseña.Text==null || txtnombre.Text == null || txtcelular.Text==null || txtfecha.Text==null || txtdireccion.Text==null || txtemail.Text==null)
            {
                MessageBox.Show("Falta ingresar campos");
            }
            else
            {
               
                usuario1.cedula = txtCedula.Text;
                usuario1.contraseña = txtcontraseña.Text;
                usuario1.nombre = txtnombre.Text;
                usuario1.celular = txtcelular.Text;
                usuario1.telefono = txttelefono.Text;
                usuario1.fechanac = Convert.ToDateTime(txtfecha.Text);
                usuario1.direccion = txtdireccion.Text;
                usuario1.email = txtemail.Text;

                usuario.RegistrarCliente(usuario1);
                MessageBox.Show("Registro exitoso, ahora puede ingresar");

                txtCedula.Text = verificadores.limpiar(txtCedula.Text);
                txtnombre.Text = verificadores.limpiar(txtnombre.Text);
                txtcontraseña.Text = verificadores.limpiar(txtcontraseña.Text);
                txtcelular.Text = verificadores.limpiar(txtcelular.Text);
                txttelefono.Text = verificadores.limpiar(txttelefono.Text);
                txtfecha.Text = verificadores.limpiar(txtfecha.Text);
                txtdireccion.Text = verificadores.limpiar(txtdireccion.Text);
                txtemail.Text = verificadores.limpiar(txtemail.Text);

               
            }

            
            
        }

    
    }
}
