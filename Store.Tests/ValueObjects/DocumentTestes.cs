using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    [TestCategory("ValueObjects")]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;

        public DocumentTests()
        {
            invalidDocument = new Document("12345678910");
            validDocument = new Document("29450389004");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            //Assert.Fail();
            Assert.AreEqual(false, invalidDocument.Valid);

        }

        [TestMethod]
        public void ShouldNotReturnNotificationWhenDocumentIsNotValid()
        {
            //Assert.Fail();
            Assert.AreEqual(true, validDocument.Valid);
        }
    }
}
