using ReviewPeliculas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ReviewPeliculas.Azure
{
    public class UsuarioAzure
    {
        static string connectionString = @"Server=DESKTOP-UJCISGT;Database=ApiReviewPelicula;Trusted_Connection=True;";

        private static List<Usuario> Users;

        public static List<Usuario> ObtenerUsuarios()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var dataTableUsuario = retornoDeUserSQL(connection);
                return LlenadoUsers(dataTableUsuario);
            }
        }

        public static Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var comando = ConsultaUserPorIdSql(connection, idUsuario);

                var dataTable = LlenarDataTable(comando);

                return CreacionUser(dataTable);
            }
        }

        public static Usuario obtenerUserPorNombres(string nombres)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var comando = obtenerUserPorNombres(connection, nombres);

                var dataTable = LlenarDataTable(comando);

                return CreacionUser(dataTable);

            }
        }

        private static SqlCommand obtenerUserPorNombres(SqlConnection connection, string nombres)
        {
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = $"select * from Usuario where nombres = '{nombres}'";
            connection.Open();
            return sqlCommand;
        }

        public static Usuario obtenerUserPorApellidos(string apellidos)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var comando = obtenerUserPorApellidos(connection, apellidos);

                var dataTable = LlenarDataTable(comando);

                return CreacionUser(dataTable);

            }
        }

        private static SqlCommand obtenerUserPorApellidos(SqlConnection connection, string apellidos)
        {
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = $"select * from Usuario where apellidos = '{apellidos}'";
            connection.Open();
            return sqlCommand;
        }

        public static Usuario obtenerUserPorGenero(string genero)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var comando = obtenerUserPorGenero(connection, genero);

                var dataTable = LlenarDataTable(comando);

                return CreacionUser(dataTable);

            }
        }

        private static SqlCommand obtenerUserPorGenero(SqlConnection connection, string genero)
        {
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = $"select * from Usuario where genero = '{genero}'";
            connection.Open();
            return sqlCommand;
        }

        public static int AgregarUsuario(Usuario user)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Insert into Usuario (nombres,apellidos,edad,genero,email) values (@nombres,@apellidos,@edad,@genero,@email)";
                sqlCommand.Parameters.AddWithValue("@nombres", user.nombres);
                sqlCommand.Parameters.AddWithValue("@apellidos", user.apellidos);
                sqlCommand.Parameters.AddWithValue("@edad", user.edad);
                sqlCommand.Parameters.AddWithValue("@genero", user.genero);
                sqlCommand.Parameters.AddWithValue("@email", user.email);

                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return resultado;
        }

        public static int AgregarUsuario(string nombres, string apellidos, int edad, string genero, string email)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Insert into Usuario (nombres,apellidos,edad,genero,email) values (@nombres,@apellidos,@edad,@genero,@email)";
                sqlCommand.Parameters.AddWithValue("@nombres", nombres);
                sqlCommand.Parameters.AddWithValue("@apellidos", apellidos);
                sqlCommand.Parameters.AddWithValue("@edad", edad);
                sqlCommand.Parameters.AddWithValue("@genero", genero);
                sqlCommand.Parameters.AddWithValue("@email", email);


                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            return resultado;
        }

        public static int EliminarUsuarioPorNombre(string nombres)
        {
            int resultado = 1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Delete from Usuario where nombres = @nombres";
                sqlCommand.Parameters.AddWithValue("@nombres", nombres);

                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return resultado;
            }
        }

        public static int EliminarUsuarioPorApellidos(string apellidos)
        {
            int resultado = 1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Delete from Usuario where apellidos = @apellidos";
                sqlCommand.Parameters.AddWithValue("@apellidos", apellidos);

                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return resultado;
            }
        }

        public static int ActualizarUsuarioPorId(Usuario usuario)
        {
            int resultado = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "Update Usuario SET Usuario = @nombres, apellidos = @apellidos where idUsuario = @idUsuario";

                sqlCommand.Parameters.AddWithValue("@nombres", usuario.nombres);
                sqlCommand.Parameters.AddWithValue("@apellidos", usuario.apellidos);
                sqlCommand.Parameters.AddWithValue("@edad", usuario.edad);
                sqlCommand.Parameters.AddWithValue("@genero", usuario.genero);
                sqlCommand.Parameters.AddWithValue("@email", usuario.email);

                try
                {
                    sqlConnection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return resultado;
        }

        private static Usuario CreacionUser(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Usuario User = new Usuario();
                User.idUsuario = int.Parse(dataTable.Rows[0]["idUsuario"].ToString());
                User.nombres = dataTable.Rows[0]["nombres"].ToString();
                User.apellidos = dataTable.Rows[0]["apellidos"].ToString();
                User.edad = int.Parse(dataTable.Rows[0]["edad"].ToString());
                User.genero = dataTable.Rows[0]["genero"].ToString();
                User.email = dataTable.Rows[0]["email"].ToString();
                return User;
            }
            else
            {
                return null;
            }
        }

        private static DataTable LlenarDataTable(SqlCommand comando)
        {
            //2. llenamos el dataTable(conversion)
            var dataTable = new DataTable();
            var dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        private static SqlCommand ConsultaUserPorIdSql(SqlConnection connection, int idUsuario)
        {
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = $"select * from Usuario where idUsuario = {idUsuario}";
            connection.Open();
            return sqlCommand;
        }

        private static List<Usuario> LlenadoUsers(DataTable dataTable)
        {
            Users = new List<Usuario>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Usuario User = new Usuario();
                User.idUsuario = int.Parse(dataTable.Rows[i]["idUsuario"].ToString());
                User.nombres = dataTable.Rows[i]["nombres"].ToString();
                User.apellidos = dataTable.Rows[i]["apellidos"].ToString();
                User.edad = int.Parse(dataTable.Rows[i]["edad"].ToString());
                User.genero = dataTable.Rows[i]["genero"].ToString();
                User.email = dataTable.Rows[i]["email"].ToString();
                Users.Add(User);
            }
            return Users;
        }

        private static DataTable retornoDeUserSQL(SqlConnection connection)
        {

            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = "select * from Usuario";
            connection.Open();

            return LlenarDataTable(sqlCommand);
        }

    }
}
