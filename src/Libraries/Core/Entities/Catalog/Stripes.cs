using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Catalog
{
    public enum Stripes
    {
        NoStripe,
        OTC,
        Yellow,
        Red,
        Black
    }
    public static class StripeFactory
    {
        /// <summary>
        /// Convert a valid string to a Stripe enum
        /// </summary>
        /// <returns>a <see cref="Stripes"/></returns>
        public static Stripes FromString(string stripeString)
        {
            return (stripeString.ToLower()) switch
            {
                "otc" => Stripes.OTC,
                "yellow" => Stripes.Yellow,
                "red" => Stripes.Red,
                "black" => Stripes.Black,
                _ => Stripes.NoStripe,
            };            
        }
    }
}
