using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using Emp_Mvc_client_Sp.Models;

namespace Emp_Mvc_client_Sp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        //[Route("Employee/Employee")]
        public ActionResult Employee()
        {
            IEnumerable<Employee> EmpList = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44374/api/");
                var responsetask = webclient.GetAsync("Employee");
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    EmpList = JsonConvert.DeserializeObject<List<Employee>>(resultdata);
                }
                else
                {
                    EmpList = Enumerable.Empty<Employee>();
                    ModelState.AddModelError(string.Empty, "Some Error Occured.. Try Later");
                }
                return View(EmpList);
            }
        }

        //[Route("Employee/Employee/{SearchText}")]
        //public ActionResult Employee(string SearchText)
        //{

        //    IEnumerable<Employee> EmpList = null;
        //    using (var webclient = new HttpClient())
        //    {
        //        webclient.BaseAddress = new Uri("https://localhost:44374/api/");
        //        var responsetask = webclient.GetAsync("Employee?SearchText=" + SearchText);
        //        responsetask.Wait();
        //        var result = responsetask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var resultdata = result.Content.ReadAsStringAsync().Result;
        //            EmpList = JsonConvert.DeserializeObject<List<Employee>>(resultdata);
        //        }
        //        else
        //        {
        //            EmpList = Enumerable.Empty<Employee>();
        //            ModelState.AddModelError(string.Empty, "Some Error Occured.. Try Later");
        //        }
        //        return View(EmpList);
        //    }
        //}

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee AddEmp)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44374/api/");
                var posttask = webclient.PostAsJsonAsync<Employee>("Employee", AddEmp);
                posttask.Wait();
                var dataresult = posttask.Result;
                if (dataresult.IsSuccessStatusCode)
                {
                    //ViewBag.message "Employee Added";
                    return RedirectToAction("Employee");
                }
            }

            ModelState.AddModelError(string.Empty, "Some Error Occured..");
            return View(AddEmp);
        }

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return View(new Employee());
            }

            else
            {
                HttpResponseMessage response = GlobalVariables.webclient.GetAsync("Employee/" + id).Result;
                return View(response.Content.ReadAsAsync<Employee>().Result);
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            HttpResponseMessage response = GlobalVariables.webclient.PutAsJsonAsync("Employee", employee).Result;
            TempData["SucessMessage"] = "Saved User Details";
            return RedirectToAction("Employee");
        }



        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webclient.DeleteAsync("Employee/" + id).Result;
            TempData["SucessMessage"] = "details deleted successfully";
            return RedirectToAction("Employee");
        }
    }
}