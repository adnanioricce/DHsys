using AutoMapper;
using Core.Models.Dtos.Financial;
using Core.Entities.Stock;
using Core.Interfaces;
using Core.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]    
    public class ManufacturerController : DefaultApiController<Manufacturer,ManufacturerDto>
    {
        public ManufacturerController(IRepository<Manufacturer> manufacturerRepository, IMapper mapper, BaseValidator<Manufacturer> validator) : base(manufacturerRepository, mapper, validator)
        {
        }
    }
}
