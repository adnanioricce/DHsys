using Core.Entities.Catalog;
using Core.Interfaces;
using Moq;
using System;
using Tests.Lib.Data;
using Tests.Lib.Seed;
using Xunit;

namespace Desktop.Tests.Scanner
{
    public class ApplicationScannerTest
    {
        [Fact]
        public void Given_entity_with_barcode_string_When_End_users_Scan_barcode_from_entity_Then_Fire_event_To_Return_Entity_that_matches_barcode()
        {
            // Given
            string barcode = Guid.NewGuid().ToString("N");
            var entity = DrugSeed.BaseCreateDrugEntity();
            entity.BarCode = barcode;
            //var fakeRepository = new FakeRepository<Drug>();
            //fakeRepository.Add(entity);
            var fakeDrugService = GetFakeDrugService(entity);
            var scanner = new ApplicationScanner(fakeDrugService);
            // When
            var result = scanner.GetEntityByBarcode<Drug>(entity.BarCode);
            // Then
            Assert.True(result.Success);
            Assert.Equal(entity.BarCode, result.Value.Barcode);
            
        }
        private IDrugService GetFakeDrugService(Drug drug)
        {
            var mockDrugService = new Mock<IDrugService>();
            mockDrugService.Setup(m => m.SearchDrugByBarCode(It.IsAny<string>()))
                .Returns(drug);
            return mockDrugService.Object;
        }
    }
}
