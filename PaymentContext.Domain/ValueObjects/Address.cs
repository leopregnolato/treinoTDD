using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string steet, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Steet = steet;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        public string Steet { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }        
    }
}