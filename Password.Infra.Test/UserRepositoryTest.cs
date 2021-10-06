using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Password.Core.Models;
using Password.Core.Services;
using System;

namespace Password.Infra.Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        private IUserRepository _userRepository;

        [TestInitialize]
        public void GetSUT()
        {
            _userRepository = new UserRepository();
        }

        [TestMethod]
        public void When_Username_Exists_GetUserByUsername_Returns_User()
        {
            // Act
            var user = _userRepository.GetUserByUsername("pepa12");
            // Assert
            user.Should().BeOfType<User>();
            user.Name.Should().Be("pepa12");
        }

        [TestMethod]
        public void When_Username_Does_Not_Exist_GetUserByUsername_Returns_Null()
        {
            // Act
            var user = _userRepository.GetUserByUsername("juanita");
            // Assert
            user.Should().BeNull();
        }

        [TestMethod]
        public void When_Email_Exits_IsEmailValid_Returns_True()
        {
            // Act
            var result = _userRepository.IsEmailValid("pepa@gmail.com");
            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void When_Email_Does_Not_Exit_IsEmailValid_Returns_False()
        {
            // Act
            var result = _userRepository.IsEmailValid("hola@gmail.com");
            // Assert
            result.Should().BeFalse();
        }
    }
}