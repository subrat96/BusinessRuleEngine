
namespace BusinessRuleProcessing.Models
{
    public class Payment
    {
        /// <summary>
        /// Total payable amount
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// type of product for which payment is hettinf processed
        /// </summary>
        public ProductType ProductType { get; set; }
        /// <summary>
        /// Email address of the customer
        /// </summary>
        public string UserEmail { get; set; }
        /// <summary>
        /// Delivery address of the product
        /// </summary>
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// Shipping address of the product
        /// </summary>
        public string ShippingAddress { get; set; }
    }
}
