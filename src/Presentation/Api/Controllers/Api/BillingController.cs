using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Financial;
using Core.Interfaces;
using AutoMapper;
using Core.Validations;

namespace Api.Controllers.Api
{
    public class BillingController : DefaultApiController<Billing,BillingDto>
    {        
        public BillingController(IRepository<Billing> repository,IMapper mapper,BaseValidator<Billing> validator) : base(repository,mapper,validator)
        {
        }        
    }
}
