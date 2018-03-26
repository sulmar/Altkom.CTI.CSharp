using Altkom.CTI.CSharp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Altkom.CTI.CSharp.UnitTests
{
    [TestClass]
    public class OrderUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullCustomerTest()
        {
            // Arrange
            var order = new Order(null)
            {
                OrderNumber = "ZAM 001/2018",
            };

        }

        [TestMethod]
        public void TotalAmountTest()
        {
            // Arrange

            Customer customer = new Customer("Marcin", "Sulecki");

            var order = new Order(customer)
            {
                OrderNumber = "ZAM 001/2018",
            };

            var monitor = new Product("Monitor", 200);
            var keboard = new Product("Keyboard", 199);
            var develop = new Service("Programowanie", 100);

            order.Details.Add(new OrderDetail(keboard));
            order.Details.Add(new OrderDetail(monitor, 2));
            order.Details.Add(new OrderDetail(develop, 5));

            // Acts

            var totalAmount = order.TotalAmount;

            // Assert

            Assert.AreEqual(1099, totalAmount);
            Assert.IsNotNull(order.Customer);
            Assert.IsNotNull(order.OrderNumber);
            Assert.AreEqual(3, order.Details.Count);

        }
    }
}
