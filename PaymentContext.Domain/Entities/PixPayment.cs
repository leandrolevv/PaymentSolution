using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class PixPayment : Payment
    {
        public string CopyPasteCode { get; private set; }

        public PixPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string document, string payer, string address, string copyPasteCode) : base(paidDate, expireDate, total, totalPaid, document, payer, address)
        {
            CopyPasteCode = copyPasteCode;
        }
    }
}
