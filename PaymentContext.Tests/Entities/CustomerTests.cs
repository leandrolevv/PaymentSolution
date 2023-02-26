using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void ShouldReturnSuccessWhenIncrementTimeSubscription()
        {
            var subscription = new Subscription();
            var customer = new Customer(new Name("Leandro"), new Document("01234567890", EDocumentType.CPF), new Email("teste@hotmail.com"), new Address("Rua Gabriel Cubel", "000", "Bandeirantes", "Campo Grande", "MS", "79006-520", "Brasil"));
            customer.AddSubscription(subscription);

            var subscription2 = new Subscription();
            customer.AddSubscription(subscription2);
            
            Assert.AreEqual(DateTime.Now.AddMonths(12).Date, customer.Subscriptions.Max(x => x.ExpireDate).Date);
        }
    }
}

