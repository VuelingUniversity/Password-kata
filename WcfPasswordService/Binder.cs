using Autofac;
using PasswordKata.Core.services;
using PasswordKata.Infra;
using PasswordKata.ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfPasswordService
{
    public static class Binder
    {
        private static string _dataPath = @"C:\Users\nettrim\source\repos\Password-kata\PasswordKata.Infra\data.json";

        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ValidationRepository>().As<IValidationRepository>().WithParameter("dataPath", _dataPath);
            builder.RegisterType<ValidationService>().As<IValidationService>();
            builder.RegisterType<Service1>().As<IService1>();
            //builder.Register<Service1>(_ => new Service1(_validationService));
            return builder.Build();
        }
    }
}