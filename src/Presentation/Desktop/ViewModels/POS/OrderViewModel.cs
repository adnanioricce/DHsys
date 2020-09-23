using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Interfaces;
using Core.Interfaces.Financial;
using Desktop.Models.POS;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Desktop.ViewModels.POS
{
    public class OrderViewModel : ViewModelBase
    {
        protected readonly ITransactionService _transactionService;
        protected readonly IDrugService _drugService;
        protected readonly IRepository<Drug> _repository;
        protected readonly IList<DrugItemModel> _backProducts = new List<DrugItemModel>();        
        public ObservableCollection<DrugItemModel> Products { get; set; } = new ObservableCollection<DrugItemModel>();        
        public ObservableCollection<TransactionItemModel> ReceiptItems { get; set; } = new ObservableCollection<TransactionItemModel>();
        public RelayCommand LoadDrugsCommand { get; set; }
        public RelayCommand<string> SearchDrugsCommand { get; set; }
        
        public OrderViewModel(ITransactionService transactionService, IRepository<Drug> repository)
        {
            _transactionService = transactionService;            
            _repository = repository;
            LoadDrugsCommand = new RelayCommand(async () => await LoadProducts());
            SearchDrugsCommand = new RelayCommand<string>(async (pattern) => await SearchDrugs(pattern));            
        }
        public async Task SearchDrugs(string searchPattern)
        {
            Products.Clear();
            await Task.Run(() =>
            {                
                foreach(var item in _backProducts)
                {
                    if (item.Name.Contains(searchPattern) || item.Barcode.Contains(searchPattern) || item.UniqueCode.Contains(searchPattern) || item.Classification.Contains(searchPattern))
                    {
                        Products.Add(item);
                    }
                }                               
            });            
        }
        public async Task LoadProducts()
        {            
            await foreach (var drug in _repository.GetAsyncEnumerable())
            {
                var drugItem = new DrugItemModel
                {
                    Id = drug.Id,
                    UniqueCode = drug.UniqueCode,
                    Barcode = drug.BarCode,
                    Name = drug.Name,
                    EndCustomerPrice = drug.EndCustomerPrice.Value,
                    CostPrice = drug.CostPrice,
                    ImageSource = !(drug.ThumbnailImage is null) ? new Uri(drug.ThumbnailImage.Media.SourceUrl) : new Uri(""),
                    Classification = drug.Classification
                };
                _backProducts.Add(drugItem);
                Products.Add(drugItem);
            }
            //Array.Copy(_backProducts.ToArray(), Products.ToArray(), _backProducts.Count);   
        }

        public void AddProductToOrder(int id,int quantity)
        {
            var product = Products.Where(p => p.Id == id).FirstOrDefault();
            ReceiptItems.Add(new TransactionItemModel{
                CustomerValue = product.EndCustomerPrice,
                ProductId = product.Id,
                Quantity = quantity,
                Drug = product
            });
        }

        public async Task CreatePosOrder()
        {
            var transactionItems = ReceiptItems.Select(item => new TransactionItem
            {
                DrugUniqueCode = item.Drug.UniqueCode,
                Quantity = item.Quantity,
                CostPrice = item.Drug.CostPrice,
                CustomerValue = item.Drug.EndCustomerPrice,
            });
            var transaction = new Transaction
            {
                HasDealWithStore = false,
            };
            transaction.AddItems(transactionItems.ToArray());
            await _transactionService.CreateTransactionAsync(transaction);
            ReceiptItems.Clear();
        }
    }
}
