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
        public ContaModel Model { get; set; }
        public RelayCommand CreateContaCommand { get; set; }
        private readonly IBillingService _billingService;
        //TODO: Write UI validations
        public CreateBillingViewModel(IBillingService billingService)
        {
            _billingService = billingService;            
        }
        public void CreateConta(ContaModel model)
        {                
            _billingService.AddBilling(new Billing
            {
                BeneficiaryName = model.NomeEmpresa,
                EndDate = DateTime.TryParse(model.DataDeVencimento, out var result) ? result : DateTime.UtcNow,
                Price = model.Valor
            });            
        }
        public bool CanCreateConta(ContaModel model)
        {
            var validator = new BillingValidator();
            var result = validator.IsValid(new Billing
            {
                EndDate = DateTime.Parse(model.DataDeVencimento),
                BeneficiaryName = model.NomeEmpresa,
                Price = model.Valor
            });
            //TODO:Log errors
            return result.Success;
        }

    }
}
