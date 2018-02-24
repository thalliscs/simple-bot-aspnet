using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class Message
    {
        public string Id { set; get; }

        public string User { set; get; }

        public string Text { set; get; }

        public Message(string id, string username, string text)
        {
            this.Id = id;
            this.User = username;
            this.Text = text;
        }
    }
}