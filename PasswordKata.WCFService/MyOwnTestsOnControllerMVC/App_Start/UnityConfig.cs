using PasswordKata.Core.Services;
using PasswordKata.Infra;
using PasswordKata.ServiceLibrary.Services;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace MyOwnTestsOnControllerMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            string path = @"C:\Users\gteam\source\repos\Etapa2\Password-kata\PasswordKata.WCFService\PasswordKata.Infra\File\UserList.json";              
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(path));
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IEncryptService, EncryptService>();
        }
    }
}