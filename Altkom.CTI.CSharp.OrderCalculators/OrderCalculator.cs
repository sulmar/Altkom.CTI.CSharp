using Altkom.CTI.CSharp.Models;
using System;

namespace Altkom.CTI.CSharp.OrderCalculators
{
    public class OrderCalculator
    {
        private readonly IPromotionStrategy strategy;

        public OrderCalculator(IPromotionStrategy strategy)
        {
            this.strategy = strategy;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (strategy.CanDiscount(order))
            {
                return strategy.Discount(order);
            }
            else
            {
                return 0;
            }

         
        }
    }
}
