using FluentValidation;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Northwind.Business.Utilities
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {

            var result = validator.Validate( entity );
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(Convert.ToString(result.Errors));
            }
        }
    }
}
