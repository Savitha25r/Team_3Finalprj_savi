using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Emp_Mvc_Client.Customclass;

namespace Emp_Mvc_client_Sp.Models
{
    public class Employee
    {
        [Required]
        [Display(Name = "EMP ID")]
        public string Emp_ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Emp_First_Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Emp_Last_Name { get; set; }

        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        [ValidBirthDate(ErrorMessage = "Date_Of_Birth should be between 12/01/1995 & 12/6/2005")]
        public DateTime Emp_Date_Of_Birth { get; set; }

        [Display(Name = "DOJ")]
        [DataType(DataType.Date)]
        [ValidJoiningDate(ErrorMessage = "Date_Of_Joining should be between 25/01/2010 & 25/01/2022")]
        public DateTime Emp_Date_Of_Joining { get; set; }

        [Required]
        [Display(Name = "Grade")]
        [GradeValidation(ErrorMessage = "Select Your Grade")]
        public string Emp_Grade { get; set; }

        [Required]
        [Display(Name = "Designaton")]
        [DesignationValidation(ErrorMessage = "Select Your Designation")]
        public string Emp_Designation { get; set; }

        [Required]
        [Range(12000, 70000, ErrorMessage = "Basic should be 12000 to 70000")]
        [Display(Name = "Basic")]
        public int Emp_Basic { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [GenderValidation(ErrorMessage = "Select Your Gender")]
        public string Emp_Gender { get; set; }

        [Required]
        [Display(Name = "Marital Status")]

        public string Emp_Marital_Status { get; set; }

        [Required]
        [Display(Name = "Home Address")]
        public string Emp_Home_Address { get; set; }

        [Required]
        [Display(Name = "Contact Num")]
        public string Emp_Contact_Num { get; set; }

        [Required]

        [Display(Name = "Dept ID")]
        [DeptValidation(ErrorMessage = "Select Your Department")]
        public Nullable<int> Dept_ID { get; set; }

        public virtual Department Department { get; set; }
    }
}