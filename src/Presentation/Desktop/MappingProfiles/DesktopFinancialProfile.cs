using Application.Mapping.Domain;
using AutoMapper;
using Core.Entities.Financial;
using Desktop.Models.POS;

namespace Desktop.MappingProfiles
{
    public class DesktopFinancialProfile : Profile
    {
        public DesktopFinancialProfile()
        {
            CreateMap<Transaction, TransactionModel>();
            CreateMap<TransactionModel, Transaction>();
        }
    }
}
