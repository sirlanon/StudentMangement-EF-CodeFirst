using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsManagement.Repository
{
    public class BaseEntity
    {
        [Key]
        public int ID;
    }
}