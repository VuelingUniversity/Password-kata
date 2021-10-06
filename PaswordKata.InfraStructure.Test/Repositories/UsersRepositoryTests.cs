using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordKata.InfraStructure.Repositories;
using System;

namespace PaswordKata.InfraStructure.Test.Repositories
{
    [TestClass]
    public class UsersRepositoryTests
    {
        [TestMethod]
        public void GetUserByUsername_Check_Correct_Name()
        {
            var usersRepository = new UsersRepository();
            string username = "Hernan";
            var result = usersRepository.GetUserByUsername(username);
            Assert.AreEqual(usersRepository._users[0], result);
        }
        [TestMethod]
        public void CheckEmailValid_Check_Correct()
        {
            var usersRepository = new UsersRepository();
            string email = "hernan@example.com";
            var result = usersRepository.CheckEmailValid(email);
            Assert.IsTrue(result);
        }
    }
}
