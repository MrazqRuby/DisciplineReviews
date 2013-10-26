using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisciplineReviews.Models
{
    public class HomeModel
    {
        public List<CourseOverview> top10courses { get; set; }
        public List<Teacher> top10teachers { get; set; }
    }
}