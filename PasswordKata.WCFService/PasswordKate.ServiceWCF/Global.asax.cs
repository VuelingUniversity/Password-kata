using Autofac;
using Autofac.Integration.Wcf;
using PasswordKata.Core.Services;
using PasswordKata.Infra;
using PasswordKata.ServiceLibrary.Services;
using PasswordKata.ServiceWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace PasswordKata.ServiceWCF
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AuthService>()
                   .As<IAuthService>();
            builder.RegisterType<UserService>()
                   .As<IUserService>();
            builder.RegisterType<EncryptService>()
                   .As<IEncryptService>();
            builder.RegisterType<UserRepository>()
                   .As<IUserRepository>()
                   .WithParameter("path", @"C:\Users\gteam\source\repos\Etapa2\Password-kata\PasswordKata.WCFService\PasswordKata.Infra\File\UserList.json");
            AutofacHostFactory.Container = builder.Build();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}