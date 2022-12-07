using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Emp_Mvc_Client.Models
{
    public class Grade_Master
    {
        [Required(ErrorMessage = "This field is required")]
        public string Grade_Code { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Min_Salary { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Max_salary { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}