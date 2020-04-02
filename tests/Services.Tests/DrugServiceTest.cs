using Xunit;
using Tests.Lib.Data;
using System.Linq;
using System;
using Core.Services;
using Core.Entities.Catalog;
using Core.Interfaces;

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
            service.CreateDrug(drug);
            var returnedDrug = repository.GetBy(1);
            //Then 
            Assert.Equal(1,returnedDrug.Id);
        }
        [Fact]
        public void AddDrug_ReceivesDrugEntityWithoutManufacturer_ShouldReturnErrorInvalidEntityEntry()
        {
            //Given                         
            var repository = new FakeRepository<Drug>();
            var drug = BaseCreateDrugEntity();                     
            drug.ManufacturerId = 0;            
            drug.UniqueCode = "";
            repository.Add(drug);
            var service = new DrugService(repository);
            //when
            service.CreateDrug(drug);
            var returnedDrug = repository.GetBy(1);
            //Then 
            Assert.Equal(1,returnedDrug.Id);
        }
        [Fact]
        public void SearchDrugsByName_ReceivesStringPattern_ShouldReturnAllDrugsThatContainsStringPatternInName()
        {
            //Given            
            var drug = new Drug{
                DrugName = "doralgina"
            };            
            var service = CreateService(drug);
            //When
            var drugs = service.SearchDrugsByName(drug.DrugName);
            //Then
            Assert.True(drugs.Any(d => string.Equals(d.DrugName,drug.DrugName,StringComparison.OrdinalIgnoreCase)));
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
        private IDrugService CreateService(Drug testDrug)
        {            
            var repository = new FakeRepository<Drug>();
            repository.Add(testDrug);
            return new DrugService(repository);
        }
        private IDrugService CreateService()
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
                DrugCost = 14.99m,
                AbsoluteDosageInMg = 30,
                Dosage = "30mg",
                QuantityInStock = 4,
                ReorderLevel = 0,
                ReorderQuantity = 1,
                EndCustomerPrice = 32.99m,
                ActivePrinciple = "Some Substance",                
                PrescriptionNeeded = false,
                DigitalBuleLink = "http://falselink.com/bule000001",
                BarCode = Guid.NewGuid().ToString(),
                UniqueCode = "40028922",
            };                  
        }
        
    }
}