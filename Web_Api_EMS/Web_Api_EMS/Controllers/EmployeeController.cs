using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Web_Api_EMS.Models;

namespace Web_Api_EMS.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: Employee
        EMS_ProjectDBEntities2 em = new EMS_ProjectDBEntities2();

        //get
        public IEnumerable<Employee> Get()
        {
            return em.Employees.ToList();
        }


        //public IEnumerable<Employee> Get(string SearchText)
        //{
        //    return em.Employees.Where(x => x.Emp_First_Name.StartsWith(SearchText)
        //    || x.Emp_Last_Name.StartsWith(SearchText)).ToList();
        //}

        //post

        public IHttpActionResult PostNewProduct([FromBody] Employee e)
        {
            if (!ModelState.IsValid)
                return BadRequest("Validations Failed");
            em.Employees.Add(new Employee()
            {
                Emp_ID = e.Emp_ID,
                Emp_First_Name = e.Emp_First_Name,
                Emp_Last_Name = e.Emp_Last_Name,
                Emp_Date_of_Birth = e.Emp_Date_of_Birth,
                Emp_Date_of_Joining = e.Emp_Date_of_Joining,
                Dept_ID = e.Dept_ID,
                Emp_Grade = e.Emp_Grade,
                Emp_Designation = e.Emp_Designation,
                Emp_Basic = e.Emp_Basic,
                Emp_Gender = e.Emp_Gender,
                Emp_Marital_Status = e.Emp_Marital_Status,
                Emp_Home_Address = e.Emp_Home_Address,
                Emp_Contact_Num = e.Emp_Contact_Num,
            });
            em.SaveChanges();
            return Ok(e);
        }


        //Get the Particular Employee Details by Id
        public Employee Get(string id)
        {
            Employee emp = em.Employees.Find(id);
            return (emp);
        }

        //Update the Employee Details by calling Put Method
        public string Put(Employee e)
        {
            var emp = em.Employees.Find(e.Emp_ID);

            if (emp.Emp_ID == null)
            {
                return "--------No Employee id exist to update----------";
            }

            else
            {
                emp.Emp_ID = e.Emp_ID;
                emp.Emp_First_Name = e.Emp_First_Name;
                emp.Emp_Last_Name = e.Emp_Last_Name;
                emp.Emp_Date_of_Birth = e.Emp_Date_of_Birth;
                emp.Emp_Date_of_Joining = e.Emp_Date_of_Joining;
                emp.Dept_ID = e.Dept_ID;
                emp.Emp_Grade = e.Emp_Grade;
                emp.Emp_Designation = e.Emp_Designation;
                emp.Emp_Basic = e.Emp_Basic;
                emp.Emp_Gender = e.Emp_Gender;
                emp.Emp_Marital_Status = e.Emp_Marital_Status;
                emp.Emp_Home_Address = e.Emp_Home_Address;
                emp.Emp_Contact_Num = e.Emp_Contact_Num;

                em.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                em.SaveChanges();

                return ("----------Employee Details updated successfully---------");
            }
        }

        //Delete the employee by employee_Id
        public string Delete(string id)
        {
            Employee emp = em.Employees.Find(id);

            if (emp == null)
            {
                return "------No Employee exist with the Id to delete---------";
            }

            else
            {
                em.Employees.Remove(emp);
                em.SaveChanges();
                return "------Employee id Deleted-------";
            }
        }


    }
}
