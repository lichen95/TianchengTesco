using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TianchengTesco.UI.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexBoss()
        {
            return View();
        }
        public ActionResult Item()
        {
            return View();
        }
    }
}