using AutoMapper;
using Core.Models.Dtos.Financial;
using Core.Entities;
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
    public class ClientController : DefaultApiController<Client,ClientDto>
    {
        public ClientController(IRepository<Client> clientRepository,IMapper mapper,BaseValidator<Client> validator) : base(clientRepository, mapper, validator)
        {

        }        
    }
}
