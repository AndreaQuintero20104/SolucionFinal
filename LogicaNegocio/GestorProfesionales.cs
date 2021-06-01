using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class GestorProfesionales
    {
        private FuenteDatosRepository fuenteDatos;

        public GestorProfesionales(FuenteDatosRepository fuente)
        {
            this.fuenteDatos = fuente;
        }

        public List<string> CargarProfesionales(string NombreEstb)
        {
            return this.fuenteDatos.MostrarProfesionales(NombreEstb);
        }

    }
}
