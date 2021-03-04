using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Entities.Payments;
using Core.Entities.Stock;
using Core.Entities.User;
using Core.Interfaces;
using Core.Interfaces.Payments;
using Core.Models;
using DAL.DbContexts;
using DAL.Seed;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Core.Tests
{
    public class POSOrderTests
    {
        
        private IRepository<Product> MockRepository(Action<Mock<IRepository<Product>>> action = null)
        {            
            var product = new Product{
                    Id = 1,                    
                };
            product.UpdatePrice(12.99m,10.0m,DateTimeOffset.UtcNow);
            var mock = new Mock<IRepository<Product>>();
            mock.Setup(m => m.GetBy(It.IsAny<int>()))
                .Returns(product);
            if(action is null){
                return mock.Object;
            }
            action(mock);
            return mock.Object;
        }
        private IPaymentMethodService MockPaymentService(Action<Mock<IPaymentMethodService>> transform){
            var mock = new Mock<IPaymentMethodService>();
            transform(mock);
            return mock.Object;
        }
        private void DefineSuccessfulPayment(decimal valueToPay,Customer customer, Mock<IPaymentMethodService> mockPaymentMethod)
        {            
            mockPaymentMethod.Setup(m => m.IssuePaymentAsync(It.IsAny<Payment>()))
                             .ReturnsAsync(new PaymentResult{
                                    PaymentStatus = PaymentStatus.Paid,
                                    Change = 0.0m,
                                    ValueIssued = valueToPay
                                });
            
        }
        private POSOrder GetBasicPOSOrder(){
            var product = new ProductSeed().GetSeedObject();
            product.Id = 1;
            product.UpdateStock(10,product);
            var repository = MockRepository((mock) => mock.Setup(m => m.GetBy(It.IsAny<int>()))
                                                          .Returns(product));
            var posOrder = new POSOrder();
            posOrder.AddItem(product.Id,1,repository);
            return posOrder;
        }
        [Fact(DisplayName = "When start new pos order it's state should be 'New'")]
        public void When_start_new_pos_order_should_have_new_state()
        {
            //Given...When
            var posOrder = new POSOrder();
            //Then
            Assert.Equal(OrderState.New,posOrder.State);
        }
        [Fact(DisplayName = "When add item of a already present product, should sum the two items")]
        public void When_add_new_item_of_already_present_product_sum_items()
        {
            // Given
            var product = new ProductSeed().GetSeedObject();
            product.Id = 1;
            product.UpdateStock(14,product);
            var posOrder = new POSOrder();
            var repository = MockRepository((mock) => mock.Setup(m => m.GetBy(It.IsAny<int>()))
                                                          .Returns(product));
            posOrder.AddItem(product.Id,2,repository);
            var expectedOrderTotal = product.EndCustomerPrice * 6;
            // When
            posOrder.AddItem(product.Id,4,repository);
            // Then
            Assert.Equal(1,posOrder.Items.Count);
            Assert.Equal(expectedOrderTotal,posOrder.OrderTotal);
        }
        [Fact(DisplayName = "When cancel order state should be equal to 'Cancelled'")]
        public void When_cancel_order_order_should_be_in_cancelled_state(){
            // Given
            var posOrder = new POSOrder();
            //When
            posOrder.Cancel();
            //Then
            Assert.Equal(OrderState.Cancelled,posOrder.State);
            Assert.True(posOrder.HasEnded);
            Assert.False(posOrder.PaidOut);
        }
        [Fact(DisplayName = "if order is cancelled, can't add item")]
        public void When_try_add_item_to_cancelled_item_shouldnt_update_object()
        {
            //Given            
            var product = new ProductSeed().GetSeedObject();
            product.Id = 1;
            product.UpdateStock(3,product);
            
            var posOrder = new POSOrder();
            var repository = MockRepository((mock) => mock.Setup(m => m.GetBy(It.IsAny<int>()))
                                                          .Returns(product));
            var expectedQuantity = 1;
            posOrder.AddItem(product.Id,expectedQuantity,repository);            
            posOrder.Cancel();

            //When
            posOrder.AddItem(product.Id,1,repository);

            //Then
            var item = posOrder.Items.FirstOrDefault();
            Assert.Equal(expectedQuantity,item.Quantity);
        }
        [Fact(DisplayName = "If order was cancelled, pay operations shouldn't be allowed")]
        public async Task When_try_to_pay_order_if_is_cancelled_return_failure(){
            // Given
            var posOrder = GetBasicPOSOrder();
            var customer = new Entities.User.Customer{ Id = 1};
            var valueToPay = 12.00m;
            var paymentMethod = new InHands(acceptsPartialPayment:false,null);            
            //When
            posOrder.Cancel();
            await posOrder.PayAsync(valueToPay,customer);
            //Then            
            Assert.False(posOrder.PaidOut);
            Assert.Equal(valueToPay,posOrder.RemainingValueToPay);
            Assert.Empty(posOrder.Payments);
        }
        [Fact]
        public async Task When_pay_whole_remaining_value_on_order_should_add_payment_to_list_change_remaining_value_to_pay_and_change_status_to_paid_out()
        {
            //Given
            var posOrder = GetBasicPOSOrder();
            var customer = new Entities.User.Customer{ Id = 1};
            var valueToPay = posOrder.OrderTotal;
            var paymentService = MockPaymentService(mock => 
                mock.Setup(m => m.IssuePaymentAsync(It.IsAny<Payment>()))
                    .ReturnsAsync(PaymentResult.Paid(Payment.Create(null,null,valueToPay,valueToPay))));
            var paymentMethod = new InHands(acceptsPartialPayment:false,paymentService);            
            //When
            posOrder.DefinePaymentMethod(paymentMethod);
            await posOrder.PayAsync(valueToPay,customer);
            //Then            
            Assert.True(posOrder.PaidOut);
            Assert.Equal(0,posOrder.RemainingValueToPay);
            Assert.Single(posOrder.Payments);
        }
        [Fact(DisplayName = "Orders that are being paid partially should state that accept partial payments")]        
        public async Task On_paying_order_when_payment_is_less_than_remaining_value_to_pay_should_return_failed_status_if_disallowed_to_receive_partial_payments()
        {
            //Given
            var posOrder = GetBasicPOSOrder();
            var customer = new Entities.User.Customer{
                Id = 1
            };
            var valueToPay = posOrder.OrderTotal / 4.0m;
            var paymentService = MockPaymentService(mock => DefineSuccessfulPayment(valueToPay,customer,mock));
            var paymentMethod = new InHands(acceptsPartialPayment:false,paymentService);
            // var payment = Payment.Create(paymentMethod, customer, valueToPay);
            //When
            posOrder.DefinePaymentMethod(paymentMethod);
            await posOrder.PayAsync(valueToPay,customer);
            //Then            
            Assert.Equal(OrderState.Failed,posOrder.State);
        }
        [Fact]
        public async Task Given_payment_value_bigger_than_order_total_When_is_in_hands_method_Then_should_set_change()
        {
            //Given
            var posOrder = GetBasicPOSOrder();
            var customer = new Customer{
                Id = 1
            };
            var valueToPay = posOrder.OrderTotal * 2;
            var expectedChange = posOrder.OrderTotal;
            var paymentService = MockPaymentService(mock => DefineSuccessfulPayment(valueToPay,customer,mock));
            var paymentMethod = new InHands(acceptsPartialPayment:false,paymentService);
            posOrder.DefinePaymentMethod(paymentMethod);
            //When
            await posOrder.PayAsync(valueToPay,customer);
            //Then
            Assert.Equal(expectedChange,posOrder.Change);
        }
        
        [Fact(DisplayName = "Create Item from product Id and quantity bigger than zero")]
        public void Create_Item_from_product_id_and_quantity()
        {
            //Given
            var posOrder = new POSOrder();
            var product = new ProductSeed().GetSeedObject();
            product.Id = 1;
            product.UpdateStock(4,product);
            var quantity = 4;
            var expectedOrderTotal = product.EndCustomerPrice * quantity;
            var repository = MockRepository((mock) => {
                mock.Setup(m => m.GetBy(It.IsAny<int>()))
                    .Returns(product);
            });
            //When
            var item = POSOrderItem.Create(product.Id,quantity,posOrder,repository);
            //Then
            Assert.True(item.Success);
            Assert.NotNull(item.Value);
            Assert.Equal(expectedOrderTotal,item.Value.Total);
            Assert.Equal(item.Value.POSOrderId,posOrder.Id);
            
        }
        [Fact(DisplayName = "Shouldn't create item if given product id has not stock available")]
        public void If_Product_is_out_of_stock_don_t_create_item()
        {
            //Given
            var posOrder = new POSOrder();
            var product = new ProductSeed().GetSeedObject();
            product.Id = 1;
            product.UpdateStock(-product.QuantityInStock,product);
            // When
            var posOrderItemResult = POSOrderItem.Create(product.Id,1,posOrder,MockRepository());
            // Then
            Assert.False(posOrderItemResult.Success);
            Assert.Null(posOrderItemResult.Value);
        }
        [Fact(DisplayName = "If given quantity is bigger than stock available, if stock is bigger than zero, provide the biggest quantity possible")]
        public void If_quantity_is_bigger_than_product_stock_use_remaining_stock()
        {
            //Given
            var posOrder = new POSOrder();
            var product = new ProductSeed().GetSeedObject();
            product.Id = 1;            
            product.UpdateStock(StockChange.CreateChange(5,product,product));
            product.UpdateStock(StockChange.CreateChange(-2,product,product));
            var quantity = 4;
            var repository = MockRepository((mock) => {
                mock.Setup(m => m.GetBy(It.IsAny<int>()))
                    .Returns(product);
            });
            //When
            var posOrderItemResult = POSOrderItem.Create(product.Id,quantity,posOrder,repository);
            //Then
            Assert.NotEqual(posOrderItemResult.Value.Quantity,quantity);
            Assert.Equal(posOrderItemResult.Value.Quantity,product.QuantityInStock);
        }
        
    }
}