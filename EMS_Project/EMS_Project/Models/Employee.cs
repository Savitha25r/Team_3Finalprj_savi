//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMS_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public string Emp_ID { get; set; }
        public string Emp_First_Name { get; set; }
        public string Emp_Last_Name { get; set; }
        public System.DateTime Emp_Date_of_Birth { get; set; }
        public System.DateTime Emp_Date_of_Joining { get; set; }
        public Nullable<int> Emp_Dept_ID { get; set; }
        public string Emp_Grade { get; set; }
        public string Emp_Designation { get; set; }
        public int Emp_Basic { get; set; }
        public string Emp_Gender { get; set; }
        public string Emp_Marital_Status { get; set; }
        public string Emp_Home_Address { get; set; }
        public string Emp_Contact_Num { get; set; }
    
        public virtual Department Department { get; set; }
        public object Employees { get; internal set; }
    }
}