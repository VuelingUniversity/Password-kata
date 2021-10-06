using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Kata_Core.Models;
using Password_Kata_Core.Services;

namespace Password_Kata_Infra
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;
        public UserRepository()
        {
            _users = new List<User>();
            //juan123
            _users.Add(new User { Name = "Juan", Email = "juan@email.com", Password = "RdEJz82Tm4h2MegYGALMwBQ9dPG43gTp", Salt = "x/B7KuXZe46S2gif3s5XCg==" });
            //paco567
            _users.Add(new User { Name = "Paco", Email="paco@email.com", Password= "B0VhWBFyOgFB5Id3JRT9AG6bdPFud94s", Salt= "TXFKFHLcvJWCzq/lePUm2Q==" });
        }
        public User GetUserByName(string userName)
        {
            return _users.FirstOrDefault(x => x.Name == userName);
        }
        public string GetPassByName(string userName)
        {
            return _users.FirstOrDefault(x => x.Name == userName).Password;
        }
    }
}
