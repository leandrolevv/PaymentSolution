using System.Text.Json;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("123")]
        [DataRow("12345678912")]
        [DataRow("00000000000")]
        [DataRow("0000000000a")]
        [DataRow("26011410000121")]
        public void ShouldReturnErrorWhenCPFIsInvalid(string cpf)
        {
            var document = new Document(cpf, EDocumentType.CPF);
            Assert.IsFalse(document.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("123")]
        [DataRow("26011410003121")]
        [DataRow("0000000000000")]
        [DataRow("0000000000a00")]
        [DataRow("01234567890")]
        public void ShouldReturnErrorWhenCNPJIsInvali(string cnpj)
        {
            var document = new Document(cnpj, EDocumentType.CNPJ);
            Assert.IsFalse(document.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("01234567890")]
        [DataRow("55373637718")]
        [DataRow("804.119.790-60")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var document = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(document.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("26011410000121")]
        [DataRow("92069005000199")]
        [DataRow("64.404.496/0001-41")]
        public void ShouldReturSuccessWhenCNPJIsValid(string cnpj)
        {
            var document = new Document(cnpj, EDocumentType.CNPJ);
            Assert.IsTrue(document.IsValid);
        }
    }
}
