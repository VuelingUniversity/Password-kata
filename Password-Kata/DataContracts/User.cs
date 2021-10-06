using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Password_Kata.DataContracts
{
    [DataContract]
    public class User
    {
		[DataMember(IsRequired = true)]
		public string UserName { get; set; }

		[DataMember(IsRequired = true)]
		public string Password { get; set; }
	}
}