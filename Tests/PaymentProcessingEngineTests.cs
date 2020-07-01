using BusinessRuleProcessing;
using BusinessRuleProcessing.Constants;
using BusinessRuleProcessing.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PaymentProcessingEngineTests
    {
        private PaymentProcessingEngine _paymentProcessing;

        [TestInitialize]
        public void Initialize()
        {
            _paymentProcessing = new PaymentProcessingEngine();
        }


        [TestMethod]
        public void PhysicalProductPaymentProcessTest()
        {
            //Assemble
            Payment payment = new Payment
            {
                Amount = 2000,
                BillingAddress = "Bellandur, Bangalore, 560035",
                ShippingAddress = "Bellandur, Bangalore, 560035",
                ProductType = ProductType.PhysicalProduct,
                UserEmail = "user@test.com"
            };
            //Act
            var result = _paymentProcessing.ProcessPayment(payment);
            //Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(PaymentProcessingMessages.PackingSlipGenerated));
            Assert.IsTrue(result.Contains(PaymentProcessingMessages.AgentCommisionPaymentGenerated));
        }

        [TestMethod]
        public void BookOrderPaymentProcessTest()
        {
            //Assemble
            Payment payment = new Payment
            {
                Amount = 2000,
                BillingAddress = "Bellandur, Bangalore, 560035",
                ShippingAddress = "Bellandur, Bangalore, 560035",
                ProductType = ProductType.Book,
                UserEmail = "user@test.com"
            };
            //Act
            var result = _paymentProcessing.ProcessPayment(payment);
            //Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(PaymentProcessingMessages.DuplicatePackingSlipGeneratedForRoyalityDept));
            Assert.IsTrue(result.Contains(PaymentProcessingMessages.AgentCommisionPaymentGenerated));
        }

        [TestMethod]
        public void NewMembershipPaymentProcessTest()
        {
            //Assemble
            Payment payment = new Payment
            {
                Amount = 2000,
                BillingAddress = "Bellandur, Bangalore, 560035",
                ShippingAddress = "Bellandur, Bangalore, 560035",
                ProductType = ProductType.NewMembership,
                UserEmail = "user@test.com"
            };
            //Act
            var result = _paymentProcessing.ProcessPayment(payment);
            //Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(PaymentProcessingMessages.MembershipActivated));
            Assert.IsTrue(result.Contains(string.Format(PaymentProcessingMessages.MembershipEmailSend, payment.UserEmail)));
        }

        [TestMethod]
        public void UpgradeMembershipPaymentProcessTest()
        {
            //Assemble
            Payment payment = new Payment
            {
                Amount = 2000,
                BillingAddress = "Bellandur, Bangalore, 560035",
                ShippingAddress = "Bellandur, Bangalore, 560035",
                ProductType = ProductType.UpgradeMembership,
                UserEmail = "user@test.com"
            };
            //Act
            var result = _paymentProcessing.ProcessPayment(payment);
            //Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(PaymentProcessingMessages.MembershipUpgraded));
            Assert.IsTrue(result.Contains(string.Format(PaymentProcessingMessages.MembershipEmailSend, payment.UserEmail)));
        }
    }
}
