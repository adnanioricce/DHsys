using System.Threading.Tasks;
using Application.Services.Payments;
using Core.Entities.Payments;
using Core.Entities.Payments.Methods.InHands;
using Core.Entities.User;
using Tests.Lib.Data;
using Xunit;

namespace Services.Tests.Payments
{
    public class InHandsProcessorTests
    {
        [Fact(DisplayName = "Should try to process payment with given payment method")]
        public async Task Given_payment_When_try_to_process_it_with_specific_payment_method_Then_expect_payment_object_status_to_change()
        {
            //Given
            var method = new InHands(false,null);
            var customer = new Core.Entities.User.Customer {
                Id = 1
            };
            var payment = Payment.Create(method,customer,12.99m,12.99m);            
            var inhandsProcessor = new InHandsProcessor();
            //When
            var result = await inhandsProcessor.ProcessAsync(new InHandsChargeRequest(payment));
            //Then
            Assert.Equal(PaymentStatus.Paid,result.PaymentStatus);
        }
        [Fact(DisplayName = "Given payments with less received value than needed should return a Partially paid status")]
        public async Task If_given_payment_has_less_received_value_than_needed_Then_it_should_return_zero_payment_result()
        {
            //Given
            var method = new InHands(false,null);
            var customer = new Core.Entities.User.Customer {
                Id = 1
            };
            var payment = Payment.Create(method,customer,9.99m ,12.99m);
            var inhandsProcessor = new InHandsProcessor();
            //When
            var result = await inhandsProcessor.ProcessAsync(new InHandsChargeRequest(payment));
            //Then
            Assert.Equal(PaymentStatus.PartiallyPaid,result.PaymentStatus);
        }
    }
}