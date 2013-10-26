using DisciplineReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisciplineReviews.Controllers
{
    public class BusinessLogic
    {
        static private DisciplineReviewsEntities context = new DisciplineReviewsEntities();

        static public List<CourseOverview> GetTop10Courses()
        {
            List<CourseOverview> courses = new List<CourseOverview>(10);
            for (int i = 0; i < 10; i++) courses.Add(new CourseOverview());
            for (int i = 0; i < 10; i++)
            {
                courses[i].Name = "Analiz 1";
                courses[i].Id = 3;
                courses[i].Credits = 2;
                courses[i].Lecturer = "Babev";
                courses[i].Type = "Zadaljitelna";
            }
            


            return courses;
        }
        
        static public Course GetCourse(int id){
            Course retval = new Course
            {
                Easiness = 1.5M,
                Helpfulness = 3.4M,
                Clarity = 4.3M,
                WorkLoad = 5M,
                Interest = 5M,
                Id = id,
                CourseName = "Анализ 1",
                LecturerName = "Бабев",
                Type = "Задължителна",
                Credits = 8,
                TotalRating = ((1.5M + 3.4M + 4.3M + 5M) / 4),
                AvgGrade = 3.2M
            };
                
            return retval;
        }

    }
}