using Core.Entities.Financial;
using Xunit;

namespace Core.Tests
{
    public class TaxTests
    {
        [Fact(DisplayName = "When create Tax domain object from existing tax, should provide tax name and percentage")]
        public void Given_tax_existing_in_domain_When_receives_a_tax_name_and_percentage_to_create_method_Then_return_tax_object()
        {
            //Given
            var taxName = "PMC 18%";
            var taxPercentage = 18m;
            
            //When
            var tax = new Tax(taxName,taxPercentage);
            //Then            
            Assert.Equal(taxName, tax.Name);
        }
        [Fact(DisplayName = "Should multiply percentage by 100 if value is between 0 and 1")]
        public void Given_tax_with_percentage_in_decimal_form_When_creates_object_Then_replace_by_product_of_percentage_and_100()
        {
            // Given
            var taxName = "PMC 12%";
            var taxPercentage = 0.18m;
            var expectedPercentage = 18.0m;
            // When
            var tax = new Tax(taxName, taxPercentage);

            // Then
            Assert.Equal(expectedPercentage, tax.Percentage);
        }
    }
}
