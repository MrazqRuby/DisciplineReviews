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

        public ActionResult _Courses()
        {
            List<List<CourseOverview>> model = new List<List<CourseOverview>>();
            List<CourseOverview> somecourses = BusinessLogic.GetTop10Courses();
            List<CourseOverview> somemorecourses = BusinessLogic.GetTop10Courses();
            model.Add(somecourses);
            model.Add(somemorecourses);
            return PartialView("_Courses", model);
        }

        public ActionResult _SingleCourse(CourseOverview model)
        {
            return PartialView("_SingleCourse", model);
        }
    }
}
