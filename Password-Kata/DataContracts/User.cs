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
		private string _Name;
		private string _Password;
		[DataMember(IsRequired = true)]
		public string UserName
		{
			get { return _Name; }
			set { _Name = value; }
		}
		[DataMember(IsRequired = true)]
		public string Password
		{
			get { return _Password; }
			set { _Password = value; }
		}
	}
}