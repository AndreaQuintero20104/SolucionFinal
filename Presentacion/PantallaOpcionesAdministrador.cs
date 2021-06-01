using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class PantallaOpcionesAdministrador : Form
    {
        public PantallaOpcionesAdministrador()
        {
            InitializeComponent();
        }

        private void PantallaOpcionesAdministrador_Load(object sender, EventArgs e)
        {

        }

        private void jThinButton2_Click(object sender, EventArgs e)
        {
            PantallaProgramarAgenda pantallaProgramarAgenda = new PantallaProgramarAgenda();
            pantallaProgramarAgenda.label6.Text = label1.Text;
            pantallaProgramarAgenda.Show();
        }

        private void jThinButton3_Click(object sender, EventArgs e)
        {
            PantallaGraficoAdministrador grafico = new PantallaGraficoAdministrador();
            grafico.label5.Text = this.label1.Text;
            grafico.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Form1 ingreso = new Form1();
            ingreso.Show();
        }
    }
}
