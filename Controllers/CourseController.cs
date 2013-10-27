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
            var Easy = form["Easiness"];
            int Id = Convert.ToInt32(form["courseId"]);
            var reviews = BusinessLogic.GetReviews(Id);
            return PartialView("_CourseReviews", Id);
        }
    }
}
