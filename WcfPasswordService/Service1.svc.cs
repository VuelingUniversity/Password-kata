using Newtonsoft.Json;
using PasswordKata.Core.services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfPasswordService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private IValidationService _validationService;

        public Service1(IValidationService validationService)
        {
            _validationService = validationService;
        }

        public bool AreValidUserCredentials(UserCredentials request)
        {
            return _validationService.AreValidCredentials(request.UserName, request.Password);
        }

        public void SendResetEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}