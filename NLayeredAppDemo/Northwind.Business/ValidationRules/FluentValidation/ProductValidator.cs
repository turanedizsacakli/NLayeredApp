using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("you have to write a product name...");
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.CategoryId ).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(p => p.UnitPrice).LessThan(0);

            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p=>p.CategoryId==2);

            //RuleFor(p => p.ProductName).Must(StartWithNew);

        }

        //private bool StartWithNew(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
