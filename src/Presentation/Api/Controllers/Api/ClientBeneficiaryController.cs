﻿using AutoMapper;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities;
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
    public class ClientBeneficiaryController : DefaultApiController<Client,ClientDto>
    {
        public ClientBeneficiaryController(IRepository<Client> clientRepository,IMapper mapper,IValidator<Client> validator) : base(clientRepository, mapper, validator)
        {

        }        
    }
}
