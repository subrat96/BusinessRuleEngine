using BusinessRuleProcessing.Constants;
using BusinessRuleProcessing.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleProcessing.Rules
{
    public class BookOrderRule : IRule
    {
        public void Process(PaymentContext paymentContext)
        {
            paymentContext.AddActionPerformed(PaymentProcessingMessages.DuplicatePackingSlipGeneratedForRoyalityDept);
        }

        public bool ShouldProcess(PaymentContext paymentContext)
        {
            return paymentContext.Payment.ProductType == ProductType.Book;
        }
    }
}
