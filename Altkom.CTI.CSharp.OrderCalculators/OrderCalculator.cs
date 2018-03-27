using Altkom.CTI.CSharp.Models;
using System;

namespace Altkom.CTI.CSharp.OrderCalculators
{
    public class OrderCalculator
    {
        private readonly IDiscountValidator discountValidatorStrategy;
        private readonly IDiscountCalculator discountCalculatorStrategy;

        public delegate void LogDelegate(string message);

        public LogDelegate Log;

        public OrderCalculator(IDiscountValidator discountValidator, IDiscountCalculator discountCalculator)
        {
            this.discountValidatorStrategy = discountValidator;
            this.discountCalculatorStrategy = discountCalculator;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (Log!=null)
             Log($"Calculating... {order.OrderNumber}");

            if (discountValidatorStrategy.CanDiscount(order))
            {
                if (Log!=null)
                    Log("Calculated");

                return discountCalculatorStrategy.Discount(order);
            }
            else
            {
                return 0;
            }

         
        }
    }
}
