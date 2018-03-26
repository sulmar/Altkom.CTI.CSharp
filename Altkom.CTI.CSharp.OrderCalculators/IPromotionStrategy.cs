using Altkom.CTI.CSharp.Models;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CTI.CSharp.OrderCalculators
{
    public interface IPromotionStrategy
    {
        bool CanDiscount(Order order);
        decimal Discount(Order order);
    }
}
