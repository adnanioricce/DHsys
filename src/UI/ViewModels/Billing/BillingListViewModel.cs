using Core.Entities;
using Core.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UI.ViewModels
{
    public class BillingListViewModel : ViewModelBase
    {
        private readonly IRepository<Billing> _contaRepository;
        private string _searchPattern = string.Empty;
        public string SearchPattern { get { return _searchPattern; } set { OnSearch(value); } }
        public RelayCommand<string> SearchUpdateCommand { get; set; }
        public ObservableCollection<Billing> Contas { get; set; }
        public BillingListViewModel(IRepository<Billing> contaRepository)
        {
            _contaRepository = contaRepository;
            SearchUpdateCommand = new RelayCommand<string>(OnSearch);
            Contas = new ObservableCollection<Billing>();
        }
        
        public virtual void OnSearch(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {                
                var contas = _contaRepository.Query()
                .Where(c => EF.Functions.Like(c.BeneficiaryName, "%" + value + "%"))
                .ToList();
                UpdateBillingCollection(Contas, contas);
            }
            else
            {
                if (Contas.Count == 0)
                    UpdateBillingCollection(Contas, _contaRepository.GetAll());
            }
        }       

        private void UpdateBillingCollection(ObservableCollection<Billing> contas,IEnumerable<Billing> novasContas)
        {            
            Contas.Clear();
            for (int i = 0; i < novasContas.Count(); i++)
                Contas.Add(novasContas.ElementAt(i));
        }
    }
}
