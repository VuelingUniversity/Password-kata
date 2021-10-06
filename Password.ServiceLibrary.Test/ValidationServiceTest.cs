using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Password.Core.Models;
using Password.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password.ServiceLibrary.Test
{
    [TestClass]
    public class ValidationServiceTest
    {
        private Mock<IUserRepository> _userRepository;
        private Mock<IEncryptionService> _encryptionService;

        [TestInitialize]
        public void TestInitialize()
        {
            _userRepository = new Mock<IUserRepository>();
            _encryptionService = new Mock<IEncryptionService>();
        }

        [TestMethod]
        public void When_Username_Or_Password_Are_NullOrEmpty_ValidateUser_Returns_False()
        {
            // Arrange
            var sut = new ValidationService(_userRepository.Object, _encryptionService.Object);
            // Act
            var resultFailUsername = sut.ValidateUser("", "1234");
            var resultFailPassword = sut.ValidateUser("juan23", null);
            // Assert
            _userRepository.Verify(repository => repository.GetUserByUsername(""), Times.Never);
            _userRepository.Verify(repository => repository.GetUserByUsername("juan23"), Times.Never);
            resultFailUsername.Should().BeFalse();
            resultFailPassword.Should().BeFalse();
        }

        [TestMethod]
        public void When_User_Does_Not_Exist_ValidateUser_Returns_False()
        {
            // Arrange
            var sut = new ValidationService(_userRepository.Object, _encryptionService.Object);
            // Act
            var result = sut.ValidateUser("pepe", "1234");
            // Assert
            _userRepository.Verify(repository => repository.GetUserByUsername("pepe"));
            _encryptionService.Verify(service => service.CheckPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            result.Should().BeFalse();
        }

        [TestMethod]
        public void When_Password_Is_Correct_ValidateUser_Returns_True()
        {
            // Arrange
            var fakeUser = new User { Name = "juan23", Email = "juan@gmail.com", Salt = "0xLJsHVXYsvekpbr", Password = "juan1234" /*"FB6979BB477A1805F4DC1BDDB3D0B6ED78ED930C"*/ };
            _userRepository.Setup(repository => repository.GetUserByUsername("juan23")).Returns(fakeUser);
            _encryptionService.Setup(service => service.CheckPassword(fakeUser.Salt, "juan1234", fakeUser.Password)).Returns(true);
            var sut = new ValidationService(_userRepository.Object, _encryptionService.Object);
            // Act
            var result = sut.ValidateUser("juan23", "juan1234");
            // Assert
            _userRepository.Verify(repository => repository.GetUserByUsername(fakeUser.Name));
            _encryptionService.Verify(service => service.CheckPassword(fakeUser.Salt, "juan1234", fakeUser.Password));
            result.Should().BeTrue();
        }

        [TestMethod]
        public void When_Password_Is_Wrong_ValidateUser_Returns_False()
        {
            // Arrange
            var fakeUser = new User { Name = "juan23", Email = "juan@gmail.com", Salt = "0xLJsHVXYsvekpbr", Password = "FB6979BB477A1805F4DC1BDDB3D0B6ED78ED930C" };
            _userRepository.Setup(repository => repository.GetUserByUsername("juan23")).Returns(fakeUser);
            var sut = new ValidationService(_userRepository.Object, _encryptionService.Object);
            // Act
            var result = sut.ValidateUser("juan23", "password");
            // Assert
            _userRepository.Verify(repository => repository.GetUserByUsername("juan23"));
            _encryptionService.Verify(service => service.CheckPassword(fakeUser.Salt, "password", fakeUser.Password));
            result.Should().BeFalse();
        }
    }
}