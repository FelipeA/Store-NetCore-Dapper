using System;
using Store.Domain.StoreContext.Enums;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entities
{
    public class Delivery: Entity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            this.EstimatedDeliveryDate = estimatedDeliveryDate;
            this.CreateDate = DateTime.Now;
            this.Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship(){
            this.Status = EDeliveryStatus.Shipped;
        }

        public void Cancel(){
            this.Status = EDeliveryStatus.Canceled;
        }
    }
}