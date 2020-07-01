using BusinessRuleProcessing.Models;
using BusinessRuleProcessing.Rules;

using System;
using System.Collections.Generic;

namespace BusinessRuleProcessing
{
    public class PaymentProcessingEngine
    {
        public List<string> ProcessPayment(Payment payment)
        {
            PaymentContext paymentContext = new PaymentContext
            {
                Payment = payment
            };

            

            return paymentContext.GetActionPerformed();
        }
    }
}
