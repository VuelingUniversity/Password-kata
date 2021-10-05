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
            _users.Add(new User { Name = "Paco", Email="paco@email.com", Password="1234"});
        }
        public User GetUserByName(string userName)
        {
            return _users.FirstOrDefault(x => x.Name == userName);
        }
    }
}
