﻿using Autofac;
using Autofac.Integration.Wcf;
using Password.Core.Services;
using Password.Infra;
using Password.ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace PasswordWCF
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AuthService>()
                   .As<IAuthService>();
            builder.RegisterType<EncryptionService>()
                .As<IEncryptionService>();
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>();
            builder.RegisterType<EmailService>()
                .As<IEmailService>();
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