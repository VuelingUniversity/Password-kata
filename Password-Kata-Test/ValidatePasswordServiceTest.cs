using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Password_Kata_Core.Models;
using Password_Kata_Core.Services;
using Password_Kata_ServiceLibrary;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Password_Kata_Test
{
    [TestClass]
    public class ValidatePasswordServiceTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IEncryptService> _mockEncryptService;
        public ValidatePasswordServiceTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockEncryptService = new Mock<IEncryptService>();
        }
        [TestMethod]
        public void When_UserName_Or_Password_Are_Null_ValidateUser_Returns_False()
        {
            //arrange
            var sut = new ValidatePasswordService(_mockUserRepository.Object, _mockEncryptService.Object);
            //act
            var failName = sut.ValidateUser("", "juan123");
            var failPass = sut.ValidateUser("Juan", "");
            //assert
            _mockUserRepository.Verify(x => x.GetUserByName(""), Times.Never);
            _mockUserRepository.Verify(x => x.GetUserByName("Juan"), Times.Never);
            failName.Should().BeFalse();
            failPass.Should().BeFalse();
        }
        [TestMethod]
        public void When_User_Not_Exist_Validate_Returns_False()
        {
            //arrange
            var sut = new ValidatePasswordService(_mockUserRepository.Object, _mockEncryptService.Object);
            //act
            var result = sut.ValidateUser("joaquin", "joaquin123");
            //assert
            _mockUserRepository.Verify(x => x.GetUserByName("joaquin"));
            _mockEncryptService.Verify(x => x.CheckPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            result.Should().BeFalse();
        }
        [TestMethod]
        public void When_User_Exist_And_Validate_Is_True()
        {
            var mockUser = new User { Name = "prueba", Email = "prueba@mail.com", Password = "RdEJz82Tm4h2MegYGALMwBQ9dPG43gTp", Salt = "x/B7KuXZe46S2gif3s5XCg==" };
            _mockUserRepository.Setup(x => x.GetUserByName("prueba")).Returns(mockUser);
            _mockEncryptService.Setup(x => x.EncryptPassword("juan123", "x/B7KuXZe46S2gif3s5XCg==")).Returns("encryptedPassword");
            var sut = new ValidatePasswordService(_mockUserRepository.Object, _mockEncryptService.Object);

            var result = sut.ValidateUser(mockUser.Name, "juan123");
            result.Should().BeTrue();
            _mockUserRepository.Verify(x => x.GetUserByName("prueba"));
            _mockEncryptService.Verify(x => x.CheckPassword("x/B7KuXZe46S2gif3s5XCg==", "juan123", "RdEJz82Tm4h2MegYGALMwBQ9dPG43gTp"));
        }
    }
}




//var mockUser = new User { Name = "prueba", Email = "prueba@mail.com", Password = "RdEJz82Tm4h2MegYGALMwBQ9dPG43gTp", Salt = "x/B7KuXZe46S2gif3s5XCg==" };
//mockUserRepository.Setup(x => x.GetUserByName("prueba")).Returns(mockUser);
//mockEncryptService.Setup(x => x.EncryptPassword("juan123", "x/B7KuXZe46S2gif3s5XCg==")).Returns("encryptedPassword");
//mockValidatePasswordService.Setup(x=>x.ValidateUser("prueba", "juan123")).Returns(true);
