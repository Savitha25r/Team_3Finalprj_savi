using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Emp_Mvc_client_Sp.Customclass;

namespace Emp_Mvc_client_Sp.Models
{
    public class Grade_Master
    {
        [Required]
        [Display(Name = "Gradecode")]
        public string Grade_Code { get; set; }
        [Required]

        [Display(Name = "Description")]
        [ValidDescription(ErrorMessage = "Select ur Description")]
        public string Description { get; set; }

        [Display(Name = "minsalary")]

        [Range(12000, 70000, ErrorMessage = "Minsalary should be 12000 to 70000")]
        public long Min_Salary { get; set; }
        [Required]
        [Display(Name = "maxsalary")]
        [Range(15000, 75000, ErrorMessage = "Maxsalary should be 15000 to 75000")]
        public long Max_salary { get; set; }

    }
}