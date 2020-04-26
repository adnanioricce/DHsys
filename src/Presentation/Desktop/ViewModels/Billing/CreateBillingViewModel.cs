using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Desktop.Models;
using Core.Interfaces;
using Core.Entities;
using Core.Validations;
using System;

namespace Desktop.ViewModels.Billings
{
    public class CreateBillingViewModel : ViewModelBase
    {
        private readonly IRepository<Billing> _contaRepository;
        public ContaModel Model { get; set; }
        public RelayCommand CreateContaCommand { get; set; }        
        //TODO: Write UI validations
        public CreateBillingViewModel(IRepository<Billing> contaRepository)
        {
            _contaRepository = contaRepository;
        }
        public void CreateConta(ContaModel model)
        {
            _contaRepository.Add(new Billing{
                BeneficiaryName = model.NomeEmpresa,
                EndDate = DateTime.TryParse(model.DataDeVencimento,out var result) ? result : DateTime.UtcNow,
                Price = model.Valor
            });
            _contaRepository.SaveChanges();
        }
        public bool CanCreateConta(ContaModel model)
        {
            var validator = new BillingValidator();
            return validator.IsValid(new Billing
            {
                EndDate = DateTime.Parse(model.DataDeVencimento),
                BeneficiaryName = model.NomeEmpresa,
                Price = model.Valor
            });
        }
    }
}
