using Altkom.CTI.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.CTI.CSharp.IServices
{
    public interface IItemsService<TItem>
        where TItem : Base  // constraints
    {
        IList<TItem> Get();
        TItem Get(int id);
        void Add(TItem item);
        void Update(TItem item);
        void Remove(int id);
    }

    public interface IProductsService : IItemsService<Product>
    {
        IList<Product> GetByName(string name);
    }

    public interface IOrdersService : IItemsService<Order>
    {

    }

    public interface ICustomersService : IItemsService<Customer>
    {

    }

    // IItemsService<Product> products = ...

    public class MockItemsService<TItem> : IItemsService<TItem>
        where TItem : Base  // constraints
    {
        private IList<TItem> items = new List<TItem>();

        public void Add(TItem item)
        {
            items.Add(item);
        }

        public IList<TItem> Get()
        {
            return items;
        }

        public TItem Get(int id)
        {
            return items.SingleOrDefault(item => item.Id == id);
        }

        public virtual void Remove(int id)
        {
            var item = Get(id);

            items.Remove(item);
        }

        public void Update(TItem item)
        {
            throw new NotImplementedException();
        }
    }

    public class MockProductsService : IProductsService
    {
        private IList<Product> products = new List<Product>();

        public void Add(Product product)
        {
            products.Add(product);
        }

        public Product Get(int id)
        {
            return products.SingleOrDefault(p => p.Id == id);
        }

        public IList<Product> Get()
        {
            return products;
        }

        public IList<Product> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var product = Get(id);

            products.Remove(product);
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }

    public class OrdersService : MockItemsService<Order>
    {

    }

    public class CustomersService : MockItemsService<Customer>
    {
        public override void Remove(int id)
        {
            base.Remove(id);
        }
    }
}
