using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Financial;

namespace Core.ApplicationModels.Dtos.Financial
{
    public class TransactionDto
    {        
        public decimal TransactionTotal { get; set; }

        public PaymentMethods PaymentMethod { get; set; }

        public bool HasDealWithStore { get; set; }

        public IList<TransactionItemDto> Items { get; set; }

        public static TransactionDto FromModel(Transaction model)
        {
            return new TransactionDto()
            {
                TransactionTotal = model.TransactionTotal, 
                PaymentMethod = model.PaymentMethod, 
                HasDealWithStore = model.HasDealWithStore, 
                Items = model.Items.Select(it =>TransactionItemDto.FromModel(it)).ToList() 
            }; 
        }

        public Transaction ToModel()
        {
            return new Transaction()
            {
                TransactionTotal = TransactionTotal, 
                PaymentMethod = PaymentMethod, 
                HasDealWithStore = HasDealWithStore, 
                Items = Items.Select(it => it.ToModel()).ToList(), 
            }; 
        }
    }
}