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
        private IEmailService _emailService;

        public AuthService(IEncryptionService encryptionService, IEmailService emailService)
        {
            _encryptionService = encryptionService;
            _emailService = emailService;
        }

        public bool AreValidUserCredentials(string username, string password)
        {
            return _encryptionService.ValidatePassword(username, password);
        }

        public bool AreValidUserCredentialsRequest(Request request)
        {
            return _encryptionService.ValidatePassword(request.username, request.password);
        }

        public void SendResetEmail(string email)
        {
            _emailService.SendResetEmail(email);
        }
    }
}