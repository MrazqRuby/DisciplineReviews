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
            newreview.Clarity = Convert.ToInt32(form["Clarity"]);
            newreview.Interests = Convert.ToInt32(form["Interest"]);
            newreview.Workload = Convert.ToInt32(form["Workload"]);
            newreview.Grade = Convert.ToInt32(form["Grade"]);
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
