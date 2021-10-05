using Password.Core.Models;
using Password.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password.Infra
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
            // Password juan1234
            _users.Add(new User { Name = "juan23", Email = "juan@gmail.com", Salt = "0xLJsHVXYsvekpbr", Password = "FB6979BB477A1805F4DC1BDDB3D0B6ED78ED930C" });
            // Password pepa1234
            _users.Add(new User { Name = "pepa12", Email = "pepa@gmail.com", Salt = "iQmV0aJg0FnVi3C0", Password = "92EA6A5D905103C3CB8D98BB64453E58E46D1E16" });
        }

        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(i => i.Name == username);
        }
    }
}