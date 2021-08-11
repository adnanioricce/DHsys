using Core.Entities.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Payments
{    
    public interface IPaymentCommandFactory
    {
        IPaymentCommand CreateChargeCommand(Payment payment);
    }
}
