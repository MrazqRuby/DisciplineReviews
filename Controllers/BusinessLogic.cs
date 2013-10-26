using DisciplineReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisciplineReviews.Controllers
{
    public class BusinessLogic
    {
        static public List<CourseOverview> GetTop10Courses()
        {
            List<CourseOverview> courses = new List<CourseOverview>(10);
            for(int i = 0; i < 10; i++) courses.Add(new CourseOverview());
            courses[0].Credits = 2;
            courses[0].Lecturer = "Babev";
            courses[0].Type = "Zadaljitelna";
            courses[1].Credits = 2;
            courses[1].Lecturer = "Babev";
            courses[1].Type = "Zadaljitelna";
            courses[2].Credits = 2;
            courses[2].Lecturer = "Babev";
            courses[2].Type = "Zadaljitelna";
            courses[3].Credits = 2;
            courses[3].Lecturer = "Babev";
            courses[3].Type = "Zadaljitelna";
            courses[4].Credits = 2;
            courses[4].Lecturer = "Babev";
            courses[4].Type = "Zadaljitelna";
            courses[5].Credits = 2;
            courses[5].Lecturer = "Babev";
            courses[5].Type = "Zadaljitelna";
            courses[6].Credits = 2;
            courses[6].Lecturer = "Babev";
            courses[6].Type = "Zadaljitelna";
            courses[7].Credits = 2;
            courses[7].Lecturer = "Babev";
            courses[7].Type = "Zadaljitelna";
            courses[8].Credits = 2;
            courses[8].Lecturer = "Babev";
            courses[8].Type = "Zadaljitelna";
            courses[9].Credits = 2;
            courses[9].Lecturer = "Babev";
            courses[9].Type = "Zadaljitelna";
            for (int i = 0; i < 10; i++)
            {
                courses[i].Name = "Analiz 1";
                courses[i].Id = 3;
            }
            return courses;
        }
        static public Course GetCourse(int id){
            return new Course();
        }

    }
}