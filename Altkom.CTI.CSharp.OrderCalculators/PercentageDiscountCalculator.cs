using Altkom.CTI.CSharp.Models;

namespace Altkom.CTI.CSharp.OrderCalculators
{
    public class PercentageDiscountCalculator : IDiscountCalculator
    {
        private readonly decimal percentage;

        public PercentageDiscountCalculator(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal Discount(Order order)
        {
            return order.TotalAmount * percentage;
        }
    }


}
