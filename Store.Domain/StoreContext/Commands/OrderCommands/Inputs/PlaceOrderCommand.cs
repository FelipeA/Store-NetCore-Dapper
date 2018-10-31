using System;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand{
        public Guid Customer { get; set; }
        public List<OrderItemCommand> OrderItems { get; set; }

        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do Cliente inválido")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Não foi encontrado nenhum item no pedido.")
            );

            return base.Valid;
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }        
        public decimal Quantity { get; set; }
    }
}