using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Password_Kata_Core.Services;
using Password_Kata_ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Password_Kata_Test
{
    [TestClass]
    public class EmailServiceTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IEmailSenderService> _mockEmailSenderService;
        public EmailServiceTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockEmailSenderService = new Mock<IEmailSenderService>();
        }
        [TestMethod]
        public void When_Email_Exist_Send_Email()
        {
            _mockUserRepository.Setup(x=>x.EmailExistInRepo("paco@gmail.com")).Returns(true);

            var sut = new EmailService(_mockUserRepository.Object, _mockEmailSenderService.Object);

            sut.SendResetEmail("prueba@gmail.com");
            //_mockEmailSenderService.Verify(x => x.SendEmail("prueba@gmail.com", It.IsAny<string>()));
        }
        [TestMethod]
        public void When_Email_Not_Exist_Not_Send_Email()
        {
            var sut = new EmailService(_mockUserRepository.Object, _mockEmailSenderService.Object);
            sut.SendResetEmail("");
            _mockEmailSenderService.Verify(x => x.SendEmail("", It.IsAny<string>()), Times.Never);
        }
    }
}
