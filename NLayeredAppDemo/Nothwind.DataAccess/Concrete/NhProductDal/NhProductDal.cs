using Northwind.Entities.Concrete;
using Nothwind.DataAccess.Abstract;
using System;
using System.Collections.Generic;

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

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }


        public List<Product> GetAll()
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
