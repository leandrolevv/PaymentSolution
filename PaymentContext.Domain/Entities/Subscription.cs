using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private IList<Payment> _payments = new List<Payment>();
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime ExpireDate { get; private set; }

        public IReadOnlyCollection<Payment> Payments
        {
            get { return _payments.ToArray(); }
        }

        public Subscription()
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
        }

        public void AddPayment(Payment payment)
        {
            _payments.Add(payment);
            LastUpdateDate = DateTime.Now;
        }

        public bool IsActive()
        {
            return ExpireDate.CompareTo(DateTime.Now) < 0;
        }

        public void AddExpireDate(DateTime expireDate)
        {
            ExpireDate = expireDate;
        }
    }
}
