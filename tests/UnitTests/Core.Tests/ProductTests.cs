using System;
using Xunit;
using System.Linq;
using DAL.Seed;
using Core.Entities.Stock;
using Core.Entities.Financial;
using Core.Entities.Orders;

namespace Core.Entities.Catalog.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Given_Update_Price_Object_When_Calling_UpdatePrice_Method_On_Instance_Of_Product_And_Pass_UpdatePrice_Object_Then_Add_Object_Collection_And_Update_Internal_Fields()
        {
            //Given
            var product = new ProductSeed().GetSeedObject();
            var productPrice = ProductPrice.CreateNewPrice(product, costPrice: 12.99m, endCustomerDrugPrice: 15.99m, DateTimeOffset.UtcNow);
            //When
            product.SetNewPrice(productPrice);
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
            product.UpdatePrice(endCustomerPrice,costPrice,DateTimeOffset.UtcNow);
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
            product.UpdateStock(StockChange.CreateChange(4,product, new StockEntry { Id = 1 }));
            var posOrder = new POSOrder
            {
                Id = 1
            };
            int quantity = -2;
            int expectedQuantity = 2;
            var stockChange = StockChange.CreateChange(quantity,product,posOrder);
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
            product.UpdateStock(StockChange.CreateChange(quantity: 0,product, new StockEntry { Id = 1 }));
            var posOrder = new POSOrder
            {
                Id = 1
            };
            int quantity = -2;            
            var stockChange = StockChange.CreateChange(quantity,product, posOrder);
            // When..., then
            
            Assert.Throws<ArgumentException>(() => product.UpdateStock(stockChange));            
        }
        [Fact(DisplayName = "Add product to a category should add a new category for the collection in product entity")]
        public void Given_category_and_product_When_add_product_to_category_Then_category_should_be_present_in_product_category_collection()
        {
            // Given
            var product = new ProductSeed().GetSeedObject();
            product.Id = 1;
            var category = new Category()
            {
                Name = "Cosmetics"                
            };
            category.Id = 1;

            // When
            product.AddToCategory(category);

            // Then 
            Assert.NotEmpty(product.Categories);
        }
        [Fact]
        public void Given_existing_tax_When_create_product_tax_from_tax_Then_add_product_tax_to_caller_product()
        {
            // Given
            var product = new ProductSeed().GetSeedObject();
            var tax = new Tax("FAKE 12%", 0.12m);
            // When
            product.AddTax(tax);
            // Then
            Assert.NotEmpty(product.ProductTaxes);
        }

    }
}