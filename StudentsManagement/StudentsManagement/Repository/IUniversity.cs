using StudentsManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsManagement.Repository
{
    public interface IUniversity : IDisposable
    {
        IEnumerable<Faculty> GetFaculty();
        Faculty GetFacultyID(int? id);
        void AddFaculty(Faculty faculty);
        void EditFaculty(Faculty faculty);
        void DeleteFaculty(int id);


        IEnumerable<UniClass> GetUniClass();
        UniClass GetUniClassID(int? id);
        void AddUniClass(UniClass uniclass);
        void EditUniClass(UniClass uniclass);
        void DeleteUniClass(int id);

    }
}