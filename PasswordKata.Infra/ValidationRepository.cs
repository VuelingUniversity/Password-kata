using Newtonsoft.Json;
using PasswordKata.Core.models;
using PasswordKata.Core.services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKata.Infra
{
    public class ValidationRepository : IValidationRepository
    {
        private readonly string _dataPath;

        public ValidationRepository(string dataPath)
        {
            _dataPath = dataPath;
        }

        public List<User> GetUserList()
        {
            string json = ReadDB();
            var userList = JsonConvert.DeserializeObject<List<User>>(json);
            return userList;
        }

        private string ReadDB()
        {
            return File.ReadAllText(_dataPath);
        }
    }
}