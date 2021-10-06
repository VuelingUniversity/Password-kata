using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordKata.InfraStructure.Repositories;

namespace PaswordKata.Infrastructure.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetUserName_Check_Correct_Name()
        {
            var userRepository = new UsersRepository();
            string name = "Hernan";
            var result = userRepository.GetUserByUsername(name);
            Assert.AreEqual(userRepository._users[0], result);
        }
        [TestMethod]
        public void CheckEmailValid_Check_Correct_Email()
        {
            var userRepository = new UsersRepository();
            string mail = "hernan@example.com";
            var result = userRepository.CheckEmailValid(mail);
            Assert.IsTrue(result);
        }
    }
}
