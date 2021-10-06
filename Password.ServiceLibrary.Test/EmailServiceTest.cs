using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Password.Core.Models;
using Password.Core.Services;
using System;

namespace Password.ServiceLibrary.Test
{
    [TestClass]
    public class EmailServiceTest
    {
        private Mock<IUserRepository> _userRepository;
        private Mock<IEmailSender> _emailSender;

        [TestInitialize]
        public void TestInitialize()
        {
            _userRepository = new Mock<IUserRepository>();
            _emailSender = new Mock<IEmailSender>();
        }

        [TestMethod]
        public void When_Email_Exist_SendResetEmail_Send_Email()
        {
            // Arrange
            _userRepository.Setup(repository => repository.IsEmailValid("juan@gmail.com")).Returns(true);
            var sut = new EmailService(_userRepository.Object, _emailSender.Object);
            // Act
            sut.SendResetEmail("juan@gmail.com");
            // Assert
            _emailSender.Verify(sender => sender.SendResetEmail("juan@gmail.com", It.IsAny<string>()));
        }

        [TestMethod]
        public void When_Email_Does_Not_Exist_SendResetEmail_Does_Not_Send_Email()
        {
            // Arrange
            var sut = new EmailService(_userRepository.Object, _emailSender.Object);
            // Act
            sut.SendResetEmail("hola@gmail.com");
            // Assert
            _emailSender.Verify(sender => sender.SendResetEmail("hola@gmail.com", It.IsAny<string>()), Times.Never);
        }
    }
}