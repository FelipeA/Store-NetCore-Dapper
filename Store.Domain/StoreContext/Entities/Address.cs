
using FluentValidator;
using Store.Domain.StoreContext.Enums;

namespace Store.Domain.StoreContext.Entities
{
    public class Address : Notifiable{

        public Address(string street, string number, string complement, string district, string city, string state, string country, string zipCode, EAddressType type)
        {
            this.Street = street;
            this.Number = number;
            this.Complement = complement;
            this.District = district;
            this.City = city;
            this.State = State;
            this.Country = country;
            this.ZipCode = zipCode;
            this.Type = type;
        }

        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Type { get; set; }

         public override string ToString(){
             return $"{Street}, { Number} - {City}/{State}";
         }
    }
}