using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisciplineReviews.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/

        public ActionResult _Teachers()
        {
            return View();
        }

        public ActionResult _SingleTeacher(Teacher model)
        {
            return PartialView(model);
        }

        public ActionResult _TeacherRating(int courseId)
        {
            Teacher model = BusinessLogic.GetTeacher(courseId);
            return PartialView(model);
        }

    }
}
