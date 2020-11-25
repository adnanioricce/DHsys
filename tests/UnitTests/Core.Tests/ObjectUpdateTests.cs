using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Extensions;
using DAL.Seed;
using System;
using Xunit;

namespace Core.Tests
{
    public class ObjectUpdateTests
    {
        [Fact]
        public void Given_two_objects_of_same_type_When__objects_have_different_values_Then_updated_values_should_be_present_in_both_objects()
        {
            // Given
            var sourceObject = new DrugSeed().GetSeedObject();
            var destinationObject = new DrugSeed().GetSeedObject();
            destinationObject.ActivePrinciple = "Some Updated Principle";
            destinationObject.AddNewProductMedia(new Entities.Media.MediaResource
            {
                Id = 5,
                Type = Entities.Media.MediaType.Image,
                SourceUrl = "https://sample.com",
                Size = 64L,
                UniqueCode = Guid.NewGuid().ToString(),
                CreatedAt = DateTimeOffset.UtcNow,
                Caption = "some caption"
            });
            destinationObject.ProductSuppliers.Add(new ProductSupplier
            {
                Id = 5,
                Supplier = new SupplierSeed().GetSeedObject(),
                Product = new DrugSeed().GetSeedObject(),
                UniqueCode = Guid.NewGuid().ToString()
            });
            // When
            var result = sourceObject.MapObjectFrom(destinationObject);
            // Then
            Assert.True(result);
        }
    }
}
