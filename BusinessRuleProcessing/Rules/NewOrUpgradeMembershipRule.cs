using BusinessRuleProcessing.Constants;
using BusinessRuleProcessing.Models;

namespace BusinessRuleProcessing.Rules
{
    public class NewOrUpgradeMembershipRule : IRule
    {
        public void Process(PaymentContext paymentContext)
        {
            paymentContext.AddActionPerformed(string.Format(PaymentProcessingMessages.MembershipEmailSend, paymentContext.Payment.UserEmail));
        }

        public bool ShouldProcess(PaymentContext paymentContext)
        {
            return paymentContext.Payment.ProductType == ProductType.NewMembership ||  paymentContext.Payment.ProductType == ProductType.UpgradeMembership;
        }
    }
}
