using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PasswordKata.ServiceWCF.Models
{
    [DataContract]
    public class User
    {
        [DataMember(IsRequired = true, Order = 0)]
        public string Username { get; set; }

        [DataMember(IsRequired = true, Order = 1)]
        public string Password { get; set; }
    }
}