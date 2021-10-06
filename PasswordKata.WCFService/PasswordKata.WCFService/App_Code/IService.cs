using PasswordKata.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

[ServiceContract]
public interface IService
{
    [OperationContract]
    bool AreValidUserCredentials(User user);

    [OperationContract]
    void SendResetEmail(string email);
}