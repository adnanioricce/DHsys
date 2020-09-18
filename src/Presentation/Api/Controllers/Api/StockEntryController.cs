using AutoMapper;
using Core.ApplicationModels.Dtos.Stock;
using Core.Entities.Stock;
using Core.Interfaces;
using FluentValidation;

namespace Api.Controllers.Api
{
    public class StockEntryController : DefaultApiController<StockEntry,StockEntryDto>
    {
        public StockEntryController(IRepository<StockEntry> clientRepository, IMapper mapper, IValidator<StockEntry> validator) : base(clientRepository, mapper, validator)
        {

        }
    }
}
