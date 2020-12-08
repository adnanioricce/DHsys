using System;
using Tests.Lib.Seed;
using Xunit;
using Core.Entities.Catalog;
using System.Linq;
namespace Core.Entities.Catalog.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Given_Update_Price_Object_When_Calling_UpdatePrice_Method_On_Instance_Of_Product_And_Pass_UpdatePrice_Object_Then_Add_Object_Collection_And_Update_Internal_Fields()
        {
            //Given
            var product = ProductSeed.BaseProductEntity();
            var productPrice = new ProductPrice{
                ProductId = 1,
                Pricestartdate = DateTimeOffset.UtcNow,
                EndCustomerDrugPrice = 15.99m,
                CostPrice = 12.99m, 
                Product = product,
            };
            //When
            product.UpdatePrice(productPrice);
            var newPrice = product.ProductPrices.FirstOrDefault();
            //Then
            Assert.Equal(12.99m,newPrice.CostPrice);
            Assert.Equal(15.99m,newPrice.EndCustomerDrugPrice);
            Assert.Equal(productPrice,newPrice);
        }
        [Fact]
        public void Given_Decimal_values_for_Cost_Price_and_Customer_Price_When_Call_UpdatePrice_With_Theses_Decimal_Values_As_Argument_Should_Then_Add_new_ProductPrice_Object_To_Entity_With_Given_Values()
        {
            //Given
            decimal costPrice = 12.99m;
            decimal endCustomerPrice = 15.99m;
            var product = ProductSeed.BaseProductEntity();
            //When
            product.UpdatePrice(endCustomerPrice,costPrice);        
            //Then
            var newPrice = product.ProductPrices.FirstOrDefault();
            Assert.Equal(12.99m,newPrice.CostPrice);
            Assert.Equal(15.99m,newPrice.EndCustomerDrugPrice);            
        }
        [Fact]
        public void Given_Existing_Product_and_Supplier_When_()
        {

        }
    }
}