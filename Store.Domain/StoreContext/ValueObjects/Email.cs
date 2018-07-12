using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            this.Address = address;

            AddNotifications(
                new ValidationContract()
                    .Requires()
                    .IsEmail(Address, "E-Mail", "E-mail inválido")
            );
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}