using NUnit.Framework;
using PasswordKata.Core.Services;
using System.IO;

namespace PasswordKata.Infra.Tests
{
    public class UserRepositoryTests
    {
        private IUserRepository _userRepository;
        private string _path;

        [SetUp]
        public void Setup()
        {
            _path = @"C:\Users\gteam\source\repos\Etapa2\Password-kata\PasswordKata.WCFService\PasswordKata.Infra.Tests\Files\StaticUserList.json";
            _userRepository = new UserRepository(_path);
        }

        [Test]
        public void When_User_And_Password_Is_Correct_Returns_True()
        {
            Assert.IsTrue(_userRepository.CheckUser("nacho", "03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4"));
        }

        [Test]
        public void When_User_Or_Password_Is_Not_Correct_Returns_False()
        {
            Assert.IsFalse(_userRepository.CheckUser("nacho", "wrongPass"));
        }

        [Test]
        public void When_User_Is_Unique_AddUser_Returns_True()
        {
            string copyPath = @"C:\Users\gteam\source\repos\Etapa2\Password-kata\PasswordKata.WCFService\PasswordKata.Infra.Tests\Files\CopyFiles\StaticUserList.json";
            try
            {
                File.Copy(_path, copyPath);
                Assert.IsTrue(_userRepository.AddUser("userTest", "encryptedPass"));
                Assert.IsTrue(_userRepository.CheckUser("userTest", "encryptedPass"));
            }
            finally
            {
                File.Delete(_path);
                File.Copy(copyPath, _path);
                File.Delete(copyPath);
            }
            Assert.IsFalse(_userRepository.CheckUser("userTest", "encryptedPass"));
        }

        [Test]
        public void When_User_AlreadyExists_Returns_False()
        {
            Assert.IsFalse(_userRepository.AddUser("nacho", "encryptedPass"));
            Assert.IsFalse(_userRepository.CheckUser("nacho", "encryptedPass"));
        }

        [Test]
        public void When_User_Is_Null_Or_Empty_Check_Returns_False()
        {
            Assert.IsFalse(_userRepository.CheckUser("", "encryptedPass"));
        }

        [Test]
        public void When_Password_Is_Null_Or_Empty_Check_Returns_False()
        {
            Assert.IsFalse(_userRepository.CheckUser("username", null));
        }

        [Test]
        public void When_User_Or_Password_Is_Null_Or_Empty_Add_Returns_False()
        {
            Assert.IsFalse(_userRepository.AddUser("username", null));
        }
    }
}