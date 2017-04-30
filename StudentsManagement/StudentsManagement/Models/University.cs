using StudentsManagement.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentsManagement.Models
{
  
    public class Faculty : BaseEntity
    {
        public Faculty()
        {
            UniClasses = new List<UniClass>();
            Activities = new List<Activity>();
        }
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
        public string FacultyDeanName { get; set; }

        public virtual ICollection<UniClass> UniClasses { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }

    public class UniClass :  Faculty
    {
        
        public virtual int FacultyID { get; set; }
        
        public int UniClassID { get; set; }
        public string UniClassName { get; set; }
        public string UniClassTeacherName { get; set; }

        
    }
}
   
