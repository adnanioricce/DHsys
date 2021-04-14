using AutoMapper;
using Core.Models.Dtos.Stock;
using Core.Entities.Stock;
using Core.Interfaces;
using Core.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class SupplierController : DefaultApiController<Supplier,SupplierDto>
    {
        public SupplierController(IRepository<Supplier> supplierRepository, IMapper mapper, BaseValidator<Supplier> validator) : base(supplierRepository, mapper, validator)
        {

        }
    }
}
