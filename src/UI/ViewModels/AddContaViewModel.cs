using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using UI.Models;
using Core.Interfaces;
using Core.Entities;
using Core.Validations;

namespace UI.ViewModels
{
    public class AddContaViewModel : ViewModelBase
    {
        private readonly IRepository<Billing> _contaRepository;
        public ContaModel Model { get; set; }
        public RelayCommand CreateContaCommand { get; set; }        
        //TODO: Write UI validations
        public AddContaViewModel(IRepository<Billing> contaRepository)
        {
            _contaRepository = contaRepository;
        }
        public void CreateConta(ContaModel model)
        {
            _contaRepository.Add(new Billing{
                BeneficiaryName = model.NomeEmpresa,
                EndDate = model.DataDeVencimento,
                Price = model.Valor
            });
            _contaRepository.SaveChanges();
        }
        public bool CanCreateConta(ContaModel model)
        {
            var validator = new ContaValidator();
            return validator.IsValid(new Billing
            {
                EndDate = model.DataDeVencimento,
                BeneficiaryName = model.NomeEmpresa,
                Price = model.Valor
            });
        }
    }
}
