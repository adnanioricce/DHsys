using AutoMapper;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Stock;
using Core.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.Api
{
    [Route("api/[Controller]")]
    [ApiController]    
    public class ManufacturerBeneficiaryController : DefaultApiController<Manufacturer,ManufacturerDto>
    {
        public ManufacturerBeneficiaryController(IRepository<Manufacturer> manufacturerRepository, IMapper mapper, IValidator<Manufacturer> validator) : base(manufacturerRepository, mapper, validator)
        {
        }
    }
}
