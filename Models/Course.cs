using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisciplineReviews.Models
{
    public class Course
    {
        public string CourseName { get; set; }
        public string LecturerName { get; set; }
        public decimal TotalRating { get; set; }
        public decimal Helpfulness { get; set; }
        public decimal Easiness { get; set; }
        public decimal Clarity { get; set; }
        public decimal WorkLoad { get; set; }
        public decimal AvgGrade { get; set; }
    }
}