using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Security;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
    public bool AreValidUserCredential(User user)
    {
        var user1 = new User();
        if (user.UserName == user1.UserName && user.Password == user1.Password)
        {
            /* uso 
            var hash = SecurityPassword.Hash(user.Password);
            // Verify
            var result = SecurityPassword.Verify(user.Password, hash);*/

            return true;
        }
        else
        {
            return false;
        }
    }

 
}
