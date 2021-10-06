using PasswordKata.Core.models;
using PasswordKata.Core.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKata.ServiceLibrary
{
    public class ValidationService : IValidationService
    {
        private readonly IValidationRepository _validationRepository;

        public ValidationService(IValidationRepository validationRepository)
        {
            _validationRepository = validationRepository;
        }

        public bool AreValidCredentials(string username, string password)
        {
            User userCredentials = new User() { UserName = username, Password = password };
            if (IsRegistered(userCredentials))
            {
                var users = _validationRepository.GetUserList();
                return users.FirstOrDefault(x => x.UserName == userCredentials.UserName && x.Password == ComputeHashing(userCredentials.Password)) != null;
            }
            return false;
        }

        /* Este método debería estar en un servicio diferente dedicado a Hashing */

        private string ComputeHashing(string rawData)
        {
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(rawData);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < tmpHash.Length; i++)
            {
                stringBuilder.Append(tmpHash[i].ToString("X2"));
            }
            return stringBuilder.ToString();
        }

        private bool IsRegistered(User user)
        {
            var users = _validationRepository.GetUserList();
            return users.FirstOrDefault(x => x.UserName == user.UserName) != null;
        }
    }
}