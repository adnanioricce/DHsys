using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Entities.Stock;
using Core.Interfaces;
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
            var repository = MockRepository((mock) => mock.Setup(m => m.GetBy(It.IsAny<int>())).Returns(product));
            posOrder.AddItem(product.Id,2,repository);
            var expectedOrderTotal = product.EndCustomerPrice * 6;
            // When
            posOrder.AddItem(product.Id,4,repository);
            // Then
            Assert.Equal(1,posOrder.Items.Count);
            Assert.Equal(expectedOrderTotal,posOrder.OrderTotal);
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