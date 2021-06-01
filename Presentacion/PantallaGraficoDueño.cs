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
using System.Windows.Forms.DataVisualization.Charting;

namespace Presentacion
{
    public partial class PantallaGraficoDueño : Form
    {
        public PantallaGraficoDueño()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void PantallaGraficoDueño_Load(object sender, EventArgs e)
        {
            GestorEstablecimientos gestor = new GestorEstablecimientos(new Data());
            

            DtMostrarDatos.DataSource = gestor.graficaDueño(label5.Text);

            List<string> establecimientos = new List<string>();
            List<string> NumeroCitas = new List<string>();

            foreach (DataGridViewRow row in DtMostrarDatos.Rows)
            {
                string establecimiento = Convert.ToString(row.Cells["Nombre"].Value);
                establecimientos.Add(establecimiento);
            }

            foreach (DataGridViewRow row in DtMostrarDatos.Rows)
            {
                string citas = Convert.ToString(row.Cells["Numero de Citas"].Value);
                NumeroCitas.Add(citas);
            }


            for (int i = 0; i < establecimientos.Count; i++)
            {
                Series serie = chart1.Series.Add(establecimientos[i]);

                serie.Label = NumeroCitas[i].ToString();

                serie.Points.Add(Convert.ToDouble(NumeroCitas[i]));
            }
        }
    }
}
