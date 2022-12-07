using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Emp_Mvc_Client.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Emp_Mvc_Client.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }



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

    }
}