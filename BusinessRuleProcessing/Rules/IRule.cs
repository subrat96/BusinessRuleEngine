using BusinessRuleProcessing.Models;

namespace BusinessRuleProcessing.Rules
{
    public interface IRule
    {
        /// <summary>
        /// This method returs true if paymentcontext is satisfied for the rule
        /// </summary>
        /// <param name="paymentContext"></param>
        /// <returns></returns>
        bool ShouldProcess(PaymentContext paymentContext);

        /// <summary>
        /// This method takes action defined by the rule
        /// </summary>
        /// <param name="paymentContext"></param>
        void Process(PaymentContext paymentContext);
    }
}
