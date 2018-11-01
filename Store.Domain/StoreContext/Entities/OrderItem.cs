using System;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            this.Product = product;
            this.Quantity = quantity;

            this.Price = this.Product.Price;

            if (Product.QuantityOnHand < this.Quantity)
            {
                AddNotification("Quantity", "Produto fora de estoque");
            }

            product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }

    }
}