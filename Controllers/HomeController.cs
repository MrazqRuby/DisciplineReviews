using DisciplineReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisciplineReviews.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Home(string page)
        {
            //if (page == "page0")
            //{
                HomeModel model = new HomeModel();
                model.top10courses = BusinessLogic.GetTop10Courses();
                return PartialView(page, model);
            //}
            //return PartialView(page);
        }
    }
}
