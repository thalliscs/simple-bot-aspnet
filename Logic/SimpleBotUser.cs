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
        public static string Reply(Message message)
        {
            IMongoClient client = new MongoClient();

            IMongoDatabase database = client.GetDatabase("Bot");

            var mensagem = new BsonDocument()
            {
                {"id", message.Id },
                {"text", message.Text },
                {"user", message.User },
            };
            var col = database.GetCollection<BsonDocument>("mensagens");
            col.InsertOne(mensagem);

            return $"{message.User} disse '{message.Text}'";
        }

        public static UserProfile GetProfile(string id)
        {
            return null;
        }

        public static void SetProfile(string id, UserProfile profile)
        {
        }
    }
}