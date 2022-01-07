using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            
            AddNotifications( new Contract<Name>()
                .Requires()
                .IsLowerThan(FirstName, 3, "Name.FisrtName", "Nome deve conter pelo menos 3 caracteres")
                .IsLowerThan(LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
                .IsGreaterThan(FirstName, 40, "Name.FisrtName", "Nome deve conter até caracteres")
                .IsGreaterThan(LastName, 40, "Name.LastName", "Nome deve conter até caracteres")
            );
        }        
        public string FirstName { get; private set; }  //private em set é boa prática, para que não seja setado 
                                                        // de fora da classe após um objeto ser instanciado
        public string LastName { get; private set; }
    }
        
}