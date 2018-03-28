using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Altkom.CTI.CSharp.Models
{
    public partial class Order : Base
    {
        public string OrderNumber { get; set; }

        partial void OnOrderDateValidating(DateTime dateTime);

        private DateTime orderDate;
        public DateTime OrderDate
        {
            get { return this.orderDate; }
            set
            {
                // walidacja przed
                OnOrderDateValidating(value);

                //if (value < DateTime.Today)
                //{
                //    throw new ArgumentOutOfRangeException();
                //}

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


        partial void OnDiscountAmountValidating(decimal amount);

        private decimal discountAmount;
        public decimal DiscountAmount
        {
            get
            {
                return discountAmount;
            }
            set
            {
                OnDiscountAmountValidating(value);

                discountAmount = value;
            }
        }

        public OrderStatus Status { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();

        public Order(Customer customer)
        {
            OrderDate = DateTime.Now;
            Status = OrderStatus.Registered;
            this.Customer = customer ?? throw new ArgumentNullException(nameof(customer));


            // 

        }

    }
}
