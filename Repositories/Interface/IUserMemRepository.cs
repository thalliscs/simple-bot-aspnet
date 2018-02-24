using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public interface IUserMemRepository
    {
        UserProfile GetProfileOffline(string id);

        void SalvarHistorico(Message message);

        void SetProfileOffline(string id, UserProfile profile);
    }
}