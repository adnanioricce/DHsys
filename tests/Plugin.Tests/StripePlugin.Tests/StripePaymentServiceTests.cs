using Core.Entities.Payments;
using StripePlugin.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StripePlugin.Tests
{    
    public class StripePaymentServiceTests
    {
        [Fact]
        public void Given_a_payment_object_from_domain_When_stripe_service_receives_it_Then_object_should_be_sended_to_gateway()
        {
            // Given
            Guid orderId = Guid.NewGuid();
            var paymentMethod = new StripeCreditCard();            
            var service = new StripePaymentService();            
            // When
            var chargeResult = Task.Run(async () => await service.ChargeOrderAsync(orderId));
            // Then
            var resultObject = chargeResult.Value;
            Assert.True(PaymentStatus.Paid,chargeResult.PaymentStatus);
            Assert.Equal(orderId,resultObject.DomainId);
        }
    }
}
