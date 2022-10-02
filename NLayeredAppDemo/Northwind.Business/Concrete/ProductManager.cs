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

        public List<Product> GetAll()
        {
            // Business codes
            
            return _productDal.GetAll();

        }
    }
}
