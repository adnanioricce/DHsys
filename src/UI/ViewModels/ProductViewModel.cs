using System.Collections.ObjectModel;
using UI.Entities.LegacyScaffold;
using UI.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace UI.ViewModels
{
     public class ProductViewModel : ViewModelBase
     {
        private readonly ILegacyRepository<Produto> _produtoRepository;
        public ObservableCollection<Produto> ProdutoCollection { get; set; } = new ObservableCollection<Produto>();     
        public RelayCommand GetProductByCodeCommand { get; set; }
        public ProductViewModel(ILegacyRepository<Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public void ExecuteGetProductByCode(string parameter)
        {
            var produto = _produtoRepository.GetById(parameter);
            if(!ProdutoCollection.Contains(produto)){
                ProdutoCollection.Add(produto);                
            }
        }
        public bool CanExecuteGetProductByCode(string parameter)
        {
            return true;
        }        
     }
}
