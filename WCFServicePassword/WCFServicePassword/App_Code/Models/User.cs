using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

[DataContract]
public class User
{
    string userName;
    string password;
	[DataMember(IsRequired =true)]
	public string UserName
	{
		get { return userName; }
		set { userName = value; }
	}
	[DataMember(IsRequired = true)]
	public string Password
	{
		get { return password; }
		set { password = value; }
	}

}