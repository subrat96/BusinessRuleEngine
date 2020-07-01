using BusinessRuleProcessing.Constants;
using BusinessRuleProcessing.Models;


namespace BusinessRuleProcessing.Rules
{
    public class PhysicalProductOrBookRule : IRule
    {
        public void Process(PaymentContext paymentContext)
        {
            paymentContext.AddActionPerformed(PaymentProcessingMessages.AgentCommisionPaymentGenerated);
        }

        public bool ShouldProcess(PaymentContext paymentContext)
        {
            return paymentContext.Payment.ProductType == ProductType.PhysicalProduct || paymentContext.Payment.ProductType == ProductType.Book;
        }
    }
}
