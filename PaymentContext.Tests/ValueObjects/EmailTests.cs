using PaymentContext.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentContext.Domain.ValueObjects;
using System.Net;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("teste@hotmail.com")]
        [DataRow("teste@dotnet.com.br")]
        [DataRow("testes@balta.com")]
        public void ShouldReturnSuccessWhenEmailIsValid(string address)
        {
            var email = new Email(address);
            Assert.IsTrue(email.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("teste_hotmail")]
        [DataRow("testes@btacom")]
        [DataRow("testesemnada")]
        public void ShouldReturnErrorWhenEmailIsInvalid(string address)
        {
            var email = new Email(address);
            Assert.IsFalse(email.IsValid);
        }
    }
}
