using System.Data.SqlClient;

namespace SistemaGestionWEB.Repository
{
    public static class RepositoryTools
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Server=WORK-LAP-IERS\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        public static bool Session(string userParameter, string passParameter)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.Parameters.Add(new SqlParameter("user", System.Data.SqlDbType.VarChar) { Value = userParameter });
                cmd.Parameters.Add(new SqlParameter("pass", System.Data.SqlDbType.VarChar) { Value = passParameter });

                cmd.CommandText = @"
                SELECT
	                *
                FROM
	                Usuario
				WHERE
					NombreUsuario = @user AND
					Contraseña = @pass
                ";

                var reader = cmd.ExecuteReader();

                if (reader.Read()) { return true; }
                else { return false; }

                reader.Close();
                connection.Close();
            }

            return false;
        }

    }
}
