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
    public partial class FormularioDetallesCita : Form
    {
        public FormularioDetallesCita()
        {
            InitializeComponent();
        }

        private void FormularioDetallesCita_Load(object sender, EventArgs e)
        {
            GestorCitas gestor = new GestorCitas(new Data());
            DtMostrarCitas.DataSource = gestor.CargarCitas(label1.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void jThinButton2_Click(object sender, EventArgs e)
        {
            if (DtMostrarCitas.CurrentRow.Selected == true)
            {

                string idCita = DtMostrarCitas.CurrentRow.Cells[0].Value.ToString();
                string nombreProfesional = DtMostrarCitas.CurrentRow.Cells[2].Value.ToString();
                string servicio = DtMostrarCitas.CurrentRow.Cells[3].Value.ToString();
                string dia = Convert.ToDateTime(DtMostrarCitas.CurrentRow.Cells[4].Value).ToString("yyyy-MM-dd");
                string hora = DtMostrarCitas.CurrentRow.Cells[5].Value.ToString();



                DialogResult boton = MessageBox.Show("Está seguro que desea cancelar la cita con el profesional:  " + nombreProfesional + ", para servicio de: " + servicio + ", el dia: " + dia + " a las: " + hora + "?", "Confirmacion de cancelación", MessageBoxButtons.OKCancel);
                if (boton == DialogResult.OK)
                {
                    GestorCitas citas = new GestorCitas(new Data());
                    
                    citas.CancelarCita(Convert.ToInt32(idCita), nombreProfesional, Convert.ToDateTime(dia), hora);
                    
                    DtMostrarCitas.DataSource = citas.CargarCitas(label1.Text);
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
