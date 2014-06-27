using OdeToFood.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    //[LogAttribute]
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string name="french")
        {
            var message = Server.HtmlEncode(name);

            return Content(message);
        }

    }
}
