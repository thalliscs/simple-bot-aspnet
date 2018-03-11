using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleBot.Context
{
    /// <summary>
    /// Caso não exista um banco será criado um de nomenclatura "Bot" e a tabela UserProfile
    /// </summary>
    public class DatabaseInitializer : CreateDatabaseIfNotExists<BotContext>
    {
       
    }
}