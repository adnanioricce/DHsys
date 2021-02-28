using Application.Services.Payments;
using Core.Entities.Payments;
using Core.Interfaces.Payments;
using Moq;
using Xunit;
using Tests.Lib;
using Tests.Lib.Data;
using Core.Entities.User;
using System.Threading.Tasks;
using System.Linq;

namespace Services.Tests.Payments
{
    public class InHandsPaymentServiceTests
    {        
        [Fact(DisplayName = "When Issue a payment, and is processed successfully, should store payment")]
        public async Task TestName()
        {
            //Given
            var customer = new Customer{
                Id = 1
            };
            var fakeProcessor = CustomMockFactory.BuildMock<IPaymentProcessor>(mock => 
                mock.Setup(m => m.ProcessAsync(It.IsAny<PaymentRequest>()))
                    .ReturnsAsync(PaymentResult.Paid(1.0m))
            );
            var fakeRepository = new FakeRepository<Payment>();
            var inHandsService = new InHandsPaymentService(fakeProcessor,fakeRepository);
            var paymentMethod = new InHands(false,inHandsService);
            var payment = Payment.Create(paymentMethod,customer,1.0m);
            //When
            var result = await inHandsService.IssuePaymentAsync(payment);
            //Then
            var savedPayment = fakeRepository.Query().Where(p => p == payment).FirstOrDefault();
            Assert.Equal(payment.Status,savedPayment.Status);
            Assert.Equal(payment.Value,savedPayment.Value);
            Assert.Equal(payment.CreatedAt,savedPayment.CreatedAt);
            
        }
    }
}