using BusinessRuleProcessing.Models;
using BusinessRuleProcessing.Rules;
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

            List<IRule> rules = new List<IRule>
            {
                new PhysicalProductRule(),
                new BookOrderRule(),
                new NewMembershipRule(),
                new UpgradeMembershipRule(),
                new NewOrUpgradeMembershipRule(),
                new PhysicalProductOrBookRule()
            };

            foreach(var rule in rules)
            {
                if(rule.ShouldProcess(paymentContext))
                {
                    rule.Process(paymentContext);
                }
            }

            return paymentContext.GetActionPerformed();
        }
    }
}
