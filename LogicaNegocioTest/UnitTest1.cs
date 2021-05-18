using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicaNegocio;
using AccesoDatos;

namespace LogicaNegocioTest
{
    [TestClass]
    public class UnitTest1
    {
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
    }
}
