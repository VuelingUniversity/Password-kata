using PasswordKata.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKata.InfraStructure.Repositories
{
    public class UsersRepository
    {
        public List<Users> _users;
        public UsersRepository()
        {
            _users = new List<Users>();
            _users.Add(new Users { Name = "Hernan", Email = "hernan@example.com", Salt = "xR3t5", Password = "3941e06948d57852774713cd86251854aec4f10aa949b0a8b3ac60fca3373658" });//Hernan5
            _users.Add(new Users { Name = "Diego", Email = "diego@example.com", Salt = "xR3t5", Password = "2c9703bc1395a8fe6fcb3d25a65815cd6bfffdb73ffa9080a702ed5d4ae715d3" });//Diego8
        }

        public Users GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(name => name.Name == username);
        }

        public bool IsEmailValid(string email)
        {
            return _users.Exists(mail => mail.Email == email);
        }
    }
}
