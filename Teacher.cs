//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DisciplineReviews
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher
    {
        public Teacher()
        {
            this.Courses = new HashSet<Cours>();
            this.CoursesToTeachers = new HashSet<CoursesToTeacher>();
            this.TeacherReviews = new HashSet<TeacherReview>();
        }
    
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual ICollection<Cours> Courses { get; set; }
        public virtual ICollection<CoursesToTeacher> CoursesToTeachers { get; set; }
        public virtual ICollection<TeacherReview> TeacherReviews { get; set; }
        public virtual User User { get; set; }
    }
}