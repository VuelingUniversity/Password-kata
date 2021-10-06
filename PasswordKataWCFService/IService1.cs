using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PasswordKataWCFService
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        bool AreValidUserCredentials(string name, string password);
        [OperationContract]
        bool AreValidUserCredentialsRequest(Request request);

        [OperationContract]
        void SendResetEmail(string emailaddress);

    }
    public class Request
    {
        [DataMember (IsRequired = true)]
        public string Username { get; set; }
        [DataMember (IsRequired = true)]
        public string PassWord { get; set; }
    }
}
