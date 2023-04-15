using ReviewFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewFood.Controllers
{

    public class HomeController : Controller
    {
        dbReviewFoodDataContext db = new dbReviewFoodDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            var all_key = from r in db.Posts select r;
            return View(all_key);
        }
    }
}