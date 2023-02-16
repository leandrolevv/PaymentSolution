namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string document, string payer, string address) : base(paidDate, expireDate, total, totalPaid, document, payer, address)
        {
            throw new NotImplementedException();
        }
    }
}
