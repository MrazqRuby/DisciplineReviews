﻿using DisciplineReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisciplineReviews.Controllers
{
    public class BusinessLogic
    {
        static private DisciplineReviewsEntities context = new DisciplineReviewsEntities();

        static public List<List<Cours>> GetAllCourses()
        {
            
            var types = context.Types.ToList();
            List<List<Cours>> courses = new List<List<Cours>>(types.Count);
            
            for (int i = 0; i < types.Count; i++)
            {
                var list = context.Courses.SqlQuery("select * from Courses as c inner join Disciplines as d on c.DisciplineID = d.DisciplineID where d.TypeID = " + types[i].TypeID).ToList();
                //courses[i] = list;
                //var list = context.Courses.Where(c => c.Discipline.TypeID == types[i].TypeID).ToList();
                courses.Add(list);
            }

            return courses;
        }
        
        static public Cours GetCourse(int id){
            return context.Courses.Single(c => c.CourseID == id);
        }

        static public Course MapCourse(Cours c)
        {
            Course course = new Course();
            course.Id = c.CourseID;
            course.CourseName = c.Discipline.DisciplineName;
            course.LecturerName = c.Teacher.TeacherName;
            course.Credits = c.Discipline.DisciplineCredits;
            course.Type = c.Discipline.Type.Name;

            decimal count = c.CourseReviews.Count;

            if (count > 0)
            {
                decimal helper = c.CourseReviews.Sum(cr => Convert.ToDecimal(cr.Usability));
                course.Helpfulness = helper / count;
                helper = c.CourseReviews.Sum(cr => Convert.ToDecimal(cr.Clarity));
                course.Clarity = helper / count;
                helper = c.CourseReviews.Sum(cr => Convert.ToDecimal(cr.Easyness));
                course.Easiness = helper / count;
                helper = c.CourseReviews.Sum(cr => Convert.ToDecimal(cr.Interests));
                course.Interest = helper / count;
                helper = c.CourseReviews.Sum(cr => Convert.ToDecimal(cr.Workload));
                course.WorkLoad = helper / count;
                course.TotalRating = (course.Helpfulness + course.Clarity + course.Interest + course.Easiness + course.WorkLoad) / 5;

            }
            else
            {
                course.Helpfulness = 0;
                course.Clarity = 0;
                course.Easiness = 0;
                course.Interest = 0;
                course.WorkLoad = 0;
                course.TotalRating = 0;
            }

            return course;
        }

        static public List<CourseReview> GetReviews (int id)
        {
            var reviews = context.Courses.Single(c => c.CourseID == id).CourseReviews.ToList();
            return reviews;
        }
    }
}