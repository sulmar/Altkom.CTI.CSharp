using Altkom.CTI.CSharp.Models;
using System;

namespace Altkom.CTI.CSharp.OrderCalculators
{

    public class FixedAmountPromotionStrategy : IPromotionStrategy
    {
        private readonly decimal limit;
        private readonly decimal discount;

        public FixedAmountPromotionStrategy(decimal limit, decimal discount)
        {
            this.limit = limit;
            this.discount = discount;
        }

        public bool CanDiscount(Order order)
        {
            return order.TotalAmount > limit;
        }

        public decimal Discount(Order order)
        {
            return order.TotalAmount - discount;
        }
    }

    public class HappyHoursPromotionStrategy : IPromotionStrategy
    {
        private readonly TimeSpan beginTime;
        private readonly TimeSpan endTime;

        private readonly decimal percentage;

        public HappyHoursPromotionStrategy(TimeSpan beginTime, TimeSpan endTime, decimal percentage)
        {
            this.beginTime = beginTime;
            this.endTime = endTime;
            this.percentage = percentage;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= beginTime
             && order.OrderDate.TimeOfDay <= endTime;
        }

        public decimal Discount(Order order)
        {
            return order.TotalAmount * percentage;
        }

        public void Test()
        {

        }
    }
}
