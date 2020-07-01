using BusinessRuleProcessing.Constants;
using BusinessRuleProcessing.Models;

namespace BusinessRuleProcessing.Rules
{
    public class NewMembershipRule : IRule
    {
        public void Process(PaymentContext paymentContext)
        {
            paymentContext.AddActionPerformed(PaymentProcessingMessages.MembershipActivated);
        }

        public bool ShouldProcess(PaymentContext paymentContext)
        {
            return paymentContext.Payment.ProductType == ProductType.NewMembership;
        }
    }
}
