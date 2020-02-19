using Core.Entities;
using DAL.Interfaces;
using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace UI.ViewModels
{
    public class ContaViewModel : ViewModelBase
    {
        private readonly IRepository<Conta> _contaRepository;
        private string _searchPattern = string.Empty;
        public string SearchPattern { get { return _searchPattern; } set { OnSearch(value); } }
        public ObservableCollection<Conta> Contas { get; set; }
        public ContaViewModel(IRepository<Conta> contaRepository)
        {
            _contaRepository = contaRepository;
        }
        
        public void OnSearch(string value)
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
        private void PopulateCollection(ObservableCollection<Conta> contas,IEnumerable<Conta> novasContas)
        {
            Contas.Clear();
            for (int i = 0; i < novasContas.Count(); i++)
                Contas.Add(novasContas.ElementAt(i));
        }
    }
}
