using UI.Entities;
using UI.Interfaces;
using UI.Validations;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using UI.Models;

namespace UI.ViewModels
{
    public class AddContaViewModel : ViewModelBase
    {
        private readonly IRepository<Conta> _contaRepository;
        public ContaModel Model { get; set; }
        public RelayCommand CreateContaCommand { get; set; }        
        //TODO: Write UI validations
        public AddContaViewModel(IRepository<Conta> contaRepository)
        {
            _contaRepository = contaRepository;
        }
        public void CreateConta(ContaModel model)
        {
            _contaRepository.Add(new Conta{
                NomeEmpresa = model.NomeEmpresa,
                DataDeVencimento = model.DataDeVencimento,
                Valor = model.Valor
            });
            _contaRepository.SaveChanges();
        }
        public bool CanCreateConta(ContaModel model)
        {
            var validator = new ContaValidator();
            return validator.IsValid(new Conta
            {
                DataDeVencimento = model.DataDeVencimento,
                NomeEmpresa = model.NomeEmpresa,
                Valor = model.Valor
            });
        }
    }
}
