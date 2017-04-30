using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsManagement.Models
{
    public class Activity
    {
        [Key]

        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public virtual ICollection<Tool> Tools {get; set;}
        public virtual ICollection<Faculty> Faculties { get; set; }
        public virtual ICollection<UniClass> UniClasses { get; set; }
    }


    public class Tool
    {
        [Key]
        public int ToolID { get; set; }
        public string ToolName { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}