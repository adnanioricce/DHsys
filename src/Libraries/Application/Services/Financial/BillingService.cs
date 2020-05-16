using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
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
        /// <summary>
        /// Inserts a valid billing in the database
        /// </summary>
        /// <param name="billing">The billing object to be inserted.</param>
        public BaseResult<Billing> AddBilling(Billing billing)
        {                    
            var validator = new BillingValidator();
            var validationResult = validator.IsValid(billing);
            if (!validationResult.Success) return validationResult;            
            _billingRepository.Add(billing);
            _billingRepository.SaveChanges();
            return validationResult;            
        }
        /// <summary>
        /// Return the last 100 unpaid billings if no limit is specified, otherwise it take the last unpaid billing on the given limit
        /// </summary>
        /// <param name="limit">The limit of unpaid billings to return</param>
        /// <returns>a collection of <see cref="Core.Entities.Billing"/> Entity objects with the IsPaid property equal false</returns>
        public IEnumerable<Billing> GetUnpaidBillings(int? limit = null)
        {
            return _billingRepository.Query()
            .Where(b => !b.IsPaid)
            .Take(limit is null ? 100 : limit.Value);            
        }                   
    }
}