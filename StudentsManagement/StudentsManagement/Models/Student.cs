using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentsManagement.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public float StudentGrade { get; set; }
        public int StudentYearOfGraduation { get; set; }

    }

    public class StudentMVC
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public float StudentGrade { get; set; }
        public int StudentYearOfGraduation { get; set; }
    }

    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int SubjectCurrentNumber { get; set; }
        public int SubjectNumOfStudent { get; set; }

        public Subject()
        {
            SubjectCurrentNumber = 0;
        }
    }

    public class Mapping 
    {
        [Key]
        public int MappingID { get; set; }
        public int StudentID { get; set; }
         [ForeignKey("StudentID")]
       public virtual StudentMVC StudentMap{ get; set; }
        public int SubjectID { get; set; }
        [ForeignKey("SubjectID")]
        public virtual Subject SubjectMap { get; set; }
        
    }
    


}