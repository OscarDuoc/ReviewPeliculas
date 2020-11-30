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

        [Fact]
        public void TestObtenerUserPorApellidos()
        {
            //Arrange
            string apellidos = "Molina Contreras";
            Usuario userRetornado;

            //Act
            userRetornado = UsuarioAzure.obtenerUserPorApellidos(apellidos);

            //Assert 
            Assert.NotNull(userRetornado);
        }

        [Fact]
        public void TestObtenerUserPorGenero()
        {
            //Arrange
            string genero = "Femenino";
            Usuario userRetornado;

            //Act
            userRetornado = UsuarioAzure.obtenerUserPorGenero(genero);

            //Assert 
            Assert.NotNull(userRetornado);
        }

        [Fact]
        public void TestAgregarUsuario()
        {
            //Arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;
            Usuario user = new Usuario();
            user.nombres = "Carlos Alberto ";
            user.apellidos = "Vibes Bueno";
            user.edad = 26;
            user.genero = "Masculino";
            user.email = "cvibes@gmail.com";

            //Act
            resultadoObtenido = UsuarioAzure.AgregarUsuario(user);

            //Assert 
            Assert.Equal(resultadoEsperado, resultadoObtenido);

        }

        [Fact]
        public void TestAgregarUsuarioPorParametro()
        {
            //Arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;
            string nombres = "Ramon Alberto";
            string apellidos = "Gonzalez Tapia";
            int edad =34;
            string genero = "Masculino";
            string email = "rgonzalez@gmail.com";

            //Act
            resultadoObtenido = UsuarioAzure.AgregarUsuario(nombres, apellidos,edad,genero,email);

            //Assert 
            Assert.Equal(resultadoEsperado, resultadoObtenido);

        }

        [Fact]
        public void TestEliminarUsuarioPorNombre()
        {
            //Arrange         
            Usuario user = new Usuario();
            user.nombres = "Marco Andre";
            user.apellidos = "Carmona Dominguez";
            user.edad = 40;
            user.genero = "Masculino";
            user.email = "mcarmona@gmail.com";


            string nombreUsuarioEliminar = "Marco Andre";

            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            UsuarioAzure.AgregarUsuario(user);

            //Act
            resultadoObtenido = UsuarioAzure.EliminarUsuarioPorNombre(nombreUsuarioEliminar);

            //Assert 
            Assert.Equal(resultadoEsperado, resultadoObtenido);

        }

        [Fact]
        public void TestEliminarUsuarioPorApellido()
        {
            //Arrange         
            Usuario user = new Usuario();
            user.idUsuario =3;
            user.nombres = "Carla Romina";
            user.apellidos = "Herrera Salas";
            user.edad = 23;
            user.genero = "Femenino";
            user.email = "cherrera@gmail.com";


            string apellidosUsuarioEliminar = "Herrera Salas";

            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            UsuarioAzure.AgregarUsuario(user);

            //Act
            resultadoObtenido = UsuarioAzure.EliminarUsuarioPorApellidos(apellidosUsuarioEliminar);

            //Assert 
            Assert.Equal(resultadoEsperado, resultadoObtenido);

        }

        [Fact]
        public void TestActualizarUsuarioPorId()
        {
            //Arrange
            int resultadoEsperado = 0;
            int resultadoObtenido = 1;

            Usuario usuario = new Usuario();
            usuario.idUsuario = 1;
            usuario.nombres = "Marco Andre";
            usuario.apellidos = "Carmona Dominguez";
            usuario.edad =40;
            usuario.genero = "Masculino";
            usuario.email = "mcarmona@gmail.com";
            //Act
            resultadoObtenido = UsuarioAzure.ActualizarUsuarioPorId(usuario);

            usuario.nombres = "Roberto Andres";
            UsuarioAzure.ActualizarUsuarioPorId(usuario);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }

    }
}
