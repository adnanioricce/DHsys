using Application.Mapping.Domain;
using AutoMapper;
using Core.Entities.Financial;
using Desktop.Models.Financial;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop.MappingProfiles
{
    public class DesktopFinancialProfile : FinancialProfile
    {
        public DesktopFinancialProfile() : base()
        {
            CreateMap<Transaction, TransactionModel>();
            CreateMap<TransactionModel, Transaction>();
        }
    }
}
