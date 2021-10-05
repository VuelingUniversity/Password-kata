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
    public class Service1 : IService1
    {
        public bool AreValidUserCredentials(User user)
        {
            return true;
        }
    }
}
