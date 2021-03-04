using System.Threading.Tasks;
using Application.Services.Payments;
using Core.Entities.Payments;
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
            var neededValue = 12.99m;
            var receivedValue = neededValue;
            var payment = Payment.Create(method,customer,receivedValue,neededValue);
            var inhandsProcessor = new InHandsProcessor();
            //When
            var result = await inhandsProcessor.ProcessAsync(new PaymentRequest(payment));
            //Then
            Assert.Equal(PaymentStatus.Paid,result.PaymentStatus);
        }
    }
}