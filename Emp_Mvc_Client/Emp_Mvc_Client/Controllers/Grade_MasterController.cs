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
    public class Grade_MasterController : Controller
    {
        //EMS_ProjectDBEntities db = new EMS_ProjectDBEntities();

        // GET: Grade_Master
        public ActionResult Index()
        {
            return View();
            
        }
        public ActionResult Display()
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
                    return RedirectToAction("Display");
                }
            }
            ModelState.AddModelError(string.Empty, "Some Error Occured..");
            return View(grade);
        }

        // GET: Grade_Master/Edit/5
        

        //public ActionResult Edit(int id)
        //{
        //    if (id == 0)
        //    {
        //        return View(new Grade_Master());
        //    }

        //    else
        //    {
        //        HttpResponseMessage response = GlobalVariables.webclient.GetAsync("Grademaster/" + id.ToString()).Result;
        //        return View(response.Content.ReadAsAsync<Grade_Master>().Result);
        //    }
        //}


        //[HttpPost]
        //public ActionResult Edit(Grade_Master grade)
        //{
        //    HttpResponseMessage response = GlobalVariables.webclient.PutAsJsonAsync("Grademaster", grade).Result;
        //    //TempData["SucessMessage"] = "Saved User Details";
        //    return RedirectToAction("Display");
        //}

        //public ActionResult Delete(int id)
        //{
        //    HttpResponseMessage response = GlobalVariables.webclient.DeleteAsync("Grademaster/" + id.ToString()).Result;
        //    return RedirectToAction("delete");
        //}
    }
}