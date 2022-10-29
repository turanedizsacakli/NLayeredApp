using Northwind.Business.Abstract;
using Northwind.Entities.Concrete;
using Nothwind.DataAccess.Abstract;
using Nothwind.DataAccess.Concrete.EntityFramework;
using System.Collections.Generic;

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
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
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
            return _productDal.GetAll(p=>p.ProductName.ToLower().Contains(prouctName.ToLower()));     
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
