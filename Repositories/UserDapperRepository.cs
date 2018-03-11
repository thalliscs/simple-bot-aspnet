using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace SimpleBot.Repositories
{
    public class UserDapperRepository : IUserRepository
    {
        #region Construtor
        private readonly string _connectionString;

        public UserDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Métodos
        public UserProfile GetProfileById(string id)
        {
            UserProfile userProfile = null;

            var strQuery = "SELECT [Id],[Visitas] FROM [Bot].[dbo].[UserProfile] WHERE Id = @id";

            using (var sqlConn = new SqlConnection(_connectionString))
            {
                userProfile = sqlConn.Query<UserProfile>(strQuery, new { Id = id }).FirstOrDefault();
            }

            return userProfile;
        }

        public void SalvarUserProfile(UserProfile perfil)
        {
            using (var sqlConn = new SqlConnection(_connectionString))
            {
                sqlConn.Execute("INSERT INTO [dbo].[UserProfile] ([Id],[Visitas]) VALUES(@Id, @Visitas)", perfil);
            }
        }

        public void AtualizarUserProfile(UserProfile perfil)
        {
            using (var sqlConn = new SqlConnection(_connectionString))
            {
                sqlConn.Execute("UPDATE [dbo].[UserProfile] SET [Visitas] = @Visitas WHERE [Id] = @Id", perfil);
            }
        }

        public void SalvarHistorico(Message message)
        {

        } 
        #endregion

    }
}