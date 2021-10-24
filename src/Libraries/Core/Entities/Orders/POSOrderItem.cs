using System;
using Core.Entities.Catalog;
using Core.Interfaces;
using Core.Models;
using Core.Results;

namespace Core.Entities.Orders
{
    public class POSOrderItem : BaseEntity
    {
        internal POSOrderItem(){}
        protected POSOrderItem(Product product,POSOrder posOrder,int quantity)
        {
            ProductUniqueCode = product.UniqueCode;
            CustomerValue = product.EndCustomerPrice;
            CostPrice = product.CostPrice;
            POSOrderId = posOrder.Id;
            Quantity = quantity;
        }
        protected POSOrderItem(string productUniqueCode,int quantity,POSOrderItem item)
        {
            ProductUniqueCode = productUniqueCode;            
            CustomerValue = item.CustomerValue;
            CostPrice = item.CostPrice;
            POSOrderId = item.POSOrderId;
            Quantity = quantity;
        }
        public string ProductUniqueCode { get; protected set; }
        public virtual Product Product { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal CustomerValue { get; protected set; }
        public decimal CostPrice { get; protected set; }
        public decimal Total { get {return Quantity * CustomerValue;} }
        public int POSOrderId { get; protected set; }        

        public virtual POSOrder POSOrder { get; protected set; }
        public virtual POSOrderItem Sum(POSOrderItem rhs)
        {
            if(this.ProductUniqueCode != rhs.ProductUniqueCode){
                return rhs;
            }
            var item = new POSOrderItem(this.ProductUniqueCode,this.Quantity + rhs.Quantity,this);
            return item;
        }
        public static Result<POSOrderItem> Create(int productId, int quantity,POSOrder posOrder, IRepository<Product> productRepository)
        {            
            var product = productRepository.GetBy(productId);
            if(product.QuantityInStock == 0){
                return Result<POSOrderItem>.Fail(default,new Error[] {
                    new Error("ProductOutOfStock",$"can't create item.Product of id {product.Id} is out of stock",true)});
            }
            if((product.QuantityInStock - quantity) < 0){                
                return Result<POSOrderItem>.Ok(new POSOrderItem(product,posOrder,product.QuantityInStock));
            }
            var item = new POSOrderItem(product,posOrder,quantity);
            return Result<POSOrderItem>.Ok(item);
        }
        
    }
}