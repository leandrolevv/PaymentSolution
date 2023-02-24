﻿using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string principalName)
        {
            PrincipalName = principalName;
        }

        public string PrincipalName { get; set; }
    }
}
