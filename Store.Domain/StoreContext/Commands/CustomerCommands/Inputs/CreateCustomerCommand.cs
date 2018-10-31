using FluentValidator;
using FluentValidator.Validation;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter no mínimo 3 carateres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no mínimo 3 carateres")
                .HasMinLen(LastName, 40, "LastName", "O sobrenome deve conter no mínimo 3 carateres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no mínimo 3 carateres")
                .IsEmail(Email, "E-Mail", "E-mail inválido")
                .HasLen(Document, 11, "Document", "CPF inválido")
            );

            return base.Valid;
        }
    }
}