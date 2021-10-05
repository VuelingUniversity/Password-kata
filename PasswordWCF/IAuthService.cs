﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PasswordWCF
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        bool AreValidUserCredentials(string username, string password);

        [OperationContract]
        bool AreValidUserCredentialsRequest(Request request);
    }

    [DataContract]
    public class Request
    {
        [DataMember(IsRequired = true)]
        public string username { get; set; }

        [DataMember(IsRequired = true)]
        public string password { get; set; }
    }
}