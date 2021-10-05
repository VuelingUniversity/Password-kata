using Password.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PasswordWCF
{
    public class AuthService : IAuthService
    {
        private IEncryptionService _encryptionService;

        public AuthService(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        public bool AreValidUserCredentials(string username, string password)
        {
            return _encryptionService.ValidatePassword(username, password);
        }
    }
}