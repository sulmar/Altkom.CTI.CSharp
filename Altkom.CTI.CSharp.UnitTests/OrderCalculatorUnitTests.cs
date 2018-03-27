using Altkom.CTI.CSharp.Models;
using Altkom.CTI.CSharp.OrderCalculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Altkom.CTI.CSharp.UnitTests
{
    [TestClass]
    public class OrderCalculatorUnitTests
    {
        [TestMethod]
        public void IsWeekendTest()
        {
            DateTime date = DateTime.Parse("2018-03-27");

            // var result = DateTimeHelper.IsWeekend(date);

            var result = date.IsWeekend();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HappyHoursTest()
        {
            // Arrange

            Customer customer = new Customer("Marcin", "Sulecki");

            var order = new Order(customer)
            {
                OrderNumber = "ZAM 001/2018",
                OrderDate = DateTime.Parse("2018-03-26 15:00")
            };

            var monitor = new Product("Monitor", 200);
            var keboard = new Product("Keyboard", 199);
            var develop = new Service("Programowanie", 100);

            order.Details.Add(new OrderDetail(keboard));
            order.Details.Add(new OrderDetail(monitor, 2));
            order.Details.Add(new OrderDetail(develop, 5));

            //IPromotionStrategy strategy = new HappyHoursPromotionStrategy(
            //    TimeSpan.FromHours(9), 
            //    TimeSpan.FromHours(16), 
            //    0.1m);

            IDiscountValidator discountValidator = new HappyHoursDiscountValidator(
                TimeSpan.FromHours(9),
                TimeSpan.FromHours(16));

            IDiscountCalculator discountCalculator = new PercentageDiscountCalculator(0.1m);

            var calculator = new OrderCalculator(discountValidator, discountCalculator);
            calculator.Log += LogToConsole;
            calculator.Log += LogToTrace;

            calculator.Log += Console.WriteLine;

            // metoda anonimowa
            calculator.Log += delegate (string message)
            {
                Console.WriteLine(message);
            };


            calculator.Log += message => Console.WriteLine(message);

            calculator.Log -= LogToConsole;

            var listeners = calculator.Log.GetInvocationList().ToList();

            calculator.Log = null;


            // Acts

            var totalAmount = order.TotalAmount;

            var discountAmount = calculator.CalculateDiscount(order);

            // Assert

            Assert.AreEqual(1099, totalAmount);
            Assert.AreEqual(109.9m, discountAmount);

            Assert.IsNotNull(order.Customer);
            Assert.IsNotNull(order.OrderNumber);
            Assert.AreEqual(3, order.Details.Count);
        }

        private string textBox;

        public void LogToConsole(string message)
        {
            textBox = message;
        }

        public void LogToTrace(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
