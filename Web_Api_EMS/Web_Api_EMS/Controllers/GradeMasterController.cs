using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api_EMS.Models;

namespace Web_Api_EMS.Controllers
{
    public class GradeMasterController : ApiController
    {
        EMS_ProjectDBEntities2 db = new EMS_ProjectDBEntities2();
        //get
        //        public IEnumerable<Grade_Master> Get()
        //        {
        //            return em.Grade_Master.ToList();
        //        }

        //        //Post
        //        public IHttpActionResult PostNewProduct([FromBody] Grade_Master g)
        //        {
        //            if (!ModelState.IsValid)
        //                return BadRequest("-----Validations Failed-------");
        //            em.Grade_Master.Add(new Grade_Master()
        //            {
        //                Grade_Code=g.Grade_Code,
        //                Description=g.Description,
        //                Min_Salary=g.Min_Salary,
        //                Max_salary=g.Max_salary,

        //            });
        //            em.SaveChanges();
        //            return Ok(g);
        //        }

        //        //Get the Particular Grademaster Details by code
        //        public Grade_Master Get(string id)
        //        {
        //            Grade_Master grade = em.Grade_Master.Find(id);
        //            return (grade);
        //        }

        //        //Update the Grade Master Details by calling Put Method
        //        public string Put(Grade_Master g)
        //        {
        //            var grade = em.Grade_Master.Find(g.Grade_Code);

        //            if (grade == null)
        //            {
        //                return "------No grade code id exist to update-------";
        //            }
        //            else
        //            {
        //                grade.Grade_Code = g.Grade_Code;
        //                grade.Description = g.Description;
        //                grade.Min_Salary = g.Min_Salary;
        //                grade.Max_salary = g.Max_salary;
        //            }
        //            em.Entry(grade).State = System.Data.Entity.EntityState.Modified;
        //            em.SaveChanges();

        //            return ("----------Grade master Details updated successfully---------");
        //        }

        //        //Delete the Grademaster  by gradecode
        //        public string Delete(string id)
        //        {
        //            Grade_Master grade = em.Grade_Master.Find(id);

        //            if (grade == null)
        //            {
        //                return "-----No grade exist with the Id to delete---------";
        //            }

        //            else
        //            {
        //                em.Grade_Master.Remove(grade);
        //                em.SaveChanges();
        //                return "---------Grade master code id Deleted-------";
        //            }
        //        }

        //    }
        //}


        public IEnumerable<Grade_Master> Get()
        {
            return db.Grade_Master.ToList();
        }
        public IHttpActionResult PostNewGradeMaster([FromBody] Grade_Master g)
        {
            if (!ModelState.IsValid)
                return BadRequest("Validations Failed");
            db.Grade_Master.Add(new Grade_Master()
            {
                Grade_Code = g.Grade_Code,
                Description = g.Description,
                Min_Salary = g.Min_Salary,
                Max_salary = g.Max_salary
            });
            db.SaveChanges();
            return Ok(g);
        }
        public Grade_Master Get(int id)
        {
            Grade_Master grade = db.Grade_Master.Find(id.ToString());
            return (grade);
        }
        public string Put(Grade_Master g)
        {
            var grade = db.Grade_Master.Find(g.Grade_Code);



            if (grade.Grade_Code == null)
            {
                return "No  exist with the Id to update";
            }



            else
            {
                grade.Grade_Code = g.Grade_Code;
                grade.Description = g.Description;
                grade.Min_Salary = g.Min_Salary;
                grade.Max_salary = g.Max_salary;


                db.Entry(grade).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();



                return ("User Details updated successfully");
            }





        }
        public string Delete(string id)
        {
            Grade_Master grade = db.Grade_Master.Find(id);
            if (grade == null)
            {
                return "No Employee exist with the Id to delete";
            }



            else
            {
                db.Grade_Master.Remove(grade);
                db.SaveChanges();
                return "User Deleted";
            }
        }
    }
}