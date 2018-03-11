using MongoDB.Driver;
using SimpleBot.Context;
using SimpleBot.Repositories;

namespace SimpleBot
{
    public class SimpleBotUser
    {
        #region Repository
        static string strCon = System.Configuration.ConfigurationManager.AppSettings["conexao"].ToString();

        static IUserRepository _userRepository = new UserSqlRepository(strCon);
        static IUserRepository _userDapperRepository = new UserDapperRepository(strCon);

        static IMongoClient _client = new MongoClient();
        static IUserRepository _userMongoRepository = new UserMongoRepository(_client);

        static BotContext _db = new BotContext();
        static IUserRepository _userEfRepository = new UserEfRepository(_db);

        static IUserRepository _userMemRepository = new UserMemRepository();

        #endregion

        #region Métodos

        public static string ReplySql(Message message)
        {
            string userId = message.Id;

            var perfil = _userRepository.GetProfileById(userId);

            if (perfil != null)
            {
                perfil.Visitas++;
                _userRepository.AtualizarUserProfile(perfil);
            }
            else
            {
                perfil = new UserProfile()
                {
                    Id = userId,
                    Visitas = 0
                };

                perfil.Visitas++;
                _userRepository.SalvarUserProfile(perfil);
            }

            return $"{message.User} conversou {perfil.Visitas}";
        }

        public static string ReplyDapper(Message message)
        {
            string userId = message.Id;

            var perfil = _userDapperRepository.GetProfileById(userId);

            if (perfil != null)
            {
                perfil.Visitas++;
                _userDapperRepository.AtualizarUserProfile(perfil);
            }
            else
            {
                perfil = new UserProfile()
                {
                    Id = userId,
                    Visitas = 0
                };
                perfil.Visitas++;
                _userDapperRepository.SalvarUserProfile(perfil);
            }

            return $"{message.User} conversou {perfil.Visitas}";
        }


        public static string ReplyMongo(Message message)
        {
            var perfil = _userMongoRepository.GetProfileById(message.Id);

            perfil.Visitas++;
            _userMongoRepository.SalvarUserProfile(perfil);

            return $"{message.User} conversou {perfil.Visitas}";
        }

        public static string ReplyOffline(Message message)
        {
            var perfil = _userMemRepository.GetProfileById(message.Id);

            perfil.Visitas++;
            _userMemRepository.SalvarUserProfile(perfil);

            return $"{message.User} conversou '{perfil.Visitas}'";
        }
     
        public static string ReplyEf(Message message)
        {
            var perfil = _userEfRepository.GetProfileById(message.Id);

            perfil = perfil ?? new UserProfile()
            {
                Id = message.Id,
                Visitas = 0
            };

            perfil.Visitas++;
            _userEfRepository.SalvarUserProfile(perfil);

            return $"{message.User} conversou {perfil.Visitas}";
        }

        #endregion
    }
}