using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Financial;
using MediatR;
using Core.Interfaces;

namespace Api.Controllers.Api
{
    public class BillingController : DefaultApiController<Billing,BillingDto>
    {        
        public BillingController(IMediator mediator,IRepository<Billing> repository) : base(mediator,repository)
        {
        }        
    }
}
