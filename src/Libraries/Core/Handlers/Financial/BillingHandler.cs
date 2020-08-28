using AutoMapper;
using Core.ApplicationModels.Dtos.Financial;
using Core.Commands.Default;
using Core.Entities.Financial;
using Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers.Financial
{
    public class BillingHandler : IRequestHandler<DefaultReadRequest<BillingDto>,BillingDto>
    {
        protected readonly IRepository<Billing> _repository;
        protected readonly IMapper _mapper;
        public BillingHandler(IRepository<Billing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BillingDto> Handle(DefaultReadRequest<BillingDto> request, CancellationToken cancellationToken)
        {
            return _mapper.Map<BillingDto>(await _repository.GetByAsync(request.Id));
        }
    }
}
