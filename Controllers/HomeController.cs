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

        public ActionResult Index(){
            return View();
        }

        public ActionResult _Home(string page)
        {
                HomeModel model = new HomeModel();
                //model.top10courses = BusinessLogic.GetTop10Courses();
                return PartialView(page, model);
        }

        public ActionResult _Courses()
        {
            //List<List<CourseOverview>> model = new List<List<CourseOverview>>();
            //List<CourseOverview> somecourses = BusinessLogic.GetTop10Courses();
            //List<CourseOverview> somemorecourses = BusinessLogic.GetTop10Courses();
            //model.Add(somecourses);
            //model.Add(somemorecourses);
            var model = BusinessLogic.GetAllCourses();
            return PartialView("_Courses", model);
        }

        public ActionResult _SingleCourse(Cours model)
        {
            return PartialView("_SingleCourse", model);
        }

        public ActionResult _SelectCoursesBy()
        {
            return PartialView();
        }
    }
}
