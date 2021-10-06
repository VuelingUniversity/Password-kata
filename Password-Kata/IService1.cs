using Password_Kata.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Password_Kata
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool AreValidUserCredentials(User user);
        [OperationContract]
        void SendResetEmail(string email);
    }
}
