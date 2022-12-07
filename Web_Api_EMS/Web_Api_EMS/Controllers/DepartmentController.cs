using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api_EMS.Models;

namespace Web_Api_EMS.Controllers
{

    public class DepartmentController : ApiController
    {
        EMS_ProjectDBEntities2 em = new EMS_ProjectDBEntities2();

        //get
        public IEnumerable<Department> Get()
        {
            return em.Departments.ToList();
        }

        //Post
        public IHttpActionResult PostNewProduct([FromBody] Department d)
        {
            if (!ModelState.IsValid)
                return BadRequest("--------Validations Failed--------");
            em.Departments.Add(new Department()
            {
                Dept_ID = d.Dept_ID,
                Dept_Name = d.Dept_Name,

            });
            em.SaveChanges();
            return Ok(d);
        }

        //Get the Particular Department Details by Id
        public Department Get(int id)
        {
            Department dept = em.Departments.Find(id);
            return (dept);
        }

        //Update the department Details by calling Put Method
        public string Put(Department d)
        {
            var dept = em.Departments.Find(d.Dept_ID);

            if (dept == null)
            {
                return "------No Department id exist to update---------";
            }
            else
            {
                dept.Dept_ID = d.Dept_ID;
                dept.Dept_Name = d.Dept_Name;
            }
            em.Entry(dept).State = System.Data.Entity.EntityState.Modified;
            em.SaveChanges();

            return ("----------Department Details updated successfully---------");
        }

        //Delete the Department by department_Id
        public string Delete(int id)
        {
            Department dept = em.Departments.Find(id);

            if (dept == null)
            {
                return "--------No Department exist with the Id to delete-------";
            }

            else
            {
                em.Departments.Remove(dept);
                em.SaveChanges();
                return "--------Department id Deleted---------";
            }
        }
    }
}
