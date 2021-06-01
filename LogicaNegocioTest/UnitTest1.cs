using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicaNegocio;
using AccesoDatos;
using System.Collections.Generic;
using System.Data;

namespace LogicaNegocioTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void ProbarAgendarUusario()
        {
            DatosPruebasUnitarias datos = new DatosPruebasUnitarias();
            string resultadoesperado = "se agregó correctamente";

            GestorUsuarios gesCon = new GestorUsuarios(new DatosPruebasUnitarias());

            string resultadoObtenido = gesCon.RegistrarCliente("10025698", "asd123", "Carlie Baaaaa", "12312312","12312312", Convert.ToDateTime("2020-11-11"), "01:00:00", "hola");

            Assert.AreEqual(resultadoesperado[1], resultadoObtenido[1]);

        }

        [TestMethod]
        public void ProbarIniciarSesionUsuarioExistente()
        {
            bool resultadoEsperado = true;

            GestorUsuarios gesCon = new GestorUsuarios(new DatosPruebasUnitarias());

            bool resultadoObtenido = gesCon.iniciarSesion("1001540023", "123456");

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ProbarIniciarSesionUsuarioNoExistente()
        {
            bool resultadoEsperado = false;

            GestorUsuarios gesCon = new GestorUsuarios(new DatosPruebasUnitarias());

            bool resultadoObtenido = gesCon.iniciarSesion("1001540023", "111");

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ProbarIniciarSesionAdminExistente()
        {
            bool resultadoEsperado = true;

            GestorAdministradores gesCon = new GestorAdministradores(new DatosPruebasUnitarias());

            bool resultadoObtenido = gesCon.iniciarSesionAdmin(123456789, "11111");

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ProbarIniciarSesionAdminNoExistente()
        {
            bool resultadoEsperado = false;

            GestorAdministradores gesCon = new GestorAdministradores(new DatosPruebasUnitarias());

            bool resultadoObtenido = gesCon.iniciarSesionAdmin(123456789, "123456");

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ProbarIniciarSesionDueñoExistente()
        {
            bool resultadoEsperado = true;

            GestorDueños gesCon = new GestorDueños(new DatosPruebasUnitarias());

            bool resultadoObtenido = gesCon.iniciarSesionDueños(292617088, "cY7R2Pnv5");

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ProbarIniciarSesionDueñoNoExistente()
        {
            bool resultadoEsperado = false;

            GestorDueños gesCon = new GestorDueños(new DatosPruebasUnitarias());

            bool resultadoObtenido = gesCon.iniciarSesionDueños(292617088, "sad");

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ProbarMostrarEstablecimientos()
        {
            DatosPruebasUnitarias datos = new DatosPruebasUnitarias();
            List<string> resultadoesperado = datos.baseDatos3;

            GestorEstablecimientos gesCon = new GestorEstablecimientos(new DatosPruebasUnitarias());

            List<string> resultadoObtenido = gesCon.CargarEstablecimientos();

            Assert.AreEqual(resultadoesperado[0], resultadoObtenido[0]);

        }

        [TestMethod]
        public void ProbarMostrarProfesionales()
        {
            DatosPruebasUnitarias datos = new DatosPruebasUnitarias();
            List<string> resultadoesperado = datos.baseDatos4;

            GestorProfesionales gesCon = new GestorProfesionales(new DatosPruebasUnitarias());

            List<string> resultadoObtenido = gesCon.CargarProfesionales("Babblestorm");

            Assert.AreEqual(resultadoesperado[0], resultadoObtenido[0]);

        }

        [TestMethod]
        public void ProbarMostrarServicioProfesionales()
        {
            DatosPruebasUnitarias datos = new DatosPruebasUnitarias();
            List<string> resultadoesperado = datos.baseDatos5;

            GestorServicios gesCon = new GestorServicios(new DatosPruebasUnitarias());

            List<string> resultadoObtenido = gesCon.CargarServicios("Software Engineer IV");

            Assert.AreEqual(resultadoesperado[0], resultadoObtenido[0]);

        }

        [TestMethod]
        public void ProbarMostrarServicioProfesionalesFecha()
        {
            DatosPruebasUnitarias datos = new DatosPruebasUnitarias();
            List<string> resultadoesperado = datos.baseDatos6;

            GestorAgendas gesCon = new GestorAgendas(new DatosPruebasUnitarias());

            List<string> resultadoObtenido = gesCon.CargarFechas("Carlie Byrd");

            Assert.AreEqual(resultadoesperado[0], resultadoObtenido[0]);

        }

        [TestMethod]
        public void ProbarMostrarServicioProfesionalesHora()
        {
            DatosPruebasUnitarias datos = new DatosPruebasUnitarias();
            List<string> resultadoesperado = datos.baseDatos6;

            GestorAgendas gesCon = new GestorAgendas(new DatosPruebasUnitarias());

            List<string> resultadoObtenido = gesCon.CargarHoras("Carlie Byrd", Convert.ToDateTime("2020-11-11"));

            Assert.AreEqual(resultadoesperado[1], resultadoObtenido[1]);

        }

        [TestMethod]
        public void ProbarAgendarCita()
        {
            DatosPruebasUnitarias datos = new DatosPruebasUnitarias();
            string resultadoesperado = "se insertó correctamente la cita";

            GestorCitas gesCon = new GestorCitas(new DatosPruebasUnitarias());

            string resultadoObtenido = gesCon.AgregarCita("1", "Babblestorm", "Carlie Byrd", "Software Engineer IV", Convert.ToDateTime("2020-11-11"), "01:00:00", "hola");

            Assert.AreEqual(resultadoesperado[1], resultadoObtenido[1]);

        }

        [TestMethod]
        public void ProbarMostrarCitas()
        {
            DatosPruebasUnitarias datos = new DatosPruebasUnitarias();

            DataTable resultadoEsperado = datos.baseDatos8;

            string a = resultadoEsperado.Rows[0]["ID"].ToString();


            GestorCitas gsCita = new GestorCitas(new DatosPruebasUnitarias());
            DataTable resultadoObtenido = gsCita.CargarCitas("1001540023");

            string b = resultadoObtenido.Rows[0]["ID"].ToString();

            Assert.AreEqual(a, b);

        }

        [TestMethod]
        public void ProbarCancelarCita()
        {
            DatosPruebasUnitarias datos = new DatosPruebasUnitarias();
            string resultadoesperado = "se cancelo la cita";

            GestorCitas gesCon = new GestorCitas(new DatosPruebasUnitarias());

            string resultadoObtenido = gesCon.CancelarCita(20020, "Garvy Thorndycraft", Convert.ToDateTime("2020-11-11"), "01:00:00");

            Assert.AreEqual(resultadoesperado[1], resultadoObtenido[1]);

        }

        [TestMethod]
        public void ProbarEstablecimientosXadmin()
        {
            DatosPruebasUnitarias datos = new DatosPruebasUnitarias();
            List<string> resultadoesperado = datos.baseDatos4;

            GestorEstablecimientos gesCon = new GestorEstablecimientos(new DatosPruebasUnitarias());

            List<string> resultadoObtenido = gesCon.CargarEstablecimientosXadmin("7780630366");

            Assert.AreEqual(resultadoesperado[1], resultadoObtenido[1]);

        }

        [TestMethod]
        public void VerAgendas()
        {
            DatosPruebasUnitarias datos = new DatosPruebasUnitarias();

            DataTable resultadoEsperado = datos.baseDatos9;

            string a = resultadoEsperado.Rows[0]["Dia"].ToString();


            GestorAgendas gsAgenda = new GestorAgendas(new DatosPruebasUnitarias());
            DataTable resultadoObtenido = gsAgenda.CargarAgenda("Carlie Byrd");

            string b = resultadoObtenido.Rows[0]["Dia"].ToString();

            Assert.AreEqual(a, b);

        }

        [TestMethod]
        public void ProbarAgendarAgenda()
        {
            
            string resultadoesperado = "se insertó correctamente la agenda";

            GestorAgendas gesCon = new GestorAgendas(new DatosPruebasUnitarias());

            string resultadoObtenido = gesCon.AgregarAgenda("Carlie Byrd", Convert.ToDateTime("2020-10-10"), "01:00:00");

            Assert.AreEqual(resultadoesperado[1], resultadoObtenido[1]);

        }

        [TestMethod]
        public void ProbarCancelarAgenda()
        {
            DatosPruebasUnitarias datos = new DatosPruebasUnitarias();
            string resultadoesperado = "se elimino correctamente la agenda";

            GestorAgendas gesCon = new GestorAgendas(new DatosPruebasUnitarias());

            string resultadoObtenido = gesCon.CancelarAgenda("Carlie Byrd", Convert.ToDateTime("2020-11-11"), "01:00:00");

            Assert.AreEqual(resultadoesperado[1], resultadoObtenido[1]);

        }
    }
}
