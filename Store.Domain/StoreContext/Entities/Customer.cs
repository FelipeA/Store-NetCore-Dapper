using System;
using System.Collections.Generic;
using System.Linq;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Domain.StoreContext.Entities
{
    public class Customer
    {
        private readonly IList<Address> _addresses;

        public Customer(Name name, Document document, Email email, string phone)
        {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this.Phone = phone;

            _addresses = new List<Address>();
        }
       
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        public void AddAddress(Address address){
            _addresses.Add(address);
        }

        public override string ToString(){
            return Name.ToString();
        }
    }
}