using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entitities
{
    public class Student
    {
        private IList<Subscription> _subscriptions;
        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }

        public string FirstName { get; private set; }   //private em set é boa prática, para que não seja setado 
                                                        // de fora da classe após um objeto ser instanciado
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get {return _subscriptions.ToArray(); } }    // para evitar que use add() para este
                                                                                        //atributo e exista duas incrições ativas ao mesmo tempo

        public void AddSubscription(Subscription subscription)
        {
            // Se já tiver assinatura ativa, cancela
            //Cancela todas as outras assinaturas e coloca esta como principal
            foreach(var sub in Subscriptions)
                sub.Inactivate();
            
            _subscriptions.Add(subscription); //o _subscritpions é para poder utilizar o metodo Add() aqui.
            //note que essa lista é privada, ou seja, o Add() so pode ser chamado aqui

        }
    }
}