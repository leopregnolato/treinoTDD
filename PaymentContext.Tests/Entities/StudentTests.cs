using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entitities;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarAssinatura() //nesse medtodo vamos criar situações que falham para refatorarmos o Domínio, de modo a
        //"obrigar" o sistema a passar pelos métodos desejados.
        {
            /* var subscription = new Subscription(null);
            var student = new Student("João", "Silva", "12345678912", "joao@mail.com");
            student.AddSubscription(subscription); */ //como a lista esta definida como IReadyOnlyCollecion
                    //chamar o método AddSubscription() torna-se obrigatório pq Add() não funciona mais

                    
            
        }
    }
}