using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleBot
{
    public class UserMongoRepository : IUserRepository
    {
        #region Construtor
        private static IMongoDatabase _database;
        private static IMongoClient _client;

        public UserMongoRepository(IMongoClient client)
        {
            _client = client;
            _database = _client.GetDatabase("Bot");
        }
        #endregion

        #region Métodos
        public UserProfile GetProfileById(string userId)
        {
            var col = _database.GetCollection<UserProfile>("profiles");

            var filter = Builders<UserProfile>.Filter.Eq("Id", userId);
            var results = col.Find(filter).FirstOrDefault();

            if (results != null)
                return results;

            return new UserProfile()
            {
                Id = userId,
                Visitas = 0
            };
        }

        public void SalvarHistorico(Message message)
        {
            var mensagem = new BsonDocument()
            {
                {"id", message.Id },
                {"text", message.Text },
                {"user", message.User },
            };

            var col = _database.GetCollection<BsonDocument>("mensagens");
            col.InsertOne(mensagem);
        }

        public void SalvarUserProfile(UserProfile perfil)
        {
            var col = _database.GetCollection<UserProfile>("profiles");

            if (perfil != null)
                col.ReplaceOne(x => x.Id == perfil.Id, perfil, new UpdateOptions() { IsUpsert = true });
        }

        public void AtualizarUserProfile(UserProfile perfil)
        {
            throw new System.NotImplementedException();
        } 
        #endregion
    }
}