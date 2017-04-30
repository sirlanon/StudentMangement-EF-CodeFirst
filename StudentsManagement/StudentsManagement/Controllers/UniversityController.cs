using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentsManagement.Models;
using StudentsManagement.Repository;

namespace StudentsManagement.Controllers
{
    public class UniversityController : Controller
    {
        private IUniversity universityRepo;
        private StudentContext db = new StudentContext();


        public UniversityController()
        {
            universityRepo = new UniversityRepository(new StudentContext());
        }
        // GET: /University/
        public ActionResult Index()
        {
            return View(universityRepo.GetFaculty());
        }

        // GET: /University/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = universityRepo.GetFacultyID(id);

            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // GET: /University/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /University/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="FacultyID,FacultyName,FacultyDeanName")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                universityRepo.AddFaculty(faculty);               
                return RedirectToAction("Index");
            }

            return View(faculty);
        }

        // GET: /University/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = universityRepo.GetFacultyID(id);

            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: /University/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="FacultyID,FacultyName,FacultyDeanName")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                universityRepo.EditFaculty(faculty);
                return RedirectToAction("Index");
            }
            return View(faculty);
        }

        // GET: /University/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = universityRepo.GetFacultyID(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: /University/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            universityRepo.DeleteFaculty(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
