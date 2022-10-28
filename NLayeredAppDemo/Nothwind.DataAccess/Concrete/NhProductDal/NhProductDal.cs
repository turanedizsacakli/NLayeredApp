using Northwind.Entities.Concrete;
using Nothwind.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Nothwind.DataAccess.Concrete.NhProductDal
{
    public class NhProductDal : IProductDal
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }



        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>
            {
            new Product{
                        ProductId = 1,
                        CategoryId = 1,
                        ProductName = "Laptop",
                        QuantityPerUnit = "1 in a box",
                        UnitPrice = 3000,
                        }
            };
            return products;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
