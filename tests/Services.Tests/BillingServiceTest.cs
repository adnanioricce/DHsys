namespace Services.Tests
{
    public class BillingServiceTest
    {        
        [Fact]
        public void AddBilling_ExpectsBillingEntity_ShouldInsertBillingOnDataSource()
        {
            //Given
            var billing = new Billing{
                BeneficiaryId = null,
                Beneficiary = "SomePharmacyName",
                Price = 189.99m,
                Discount = 0,
                EndDate = DateTime.Now.AddMount(1),
                IsPaid = false
            };            
            var repository = new FakeRepository<Billing>();
            var service = new BillingService(repository,null);
            service.AddBilling(billing);       
            var billings = repository.GetAll();
            //When
            Assert.Equal(1,billings.Count());
            //Then
        }
        [Fact]
        public void GetUnpaidBillings_ReceivesOptionalLimit_ReturnTill100BillingsOrTillSpecifiedLimit()
        {
            //Given
            var billings = new Billing[
                new Billing{
                    BeneficiaryId = null,
                    Beneficiary = "SomePharmacyName",
                    Price = 189.99m,
                    Discount = 0,
                    EndDate = DateTime.Now.AddMount(1),
                    IsPaid = false
                },
                new Billing{
                    BeneficiaryId = null,
                    Beneficiary = "OtherPharmacyName",
                    Price = 565.99m,
                    Discount = 0,
                    EndDate = DateTime.Now.AddMount(1),
                    IsPaid = false
                }
            ];
            int limit = 2;
            var repository = new FakeRepository<Billing>();
            repository.AddRange(billings);
            var service = new BillingService(repository,null);
            //When
            var unpaidBillings = service.GetUnpaidBillings(limit);
            //Then
            Assert.Equal(2,unpaidBillings.Count());
        }
        [Fact]
        public async Task GetAllBillingsByBeneficiaryId_ReceivesBeneficiaryId_ShouldReturnAllBillingsWithBeneficiaryId()
        {
            //Given
            int beneficiaryId = 1;
            var billings = new Billing[
                new Billing{
                    BeneficiaryId = beneficiaryId,
                    Beneficiary = "SomePharmacyName",
                    Price = 189.99m,
                    Discount = 0,
                    EndDate = DateTime.Now.AddMount(1),
                    IsPaid = false
                },
                new Billing{
                    BeneficiaryId = beneficiaryId,
                    Beneficiary = "OtherPharmacyName",
                    Price = 565.99m,
                    Discount = 0,
                    EndDate = DateTime.Now.AddMount(1),
                    IsPaid = true
                },
                new Billing{
                    BeneficiaryId = 2,
                    Beneficiary = "TheNameOfTheSupplier",
                    Price = 458.99,
                    Discount = 0,
                    EndDate = DateTime.Now.AddMount(1),
                    IsPaid = false
                }
            ];
            var repository = new FakeRepository<Billing>();
            repository.AddRange(billings);
            var service = new BillingService(repository,null);
            //When
            var beneficiaryBillings = await service.GetAllBillingsByBeneficiaryId(1);
            //Then
            Assert.True(beneficiaryBillings.All(b => b.BeneficiaryId == beneficiaryId));
        }
        [Fact]
        public void GenerateMountlyReport_ReceivesNoArgument_ReturnsObjectWithReportOfBillingInCurrentMount()
        {
            //Given
            int beneficiaryId = 1;
            var billings = new Billing[
                new Billing{
                    BeneficiaryId = beneficiaryId,
                    Beneficiary = "SomePharmacyName",
                    Price = 189.99m,
                    Discount = 0,
                    EndDate = DateTime.Now,
                    IsPaid = false
                },
                new Billing{
                    BeneficiaryId = beneficiaryId,
                    Beneficiary = "OtherPharmacyName",
                    Price = 565.99m,
                    Discount = 0,
                    EndDate = DateTime.Now,
                    IsPaid = true
                },
                new Billing{
                    BeneficiaryId = 2,
                    Beneficiary = "TheNameOfTheSupplier",
                    Price = 458.99,
                    Discount = 0,
                    EndDate = DateTime.Now,
                    IsPaid = false
                }
            ];
            var repository = new FakeRepository<Billing>();
            repository.AddRange(billings);
            var service = new BillingService(repository,null);
            //When
            var report = await service.GenerateMountlyReport();
            //Then
            Assert.Equal(1214.97,report.TotalCost); 
            Assert.Equal(3,report.Billings.Count);            
        }
    }
}