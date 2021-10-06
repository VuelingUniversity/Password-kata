using Newtonsoft.Json;
using PasswordKata.Core.Services;
using PasswordKata.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKata.Infra
{
    public class UserRepository : IUserRepository
    {
        private string _path;
        private List<User> _userList;

        public UserRepository(string path)
        {
            _path = path;
            UpdateUserList();
        }

        public bool CheckUser(string username, string password)
        {
            if (_userList == null || _userList.Count < 1)
                return false;
            UpdateUserList();
            var userIndex = _userList.FindIndex(user => user.Username == username && user.Password == password);

            if (userIndex > -1)
                return true;

            return false;
        }

        public User GetUserFromUsername(string username)
        {
            return _userList.FirstOrDefault(user => user.Username == username);
        }

        public bool AddUser(string username, string password)
        {
            User user = new User { Username = username, Password = password };
            if (user == null || user.Username == "" || user.Password == "")
                return false;
            UpdateUserList();
            if (GetUserFromUsername(username) != null)
                return false;
            _userList.Add(user);
            return UpdateUserRepository();
        }

        public bool UpdateUserRepository()
        {
            if (_userList == null || _userList.Count < 1)
            {
                return false;
            }
            try
            {
                File.WriteAllText(_path, JsonConvert.SerializeObject(_userList));
                return true;
            }
            catch (DirectoryNotFoundException dirEx)
            {
                return false;
            }
        }

        public void UpdateUserList()
        {
            string register = File.ReadAllText(_path);
            if (register == null || register == "")
            {
                _userList = new List<User>();
                return;
            }
            _userList = JsonConvert.DeserializeObject<List<User>>(register);
        }
    }
}