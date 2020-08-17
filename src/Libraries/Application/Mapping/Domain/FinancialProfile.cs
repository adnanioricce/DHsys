using Core.ApplicationModels.Dtos.Catalog;
using AutoMapper;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Financial;

namespace Application.Mapping.Domain
{
    public class FinancialProfile : Profile
    {
        public FinancialProfile()
        {
            CreateMap<TransactionItem, TransactionDto>();
            CreateMap<TransactionDto, TransactionItem>();
            CreateMap<Transaction, TransactionDto>();
            CreateMap<TransactionDto,Transaction>();            
        }
    }
}
