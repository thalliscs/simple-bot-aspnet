using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public interface IUserMongoRepository
    {
        void SalvarHistorico(Message message);

        void SalvarUserProfile(string userId, UserProfile perfil);

        UserProfile GetUserProfileById(string userId);
    }
}