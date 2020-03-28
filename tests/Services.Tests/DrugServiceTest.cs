using Xunit;
using Core.Entities;
using Core.Entities.Catalog;
using Tests.Lib.Data;
namespace Services.Tests
{
    public class DrugServiceTest
    {
        [Fact]
        public void AddDrug_ReceivesDrugEntity_ShouldAddDrugEntryToDataSource()
        {
            //Given             
            var drug = BaseCreateDrugEntity();         
             
            var repository = new FakeRepository<Drug>();            
            var service = new DrugService(repository);
            //when
            service.AddDrug(drug);
            var returnedDrug = repository.GetById(1);
            //Then 
            Assert.Equal(1,returnedDrug.Id);
        }
        [Fact]
        public void AddDrug_ReceivesDrugEntityWithoutManufacturer_ShouldReturnErrorInvalidEntityEntry()
        {
            //Given             
            var drug = BaseCreateDrugEntity();                  
            drug.ManufacturerId = 0;            
            drug.Code = "";
            var service = CreateService();
            //when
            service.AddDrug(drug);
            var returnedDrug = repository.GetById(1);
            //Then 
            Assert.Equal(1,returnedDrug.Id);
        }
        [Fact]
        public void SearchDrugsByName_ReceivesStringPattern_ShouldReturnAllDrugsThatContainsStringPatternInName()
        {
            //Given            
            var drug = new Drug{
                Name = "doralgina"
            };            
            var service = CreateService(drug);
            //When
            var drugs = service.SearchDrugsByName(drugName);
            //Then
            Assert.True(drugs.Any(d => string.Equals(d.Name,drugName,StringComparison.IgnoreOrdinalCase)));
        }
        //? And if I receive more than one drug?
        [Fact]
        public void SearchDrugByBarCode_ReceivesStringCode_ShouldReturnOnlyOneDrugWithTheGivenString()
        {
            //Given            
            var drug = new Drug {
                BarCode = "300024567124766437435"
            };
            var service = CreateService(drug);
            //When
            var returnedDrug = service.SearchDrugByBarCode(drug.BarCode);
            //Then
            Assert.Equal(drug.BarCode,returnedDrug.BarCode);
        }
        private DrugService CreateService(Drug testDrug)
        {            
            var repository = new FakeRepository<Drug>();
            repository.Add(drug);
            return new DrugService(repository);
        }
        private DrugService CreateService()
        {
            var repository = new FakeRepository<Drug>();            
            return new DrugService(repository);
        }
        private Drug BaseCreateDrugEntity()
        {
            return new Drug{
                ManufacturerId = 1,
                DrugName = "SomeDrugName 30mg 30cp",
                Description = "no description",
                Classification = "some classification",
                DrugCost = 14.99,
                DosageInMg = 30,
                QuantityInStock = 4,
                ReorderLevel = 0,
                ReorderQuantity = 1,
                EndCustomerPrice = 32.99,
                Substance = "Some Substance",
                TypeOfUse = "Oral",
                MinimalAgeOfUse = 12,
                PrescriptionNeeded = false,
                DigitalBuleLink = "http://falselink.com/bule000001",
                BarCode = Guid.NewGuid().ToString(),
                Code = "40028922",
            };                  
        }
        
    }
}