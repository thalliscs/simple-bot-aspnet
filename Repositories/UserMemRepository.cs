using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class UserMemRepository : IUserRepository
    {
        Dictionary<string, UserProfile> _perfil = new Dictionary<string, UserProfile>();
        
        public UserProfile GetProfileById(string id)
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
            throw new NotImplementedException();
        }

        public void SalvarUserProfile(UserProfile perfil)
        {
            _perfil[perfil.Id] = perfil;
        }

        public void AtualizarUserProfile(UserProfile perfil)
        {
            throw new NotImplementedException();
        }

    }
}