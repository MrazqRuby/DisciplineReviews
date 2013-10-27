using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisciplineReviews.Controllers
{
    public class SliderController : Controller
    {
        //
        // GET: /Slider/

        public ActionResult _SliderView()
        {
            return PartialView();
        }


        public ActionResult _SliderCourse(Cours course){
            return PartialView("_SliderCourse", course);
        }
    }
}
