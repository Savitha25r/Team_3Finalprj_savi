using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emp_MVC_UserLogin.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Emp_MVC_UserLogin.Controllers
{
    public class MVC_UserMasterController : Controller
    {
        // GET: MVC_UserMaster
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display()
        {
            IEnumerable<MVC_UserMaster_Model> userList = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44374/api/");
                var responsetask = webclient.GetAsync("api_UserMaster");
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    userList = JsonConvert.DeserializeObject<List<MVC_UserMaster_Model>>(resultdata);
                }
                else
                {
                    userList = Enumerable.Empty<MVC_UserMaster_Model>();
                    ModelState.AddModelError(string.Empty, "Some Error Occured.. Try Later");
                }
                return View(userList);
            }
        }







        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MVC_UserMaster_Model addUser)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44374/api/");
                var posttask = webclient.PostAsJsonAsync<MVC_UserMaster_Model>("api_UserMaster", addUser);
                posttask.Wait();
                var dataresult = posttask.Result;
                if (dataresult.IsSuccessStatusCode)
                {
                    //ViewBag.message "User Added";
                    return RedirectToAction("Display");
                }
            }

            ModelState.AddModelError(string.Empty, "Some Error Occured..");
            return View(addUser);
        }
    }
}