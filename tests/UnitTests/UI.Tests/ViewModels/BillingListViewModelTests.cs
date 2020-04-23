using System.Linq;
using UI.ViewModels;
using Xunit;
using Tests.Lib.Data;
using Core.Entities;

namespace UI.Tests.ViewModels
{
    public class BillingListViewModelTests
    {                        

        [Fact]
        public void OnSearch_StateUnderTest_ExpectedBehavior()
        {
            // Arrange            
            var repository = new FakeRepository<Billing>();
            repository.Add(new Billing
            {
                BeneficiaryId = 1,
                BeneficiaryName = "1",
                UniqueCode = "123456",
            });
            var viewModel = new BillingListViewModel(repository);
            string value = "1";

            // Act
            viewModel.OnSearch(value);

            // Assert
            Assert.True(viewModel.Contas.All(item => item.BeneficiaryName.Contains(value)));            
        }
    }
}
