using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using Emp_Mvc_Client.Models;

namespace Emp_Mvc_Client.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Department()
        {
            IEnumerable<Department> deptList = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44374/api/");
                var responsetask = webclient.GetAsync("Department");
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    deptList = (IEnumerable<Department>)JsonConvert.DeserializeObject<List<Department>>(resultdata);
                }
                else
                {
                    deptList = Enumerable.Empty<Department>();
                    ModelState.AddModelError(string.Empty, "Some Error Occured.. Try Later");
                }
                return View(deptList);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department addDept)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44374/api/");
                var posttask = webclient.PostAsJsonAsync<Department>("Departments", addDept);
                posttask.Wait();
                var dataresult = posttask.Result;
                if (dataresult.IsSuccessStatusCode)
                {
                    return RedirectToAction("Department");
                }
            }

            ModelState.AddModelError(string.Empty, "Some Error Occured..");
            return View(addDept);
        }

    }
}