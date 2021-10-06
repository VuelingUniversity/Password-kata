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
        //public When_UserName_
    }
}




//var mockUser = new User { Name = "prueba", Email = "prueba@mail.com", Password = "RdEJz82Tm4h2MegYGALMwBQ9dPG43gTp", Salt = "x/B7KuXZe46S2gif3s5XCg==" };
//mockUserRepository.Setup(x => x.GetUserByName("prueba")).Returns(mockUser);
//mockEncryptService.Setup(x => x.EncryptPassword("juan123", "x/B7KuXZe46S2gif3s5XCg==")).Returns("encryptedPassword");
//mockValidatePasswordService.Setup(x=>x.ValidateUser("prueba", "juan123")).Returns(true);
