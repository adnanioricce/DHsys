using Core.ApplicationModels.Dtos.Financial;
using Core.Commands.Default;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands.Financial
{
    public class GetBillingByIdRequest : DefaultReadRequest<BillingDto>
    {
    }
}