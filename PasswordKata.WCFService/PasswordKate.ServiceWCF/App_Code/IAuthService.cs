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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        bool AreValidUserCredentials(User user);

        [OperationContract]
        bool AddUser(User user);

        [OperationContract]
        void SendResetEmail(string email);
    }
}