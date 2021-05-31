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
    public partial class FormularioDisponibilidadCita : Form
    {
        public FormularioDisponibilidadCita()
        {
            InitializeComponent();
        }
        Verificadores verificadores = new Verificadores();


        private void I_Paint(object sender, PaintEventArgs e)
        {

        }


        private void jThinButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void FormularioDisponibilidadCita_Load(object sender, EventArgs e)
        {
            CbEstablecimientos.Items.Clear();
            GestorEstablecimientos gestorEstablecimientos = new GestorEstablecimientos(new Data());

            foreach (string elemento in gestorEstablecimientos.CargarEstablecimientos())
            {
                CbEstablecimientos.Items.Add(elemento);
            }


        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Form1 inicio = new Form1();
            inicio.Show();
        }

        private void jThinButton1_Click_1(object sender, EventArgs e)
        {
            GestorCitas citas = new GestorCitas(new Data());

            if (cbHoras.Text == null || cbFechas.Text == null || CbEstablecimientos.Text == null || CbProfesionales.Text == null || cbServicios.Text == null)
            {
                MessageBox.Show("Falta ingresar campos");
            }
            else
            {
                citas.AgregarCita(label9.Text, CbEstablecimientos.Text, CbProfesionales.Text, cbServicios.Text, 
                    Convert.ToDateTime(cbFechas.Text), cbHoras.Text, richTextBox1.Text);

                MessageBox.Show("Se agendó la cita");

                CbEstablecimientos.Text = verificadores.limpiar(CbEstablecimientos.Text);
                CbProfesionales.Text = verificadores.limpiar(CbProfesionales.Text);
                cbServicios.Text = verificadores.limpiar(cbServicios.Text);
                cbFechas.Text = verificadores.limpiar(cbFechas.Text);
                cbHoras.Text = verificadores.limpiar(cbHoras.Text);
                richTextBox1.Text = verificadores.limpiar(richTextBox1.Text);
            }


        }

        private void CbProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbServicios.Text = verificadores.limpiar(cbServicios.Text);
            cbFechas.Text = verificadores.limpiar(cbFechas.Text);
            cbHoras.Text = verificadores.limpiar(cbHoras.Text);

            cbServicios.Items.Clear();
            cbFechas.Items.Clear();
            cbHoras.Items.Clear();

            GestorServicios servicios = new GestorServicios(new Data());
            string se = CbProfesionales.Text;

            foreach (string elemento in servicios.CargarServicios(se))
            {
                cbServicios.Items.Add(elemento);
            }

            GestorAgendas agendas = new GestorAgendas(new Data());
            string ag = CbProfesionales.Text;

            foreach (string elemento in agendas.CargarFechas(ag))
            {
                cbFechas.Items.Add(Convert.ToDateTime(elemento).ToString("yyyy-MM-dd"));
            }

        }

        private void CbEstablecimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbProfesionales.Items.Clear();
            CbProfesionales.Text = verificadores.limpiar(CbProfesionales.Text);
            GestorProfesionales profesionales = new GestorProfesionales(new Data());
            string se = CbEstablecimientos.Text;

            foreach (string elemento in profesionales.CargarProfesionales(se))
            {
                CbProfesionales.Items.Add(elemento);
            }
        }

        private void cbFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbHoras.Items.Clear();
            cbHoras.Text = verificadores.limpiar(cbHoras.Text);

            GestorAgendas agendas = new GestorAgendas(new Data());
            string ag = CbProfesionales.Text;
            DateTime fe = Convert.ToDateTime(cbFechas.Text).Date;
           

            foreach (string elemento in agendas.CargarHoras(ag, fe))
            {
                cbHoras.Items.Add(elemento);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void jThinButton2_Click(object sender, EventArgs e)
        {
            CbEstablecimientos.Text = verificadores.limpiar(CbEstablecimientos.Text);
            CbProfesionales.Text = verificadores.limpiar(CbProfesionales.Text);
            cbServicios.Text = verificadores.limpiar(cbServicios.Text);
            cbFechas.Text = verificadores.limpiar(cbFechas.Text);
            cbHoras.Text = verificadores.limpiar(cbHoras.Text);
            richTextBox1.Text = verificadores.limpiar(richTextBox1.Text);
        }

        private void jFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void jFlatButton2_Click(object sender, EventArgs e)
        {
            FormularioDetallesCita misCitas = new FormularioDetallesCita();
            misCitas.label1.Text = label9.Text;
            misCitas.Show();
        }

        private void cbHoras_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
