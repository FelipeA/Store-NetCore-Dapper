using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enums;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    [TestCategory("Entities")]
    public class OrderTest
    {
        private Order _order;
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;

        public OrderTest()
        {
            var name = new Name("Felipe", "Augusto");
            var document = new Document("29450389004");
            var email = new Email("teste@teste.com");
            var customer = new Customer(name, document, email, "5511999999999");

            _order = new Order(customer);


            _mouse = new Product("Mouse", "Mouse", "Mouse.jpg", 100M, 10);
            _keyboard = new Product("Keyboard", "Keyboard", "Keyboard.jpg", 100M, 10);
            _chair = new Product("Chair", "Chair", "Chair.jpg", 100M, 10);
            _monitor = new Product("Monitor", "Monitor", "Monitor.jpg", 100M, 10);
        }

        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            //Assert.Fail();
            Assert.AreEqual(true, _order.Valid);
        }

        [TestMethod]
        public void StatusShouldBeCreateOrderWhenOrderCreated()
        {
            //Assert.Fail();
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        [TestMethod]
        public void ShouldReturnTwoWhenAddTwoValidItems()
        {
            //Assert.Fail();

            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItems()
        {
            //Assert.Fail();

            _order.AddItem(_mouse, 5);
            Assert.AreEqual(5, _mouse.QuantityOnHand);
        }

        [TestMethod]
        public void ShouldReturnaNumberWhenOrderPlaced()
        {
            //Assert.Fail();

            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        [TestMethod]
        public void StatusShouldReturnPayWhenOrderPaid()
        {
            //Assert.Fail();
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        [TestMethod]
        public void ShouldReturnTwoDeliveriesWhenPurchasedTenProducts()
        {
            //Assert.Fail();
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);

            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        [TestMethod]
        public void StatusShouldReturnCancelWhenOrderCanceled()
        {
            //Assert.Fail();

            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        [TestMethod]
        public void ShouldCancelShippimentWhenOrderCanceled()
        {
            //Assert.Fail();

            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);

            _order.Ship();

            _order.Cancel();

            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }

        }

    }
}
