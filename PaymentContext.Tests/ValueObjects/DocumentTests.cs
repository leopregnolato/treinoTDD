using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        //red, green, refactor
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.cnpj);
            Assert.IsFalse(doc.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("41941490000108", EDocumentType.cnpj);
            Assert.IsTrue(doc.IsValid);
        }

         [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.cpf);
            Assert.IsFalse(doc.IsValid);
        }

        [TestMethod]
        [DataTestMethod] //Aqui serve para testar várias entradas no mesmo método
        [DataRow("31164787080")]
        [DataRow("39615579009")]
        [DataRow("84206212007")]
        [DataRow("31573303062")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.cpf);
            Assert.IsTrue(doc.IsValid);
        }
    }
}