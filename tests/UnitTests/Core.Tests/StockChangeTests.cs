using Core.Entities;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Entities.Orders;
using Core.Entities.Stock;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Core.Tests
{
    public class StockChangeTests
    {
        [Theory(DisplayName = "Should create a out or in operation for stock change depending on the quantity provided")]
        [InlineData(1,1,-2)]
        [InlineData(1, 1, 2)]        
        public void Given_negative_or_positive_stock_change_When_try_to_create_stock_change_in_system_Then_return_out_or_in_stock_change(int productId,int impactingId,int quantity)
        {
            // Given            
            var expectedStockChange = quantity < 0 ? StockChangeType.Out : StockChangeType.In;
            var product = new Product
            {
                Id = productId
            };
            var impactingEntity = new BaseEntity
            {
                Id = impactingId
            };
            // When
            var stockChange = StockChange.CreateChange(quantity,product, impactingEntity);
            // Then
            Assert.Equal(expectedStockChange, stockChange.Type);            
        }
        [Fact(DisplayName = "If quantity is zero, should a return a None stock change")]
        public void Given_stock_change_with_quantity_equal_zero_When_try_to_create_stock_change_Then_return_a_None_stock_change()
        {
            // Given
            var productId = 1;
            var impactingId = 1;
            var quantity = 0;
            var product = new Product
            {
                Id = productId
            };
            var stockEntry = new StockEntry
            {
                Id = impactingId,
                
            };
            // When 
            var stockChange = StockChange.CreateChange(quantity,product, stockEntry);
            // Then 
            Assert.Equal(StockChangeType.None, stockChange.Type);
        }
        [Fact(DisplayName = "A existing product should be provided, can't pass a yet to be created product or a null value")]
        public void Given_product_not_present_on_system_When_try_to_create_stock_change_Then_throw_a_exception()
        {
            // Given
            var productId = 0;
            var impactingId = 1;
            var quantity = 1;
            var product = new Product
            {
                Id = productId
            };
            var posOrder = new POSOrder
            {
                Id = impactingId
            };
            // When and Then
            Assert.Throws<InvalidOperationException>(() => StockChange.CreateChange(quantity,product, posOrder));
        }
    }
}
