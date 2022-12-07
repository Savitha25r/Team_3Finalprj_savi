using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMS_Project.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace EMS_Project.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        //action method that is to consume the web api get
        // [AllowAnonymous]
        public ActionResult Display()
        {
            IEnumerable<Employee> emplist = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44374/api/");
                var responsetask = webclient.GetAsync("Employee");
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    emplist = JsonConvert.DeserializeObject<List<Employee>>(resultdata);
                }
                else
                {
                    emplist = Enumerable.Empty<Employee>();
                    ModelState.AddModelError(string.Empty, "Some Error Occured.. Try Later");
                }
                return View(emplist);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //44302
        // [Authorize]
        public ActionResult Create(Employee emp)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44374/api/");
                var posttask = webclient.PostAsJsonAsync<Employee>("Employee", emp);
                posttask.Wait();
                var dataresult = posttask.Result;
                if (dataresult.IsSuccessStatusCode)
                {
                    return RedirectToAction("Display");
                }
            }
            ModelState.AddModelError(string.Empty, "Some Error Occured..");
            return View(emp);
        }

    }
}