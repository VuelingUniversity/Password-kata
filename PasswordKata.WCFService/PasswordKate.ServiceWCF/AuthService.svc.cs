using PasswordKata.Core.Services;
using PasswordKata.ServiceWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService1.Models;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AuthService : IAuthService
    {
        private IUserService _userService;

        public AuthService(IUserService userService)
        {
            _userService = userService;
        }

        public bool AreValidUserCredentials(User user)
        {
            return _userService.CheckUser(user.Username, user.Password);
        }

        public void SendResetEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}