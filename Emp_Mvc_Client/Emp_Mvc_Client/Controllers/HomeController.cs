using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emp_Mvc_Client.Models;
using System.Data.Entity;
using System.Net.Http;
using Newtonsoft.Json;

namespace Emp_Mvc_Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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

        public ActionResult Homepage()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult Employee()
        {
            return View();
        }


        public ActionResult Report()
        {
            return View();
        }

        public ActionResult Department()
        {
            return View();
        }
        public ActionResult GradeMaster1()
        {
            return View();
        }

        public ActionResult GradeMaster()
        {
            IEnumerable<Grade_Master> gradelist = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44374/api/");
                var responsetask = webclient.GetAsync("Grademaster");
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    gradelist = JsonConvert.DeserializeObject<List<Grade_Master>>(resultdata);
                }
                else
                {
                    gradelist = Enumerable.Empty<Grade_Master>();
                    ModelState.AddModelError(string.Empty, "Some Error Occured.. Try Later");
                }
                return View(gradelist);
            }
        }

        //create for gm
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        // [Authorize]
        //44335
        public ActionResult Create(Grade_Master grade)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44374/api/");
                var posttask = webclient.PostAsJsonAsync<Grade_Master>("Grademaster", grade);
                posttask.Wait();
                var dataresult = posttask.Result;
                if (dataresult.IsSuccessStatusCode)
                {
                    return RedirectToAction("GradeMaster");
                }
            }
            ModelState.AddModelError(string.Empty, "Some Error Occured..");
            return View(grade);
        }

        //grade master edit
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return View(new Grade_Master());
            }

            else
            {
                HttpResponseMessage response = GlobalVariables.webclient.GetAsync("Grademaster/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Grade_Master>().Result);
            }
        }

        [HttpPost]
        public ActionResult Edit(Grade_Master grade)
        {
            HttpResponseMessage response = GlobalVariables.webclient.PutAsJsonAsync("Grademaster", grade).Result;
            //TempData["SucessMessage"] = "Saved User Details";
            return RedirectToAction("GradeMaster");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webclient.DeleteAsync("Grademaster/" + id.ToString()).Result;
            return RedirectToAction("delete");
        }
    }

    //public ActionResult Reports()
    //{
    //    return View();
    //}
}

//public ActionResult UserMasterlogin()
//{
//    return View();
//}


