using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsManagement.Models
{
    public class RegisterSubject
    {
        [Key]
        public int RegSubID { get; set; }
        public StudentMVC RegStudent { get; set; }
        public Subject RegSubject { get; set; }
        public IList<StudentMVC> RegStudents { get; set; }
        public IList<Subject> RegSubjects { get; set; }

        public RegisterSubject()
        {

            RegStudents = new List<StudentMVC>();
            RegSubjects = new List<Subject>();
        }

       
        
    }


}