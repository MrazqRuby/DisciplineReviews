using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisciplineReviews.Models
{
    public class CourseOverview
    {
        public string Name { get; set; }
        public decimal Credits { get; set; }
        public string Lecturer { get; set; }
        public string Type { get; set; }
    }
}