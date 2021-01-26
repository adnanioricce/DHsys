using System;

namespace Core.Entities.Financial
{
    public class Tax : BaseEntity
    {
        protected Tax(){}
        public Tax(int id)
        {
            Id = id;
        }
        public Tax(string name,decimal percentage)
        {
            Name = name;
            Percentage = Math.Abs(percentage) > 0 && Math.Abs(percentage) < 1 ? percentage * 100 : percentage;
        }        
        public string Name { get; protected set; }
        /// <summary>
        /// Get the percentage in decimal form
        /// </summary>
        public decimal Percentage { get; protected set; }
    }
}
