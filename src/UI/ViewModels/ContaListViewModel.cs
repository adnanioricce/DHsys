using UI.Entities;
using UI.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UI.ViewModels
{
    public class ContaListViewModel : ViewModelBase
    {
        private readonly IRepository<Conta> _contaRepository;
        private string _searchPattern = string.Empty;
        public string SearchPattern { get { return _searchPattern; } set { OnSearch(value); } }
        public RelayCommand<string> SearchUpdateCommand { get; set; }
        public ObservableCollection<Conta> Contas { get; set; }
        public ContaListViewModel(IRepository<Conta> contaRepository)
        {
            _contaRepository = contaRepository;
            SearchUpdateCommand = new RelayCommand<string>(OnSearch, CanSearch);
            Contas = new ObservableCollection<Conta>();
        }
        
        public virtual void OnSearch(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {                
                var contas = _contaRepository.Query()
                .Where(c => EF.Functions.Like(c.NomeEmpresa, "%" + value + "%"))
                .ToList();
                PopulateCollection(Contas, contas);
            }
            else
            {
                if (Contas.Count == 0)
                    PopulateCollection(Contas, _contaRepository.GetAll());
            }
        }
        public virtual bool CanSearch(object parameter)
        {
            return true;
        }

        private void PopulateCollection(ObservableCollection<Conta> contas,IEnumerable<Conta> novasContas)
        {
            Contas.Clear();
            for (int i = 0; i < novasContas.Count(); i++)
                Contas.Add(novasContas.ElementAt(i));
        }
    }
}
