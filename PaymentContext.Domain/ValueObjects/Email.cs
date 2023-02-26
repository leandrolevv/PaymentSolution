using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            this.address = address;
            AddNotifications(new Contract<Notification>().Requires().IsEmail(address,"Email.Address", "Email inválido"));
        }

        public string address { get; set; }
    }
}
