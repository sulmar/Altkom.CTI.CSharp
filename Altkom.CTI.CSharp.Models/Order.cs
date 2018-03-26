using System;
using System.Collections.Generic;
using System.Threading;

namespace Altkom.CTI.CSharp.Models
{
    public class Order : Base
    {
        public string OrderNumber { get; set; }

        private DateTime orderDate;
        public DateTime OrderDate
        {
            get { return this.orderDate; }
            set
            {
                this.orderDate = value;
                this.DueDate = OrderDate.AddDays(14);
            }
        }

        public DateTime DueDate { get; private set; }

        public decimal TotalAmount
        {
            get
            {
                decimal totalAmount = 0;

                foreach (var item in this.Details)
                {
                    totalAmount += item.UnitPrice * item.Quantity;
                }

                return totalAmount;
            }
        }

        public decimal DiscountAmount { get; set; }

        public OrderStatus Status { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();

        public Order(Customer customer)
        {
            OrderDate = DateTime.Now;
            Status = OrderStatus.Registered;

            

            this.Customer = customer ?? throw new ArgumentNullException(nameof(customer));

        }

    }
}
