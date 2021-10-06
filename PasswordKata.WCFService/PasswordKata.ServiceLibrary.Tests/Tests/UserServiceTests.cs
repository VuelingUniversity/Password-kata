using Moq;
using NUnit.Framework;
using PasswordKata.Core.Services;
using PasswordKata.ServiceLibrary.Services;

namespace PasswordKata.Infra.Tests
{
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepository;
        private Mock<IEncryptService> _encryptService;

        [SetUp]
        public void Inizialize()
        {
            _userRepository = new Mock<IUserRepository>();
            _encryptService = new Mock<IEncryptService>();
        }

        [Test]
        public void When_Correct_Username_And_Pasword_Returns_True()
        {
            _userRepository.Setup(x => x.CheckUser("nacho", "encryptedpass")).Returns(true);
            _encryptService.Setup(x => x.GetHashPassword("plainpass")).Returns("encryptedpass");
            IUserService userService = new UserService(_userRepository.Object, _encryptService.Object);
            Assert.IsTrue(userService.CheckUser("nacho", "plainpass"));
            _userRepository.Verify(t => t.CheckUser("nacho", "encryptedpass"));
            _encryptService.Verify(t => t.GetHashPassword("plainpass"));
        }

        [Test]
        public void When_Empty_Password_Returns_False()
        {
            _userRepository.Setup(x => x.CheckUser("nacho", "encryptedpass")).Returns(true);
            _encryptService.Setup(x => x.GetHashPassword("")).Returns("encryptedpass");
            IUserService userService = new UserService(_userRepository.Object, _encryptService.Object);
            Assert.IsFalse(userService.CheckUser("nacho", ""));
            //Verificar que no ha pasado
            _userRepository.Verify(t => t.CheckUser("nacho", "encryptedpass"), Times.Never);
            _encryptService.Verify(t => t.GetHashPassword(""), Times.Never);
        }

        [Test]
        public void When_Empty_Username_Returns_False()
        {
            _userRepository.Setup(x => x.CheckUser("", "encryptedpass")).Returns(true);
            _encryptService.Setup(x => x.GetHashPassword("plainpass")).Returns("encryptedpass");
            IUserService userService = new UserService(_userRepository.Object, _encryptService.Object);
            Assert.IsFalse(userService.CheckUser("", "plainpass"));
            //Verificar que no ha pasado
            _userRepository.Verify(t => t.CheckUser("nacho", "encryptedpass"), Times.Never);
            _encryptService.Verify(t => t.GetHashPassword(""), Times.Never);
        }

        [Test]
        public void When_Empty_Username_And_Empty_Password_Returns_False()
        {
            _userRepository.Setup(x => x.CheckUser("", "encryptedpass")).Returns(true);
            _encryptService.Setup(x => x.GetHashPassword("")).Returns("encryptedpass");
            IUserService userService = new UserService(_userRepository.Object, _encryptService.Object);
            Assert.IsFalse(userService.CheckUser("", ""));
            //Verificar que no ha pasado
            _userRepository.Verify(t => t.CheckUser("", "encryptedpass"), Times.Never);
            _encryptService.Verify(t => t.GetHashPassword(""), Times.Never);
        }
    }
}