
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public string TransactionCode { private get; set; }
        public PayPalPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Document document, string payer, Address address, string transactionCode) : base(paidDate, expireDate, total, totalPaid, document, payer, address)
        {
            TransactionCode = transactionCode;
        }
    }
}
