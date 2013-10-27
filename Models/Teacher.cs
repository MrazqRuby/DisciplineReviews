using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisciplineReviews.Models
{
    public class Teacher
    {
        public string Name { get; set; }
        public decimal TotalRating { get; set; }
        public decimal Clarity { get; set; }
        public decimal Criteria { get; set; }
        public decimal Enthusiasm { get; set; }
        public decimal Speed { get; set; }
        public decimal Material { get; set; }
    }
}
