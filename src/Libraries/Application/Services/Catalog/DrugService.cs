using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DrugService : IDrugService
    {
        private readonly IRepository<Drug> _drugRepository;
        private readonly ILegacyDataMapper<Drug,Produto> _produtoMapper;
        public DrugService(IRepository<Drug> drugRepository, ILegacyDataMapper<Drug, Produto> produtoMapper)
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
            throw new System.NotImplementedException();
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
                .Where(d => EF.Functions.Like(d.BarCode.ToLower(), "%" + barCode.ToLower() + "%") 
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

        public void UpdateDrugPrice(int drugId, DrugPrice newDrugPrice)
        {
            //TODO:Validate drug price
            var drug = _drugRepository.GetBy(drugId);
            drug.Drugprices.Add(newDrugPrice);
            _drugRepository.Update(drug);
        }
    }
}
