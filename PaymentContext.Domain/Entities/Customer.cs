namespace PaymentContext.Domain.Entities
{
    public class Customer
    {
        private IList<Subscription> _subscriptions;
        public Customer(string name, string document, string email)
        {
            if (name.Length == 0)
            {
                throw new Exception("Nome inválido");
            }

            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Document { get; private set; }
        public string Address { get; private set; }

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
