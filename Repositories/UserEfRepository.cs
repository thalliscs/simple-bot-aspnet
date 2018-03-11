using SimpleBot.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SimpleBot.Repositories
{
    public class UserEfRepository : IUserRepository
    {
        #region Construtor
        private BotContext _context;
        public UserEfRepository(BotContext context)
        {
            _context = context;
        }
        #endregion

        #region Métodos
        public UserProfile GetProfileById(string id)
        {
            return _context.UserProfile.Find(id);
        }

        public void SalvarUserProfile(UserProfile perfil)
        {
            _context.UserProfile.AddOrUpdate(perfil);
            _context.SaveChanges();
        }

        public void AtualizarUserProfile(UserProfile perfil)
        {
            throw new NotImplementedException();
        }

        public void SalvarHistorico(Message message)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}