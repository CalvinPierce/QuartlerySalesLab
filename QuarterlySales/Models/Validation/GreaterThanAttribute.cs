using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models.Validation
{
    public class GreaterThanAttribute : ValidationAttribute
    {

        private object compareValue;

        public GreaterThanAttribute(object val)
        {
            compareValue = val;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int)
            {
                int intToCheck = (int)value;
                int intToCompare = (int)compareValue;

                if (intToCheck > intToCompare)
                {
                    return ValidationResult.Success;
                }
            } else if (value is double)
            {
                double doubleToCheck = (double)value;
                double doubleToCompare = (double)compareValue;

                if (doubleToCheck > doubleToCompare)
                {
                    return ValidationResult.Success;
                }
            }
            else if (value is DateTime)
            {
                DateTime dateTimeToCheck = (DateTime)value;
                DateTime dateTimeToCompare = new DateTime();
                DateTime.TryParse(compareValue.ToString(), out dateTimeToCompare);

                if (dateTimeToCheck > dateTimeToCompare)
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return ValidationResult.Success;
            }

            string msg = base.ErrorMessage ?? 
                $"{validationContext.DisplayName} must be greater than {compareValue.ToString()}.";

            return new ValidationResult(msg);
        }
    }
}
