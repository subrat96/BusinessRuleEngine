using BusinessRuleProcessing.Constants;
using BusinessRuleProcessing.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleProcessing.Rules
{
    public class UpgradeMembershipRule : IRule
    {
        public void Process(PaymentContext paymentContext)
        {
            paymentContext.AddActionPerformed(PaymentProcessingMessages.MembershipUpgraded);
        }

        public bool ShouldProcess(PaymentContext paymentContext)
        {
            return paymentContext.Payment.ProductType == ProductType.UpgradeMembership;
        }
    }
}
