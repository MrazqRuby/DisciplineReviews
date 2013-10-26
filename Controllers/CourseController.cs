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

        public ActionResult _CourseRating(int courseid)
        {
            Course model = BusinessLogic.GetCourse(courseid);
            return PartialView(model);
        }

        public ActionResult _CourseBody(int courseid)
        {
            Course model = BusinessLogic.GetCourse(courseid);
            return PartialView(model);
        }

        public ActionResult _CourseOverview(Course model)
        {
            return PartialView(model);
        }

        public ActionResult _CourseReview(int courseid)
        {
            List<DisciplineReviews.CourseReview> reviews = new List<CourseReview>(5);
            for (int i = 0; i < 5; i++)
            {
                DisciplineReviews.CourseReview review = new CourseReview();
                review.User = new User();
                review.User.UserName = "Саламчо";
                review.Comment = "Страхотен курс, Бабев говори с ентусиазъм, изпита е лесен и асистентите винаги ти помагат. Единственият проблем е, че на единият малко не се разбира какво приказва.";
                reviews.Add(review);
            }
            return PartialView(reviews);
        }
    }
}
