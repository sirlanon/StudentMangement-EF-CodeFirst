using StudentsManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsManagement.Repository
{
    public class UniversityRepository :IUniversity,IDisposable
    {
        private StudentContext context;

        public UniversityRepository(StudentContext ctx)
        {
            this.context = ctx;
        }

        //for faculty
         public IEnumerable<Faculty> GetFaculty()
        {
            return context.Faculties.ToList();
        }

         public Faculty GetFacultyID(int? id)
        {
            return context.Faculties.Find(id);
        }

         public void AddFaculty(Faculty faculty)
        {
            context.Faculties.Add(faculty);
            context.SaveChanges();
        }

         public void EditFaculty(Faculty faculty)
        {
            context.Entry(faculty).State = EntityState.Modified;
            context.SaveChanges();
        }

         public void DeleteFaculty(int id)
        {
            Faculty act = context.Faculties.Find(id);
            context.Faculties.Remove(act);
            context.SaveChanges();
        }


        ///////////// for Class
         public IEnumerable<UniClass> GetUniClass()
        {
            return context.UniClasses.ToList();
        }

         public UniClass GetUniClassID(int? id)
        {
            return context.UniClasses.Find(id);
        }

         public void AddUniClass(UniClass uniclass)
        {
            context.UniClasses.Add(uniclass);
            context.SaveChanges();
        }

         public void EditUniClass(UniClass uniclass)
        {
            context.Entry(uniclass).State = EntityState.Modified;
            context.SaveChanges();
        }

         public void DeleteUniClass(int id)
        {
            UniClass uniclass = context.UniClasses.Find(id);
            context.UniClasses.Remove(uniclass);
            context.SaveChanges();
        }

      
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}