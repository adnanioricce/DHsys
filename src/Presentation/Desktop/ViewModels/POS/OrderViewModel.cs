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
                _backProducts.Add(new DrugItemModel
                {
                    Id = drug.Id,
                    UniqueCode = drug.UniqueCode,
                    Barcode = drug.BarCode,
                    Name = drug.Name,
                    EndCustomerPrice = drug.EndCustomerPrice.Value,
                    ImageSource = !(drug.ThumbnailImage is null) ? new Uri(drug.ThumbnailImage.Media.SourceUrl) : new Uri("")
                });
            }
            
        }
    }
}
