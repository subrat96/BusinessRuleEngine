using BusinessRuleProcessing.Models;
using BusinessRuleProcessing.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BusinessRuleProcessing
{
    public class PaymentProcessingEngine
    {
        /// <summary>
        /// This method takes paymet as an input, Process the payment and returns list of actions performed during processing of the payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public List<string> ProcessPayment(Payment payment)
        {
            //Create a payment context object
            PaymentContext paymentContext = new PaymentContext
            {
                Payment = payment
            };

            //Create list of IRules instance defined in this assembly
            List<Type> ruleTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterfaces().Contains(typeof(IRule))).ToList();

            //stores object of IRule type
            List<IRule> rules = new List<IRule>();

            foreach(var ruleType in ruleTypes)
            {
                //Create a instance of IRule type defined
                rules.Add((IRule)Activator.CreateInstance(ruleType));
            }

            //For each rule process the payment context if processing precondition satisfied
            foreach(var rule in rules)
            {
                //check if pre condition is satisfied
                if(rule.ShouldProcess(paymentContext))
                {
                    //do processing
                    rule.Process(paymentContext);
                }
            }

            return paymentContext.GetActionPerformed();
        }
    }
}
