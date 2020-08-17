using Core.Entities.Financial;
using MediatR;

namespace Api.Controllers.Api
{
    public class BillingController : DefaultApiController<Billing>
    {        
        public BillingController(IMediator mediator) : base(mediator)
        {
        }
    }
}
