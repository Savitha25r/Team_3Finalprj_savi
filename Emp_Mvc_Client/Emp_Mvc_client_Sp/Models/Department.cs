using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Emp_Mvc_client_Sp.Models
{
    public class Department
    {
        [Display(Name = "DEPT ID")]
        [Required(ErrorMessage = "This field is required")]
        public Nullable<int> Dept_ID { get; set; }


        [Display(Name = "DEPT NAME")]
        [Required(ErrorMessage = "This field is required")]
        public string Dept_Name { get; set; }
        public Department()
        {
            this.Employees = new HashSet<Employee>();
        }
        
        public virtual ICollection<Employee> Employees { get; set; }
    }
}