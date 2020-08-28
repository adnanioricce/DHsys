using Core.Models.ApplicationResources;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Financial;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Core.Commands.Financial;
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
