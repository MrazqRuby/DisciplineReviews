using DisciplineReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisciplineReviews.Controllers
{
    public class BusinessLogic
    {
        static private DisciplineReviewsEntities context;

        static public List<Cours> GetMatchingCourses(FormCollection form)
        {
            var name = form["Name"];
            var retval = (from c in context.Courses
                          where c.Discipline.DisciplineName.Contains(name)
                          select c).ToList();
            return retval;
        }

        static public Cours GetBestCourse(Func<Cours, double?> func){
            var a = context.Courses.Where(c => c.CourseReviews.Count > 0).OrderBy(func);
            var b = a.FirstOrDefault();
            return b;
        }

        static public Cours GetWorstCourse(Func<Cours, double?> func)
        {
            var a = context.Courses.Where(c => c.CourseReviews.Count > 0).OrderByDescending(func);
            var b = a.FirstOrDefault();
            return b;
        }

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
            var a = context.Courses;
            var b = a.First(c => c.CourseID == id);
            return b;
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

        static public int GetUserIdByName(string p)
        {
            return context.Users.First(user => user.UserName == p).UserID;
        }

        public static void AddNewCourseReview(CourseReview newreview)
        {
            context.CourseReviews.Add(newreview);
            context.SaveChanges();
        }

        public static Teacher GetTeacher(int teacherId)
        {
            return context.Teachers.First(t => t.TeacherID == teacherId);
        }
    
        public static void Init()
        {
 	        context = new DisciplineReviewsEntities();
        }
    }
}