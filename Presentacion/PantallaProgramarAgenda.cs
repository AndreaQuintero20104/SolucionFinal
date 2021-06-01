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
using System.Globalization;

namespace Presentacion
{
    public partial class PantallaProgramarAgenda : Form
    {
        public PantallaProgramarAgenda()
        {
            InitializeComponent();
        }
        Verificadores verificadores = new Verificadores();

        private void PantallaProgramarAgenda_Load(object sender, EventArgs e)
        {
            CbEstablecimientos.Items.Clear();
            GestorEstablecimientos gestorEstablecimientos = new GestorEstablecimientos(new Data());

            foreach (string elemento in gestorEstablecimientos.CargarEstablecimientosXadmin(label6.Text))
            {
                CbEstablecimientos.Items.Add(elemento);
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

        private void CbProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbFecha.Clear();
            GestorAgendas gestor = new GestorAgendas(new Data());

            dtAgendas.DataSource = gestor.CargarAgenda(CbProfesionales.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void jThinButton1_Click(object sender, EventArgs e)
        {
            GestorAgendas gestor = new GestorAgendas(new Data());

            if (CbEstablecimientos.Text == null || CbProfesionales.Text == null || CbFecha.Text == null || CbHora.Text == null)
            {
                MessageBox.Show("Falta ingresar campos");
            }
            else
            {
                var cultureInfo = new CultureInfo("de-DE");
                gestor.AgregarAgenda(CbProfesionales.Text,DateTime.Parse(CbFecha.Text, cultureInfo), CbHora.Text);
                MessageBox.Show("Agregado correctamente");

                CbFecha.Text = verificadores.limpiar(CbFecha.Text);
                CbHora.Text = verificadores.limpiar(CbHora.Text);

                dtAgendas.DataSource = gestor.CargarAgenda(CbProfesionales.Text);
            }
        }

        private void jThinButton2_Click(object sender, EventArgs e)
        {
            if (dtAgendas.CurrentRow.Selected == true)
            {


                string nombreProfesional = CbProfesionales.Text;
                string dia = Convert.ToDateTime(dtAgendas.CurrentRow.Cells[0].Value).ToString("yyyy-MM-dd");
                string hora = dtAgendas.CurrentRow.Cells[1].Value.ToString();



                DialogResult boton = MessageBox.Show("Está seguro que desea eliminar la agenda del profesional:  " + nombreProfesional + ", el dia: " + dia + " a las: " + hora + "?", "Confirmacion de cancelación", MessageBoxButtons.OKCancel);
                if (boton == DialogResult.OK)
                {
                    GestorAgendas agendas = new GestorAgendas(new Data());
                   


                    agendas.CancelarAgenda(nombreProfesional, Convert.ToDateTime(dia),hora);

                    dtAgendas.DataSource = agendas.CargarAgenda(nombreProfesional);
                    MessageBox.Show("se canceló la cita");
                }

            }
            else
            {
                MessageBox.Show("no se selecciono nada");
            }
        }
    }
}
