using BusinessRuleProcessing.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleProcessing
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Payment payment = new Payment
            {
                Amount = 1290,
                DeliveryAddress = "Bellandure,Bangalore,560035",
                ShippingAddress = "Bellandure,Bangalore,560035",
                ProductType = ProductType.PhysicalProduct,
                UserEmail = "user@xyz.com"
            };

            var res = new PaymentProcessingEngine().ProcessPayment(payment);

            foreach (var action in res)
            {
                Console.WriteLine(action);
            }
        }
    }
}
