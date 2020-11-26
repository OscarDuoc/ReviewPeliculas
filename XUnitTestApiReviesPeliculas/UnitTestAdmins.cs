using ReviewPeliculas.Azure;
using ReviewPeliculas.Models;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestApiReviesPeliculas
{ 
    public class UnitTestAdmin
    {

        [Fact]
        public void TestObtenerUser()
        {
            //Arrange
            bool vieneConDatos = false;

            //Act
            var resultado = UsuarioAzure.ObtenerUsuarios();
            vieneConDatos = resultado.Any();

            //Assert 
            Assert.True(vieneConDatos);
        }

        [Fact]
        public void TestObtenerUserPorId()
        {
            //Arrange
            int idProbar = 1;
            Usuario userRetornado;

            //Act
            userRetornado = UsuarioAzure.ObtenerUsuarioPorId(idProbar);

            //Assert 
            Assert.NotNull(userRetornado);
        }

        [Fact]
        public void TestObtenerUserPorNombres()
        {
            //Arrange
            string nombres = "Carla Romina";
            Usuario userRetornado;

            //Act
            userRetornado = UsuarioAzure.obtenerUserPorNombres(nombres);

            //Assert 
            Assert.NotNull(userRetornado);
        }
    }
}
