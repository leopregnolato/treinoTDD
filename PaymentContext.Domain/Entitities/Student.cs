using System;
using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entitities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }   //private em set é boa prática, para que não seja setado 
                                                        // de fora da classe após um objeto ser instanciado        
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
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