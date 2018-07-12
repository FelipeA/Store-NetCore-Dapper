using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable{

        public Name(string firstname, string lastName)
        {
            this.FirstName = firstname;
            this.LastName = lastName;
            
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter no mínimo 3 carateres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no mínimo 3 carateres")
                .HasMinLen(LastName, 40, "LastName", "O sobrenome deve conter no mínimo 3 carateres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no mínimo 3 carateres"));
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString(){
            return $"{FirstName} {LastName}";
        }
    }
}