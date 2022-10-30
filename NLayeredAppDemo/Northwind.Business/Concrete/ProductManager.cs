using Northwind.Business.Abstract;
using Northwind.Business.Utilities;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.Entities.Concrete;
using Nothwind.DataAccess.Abstract;
using Nothwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        //EfProductDal _productDal = new EfProductDal();

        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(),product);
            _productDal.Add(product);

        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
            }
            catch
            {

                throw new Exception("exception about update...");
            }

        }

        public List<Product> GetAll()
        {
            // Business codes

            return _productDal.GetAll();

        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);

        }

        public List<Product> GetProductsByProductName(string prouctName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(prouctName.ToLower()));
        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);

            _productDal.Update(product);
        }
    }
}
