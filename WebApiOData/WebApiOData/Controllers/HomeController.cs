using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace WebApiOData.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {

                var requestUri = "http://localhost:8080/api/Meetings?$filter=(Id le 7')";
                var result = client.GetAsync(requestUri).Result;
                var content = result.Content.ReadAsStringAsync().Result;

            }
            return View();
        }
    }
}
