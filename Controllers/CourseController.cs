using DisciplineReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisciplineReviews.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Index(int id)
        {
            //Course course = new Course();
            return View();
        }

        public ActionResult _CourseRating(int courseId)
        {
            Cours cours = BusinessLogic.GetCourse(courseId);
            Course model = BusinessLogic.MapCourse(cours);
            return PartialView(model);
        }

        public ActionResult _CourseBody(int courseId)
        {
            Cours model = BusinessLogic.GetCourse(courseId);
            return PartialView(model);
        }

        public ActionResult _CourseOverview(int courseId)
        {
            var model = BusinessLogic.GetCourse(courseId);
            return PartialView(model);
        }

        public ActionResult _CourseReviews(int courseId)
        {
            var reviews = BusinessLogic.GetReviews(courseId);
            return PartialView(reviews);
        }

        public ActionResult _AddReview()
        {
            return PartialView();
        }

        public ActionResult _CourseMaterials(int courseId)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SubmitReview(FormCollection form)
        {
            CourseReview newreview = new CourseReview();
            newreview.CourseID = Convert.ToInt32(form["courseId"]);
            newreview.Easyness = Convert.ToInt32(form["Easiness"]);
            newreview.Usability = Convert.ToInt32(form["Helpfulness"]);
            newreview.Clarity = Convert.ToInt32(form["Clarity"]);
            newreview.Interests = Convert.ToInt32(form["Interesting"]);
            newreview.Workload = 6 - Convert.ToInt32(form["Workload"]);
            newreview.Grade = newreview.Easyness + newreview.Clarity + newreview.Interests + newreview.Workload + newreview.Usability;
            newreview.Comment = form["Comment"];
            newreview.CourseUp = 0;
            newreview.CourseDown = 0;
            newreview.UserID = BusinessLogic.GetUserIdByName(form["User"]);
            newreview.Date = DateTime.Now;

            BusinessLogic.AddNewCourseReview(newreview);

            var reviews = BusinessLogic.GetReviews(Convert.ToInt32(form["courseId"]));
            return PartialView("_CourseReviews", reviews);
        }
    }
}
