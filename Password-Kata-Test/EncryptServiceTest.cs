using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Password_Kata_Core.Models;
using Password_Kata_Core.Services;
using Password_Kata_ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Password_Kata_Test
{
    [TestClass]
    public class EncryptServiceTest
    {
        private Mock<IUserRepository> mockUserRepository;
        private Mock<IEncryptService> mockEncryptService;
        public EncryptServiceTest()
        {
            mockUserRepository = new Mock<IUserRepository>();
            mockEncryptService = new Mock<IEncryptService>();
        }
        [TestInitialize]
        //public void GetSUT()
        //{
        //    var sut = new EncryptService();
        //}
        [TestMethod]
        public void When_Is_True_CheckPassword_Return_True()
        {
            //Arrange
            var mockUser = new User { Name = "prueba", Email = "prueba@mail.com", Password = "RdEJz82Tm4h2MegYGALMwBQ9dPG43gTp", Salt = "x/B7KuXZe46S2gif3s5XCg==" };
            mockUserRepository.Setup(x => x.GetUserByName("prueba")).Returns(mockUser);
            mockEncryptService.Setup(x => x.EncryptPassword("juan123", "x/B7KuXZe46S2gif3s5XCg==")).Returns("encryptedPassword");
            var sut = new EncryptService();
            //Act
            var result = sut.CheckPassword(mockUser.Salt, "juan123", mockUser.Password);
            //Assert
            result.Should().BeTrue();
            //mockEncryptService.Verify(x => x.EncryptPassword("juan123", mockUser.Salt)/*, Times.Never*/);
            //mockUserRepository.Verify(x=>x.GetUserByName("prueba")/*, Times.Never*/);
        }
        [TestMethod]
        public void When_Password_Is_Correct_CheckPassword_Return_True()
        {
            var sut = new EncryptService();
            var result = sut.CheckPassword("x/B7KuXZe46S2gif3s5XCg==", "juan123", "RdEJz82Tm4h2MegYGALMwBQ9dPG43gTp");
            result.Should().BeTrue();
        }
        [TestMethod]
        public void When_Password_Is_Not_Right_CheckPassword_Return_False()
        {
            var sut = new EncryptService();
            var result = sut.CheckPassword("x/B7KuXZe46S2gif3s5XCg==", "juan123", "asd");
            result.Should().BeFalse();
        }
        [TestMethod]
        public void When_Password_Is_Null_CheckPassword_Return_False()
        {
            var sut = new EncryptService();
            var result = sut.CheckPassword("x/B7KuXZe46S2gif3s5XCg==", "", "RdEJz82Tm4h2MegYGALMwBQ9dPG43gTp");
            result.Should().BeFalse();
        }
    }
}
// if(string.IsNullOrEmpty(password)
//  return false;
