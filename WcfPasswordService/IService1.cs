using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfPasswordService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool AreValidUserCredentials(UserCredentials request);

        [OperationContract(IsOneWay = true)]
        void SendResetEmail(string email);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class UserCredentials
    {
        private string _userName;
        private string _password;

        [DataMember]
        public string UserName { get => _userName; set => _userName = value; }

        [DataMember]
        public string Password { get => _password; set => _password = value; }
    }
}