using BusinessRuleProcessing.Constants;
using BusinessRuleProcessing.Models;

namespace BusinessRuleProcessing.Rules
{
    public class PhysicalProductRule : IRule
    {
        public void Process(PaymentContext paymentContext)
        {
            paymentContext.AddActionPerformed(PaymentProcessingMessages.PackingSlipGenerated);
        }

        public bool ShouldProcess(PaymentContext paymentContext)
        {
            return paymentContext.Payment.ProductType == ProductType.PhysicalProduct;
        }
    }
}
