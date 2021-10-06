using NUnit.Framework;
using PasswordKata.Core.Services;

namespace PasswordKata.Infra.Tests
{
    public class UserRepositoryTests
    {
        private IUserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            _userRepository = new UserRepository(@"C:\Users\gteam\source\repos\Etapa2\Password-kata\PasswordKata.WCFService\PasswordKata.Infra.Tests\Files\StaticUserList.json");
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
    }
}