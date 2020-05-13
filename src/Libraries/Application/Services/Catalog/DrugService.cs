﻿using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DrugService : IDrugService
    {
        private readonly IRepository<Drug> _drugRepository;
        private readonly ILegacyDataMapper<Drug,Produto> _produtoMapper;
        public DrugService(IRepository<Drug> drugRepository,
         ILegacyDataMapper<Drug, Produto> produtoMapper)
        {
            _drugRepository = drugRepository;
            _produtoMapper = produtoMapper;
        }
        public void CreateDrug(Drug drug)
        {
            //TODO:write Drug validation
            _drugRepository.Add(drug);
            _drugRepository.SaveChanges();
        }

        public void CreateDrug(Produto produto)
        {
            var drug = _produtoMapper.MapToDomainModel(produto);
            _drugRepository.Add(drug);
            _drugRepository.SaveChanges();
        }

        public void CreateDrugs(IEnumerable<Produto> produtos)
        {
            var drugs = produtos.Select(_produtoMapper.MapToDomainModel);
            _drugRepository.AddRange(drugs);
            _drugRepository.SaveChanges();
        }

        public void CreateDrugs(IEnumerable<Drug> drugs)
        {                        
            foreach (var drug in drugs) {
                if(drug.Produto is null) {
                    drug.Produto = _produtoMapper.MapToLegacyModel(drug);
                }
            }
            _drugRepository.AddRange(drugs);
            _drugRepository.SaveChanges();
        }

        public Drug GetDrugByUniqueCode(string uniqueCode)
        {
            return _drugRepository.Query()
            .Where(d => d.UniqueCode == uniqueCode)
            .FirstOrDefault();
        }

        public Task<Drug> GetDrugByUniqueCodeAsync(string uniqueCode)
        {
            return _drugRepository.Query()
            .Where(d => d.UniqueCode == uniqueCode)
            .FirstOrDefaultAsync();
        }

        public IEnumerable<Drug> GetDrugs(int start, int end)
        {
            return _drugRepository.Query().TakeWhile(d => d.Id >= start && d.Id <= end);
        }

        public async Task<IEnumerable<Drug>> GetDrugsAsync(int start, int end)
        {
            return await _drugRepository.Query()
                .Take(start - end)
                .ToListAsync();
        }

        public IEnumerable<Drug> GetDrugsByNcm(IEnumerable<string> ncms)
        {
            return _drugRepository.Query()
            .Where(drug => ncms.Any(nc => nc == drug.Ncm));
        }

        public Drug SearchDrugByBarCode(string barCode)
        {
            return _drugRepository
                .Query()
                .Where(d => d.BarCode == barCode)                
                .FirstOrDefault();
        }

        public Task<Drug> SearchDrugByBarCodeAsync(string barCode)
        {
            return _drugRepository.Query()
                .Where(d => 
                EF.Functions.Like(d.BarCode.ToLower(), "%" + barCode.ToLower() + "%") 
                || EF.Functions.Like(d.UniqueCode, "%" + barCode.ToLower() + "%"))
                .FirstOrDefaultAsync();
        }

        public IEnumerable<Drug> SearchDrugsByName(string name)
        {
            return _drugRepository.Query().Where(d => d.DrugName.Contains(name));
        }

        public async Task<Drug> SearchDrugsByNameAsync(string name)
        {
            return await _drugRepository.Query()
                .Where(d => EF.Functions.Like(d.DrugName.ToLower(), "%" + name.ToLower() + "%"))
                .FirstOrDefaultAsync();
        }

        public void UpdateDrug(int drugId, Drug drug)
        {
            //var _drug = _drugRepository.GetBy(drugId);
            //_drug.
            throw new NotImplementedException();
        }

        public void UpdateDrugPrice(int drugId, ProductPrice newDrugPrice)
        {
            //TODO:Validate drug price
            var drug = _drugRepository.GetBy(drugId);
            drug.ProductPrices.Add(newDrugPrice);
            _drugRepository.Update(drug);
        }
    }
}