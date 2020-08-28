using Application.Services;
using Core.Entities;
using Core.Entities.Financial;
using Core.Entities.Stock;
using Core.Interfaces;
using Moq;
using System;
using System.Linq;
using Tests.Lib.Data;
using Xunit;

namespace Services.Tests.Services.Financial
{
    public class BillingServiceTests
    {                
        [Fact]
        public void Given_New_Billing_Entity_Object_When_Passes_Object_To_Billing_Service_Then_Validate_Object_And_Save_It()
        {
            // Given
            var fakeBillingRepository = new FakeRepository<Billing>();
            var fakeBeneficiaryRepository = new FakeRepository<Beneficiary>();
            fakeBeneficiaryRepository.Add(GetFakeValidManufacturer());
            var service = this.CreateService(fakeBillingRepository,fakeBeneficiaryRepository);
            
            Billing billing = GetFakeValidBilling(1);

            // When
            var result = service.AddBilling(billing);

            // Then
            Assert.True(result.Success);
            Assert.Equal(1, result.Value.Id);
            Assert.Empty(result.Errors);
        }
        [Fact]
        public void Given_New_Billing_Entity_Object_Without_Beneficiary_Name_When_Passes_Object_To_Billing_Service_Then_Validate_Object_Set_BeneficiaryName_And_Save_It()
        {
            // Given
            var fakeBillingRepository = new FakeRepository<Billing>();
            var fakeBeneficiaryRepository = new FakeRepository<Beneficiary>();
            fakeBeneficiaryRepository.Add(GetFakeValidManufacturer());
            var service = this.CreateService(fakeBillingRepository, fakeBeneficiaryRepository);

            Billing billing = GetFakeValidBilling(1);
            billing.BeneficiaryName = "";

            // When
            var result = service.AddBilling(billing);

            // Then
            Assert.True(result.Success);
            Assert.Empty(result.Errors);
            Assert.Equal(1, result.Value.Id);
            Assert.False(string.IsNullOrEmpty(result.Value.BeneficiaryName));
            
        }
        [Fact]
        public void Given_Existing_Unpaid_Billing_When_Gets_All_Unpaid_Billings_Till_Limit_Then_Return_All_Unpaid_Billings_Till_Limit()
        {
            // Given
            var fakeBillingRepository = new FakeRepository<Billing>();
            var service = this.CreateService(fakeBillingRepository);
            fakeBillingRepository.Add(GetFakeValidBilling(1));
            int? limit = 100;

            // When
            var result = service.GetUnpaidBillings(limit);
            int billingsCount = result.Count();
            // Then
            Assert.True(billingsCount <= 100 && billingsCount > 0);                        
        }
        [Fact]
        public void Given_Existing_Billing_When_Gets_Billing_By_Its_Beneficiary_Name_Then_Return_All_Billings_With_Same_Beneficiary_Name()
        {
            //Given
            var billing = GetFakeValidBilling(1);
            var fakeBillingRepository = new FakeRepository<Billing>();
            fakeBillingRepository.Add(billing);
            var service = this.CreateService(fakeBillingRepository, null);            

            //When
            var result = service.GetBillingsByBeneficiaryName(billing.BeneficiaryName);
            //Then 
            Assert.NotEmpty(result);
            Assert.Collection(result, bill => Assert.Equal(billing.BeneficiaryName, bill.BeneficiaryName));
        }
        private Billing GetFakeValidBilling(int beneficiaryId)
        {
            return new Billing
            {
                BeneficiaryName = "fake beneficiary",
                BeneficiaryId = beneficiaryId,
                IsPaid = false,
                Discount = 0,
                EndDate = DateTime.UtcNow.AddDays(3),
                Price = 200.00m
            };
        }
        private Manufacturer GetFakeValidManufacturer()
        {
            return new Manufacturer
            {
                Name = "fake beneficiary",
                Cnpj = "40028922-01/0001",
                UniqueCode = Guid.NewGuid().ToString(),
                Address = new Address
                {
                    Addressnumber = "1212",
                    District = "fake district",
                    City = "fake city",
                    Zipcode = "12345678",
                    FirstAddressLine = "fake first line",
                    SecondAddressLine = "fake second line",
                    AddressState = "fake state",
                    UniqueCode = Guid.NewGuid().ToString()
                }
            };
        }
        private IBillingService CreateService(IRepository<Billing> billingRepository)
        {
            return new BillingService(billingRepository,null);
        }
        private IBillingService CreateService(IRepository<Billing> billingRepository,IRepository<Beneficiary> beneficiaryRepository)
        {
            return new BillingService(billingRepository, beneficiaryRepository);
        }
    }
}
