using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Interfaces;
using Core.Validations;
using DAL;
using FluentValidation;

namespace Application.Services
{
    public class BillingService : IBillingService
    {
        private readonly IRepository<Billing> _billingRepository;        
        public BillingService(IRepository<Billing> billingRepository)
        {
            _billingRepository = billingRepository;            
        }
        public void AddBilling(Billing billing)
        {                    
            var validator = new BillingValidator();
            if (validator.IsValid(billing))
            {
                _billingRepository.Add(billing);
                _billingRepository.SaveChanges();
            }
            throw new ValidationException("was not possible to save billing because it have a invalid state");
        }
        public IEnumerable<Billing> GetUnpaidBillings(int? limit = null)
        {
            return _billingRepository.Query()
            .Where(b => !b.IsPaid)
            .Take(limit is null ? 100 : limit.Value);            
        }                   
    }
}