using Xunit;
namespace Core.Entities.Catalog.Tests
{
    public class ProductPriceTests
    {
        [Fact]
        //TODO:test for a method that calculates SavingPercentage of CostPrice and EndCustomerPrice
        public void Given_Cost_Price_And_Customer_Price_For_A_ProductPrice_When_Calling_Method_To_Calculates_Percentage_Of_Saving_Then_Return_Saving_Percentage_Between_Cost_Price_And_Customer_Price()
        {
            //Given
            decimal costPrice = 12.99m;
            decimal endCustomerPrice = 15.99m;
            var productPrice = new ProductPrice(costPrice,endCustomerPrice);
            //When        
            var savingPercentage = productPrice.CalculatePercentageSaving();
            //Then
            Assert.Equal(0.187617m,savingPercentage,6);
        }
    }
}