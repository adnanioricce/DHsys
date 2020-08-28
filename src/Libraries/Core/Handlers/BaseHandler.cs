using Core.ApplicationModels;
using Core.Commands.Default;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers
{
    public interface IGetByIdHandler : IRequestHandler<DefaultReadRequest, IBaseResult>
    {
        
    }
}
