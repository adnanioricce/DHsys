using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Entities;
using Core.Entities.Financial;
using Core.Entities.Inventory;
using Core.Interfaces;
using Core.Models;
using Core.Validations;
using FluentValidation;

namespace Application.Services
{
    public class BillingService : IBillingService
    {
        private readonly IRepository<Billing> _billingRepository;
        private readonly IRepository<Beneficiary> _beneficiaryRepository;        
        public BillingService(IRepository<Billing> billingRepository,
            IRepository<Beneficiary> beneficiaryRepository)
        {
            _billingRepository = billingRepository;
            _beneficiaryRepository = beneficiaryRepository;
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
            if(!HasBeneficiary(billing.BeneficiaryId,billing.BeneficiaryName))
            {
                return BaseResult<Billing>.Failed(new string[] { "no beneficiary was provided with the billing" }, billing);                
            }            
            if(billing.BeneficiaryId == 0){

                var beneficiaryByName = GetBeneficiaryByName(billing.BeneficiaryName);
                billing.BeneficiaryId = beneficiaryByName.Id;                
            }
            else
            {
                var beneficiaryById = _beneficiaryRepository.GetBy(billing.BeneficiaryId);
                billing.BeneficiaryName = beneficiaryById.Name;
            }
            
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
        /// <summary>
        /// Return all 100 billings with the given beneficiary name
        /// </summary>
        /// <param name="beneficiaryName"></param>
        /// <returns></returns>
        public IEnumerable<Billing> GetBillingsByBeneficiaryName(string beneficiaryName)
        {
            return _billingRepository.Query()
                                     .Where(b => b.BeneficiaryName.Contains(beneficiaryName));
        }
        private Beneficiary GetBeneficiaryByName(string name)
        {            
            return _beneficiaryRepository.Query()
                .Where(m => m.Name == name)
                .FirstOrDefault();                        
        }        
        private bool HasBeneficiary(int beneficiaryId,string beneficiaryName)
        {
            if (string.IsNullOrEmpty(beneficiaryName) && beneficiaryId == 0) return false;
            if (beneficiaryId > 0)
            {
                var billingById = _beneficiaryRepository.GetBy(beneficiaryId);
                return !(billingById is null);
            }
            var billingByName = _beneficiaryRepository.Query()
                                                  .Where(b => string.Compare(beneficiaryName, b.Name) <= 4 
                                                  && string.Compare(beneficiaryName, b.Name) >= 0)
                                                  .FirstOrDefault();
            return !(billingByName is null);
        }

        public BaseResult<IEnumerable<Billing>> AddBillingsFromFile(string csvFilePath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Billing> GetBillings(int? limit)
        {
            throw new NotImplementedException();
        }
    }
}