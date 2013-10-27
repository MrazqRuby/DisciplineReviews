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

        [HttpPost]
        public ActionResult Search(FormCollection form)
        {
            var model = BusinessLogic.GetMatchingCourses(form);
            return PartialView("_SearchResults", model);
        }

        public ActionResult _SingleCourse(Course model)
        {
            return PartialView("_SingleCourse", model);
        }

        public ActionResult _SelectCoursesBy()
        {
            return PartialView();
        }
        
        public ActionResult _MainPageContent()
        {
            return PartialView();
        }

        public ActionResult _MakeCriteriaForm()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SubmitCriteria(FormCollection form)
        {
            IQueryable<Cours> currentMatch = BusinessLogic.GetAllCoursesDBContext();
            currentMatch = currentMatch.Where(c => c.CourseReviews.Count > 0);
            if (form["Helpfulness"] != null)
            {
                int data = Convert.ToInt32(form["Helpfulness"]);
                currentMatch =
                                currentMatch.Where(c => (c.CourseReviews.Average(r => r.Usability) >= data - 0.5));

            }
            if (form["Easiness"] != null)
            {
                int data = Convert.ToInt32(form["Easiness"]);
                currentMatch =
                                currentMatch.Where(c => (c.CourseReviews.Average(r => r.Easyness) >= data - 0.5));

            }
            if (form["Interesting"] != null)
            {
                int data = Convert.ToInt32(form["Interesting"]);
                currentMatch =
                                currentMatch.Where(c => (c.CourseReviews.Average(r => r.Interests) >= data - 0.5));

            }
            if (form["Clarity"] != null)
            {
                int data = Convert.ToInt32(form["Clarity"]);
                currentMatch =
                                currentMatch.Where(c => (c.CourseReviews.Average(r => r.Clarity) >= data - 0.5));

            }
            if (form["Workload"] != null)
            {
                int data = Convert.ToInt32(form["Workload"]);
                currentMatch =
                                currentMatch.Where(c => (c.CourseReviews.Average(r => r.Workload) >= data - 0.5));

            }

            IEnumerable<Cours> model = currentMatch.ToList();
            
            return PartialView("_SearchResults",model);
        }
    }
}
