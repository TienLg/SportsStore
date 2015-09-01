using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        IDiscountHelper discounter;
        private static int counter = 0;

        public LinqValueCalculator(IDiscountHelper discounterParam)
        {
            discounter = discounterParam;
            System.Diagnostics.Debug.WriteLine(
                string.Format("Instance {0} created", ++counter));
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}