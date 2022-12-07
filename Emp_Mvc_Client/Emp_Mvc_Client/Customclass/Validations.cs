using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Emp_Mvc_Client.Customclass
{
    public class Validations
    {

    }

    public sealed class ValidBirthDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime entered_dob = Convert.ToDateTime(value);
            DateTime mindt = Convert.ToDateTime("25/01/1995");
            DateTime maxdt = Convert.ToDateTime("25/01/2020");
            if (entered_dob >= mindt && entered_dob <= maxdt)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }

    public sealed class ValidJoiningDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime entered_dob = Convert.ToDateTime(value);
            DateTime mindt = Convert.ToDateTime("25/01/2010");
            DateTime maxdt = Convert.ToDateTime("25/12/2022");
            if (entered_dob >= mindt && entered_dob <= maxdt)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
    public class GradeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToString(value) == "m1" || Convert.ToString(value) == "m2" ||
                Convert.ToString(value) == "m3" || Convert.ToString(value) == "m4" ||
                Convert.ToString(value) == "m5" || Convert.ToString(value) == "m6" ||
                Convert.ToString(value) == "m7")
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }

    public class DesignationValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToString(value) == "a" || Convert.ToString(value) == "s" ||
                Convert.ToString(value) == "e" || Convert.ToString(value) == "e" ||
                Convert.ToString(value) == "m" || Convert.ToString(value) == "d" ||
                Convert.ToString(value) == "v" || Convert.ToString(value) == "c")
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
    public class GenderValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToString(value) == "M" || Convert.ToString(value) == "F" || Convert.ToString(value) == "O")
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}