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
                var posttask = webclient.PostAsJsonAsync<Department>("Department", addDept);
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

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return View(new Department());
            }

            else
            {
                HttpResponseMessage response = GlobalVariables.webclient.GetAsync("Department/" + id).Result;
                return View(response.Content.ReadAsAsync<Department>().Result);
            }
        }

        [HttpPost]
        public ActionResult Edit(Department user)
        {
            HttpResponseMessage response = GlobalVariables.webclient.PutAsJsonAsync("Department", user).Result;
            return RedirectToAction("Display");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                HttpResponseMessage response = GlobalVariables.webclient.DeleteAsync("Department/" + id.ToString()).Result;
                return RedirectToAction("Department");
            }
            catch
            {
                return View();
            }
        }

    }
}