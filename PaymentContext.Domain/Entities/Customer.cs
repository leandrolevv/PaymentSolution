using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Customer : Entity
    {
        private IList<Subscription> _subscriptions;
        public Customer(Name name, Document document, Email email, Address address)
        {
            if (name.PrincipalName.Length == 0)
            {
                throw new Exception("Nome inválido");
            }

            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscriptions = new List<Subscription>();
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions
        {
            get
            {
                return _subscriptions.ToArray();

            }
        }

        public void AddSubscription(Subscription subscription)
        {
            _subscriptions.Add(subscription);
            
            subscription.AddExpireDate(CalculateExpireDate(6));
        }

        private DateTime CalculateExpireDate(int expireDateInMonths)
        {
            if (_subscriptions.Count == 1)
            {
                return DateTime.Now.AddMonths(expireDateInMonths);
            }
            else
            {
                return _subscriptions.Max(x => x.ExpireDate).AddMonths(expireDateInMonths);
            }
        }
    }
}
