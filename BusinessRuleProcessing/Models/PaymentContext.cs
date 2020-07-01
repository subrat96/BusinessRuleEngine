using System;
using System.Collections.Generic;

namespace BusinessRuleProcessing.Models
{
    public class PaymentContext
    {
        /// <summary>
        /// List to keep track of action performed during payment processing
        /// </summary>
        private readonly List<String> _actionsPerformed = new List<string>();

        /// <summary>
        /// Payment Details
        /// </summary>
        public Payment Payment { get; set; }

        /// <summary>
        /// Add action perfomed to the list
        /// </summary>
        /// <param name="actionPerformed"></param>
        public void AddActionPerformed(string actionPerformed)
        {
            _actionsPerformed.Add(actionPerformed);
        }

        /// <summary>
        /// This method returs list of action performed
        /// </summary>
        /// <returns></returns>
        public List<string> GetActionPerformed()
        {
            return this._actionsPerformed;
        }
    }
}
