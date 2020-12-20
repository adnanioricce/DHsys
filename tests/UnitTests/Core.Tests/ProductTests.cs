using System;
using Xunit;
using Core.Entities.Catalog;
using System.Linq;
using DAL.Seed;
using Core.Entities.Stock;
using Core.Entities.Financial;

namespace Core.Entities.Catalog.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Given_Update_Price_Object_When_Calling_UpdatePrice_Method_On_Instance_Of_Product_And_Pass_UpdatePrice_Object_Then_Add_Object_Collection_And_Update_Internal_Fields()
        {
            //Given
            var product = new ProductSeed().GetSeedObject();
            var productPrice = new ProductPrice{
                ProductId = 1,
                Pricestartdate = DateTimeOffset.UtcNow,
                EndCustomerDrugPrice = 15.99m,
                CostPrice = 12.99m, 
                Product = product,
            };
            //When
            product.UpdatePrice(productPrice);
            var newPrice = product.ProductPrices.Where(p => p == productPrice).FirstOrDefault();
            //Then
            Assert.Equal(12.99m,newPrice.CostPrice);
            Assert.Equal(15.99m,newPrice.EndCustomerDrugPrice);
            Assert.Equal(productPrice,newPrice);
        }
        [Fact]
        public void Given_decimal_values_for_cost_price_and_customer_price_When_call_UpdatePrice_with_theses_decimal_values_as_argument_Then_add_new_ProductPrice_object_to_entity_with_given_values()
        {
            //Given
            decimal costPrice = 12.99m;
            decimal endCustomerPrice = 15.99m;
            var product = new ProductSeed().GetSeedObject();
            //When
            product.UpdatePrice(endCustomerPrice,costPrice);
            //Then
            var newPrice = product.ProductPrices.LastOrDefault();
            Assert.Equal(12.99m,newPrice.CostPrice);
            Assert.Equal(15.99m,newPrice.EndCustomerDrugPrice);            
        }
        [Fact(DisplayName = "update the quantity in stock with a negative stock change should result ")]
        public void Given_negative_stock_change_When_try_update_stock_quantity_of_a_product_Then_current_stock_quantity_should_be_actual_stock_quantity_minus_stock_change()
        {
            // Given
            var product = new ProductSeed().GetSeedObject();
            product.Id = 1;
            product.UpdateStock(StockChange.CreateChange(product, new StockEntry { Id = 1 }, 4));
            var posOrder = new POSOrder
            {
                Id = 1
            };
            int quantity = -2;
            int expectedQuantity = 2;
            var stockChange = StockChange.CreateChange(product,posOrder,quantity);
            // When 
            product.UpdateStock(stockChange);
            // Then
            Assert.Equal(expectedQuantity, product.QuantityInStock);
        }
        [Fact(DisplayName = "Product entity shouldn't allow a negative change that would let stock quantity negative be applied")]
        public void Given_negative_stock_change_When_try_update_stock_quantity_with_change_bigger_than_existing_quantity_Then_exception_is_throwed()
        {
            // Given
            var product = new ProductSeed().GetSeedObject();
            product.Id = 1;
            product.UpdateStock(StockChange.CreateChange(product, new StockEntry { Id = 1 },quantity: 0));
            var posOrder = new POSOrder
            {
                Id = 1
            };
            int quantity = -2;            
            var stockChange = StockChange.CreateChange(product, posOrder, quantity);
            // When..., then
            
            Assert.Throws<ArgumentException>(() => product.UpdateStock(stockChange));            
        }        
    }
}