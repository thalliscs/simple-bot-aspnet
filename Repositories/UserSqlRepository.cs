using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class UserSqlRepository : IUserRepository
    {
        #region Construtor
        private readonly string _connectionString;

        public UserSqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Métodos
        public UserProfile GetProfileById(string id)
        {
            UserProfile userProfile = null;

            var queryString = "SELECT [Id],[Visitas] FROM [Bot].[dbo].[UserProfile] WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userProfile = new UserProfile()
                    {
                        Id = reader["Id"].ToString(),
                        Visitas = Convert.ToInt32(reader["Visitas"])
                    };
                }
                reader.Close();

            }

            return userProfile;
        }

        public void SalvarHistorico(Message message)
        {
            string query = "INSERT INTO [dbo].[Message]([Id],[User],[Text]) VALUES (@Id, @User, @Text)";

            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.VarChar, 50).Value = message.Id;
                cmd.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = message.User;
                cmd.Parameters.Add("@Text", SqlDbType.VarChar, 50).Value = message.Text;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void SalvarUserProfile(UserProfile perfil)
        {
            string query = "INSERT INTO [dbo].[UserProfile] ([Id],[Visitas]) VALUES(@Id, @Visitas)";

            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.VarChar, 50).Value = perfil.Id;
                cmd.Parameters.Add("@Visitas", SqlDbType.VarChar, 50).Value = perfil.Visitas;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }


        public void AtualizarUserProfile(UserProfile perfil)
        {
            string query = "UPDATE [dbo].[UserProfile] SET [Visitas] = @Visitas WHERE [Id] = @Id";

            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {

                cmd.Parameters.Add("@Id", SqlDbType.VarChar, 50).Value = perfil.Id;
                cmd.Parameters.Add("@Visitas", SqlDbType.VarChar, 50).Value = perfil.Visitas;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        } 
        #endregion
    }
}