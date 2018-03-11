using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SimpleBot.Context
{
    public class BotContext : DbContext
    {
        static readonly string strConn = System.Configuration.ConfigurationManager.AppSettings["conexao"].ToString();

        public BotContext() : base(strConn) { }

        public DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove a pluralização da tabela -> UserProfile em vez de UserProfiles
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}