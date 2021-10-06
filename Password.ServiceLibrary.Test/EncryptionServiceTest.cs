using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Password.Core.Models;
using Password.Core.Services;
using System;

namespace Password.ServiceLibrary.Test
{
    [TestClass]
    public class EncryptionServiceTest
    {
        private IEncryptionService _encryptionService;

        [TestInitialize]
        public void GetSUT()
        {
            _encryptionService = new EncryptionService();
        }

        [TestMethod]
        public void When_Password_Is_Correct_CheckPassword_Returns_True()
        {
            // Act
            var result = _encryptionService.CheckPassword("0xLJsHVXYsvekpbr", "juan1234", "FB6979BB477A1805F4DC1BDDB3D0B6ED78ED930C");
            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void When_Salt_Is_Wrong_CheckPassword_Returns_False_()
        {
            // Act
            var result = _encryptionService.CheckPassword("hdfshf12", "juan1234", "FB6979BB477A1805F4DC1BDDB3D0B6ED78ED930C");
            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void When_Password_Is_Wrong_CheckPassword_Returns_False_()
        {
            // Act
            var result = _encryptionService.CheckPassword("0xLJsHVXYsvekpbr", "contraseña", "FB6979BB477A1805F4DC1BDDB3D0B6ED78ED930C");
            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EncryptPassword_Returns_As_Expected()
        {
            // Act
            var hashPassword = _encryptionService.EncryptPassword("juan1234", "0xLJsHVXYsvekpbr");
            // Assert
            hashPassword.Should().Be("FB6979BB477A1805F4DC1BDDB3D0B6ED78ED930C");
        }

        [TestMethod]
        public void When_Salt_Is_Empty_EncryptPassword_Does_Not_Work_As_Expected()
        {
            // Act
            var hashPassword = _encryptionService.EncryptPassword("juan1234", "");
            // Assert
            hashPassword.Should().NotBe("FB6979BB477A1805F4DC1BDDB3D0B6ED78ED930C");
        }
    }
}