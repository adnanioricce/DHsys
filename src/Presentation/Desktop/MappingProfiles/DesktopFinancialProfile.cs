using Application.Mapping.Domain;
using Core.Entities.Financial;
using Desktop.Models.Financial;

namespace Desktop.MappingProfiles
{
    public class DesktopFinancialProfile : FinancialProfile
    {
        public DesktopFinancialProfile() : base()
        {
            CreateMap<Transaction, TransactionModel>();
            CreateMap<TransactionModel, Transaction>();
        }
    }
}
