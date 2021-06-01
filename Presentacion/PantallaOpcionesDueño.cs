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
    public partial class PantallaOpcionesDueño : Form
    {
        public PantallaOpcionesDueño()
        {
            InitializeComponent();
        }

        private void jThinButton3_Click(object sender, EventArgs e)
        {
            PantallaGraficoDueño grafico = new PantallaGraficoDueño();
            grafico.label5.Text = this.label5.Text;
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
