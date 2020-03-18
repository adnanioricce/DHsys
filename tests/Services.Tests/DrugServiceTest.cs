namespace Services.Tests
{
    public class DrugServiceTest
    {
        [Fact]
        public void AddDrug_ReceivesDrugEntity_ShouldAddDrugEntryToDataSource()
        {
            //Given             
            var drug = new Drugs{
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
            var repository = new FakeRepository<Drugs>();            
            var service = new DrugService(repository);
            //when
            service.AddDrug(drug);
            var returnedDrug = repository.GetById(1);
            //Then 
            Assert.Equal(1,returnedDrug.Id);
        }
        [Fact]
        public void SearchDrugByName_ReceivesStringPattern_ShouldReturnAllDrugsThatContainsStringPatternInName()
        {
            //Given
            
            //When
            
            //Then
        }
    }
}