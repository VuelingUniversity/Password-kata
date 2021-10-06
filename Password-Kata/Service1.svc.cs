﻿using Password_Kata.DataContracts;
using Password_Kata_Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Password_Kata
{
    public class Service1 : IService1
    {
        IValidatePasswordService _validatePasswordService;
        public Service1(IValidatePasswordService validatePasswordService)
        {
            _validatePasswordService = validatePasswordService;
        }

        public bool AreValidUserCredentials(User user)
        {
            return _validatePasswordService.ValidateUser(user.UserName, user.Password);
        }
    }
}
