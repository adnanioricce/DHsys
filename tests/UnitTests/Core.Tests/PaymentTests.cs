using System;
using System.Threading.Tasks;
using Core.Entities.Payments.Methods.InHands;
using Core.Entities.User;
using Core.Interfaces;
using Core.Interfaces.Payments;
using Core.Models;
using DAL.Seed;
using Moq;
using Tests.Lib.Data;
using Xunit;
namespace Core.Entities.Payments.Tests
{
    public class PaymentTests
    {
        private static IPaymentProcessor GetMockPaymentProcessor(){
            var mockPaymentProcessor = new Mock<IPaymentProcessor>();
            // mockPaymentProcessor.Setup(m => )
            return mockPaymentProcessor.Object;
        }

        [Fact(DisplayName = "if payment pass for all the proccessing, should return if was successful or not")]
        public async Task When_process_payment_after_validation_should_return_processing_result()
        {
            //Given
            var customer = new Customer{
                Id = 1
            };
            
            var priceToCharge = 12.00m;
            var expectedPayment = Payment.Create(new InHands(acceptsPartialPayment:false,null),customer,priceToCharge,priceToCharge);
            var mockPaymentProcessor = GetMockPaymentProcessor();
            var paymentMethod = new InHands(acceptsPartialPayment:false,mockPaymentProcessor);            
            var payment = Payment.Create(paymentMethod,customer,priceToCharge,priceToCharge);
            // When 
            await payment.IssueAsync();
            //Then
            Assert.Equal(PaymentStatus.Paid,payment.Status);
            
        }
        [Fact(DisplayName = "Throw exception if given payment is less than or equal to zero")]
        public void If_given_payment_value_is_less_than_or_equal_to_zero_should_throw_exception()
        {
            //Given
            var customer = new Customer{
                Id = 1
            };
            var priceToCharge = 0.0m;
            var paymentMethod = new InHands(false, GetMockPaymentProcessor());
            //When... Then
            Assert.Throws<DomainException>(() => Payment.Create(paymentMethod,customer,priceToCharge,priceToCharge));
        }

    }   
}