using Altkom.CTI.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CTI.CSharp.OrderCalculators
{
    public interface IPromotionStrategy : IDiscountValidator,  IDiscountCalculator
    {
      
    }

    public interface IDiscountValidator
    {
        bool CanDiscount(Order order);
    }

    public interface IDiscountCalculator
    {
        decimal Discount(Order order);
    }

    public class HappyHoursDiscountValidator : IDiscountValidator
    {
        private readonly TimeSpan beginTime;
        private readonly TimeSpan endTime;

        public HappyHoursDiscountValidator(TimeSpan beginTime, TimeSpan endTime)
        {
            this.beginTime = beginTime;
            this.endTime = endTime;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= beginTime
                       && order.OrderDate.TimeOfDay <= endTime;
        }
    }


}
