using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class UserMemRepository : IUserMemRepository
    {
        Dictionary<string, UserProfile> _perfil = new Dictionary<string, UserProfile>();

        public UserProfile GetProfileOffline(string id)
        {
            if (_perfil.ContainsKey(id))
                return _perfil[id];

            return new UserProfile()
            {
                Id = id,
                Visitas = 0
            };
        }

        public void SalvarHistorico(Message message)
        {
            
        }

        public void SetProfileOffline(string id, UserProfile profile)
        {
            _perfil[id] = profile;
        }
    }
}