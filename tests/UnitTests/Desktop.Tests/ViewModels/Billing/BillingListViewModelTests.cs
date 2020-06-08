using System.Linq;
using Desktop.ViewModels;
using Xunit;
using Tests.Lib.Data;
using Core.Entities;
using Desktop.ViewModels.Billings;
using Core.Entities.Financial;
using Application.Services;

namespace Desktop.Tests.ViewModels
{
    public class BillingListViewModelTests
    {                        

        [Fact]
        public void Given_billing_with_beneficiary_When_searchs_for_billing_by_beneficiary_name_Then_return_billing_that_match_beneficiary_name()
        {
            // Given            
            var repository = new FakeRepository<Billing>();
            repository.Add(new Billing
            {
                BeneficiaryId = 1,
                BeneficiaryName = "1",
                UniqueCode = "123456",
            });
            var viewModel = new BillingListViewModel(new BillingService(repository,null),null,null);
            string value = "1";

            // When
            viewModel.OnSearch(value);

            // Then
            Assert.True(viewModel.Contas.All(item => item.BeneficiaryName.Contains(value)));            
        }
        [Fact]
        public void Given_csv_file_with_billings_When_Users_tries_to_open_file_from_dialog_Then_save_all_lines_on_database()
        {
            // Given
            // When
            // Then
        }
    }
}
