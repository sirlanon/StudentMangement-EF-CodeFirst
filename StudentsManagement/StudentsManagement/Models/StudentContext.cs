using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsManagement.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext()
            : base("StudentContext")
        {
        }
     
        public static StudentContext Create()
        {
            return new StudentContext();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentMVC> StudentsMVC { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mapping> Mappings { get; set; }
        public DbSet<RegisterSubject> RegisterSubjects { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Tool> Tools { get; set; }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<UniClass> UniClasses { get; set; }
    }
    
}