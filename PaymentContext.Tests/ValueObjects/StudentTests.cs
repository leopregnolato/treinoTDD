using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entitities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("João", "Silva");
            _document = new Document("31573303062", EDocumentType.cpf);
            _email = new Email("joao@mail.com");
            _address = new Address("Rua 1", "1234" , "Bairro", "Cidade", "Estado", "País", "123123888");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
           
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PaypalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "João", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsFalse(_student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsFalse(_student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PaypalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "João", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);         

            Assert.IsTrue(_student.IsValid);
        }




        //[TestMethod]
        //public void AdicionarAssinatura() //nesse medtodo vamos criar situações que falham para refatorarmos o Domínio, de modo a
        //"obrigar" o sistema a passar pelos métodos desejados.
        //{
            /* var subscription = new Subscription(null);
            var student = new Student("João", "Silva", "12345678912", "joao@mail.com");
            student.AddSubscription(subscription); */ //como a lista esta definida como IReadyOnlyCollecion
                    //chamar o método AddSubscription() torna-se obrigatório pq Add() não funciona mais                 
            
       // }
    }
}