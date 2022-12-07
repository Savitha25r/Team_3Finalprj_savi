using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Emp_Mvc_client_Sp.Customclass
{
    public class Validations1
    {
    }

    public class ValidDescription : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToString(value) == "Associate" || Convert.ToString(value) == "Senior" ||
                Convert.ToString(value) == "Exucutive" || Convert.ToString(value) == "Manager" ||
                Convert.ToString(value) == "Deputy Manager" || Convert.ToString(value) == "Vice President" ||
                Convert.ToString(value) == "CEO")
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}
