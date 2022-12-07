using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Emp_Mvc_client_Sp.Models;
using Newtonsoft.Json;

namespace Emp_Mvc_client_Sp.Controllers
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

        public ActionResult Report()
        {
            return View();
        }
        public ActionResult GradeMaster_SP()
        {
            IEnumerable<Grade_Master> gradelist = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44374/api/");
                var responsetask = webclient.GetAsync("GradeMaster");
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
                var posttask = webclient.PostAsJsonAsync<Grade_Master>("GradeMaster", grade);
                posttask.Wait();
                var dataresult = posttask.Result;
                if (dataresult.IsSuccessStatusCode)
                {
                    return RedirectToAction("GradeMaster_SP");
                }
            }
            ModelState.AddModelError(string.Empty, "Some Error Occured..");
            return View(grade);
        }


        //edit



        public ActionResult Edit(string Grade_Code)
        {
            Grade_Master grade = null;



            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44374/api/");

                var responseTask = client.GetAsync("GradeMaster=" + Grade_Code);
                responseTask.Wait();



                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Grade_Master>();
                    readTask.Wait();



                    grade = readTask.Result;
                }
            }



            return View(grade);
        }









        //delete
        public ActionResult Delete(string id)
        {
            HttpResponseMessage response = GlobalVariables.webclient.DeleteAsync("GradeMaster/" + id).Result;
            TempData["SucessMessage"] = "details deleted successfully";
            return RedirectToAction("GradeMaster_SP");
        }







       



        //public ActionResult Edit(int id)
        //{
        //    if (id == 0)
        //    {
        //        return View(new Grade_Master());
        //    }

        //    else
        //    {
        //        HttpResponseMessage response = GlobalVariables.webclient.GetAsync("GradeMaster/" + id).Result;
        //        return View(response.Content.ReadAsAsync<Grade_Master>().Result);
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(Grade_Master grade)
        //{
        //    HttpResponseMessage response = GlobalVariables.webclient.PutAsJsonAsync("GradeMaster", grade).Result;
        //    TempData["SucessMessage"] = "Saved User Details";
        //    return RedirectToAction("GradeMaster_SP");
        //}



        //public ActionResult Delete(int id)
        //{
        //    HttpResponseMessage response = GlobalVariables.webclient.DeleteAsync("GradeMaster/" + id).Result;
        //    TempData["SucessMessage"] = "details deleted successfully";
        //    return RedirectToAction("GradeMaster_SP");
        //}





        //grade master edit
        //public ActionResult Edit(int id)
        //{
        //    if (id == 0)
        //    {
        //        return View(new GradeMaster());
        //    }

        //    else
        //    {
        //        HttpResponseMessage response = GlobalVariables.webclient.GetAsync("Grademaster/" + id.ToString()).Result;
        //        return View(response.Content.ReadAsAsync<GradeMaster>().Result);
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(GradeMaster grade)
        //{
        //    HttpResponseMessage response = GlobalVariables.webclient.PutAsJsonAsync("Grademaster", grade).Result;
        //    TempData["SucessMessage"] = "Saved User Details";
        //    return RedirectToAction("GradeMaster_SP");
        //}

        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GradeMaster grade_Master = GradeMaster.Find(id);
        //    if (grade_Master == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(grade_Master);
        //}


        //public ActionResult Delete(int id)
        //{
        //    HttpResponseMessage response = GlobalVariables.webclient.DeleteAsync("Grademaster/" + id.ToString()).Result;
        //    return RedirectToAction("GradeMaster_SP");
        //}
    }










}
