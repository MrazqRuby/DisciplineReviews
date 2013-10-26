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
        //
        // GET: /Course/

        public ActionResult Index(int id)
        {
            Course course = new Course();
            return View(course);
        }
        public ActionResult _CourseView(int id)
        {
            Course model = BusinessLogic.GetCourse(id);
            return PartialView(model);
        }

        public ActionResult _CourseRating(Course model)
        {
            return PartialView(model);
        }

        public ActionResult _CourseBody(Course model)
        {
            return PartialView(model);
        }

        public ActionResult _CourseOverview(Course model)
        {
            return PartialView(model);
        }

        public ActionResult _CourseReview(Course model)
        {
            return PartialView(model);
        }
    }
}
