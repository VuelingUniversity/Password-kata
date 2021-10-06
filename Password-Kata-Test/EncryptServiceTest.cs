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
        [TestMethod]
        public void CheckPassword_Return_True_When_IsValidated()
        {   
            //Arrange
            var mockUser = new User { Name = "prueba", Email = "prueba@mail.com", Password = "RdEJz82Tm4h2MegYGALMwBQ9dPG43gTp", Salt = "x/B7KuXZe46S2gif3s5XCg==" };
            mockUserRepository.Setup(x => x.GetUserByName("prueba")).Returns(mockUser);
            mockEncryptService.Setup(x=>x.EncryptPassword("juan123", "x/B7KuXZe46S2gif3s5XCg==")).Returns("encryptedPassword");
            var sut = new EncryptService();
            //Act
            var result = sut.CheckPassword(mockUser.Salt, "juan123", mockUser.Password);
            //Assert
            result.Should().BeTrue();
            //mockEncryptService.Verify(x => x.EncryptPassword("juan123", mockUser.Salt)/*, Times.Never*/);
            //mockUserRepository.Verify(x=>x.GetUserByName("prueba")/*, Times.Never*/);
        }        
    }
}
// if(string.IsNullOrEmpty(password)
//  return false;
