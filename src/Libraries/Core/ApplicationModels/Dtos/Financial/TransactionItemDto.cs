using System;
using System.Linq;
using Core.ApplicationModels.Dtos.Catalog;
using Core.Entities.Financial;

namespace Core.ApplicationModels.Dtos.Financial
{
    public class TransactionItemDto
    {
        public string DrugUniqueCode { get; set; }

        public DrugDto Drug { get; set; }

        public int Quantity { get; set; }

        public decimal CustomerValue { get; set; }

        public decimal CostPrice { get; set; }

        public static TransactionItemDto FromModel(TransactionItem model)
        {
            return new TransactionItemDto()
            {
                DrugUniqueCode = model.DrugUniqueCode, 
                Drug = DrugDto.FromModel(model.Drug), 
                Quantity = model.Quantity, 
                CustomerValue = model.CustomerValue, 
                CostPrice = model.CostPrice, 
            }; 
        }

        public TransactionItem ToModel()
        {
            return new TransactionItem()
            {
                DrugUniqueCode = DrugUniqueCode, 
                Drug = Drug?.ToModel(), 
                Quantity = Quantity, 
                CustomerValue = CustomerValue, 
                CostPrice = CostPrice, 
            }; 
        }
    }
}