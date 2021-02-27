using System;
using System.Threading.Tasks;
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
        private IRepository<Customer> GetMockCustomerRepository()
        {
            var mockCustomerRepo = new Mock<IRepository<Customer>>();
            mockCustomerRepo.Setup(mock => mock.GetBy(It.IsAny<int>()))
                            .Returns(new Customer{
                                Id = 1
                            });
            return mockCustomerRepo.Object;
        }
        
        private IRepository<Payment> GetMockPaymentRepository(Action<Mock<IRepository<Payment>>> action)
        {
            return new FakeRepository<Payment>();
        }
        private IPaymentProcessor GetMockPaymentProcessor(){
            var mockPaymentProcessor = new Mock<IPaymentProcessor>();
            // mockPaymentProcessor.Setup(m => )
            return mockPaymentProcessor.Object;
        }
        private IPaymentMethodService GetMockPaymentService(Action<Mock<IPaymentMethodService>> paymentMethodTransform = null){
            var mockPaymentMethodService = new Mock<IPaymentMethodService>();
            if(!(paymentMethodTransform is null)){ 
                paymentMethodTransform(mockPaymentMethodService);
            }
            return mockPaymentMethodService.Object;
        }
        [Fact(DisplayName = "if payment pass for all the proccessing, should return if was successful or not")]
        public async Task When_process_payment_after_validation_should_return_processing_result()
        {
            //Given
            var customer = new Customer{
                Id = 1
            };
            
            var priceToCharge = 12.00m;
            var expectedPayment = new Payment(priceToCharge,PaymentStatus.Paid,new InHands(null),customer);
            var mockPaymentService = GetMockPaymentService(mock => {
                mock.Setup(m => m.IssuePaymentAsync(It.IsAny<Payment>()))
                    .ReturnsAsync(BaseResult<Payment>.CreateSuccessResult("message",expectedPayment));
            });
            var paymentMethod = new InHands(mockPaymentService);            
            var payment = Payment.Create(paymentMethod,customer,priceToCharge);
            // When 
            await payment.IssueAsync();
            //Then
            Assert.Equal(PaymentStatus.Paid,payment.Status);
            
        }

        
    }   
}