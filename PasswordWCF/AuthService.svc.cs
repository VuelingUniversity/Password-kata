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
        private IValidationService _validationService;

        public AuthService(IEncryptionService encryptionService, IEmailService emailService)
        {
            _encryptionService = encryptionService;
            _emailService = emailService;
        }

        public bool AreValidUserCredentials(string username, string password)
        {
            return _validationService.ValidateUser(username, password);
        }

        public bool AreValidUserCredentialsRequest(Request request)
        {
            return _validationService.ValidateUser(request.Username, request.Password);
        }

        public void SendResetEmail(string email)
        {
            _emailService.SendResetEmail(email);
        }
    }
}