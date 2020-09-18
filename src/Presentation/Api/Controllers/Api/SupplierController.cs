using AutoMapper;
using Core.ApplicationModels.Dtos.Stock;
using Core.Entities.Stock;
using Core.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.Api
{
    public class SupplierController : DefaultApiController<Supplier,SupplierDto>
    {
        public SupplierController(IRepository<Supplier> supplierRepository, IMapper mapper, IValidator<Supplier> validator) : base(supplierRepository, mapper, validator)
        {

        }
    }
}
