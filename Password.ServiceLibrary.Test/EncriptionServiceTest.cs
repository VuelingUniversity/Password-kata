using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Password.Core.Models;
using Password.Core.Services;
using System;

namespace Password.ServiceLibrary.Test
{
    [TestClass]
    public class EncriptionServiceTest
    {
        [TestMethod]
        public void ValidatePassword_Returns_True_When_Password_Is_Correct()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();
            var fakeUser = new User { Name = "juan23", Email = "juan@gmail.com", Salt = "0xLJsHVXYsvekpbr", Password = "FB6979BB477A1805F4DC1BDDB3D0B6ED78ED930C" };
            userRepository.Setup(repository => repository.GetUserByUsername("juan23")).Returns(fakeUser);
            var encryptionService = new EncryptionService(userRepository.Object);
            // Act
            var result = encryptionService.ValidatePassword("juan23", "juan1234");
            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ValidatePassword_Returns_False_When_User_Does_Not_Exist()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();
            var encryptionService = new EncryptionService(userRepository.Object);
            // Act
            var result = encryptionService.ValidatePassword("juan23", "juan1234");
            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void ValidatePassword_Returns_False_When_Password_Is_Wrong()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();
            var fakeUser = new User { Name = "juan23", Email = "juan@gmail.com", Salt = "0xLJsHVXYsvekpbr", Password = "FB6979BB477A1805F4DC1BDDB3D0B6ED78ED930C" };
            userRepository.Setup(repository => repository.GetUserByUsername("juan23")).Returns(fakeUser);
            var encryptionService = new EncryptionService(userRepository.Object);
            // Act
            var result = encryptionService.ValidatePassword("juan23", "password");
            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EncryptPassword_Returns_As_Expected()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();
            var encryptionService = new EncryptionService(userRepository.Object);
            // Act
            var hashPassword = encryptionService.EncryptPassword("juan1234", "0xLJsHVXYsvekpbr");
            // Assert
            hashPassword.Should().Be("FB6979BB477A1805F4DC1BDDB3D0B6ED78ED930C");
        }

        [TestMethod]
        public void EncryptPassword_Does_Not_Work_Without_Salt()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();
            var encryptionService = new EncryptionService(userRepository.Object);
            // Act
            var hashPassword = encryptionService.EncryptPassword("juan1234", "");
            // Assert
            hashPassword.Should().NotBe("FB6979BB477A1805F4DC1BDDB3D0B6ED78ED930C");
        }
    }
}