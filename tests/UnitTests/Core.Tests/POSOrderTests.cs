using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Entities.Payments;
using Core.Entities.Stock;
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
            var valueToPay = 12.99m;
            var paymentMethod = new InHands(null);
            var payment = new Payment(valueToPay,PaymentStatus.Pending,paymentMethod,customer);
            //When
            posOrder.Cancel();
            var result = await posOrder.PayAsync(payment);
            //Then
            Assert.False(result.Success);
            Assert.False(posOrder.PaidOut);
            Assert.Equal(0,posOrder.RemainingValueToPay);
            Assert.Equal(0,posOrder.Payments.Count);
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
                    .ReturnsAsync(BaseResult<Payment>.CreateSuccessResult("order was paid with success",new Payment(valueToPay,PaymentStatus.Paid,new InHands(null),customer))));
            var paymentMethod = new InHands(paymentService);
            var payment = Payment.Create(paymentMethod,customer,valueToPay);
            //When
            var result = await posOrder.PayAsync(payment);
            //Then
            Assert.True(result.Success);
            Assert.True(posOrder.PaidOut);
            Assert.Equal(0,posOrder.RemainingValueToPay);
            Assert.Equal(1,posOrder.Payments.Count);
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