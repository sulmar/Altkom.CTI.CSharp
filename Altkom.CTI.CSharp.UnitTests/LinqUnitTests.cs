using Altkom.CTI.CSharp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Altkom.CTI.CSharp.OrderCalculators;

namespace Altkom.CTI.CSharp.UnitTests
{
    [TestClass]
    public class LinqUnitTests
    {
        [TestMethod]
        public void LinqTest()
        {
            var items = new List<Item>
            {
                new Product("Monitor", 200),
                new Product("Keyboard", 199),
                new Service("Programowanie", 100),
                new Product("Monitor", 1000),
                new Product("Keyboard", 90),
                new Service("Czyszczenie drukarki", 60)
            };

            
            var services = items
                    .OfType<Service>()
                    .Where(service => service.UnitPrice >= 100);

            foreach (var service in services)
            {
                Console.WriteLine(service);
            }

            services.ToList().ForEach(service => Console.WriteLine(service));

            var products = items.Except(services);

            var monitors = items.Where(product => product.Name == "Monitor");
            var keyboards = items.Where(product => product.Name == "Keyboard");

            var query = monitors.Concat(keyboards);




        }
    }
}
