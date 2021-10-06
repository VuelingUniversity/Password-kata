using Moq;
using NUnit.Framework;
using PasswordKata.ServiceLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordKata.ServiceLibrary.Tests.Tests
{
    internal class EncryptServiceTests
    {
        private Mock<IEncryptService> _encryptService;

        [SetUp]
        public void Inizialize()
        {
            _encryptService = new Mock<IEncryptService>();
        }

        [Test]
        public void When_Empty_Password_Return_Null()
        {
        }
    }
}