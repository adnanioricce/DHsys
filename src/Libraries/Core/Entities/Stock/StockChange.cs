using Core.Entities.Catalog;
using System;

namespace Core.Entities.Stock
{
    /// <summary>
    /// Represents the stock tracking of the system, keeping track of how much is getting in and out on the stock
    /// </summary>
    public class StockChange : BaseEntity
    {
        public StockChange(){}        
        /// <summary>
        /// Get or set the type of the track operation. ie: 4 units of Product x getting in or out
        /// </summary>
        public StockChangeType Type { get; set; }
        /// <summary>
        /// Get or set the quantity of impacted products
        /// </summary>
        public int Quantity { get; set; }       

        /// <summary>
        /// Get or set the Id of the impacted product
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Get or set the reference of the impacted product
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// Get or set the Id of the impacting entity the product
        /// </summary>
        public int ImpactingEntityId { get; set; }
        /// <summary>
        /// Get or set a note text
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Creates a stock change of specified quantity for a product issued by a impacting entity
        /// </summary>
        /// <param name="product">the product to be impacted by the stock change</param>
        /// <param name="impactingId">the id of the entity that issued the change</param>
        /// <param name="quantity">the quantity applied in the operation</param>
        /// <returns></returns>
        public static StockChange CreateChange(Product product, BaseEntity impactingEntity, int quantity)
        {
            if(product is null || product?.Id == 0)
            {
                throw new InvalidOperationException("It's not possible to create a stock change for a product that don't exists. Provide a product alreadly created");
            }
            return Change(product.Id, impactingEntity.Id, quantity);
        }
        /// <summary>
        /// Create a In,Out or None change of stock for the given quantity of the specified product
        /// </summary>
        /// <param name="productId">the id of the impacted product</param>
        /// <param name="quantity">the quantity to be used on the operation</param>
        /// <returns></returns>
        protected static StockChange Change(int productId,int impactingEntityId,int quantity)
        {
            return new StockChange
            {
                ProductId = productId,
                ImpactingEntityId = impactingEntityId,
                Quantity = quantity,
                Type = quantity < 0 ? StockChangeType.Out : quantity == 0 ? StockChangeType.None : StockChangeType.In
            };
        }        

    }
    public enum StockChangeType
    {
        In,
        Out,
        None
    }
}
