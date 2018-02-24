using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class SimpleBotUser
    {
        static IMongoClient _client = new MongoClient();
        static IUserRepository _userRepository = new UserSqlRepository(System.Configuration.ConfigurationManager.AppSettings["conexao"].ToString());
        static IUserMongoRepository _userMongoRepository = new UserMongoRepository(_client);
        static IUserMemRepository _userMemRepository = new UserMemRepository();

        public static string Reply(Message message)
        {
            string userId = message.Id;

            var perfil = _userRepository.GetProfileById(userId);

            if (perfil != null)
                perfil.Visitas++;
            else
            {
                perfil = new UserProfile()
                {
                    Id = userId,
                    Visitas = 0
                };
            }

            _userRepository.SalvarUserProfile(perfil);

            return $"{message.User} conversou {perfil.Visitas}";
        }

        public static string ReplyMongo(Message message)
        {
            string userId = message.Id;

            var perfil = _userMongoRepository.GetProfileById(userId);

            _userMongoRepository.SalvarUserProfile(userId, perfil);

            return $"{message.User} conversou {perfil.Visitas}";
        }
      
        public static string ReplyOffline(Message message)
        {
            string userId = message.Id;

            var perfil = _userMemRepository.GetProfileOffline(userId);

            perfil.Visitas++;

            _userMemRepository.SetProfileOffline(userId, perfil);

            return $"{message.User} conversou '{perfil.Visitas}'";
        }
    }
}