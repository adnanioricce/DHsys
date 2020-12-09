using Xunit;
using Desktop.ViewModels.POS;
using System;
using Moq;
using Core.Interfaces.Financial;
using Core.Entities.Catalog;
using Tests.Lib.Data;
using Tests.Lib.Seed;
using System.Linq;
using System.Threading.Tasks;
using Desktop.Models.POS;
using Core.Entities.Financial;

namespace Desktop.ViewModels.Tests
{
    public class OrderViewModelTests
    {        
        [Fact(DisplayName = "Test if ViewModel search for elements with given search patterns")]
        public async Task Given_SearchDrugs_When_condition_Should_expect()
        {
            // Given
            var drug = ProductSeed.BaseCreateDrugEntity();
            var fakeRepository = new FakeRepository<Drug>(new[] { drug });
            var viewModel = new OrderViewModel(null, fakeRepository);
            // When
            await viewModel.LoadProducts();
            await viewModel.SearchDrugs(drug.Name);
            var drugs = viewModel.Products.Where(d => d.Name == drug.Name);
            // Then
            Assert.NotEmpty(drugs);
        }

        [Fact(DisplayName = "test if Load functions is loading drugs into Products Property")]
        public async Task Given_LoadProducts_When_condition_Should_expect()
        {
            // Given
            var drug = ProductSeed.BaseCreateDrugEntity();
            var fakeRepository = new FakeRepository<Drug>(new[] { drug });
            var viewModel = new OrderViewModel(null, fakeRepository);
            // When
            await viewModel.LoadProducts();
            var drugItem = viewModel.Products.Where(p => p.Id == drug.Id).FirstOrDefault();
            // Then
            Assert.NotNull(drugItem);
        }

        //This seem useless...
        [Fact(DisplayName = "Test if can add product to Receipt without problem")]
        public void Given_AddProductToOrder_When_condition_Should_expet()
        {
            // Given
            var drug = ProductSeed.BaseCreateDrugEntity();            
            var viewModel = new OrderViewModel(null, null);
            // When
            
            viewModel.Products.Add(new ProductItemModel
            {
                Id = drug.Id,
                UniqueCode = drug.UniqueCode,
                Barcode = drug.BarCode,
                Name = drug.Name,
                EndCustomerPrice = drug.EndCustomerPrice.Value,
                ImageSource = !(drug.GetThumbnailImage() is null) ? new Uri(drug.GetThumbnailImage().Media.SourceUrl) : new Uri("")
            });            
            viewModel.AddProductToOrder(drug.Id,1);
            var receiptItem = viewModel.ReceiptItems.Where(p => p.ProductId == drug.Id).FirstOrDefault();
            // Then
            Assert.Equal(drug.Id ,receiptItem.ProductId);
        }
        [Fact(DisplayName = "Test if function save Receipt as a Transaction Entity on database")]
        public void Given_CreatePosOrder_When_condition_should_expect()
        {
            // Given
            var drug = ProductSeed.BaseCreateDrugEntity();            
            var drugRepository = new FakeRepository<Drug>(new[] { drug });            
            var mockTransactionService = new Mock<ITransactionService>();
            mockTransactionService.Setup(m => m.CreateTransactionAsync(It.IsAny<POSOrder>()))
                                  .Callback(() => Task.Delay(0));
            var viewModel = new OrderViewModel(mockTransactionService.Object, null);
            // When
            viewModel.Products.Add(new ProductItemModel
            {
                Id = drug.Id,
                UniqueCode = drug.UniqueCode,
                Barcode = drug.BarCode,
                Name = drug.Name,
                EndCustomerPrice = drug.EndCustomerPrice.Value,
                CostPrice = drug.CostPrice,
                ImageSource = !(drug.GetThumbnailImage() is null) ? new Uri(drug.GetThumbnailImage().Media.SourceUrl) : new Uri(""),
                Classification = drug.Classification
            });
            viewModel.AddProductToOrder(drug.Id,1);
            viewModel.CreatePosOrder().GetAwaiter().GetResult();
            
            //Then             
            Assert.Empty(viewModel.ReceiptItems);
        }
    }
}