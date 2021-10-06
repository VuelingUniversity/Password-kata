using PasswordKata.Core.Services;
using PasswordKata.ServiceWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PasswordKata.ServiceWCF.Models;

namespace PasswordKata.ServiceWCF
{
    public class AuthService : IAuthService
    {
        private IUserService _userService;

        public AuthService(IUserService userService)
        {
            _userService = userService;
        }

        public bool AddUser(User user)
        {
            return _userService.AddUser(user.Username, user.Password);
        }

        public bool AreValidUserCredentials(User user)
        {
            return _userService.CheckUser(user.Username, user.Password);
        }

        public void SendResetEmail(string email)
        {
            Console.WriteLine("bla");
        }
    }
}