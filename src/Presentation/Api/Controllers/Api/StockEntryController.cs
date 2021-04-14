using AutoMapper;
using Core.Models.Dtos.Stock;
using Core.Entities.Stock;
using Core.Interfaces;
using Core.Validations;
using FluentValidation;

namespace Api.Controllers
{
    public class StockEntryController : DefaultApiController<StockEntry,StockEntryDto>
    {
        public StockEntryController(IRepository<StockEntry> clientRepository, IMapper mapper, BaseValidator<StockEntry> validator) : base(clientRepository, mapper, validator)
        {

        }
    }
}
