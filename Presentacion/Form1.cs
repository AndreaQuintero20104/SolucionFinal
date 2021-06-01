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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void jThinButton1_Click(object sender, EventArgs e)
        {
            GestorUsuarios gsUsuarios = new GestorUsuarios(new Data());

            string cedula = txtCedula.Text;
            string contrasena = txtContraseña.Text;
            Usuario usuario = new Usuario();
            usuario.cedula = cedula;
            usuario.contraseña = contrasena;

            if (gsUsuarios.iniciarSesion(usuario))
            {
                MessageBox.Show("Ingreso Correcto");
                this.Hide();
                FormularioDisponibilidadCita cita = new FormularioDisponibilidadCita();
                cita.label9.Text = txtCedula.Text;
                cita.Show();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Application.Exit();
            System.Environment.Exit(1);
        }

        private void btnInicioAdministrador_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GestorAdministradores gsAdmin = new GestorAdministradores(new Data());

            int cedula =int.Parse(txtCedula.Text);
            string contrasena = txtContraseña.Text;

            if (gsAdmin.iniciarSesionAdmin(cedula, contrasena))
            {
                MessageBox.Show("Ingreso Correcto");
                this.Hide();
                PantallaOpcionesAdministrador pantallaAdmin = new PantallaOpcionesAdministrador();

                pantallaAdmin.label1.Text = txtCedula.Text;
                pantallaAdmin.Show();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }

        private void btnIniciarDueño_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GestorDueños gsDueño = new GestorDueños(new Data());

            int cedula = int.Parse(txtCedula.Text);
            string contrasena = txtContraseña.Text;

            if (gsDueño.iniciarSesionDueños(cedula, contrasena))
            {
                MessageBox.Show("Ingreso Correcto");
                this.Hide();

                PantallaOpcionesDueño dueño = new PantallaOpcionesDueño();
                dueño.label5.Text = txtCedula.Text;
                dueño.Show();

            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PantallaRegistrar registrar = new PantallaRegistrar();
            registrar.Show();
        }
    }
}
