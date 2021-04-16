using System;
using Xunit;
namespace Core.Entities.Catalog.Tests
{
    public class ProductPriceTests
    {        
        [Fact(DisplayName = "Should return calculation of saving percentage given his cost and end customer price")]        
        public void Given_Cost_Price_And_Customer_Price_For_A_ProductPrice_When_Calling_Method_To_Calculates_Percentage_Of_Saving_Then_Return_Saving_Percentage_Between_Cost_Price_And_Customer_Price()
        {
            // Given
            var product = new Product
            {
                Id = 1
            };
            decimal costPrice = 12.99m;
            decimal endCustomerPrice = 15.99m;
            var productPrice = ProductPrice.CreateNewPrice(product, costPrice, endCustomerPrice,DateTimeOffset.UtcNow);
            // When        
            var savingPercentage = productPrice.CalculatePercentageSaving();
            // Then
            Assert.Equal(0.187617m,savingPercentage,6);
        }
        [Fact(DisplayName = "If some given price is negative, throws a exception")]
        public void Given_some_prices_When_entity_receives_a_negative_value_for_cost_or_customer_price_Then_throws_a_exception()
        {
            // Given
            var product = new Product { Id = 1 };
            decimal costPrice = -12.99m;
            decimal endCustomerPrice = -15.99m;
            DateTimeOffset startDate = DateTimeOffset.UtcNow;
            // When..., Then
            Assert.Throws<ArgumentException>(() => ProductPrice.CreateNewPrice(product, costPrice, endCustomerPrice, startDate));            
        }
        [Fact()]
        public void Given_some_start_date_When_entity_receives_a_date_older_than_actual_Then_set_date_to_actual_utc_date()
        {
            // Given
            var product = new Product { Id = 1 };
            decimal costPrice = 12.99m;
            decimal endCustomerPrice = 15.99m;
            DateTimeOffset startDate = DateTimeOffset.UtcNow;
            // When
            var price = ProductPrice.CreateNewPrice(product, costPrice, endCustomerPrice, startDate);
            // Then
            Assert.NotEqual(startDate,price.Pricestartdate);
        }
    }
}