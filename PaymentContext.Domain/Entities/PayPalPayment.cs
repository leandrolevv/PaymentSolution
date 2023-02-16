
namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public string TransactionCode { private get; set; }
        public PayPalPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string document, string payer, string address, string transactionCode) : base(paidDate, expireDate, total, totalPaid, document, payer, address)
        {
            TransactionCode = transactionCode;
        }
    }
}
