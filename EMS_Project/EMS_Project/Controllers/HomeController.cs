using EMS_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace EMS_Project.Controllers
{
    public class HomeController : Controller
    {
        EMS_ProjectDBEntities emp = new EMS_ProjectDBEntities();
        public ActionResult Index()
        {
            //EMS_ProjectDBEntities emp = new EMS_ProjectDBEntities();
            //var employees = emp.Employees.Include(e => e.Department);
            //return View(employees.ToList());
            //var employeelist = emp.Employees.ToList();
            //return View(employeelist);
            //ViewBag.Departments = new SelectList(emp.Departments, "Dept_ID", "Dept_Name");
                return View();

        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee em)
        {
            if(ModelState.IsValid)
            {
                emp.Employees.Add(em);
                emp.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int ? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Employee em = emp.Employees.Find(id);
                if(em==null)
            {
                return HttpNotFound();
            }

            return View(em);
        }


        public ActionResult Homepage()
        {
            return View();
        }

        public ActionResult Employee()
        {
            return View();
        }

        public ActionResult Department()
        {
            return View();
        }
        public ActionResult GradeMaster()
        {
            return View();
        }

        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}