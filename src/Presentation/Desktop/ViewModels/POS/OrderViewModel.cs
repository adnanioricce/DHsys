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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Desktop.ViewModels.POS
{
    public class OrderViewModel : ViewModelBase
    {
        protected readonly ITransactionService _transactionService;
        protected readonly IProductService _drugService;
        protected readonly IRepository<Core.Entities.Catalog.Product> _repository;
        protected readonly List<Core.Entities.Catalog.Product> _backProducts = new List<Core.Entities.Catalog.Product>();
        public string TransactionTotalString 
        { 
            get 
            { 
                return $"Total: ${ReceiptItems.Sum(item => item.Quantity * item.CustomerValue)}"; 
            } 
        }
        private string _searchPattern = string.Empty;
        public string SearchPattern { get { return _searchPattern; }
            set 
            {
                if (this._searchPattern == value) return;
                Set(ref _searchPattern, value.ToUpper());
                Dispatcher.CurrentDispatcher.InvokeAsync(() => SearchDrugs(_searchPattern));
            }
        }
        public ObservableCollection<ProductItemModel> Products { get; set; } = new ObservableCollection<ProductItemModel>();        
        public ObservableCollection<TransactionItemModel> ReceiptItems { get; set; } = new ObservableCollection<TransactionItemModel>();
        public RelayCommand LoadCommand { get; set; }        
        public RelayCommand CreatePosOrderCommand { get; set; }

        public OrderViewModel(ITransactionService transactionService, IRepository<Core.Entities.Catalog.Product> repository)
        {
            _transactionService = transactionService;            
            _repository = repository;            
            CreatePosOrderCommand = new RelayCommand(async () => await Dispatcher.CurrentDispatcher.InvokeAsync(CreatePosOrder));
            LoadCommand = new RelayCommand(() => ThreadPool.QueueUserWorkItem(async (state) => await LoadProducts()));
        }
        public Task SearchDrugs(string searchPattern)
        {                        
            return Task.Run(() =>
            {
                var products = _backProducts.Where(item => item.Name.Contains(searchPattern) || item.BarCode.Contains(searchPattern) || item.UniqueCode.Contains(searchPattern) || item.Classification.Contains(searchPattern));
                Products = ToObserableCollection(products);                                               
            });            
        }
        public async Task LoadProducts()
        {            
            _backProducts.AddRange(await _repository.GetAsyncEnumerable().ToListAsync());            
            Products = ToObserableCollection(_backProducts);
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
            var transactionItems = ReceiptItems.Select(item => new POSOrderItem
            {
                ProductUniqueCode = item.Drug.UniqueCode,
                Quantity = item.Quantity,
                CostPrice = item.Drug.CostPrice,
                CustomerValue = item.Drug.EndCustomerPrice,
            });
            var transaction = new POSOrder();
            transaction.AddItems(transactionItems.ToArray());
            await _transactionService.CreateTransactionAsync(transaction);
            ReceiptItems.Clear();
        }
        private ObservableCollection<ProductItemModel> ToObserableCollection(IEnumerable<Core.Entities.Catalog.Product> products)
        {
            var collection = new ObservableCollection<ProductItemModel>();
            foreach (var product in products)
            {
                collection.Add(ToProductItemModel(product));
            }
            return collection;
        }
        private ProductItemModel ToProductItemModel(Core.Entities.Catalog.Product product)
        {
            return new ProductItemModel
            {
                Id = product.Id,
                UniqueCode = product.UniqueCode,
                Barcode = product.BarCode,
                Name = product.Name,
                EndCustomerPrice = product.EndCustomerPrice.Value,
                CostPrice = product.CostPrice,
                ImageSource = !(product.GetThumbnailImage() is null) ? new Uri(product.GetThumbnailImage().Media.SourceUrl) : new Uri("\\Resources\\Images\\placeholder.png"),
                Classification = product.Classification
            };
        }
    }
}
