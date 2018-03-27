using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

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

        public decimal TotalAmount => this.Details.Sum(d => d.Quantity * d.UnitPrice);

        public void Send(string message) => Console.WriteLine(message);

        //public decimal TotalAmount
        //{
        //    get
        //    {
        //        return this.Details
        //            .Sum(bla => bla.Quantity * bla.UnitPrice);

        //       // return (from detail in this.Details
        //        //              select detail.Quantity * detail.UnitPrice).Sum();
        //    }

         
        //}

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
