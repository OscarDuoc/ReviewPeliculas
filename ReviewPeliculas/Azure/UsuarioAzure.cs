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
            sqlCommand.CommandText = $"select * from Administrador where nombres = '{nombres}'";
            connection.Open();
            return sqlCommand;
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
