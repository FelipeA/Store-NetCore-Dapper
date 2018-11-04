using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    [TestCategory("ValueObjects")]
    public class NameTests
    {
        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            var name = new Name("", "Augusto");

            //Assert.Fail();
            Assert.AreEqual(false, name.Valid);
        }
    }
}
