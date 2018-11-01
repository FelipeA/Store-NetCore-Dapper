using System;
using FluentValidator;
using Store.Domain.StoreContext.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable
        , ICommandHandler<CreateCustomerCommand>
        , ICommandHandler<AddAddressCommand>
    {

        

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF já existe na base

            // Verificar se o E-mail já existe na base

            // Criar VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email =  new Email(command.Email);

            // Instanciar Entidade (Cliente)
            var customer = new Customer(name, document, email, command.Phone);

            // Validar Entidade e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            // Persistir a Entidade (Cliente)

            // Enviar E-mail de boas vindas

            // Retornar resultado para a tela
            return new CreateCustomerCommandResult(Guid.NewGuid(), customer.ToString(), customer.Email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }

}