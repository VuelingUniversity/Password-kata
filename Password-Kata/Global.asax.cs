using Autofac;
using Autofac.Integration.Wcf;
using Password_Kata_Core.Services;
using Password_Kata_Infra;
using Password_Kata_ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Password_Kata
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Service1>()
                   .As<IService1>();
            builder.RegisterType<EncryptService>()
                .As<IEncryptService>();
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>();
            builder.RegisterType<ValidatePasswordService>()
                .As<IValidatePasswordService>();
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