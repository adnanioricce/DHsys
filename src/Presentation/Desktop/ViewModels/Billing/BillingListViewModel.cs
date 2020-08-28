using Core.Entities;
using Core.Entities.Financial;
using Core.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Desktop.ViewModels.Billings
{
    public class BillingListViewModel : ViewModelBase
    {
        private readonly IRepository<Billing> _contaRepository;
        private readonly IBillingService _billingService;
        private readonly IFileSystemService _ioService;
        private string _searchPattern = string.Empty;
        public string SearchPattern { get { return _searchPattern; } set { OnSearch(value); } }
        public RelayCommand<string> SearchUpdateCommand { get; set; }
        public RelayCommand LoadBillingsCommand { get; set; }
        public RelayCommand AddBillingsFromCsvCommand { get; set; }
        public ObservableCollection<Billing> Contas { get; set; }
        public BillingListViewModel(IBillingService billingService,IRepository<Billing> contaRepository, IFileSystemService ioService)
        {
            _billingService = billingService;
            _contaRepository = contaRepository;
            _ioService = ioService;
            SearchUpdateCommand = new RelayCommand<string>(OnSearch);
            Contas = new ObservableCollection<Billing>();
            LoadBillingsCommand = new RelayCommand(OnLoadBillings);
            //Should this command be used here? Maybe call create view from CustomNavigationService class and handle from there?
            AddBillingsFromCsvCommand = new RelayCommand(AddBillingsFromCsv);
        }
        
        public virtual void OnSearch(string value)
        {
            if (!string.IsNullOrEmpty(value)){
                
                var contas = _billingService.GetBillingsByBeneficiaryName(value);
                UpdateBillingCollection(Contas, contas);
            }
            else
            {
                if (Contas.Count == 0)
                    UpdateBillingCollection(Contas, _contaRepository.GetAll());
            }
        }       
        public virtual void OnLoadBillings()
        {
            UpdateBillingCollection(Contas,_billingService.GetBillings(null));
        }
        public virtual void AddBillingsFromCsv()
        {
            var file = _ioService.OpenFileDialog("C:\\");
            //TODO:open file with a csv reader and save it on database
        }
        private void UpdateBillingCollection(ObservableCollection<Billing> contas,IEnumerable<Billing> novasContas)
        {            
            Contas.Clear();
            for (int i = 0; i < novasContas.Count(); i++)
                Contas.Add(novasContas.ElementAt(i));
        }
    }
}
