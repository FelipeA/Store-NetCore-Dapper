using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.CustomerCommands.Inputs;

namespace Store.Tests
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Felipe";
            command.LastName = "Augusto";
            command.Document = "33767140888";
            command.Email = "teste@gmail.com";
            command.Phone = "11999999997";

            Assert.AreEqual(true, command.Valid());
        }
    }
}