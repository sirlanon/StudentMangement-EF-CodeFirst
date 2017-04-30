using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentsManagement.Models;
using System.Net.Mime;


namespace StudentsManagement.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: /Student/
        public ActionResult Index()
        {
            return View(db.StudentsMVC.ToList());
        }

        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMVC student = db.StudentsMVC.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
         [HttpPost]
        public ActionResult DetailsPartial(int id)
        {
            //StudentMVC student = db.StudentsMVC.Find(id);
            //return PartialView("_DetailsPartial1",student);
            var mapView = new RegisterSubject();
            mapView.RegStudent = db.StudentsMVC.Find(id);

            var listSubjectID = new List<int>();
            var list = new List<StudentsManagement.Models.Mapping>();
            list = db.Mappings.Where(i => i.StudentID == id).ToList();
            foreach(var item in list)
            {
                listSubjectID.Add(item.SubjectID);
            }
            foreach (var i in listSubjectID)
            {
                mapView.RegSubjects.Add(db.Subjects.Find(i));
            }
            
             
             return PartialView("_DetailsPartial1",mapView);
        }

         [HttpPost]
         public ActionResult SubjectPartial()
         {
             var subModel = new List<Subject>();
             subModel = db.Subjects.ToList();
           return PartialView("SubjectPartial1",subModel);
         }

         [HttpPost]
         public ActionResult SubjectDetailPartial(int id)
         {
             
             var mapView = new RegisterSubject();
             mapView.RegSubject = db.Subjects.Find(id);

             var listStudentID = new List<int>();
             var list = new List<StudentsManagement.Models.Mapping>();
             list = db.Mappings.Where(i => i.SubjectID == id).ToList();
             foreach (var item in list)
             {
                 listStudentID.Add(item.StudentID);
             }
             foreach (var i in listStudentID)
             {
                 mapView.RegStudents.Add(db.StudentsMVC.Find(i));
             }


             return PartialView("SubjectDetailsPartial1", mapView);
         }


        // GET: /Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,StudentName,StudentAge,StudentGrade,StudentYearOfGraduation")] StudentMVC student)
        {
           // var student = new Student();
            if (ModelState.IsValid)
            {
                db.StudentsMVC.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMVC student = db.StudentsMVC.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StudentID,StudentName,StudentAge,StudentGrade,StudentYearOfGraduation")] StudentMVC student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMVC student = db.StudentsMVC.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentMVC student = db.StudentsMVC.Find(id);
            db.StudentsMVC.Remove(student);

            var listMap = new List<StudentsManagement.Models.Mapping>();
            listMap = db.Mappings.Where(i => i.StudentID == id ).ToList();
            var tempSub = new StudentsManagement.Models.Subject();
            
            foreach(var item in listMap)
            {
                tempSub = db.Subjects.Find(item.SubjectID);
                tempSub.SubjectCurrentNumber -= 1;
                db.Mappings.Remove(item);
                
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteRange(int[] deleteInputs)
        {
            
            if (deleteInputs != null && deleteInputs.Length > 0)
            {
                for(int j = 0; j<  deleteInputs.Length; j++)
                {
                    int index = deleteInputs[j];
                    StudentMVC student = db.StudentsMVC.Find(index);
                    db.StudentsMVC.Remove(student);
                    var listMap = new List<StudentsManagement.Models.Mapping>();
                    listMap = db.Mappings.Where(i => i.StudentID == index).ToList();
                    var tempSub = new StudentsManagement.Models.Subject();

                    foreach (var item in listMap)
                    {
                        tempSub = db.Subjects.Find(item.SubjectID);
                        tempSub.SubjectCurrentNumber -= 1;
                        db.Mappings.Remove(item);

                    }
                    db.SaveChanges();
                }
            }
           
            return RedirectToAction("Index");
        }

        [HttpPost]

        public ActionResult RegisterSubject([Bind(Include = "StudentID")] Mapping map)
        {
            var registerSubject = new RegisterSubject();
            registerSubject.RegStudent = db.StudentsMVC.Find(map.StudentID);  
            registerSubject.RegSubjects = db.Subjects.ToList();

            var listMap = new List<Mapping>();
            listMap = db.Mappings.Where(i=>i.StudentID==map.StudentID ).ToList();


            foreach(var itemSub in db.Subjects.ToList())
            {
               foreach(var itemMap in listMap)
                {
                    if(itemSub.SubjectID == itemMap.SubjectID)
                    {
                        ///// disable reg
                    }
                }
            }

            if (registerSubject == null)
            {
                return HttpNotFound();
            }
            return View(registerSubject);
        }

        public ActionResult RegisterSubject(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var registerSubject = new RegisterSubject();
            registerSubject.RegStudent = db.StudentsMVC.Find(id);

            registerSubject.RegSubjects = db.Subjects.ToList();
            if (registerSubject == null)
            {
                return HttpNotFound();
            }
            return View(registerSubject);
        }

        [HttpPost]
        public ActionResult CancelReg([Bind(Include = "StudentID,SubjectID")] Mapping map)
        {
            var temp = new Mapping();
            
            temp = db.Mappings.Where(i => i.StudentID == map.StudentID && i.SubjectID == map.SubjectID).First();
            if (temp != null)
            {
                db.Mappings.Remove(temp);
                db.Subjects.Find(map.SubjectID).SubjectCurrentNumber -= 1;
                db.SaveChanges();
                
            }
            else
            {
                return null;
            }
            return RedirectToAction("_DetailsPartial1",map);
        }

        [HttpPost]
        public ActionResult ConfirmRegister([Bind(Include="StudentID,SubjectID")] Mapping map)
        {
            if (ModelState.IsValid)
            {
                int num;
                var list = new List<StudentsManagement.Models.Mapping>();
                list = db.Mappings.Where(i => i.SubjectID == map.SubjectID).ToList();
                num = list.Count;
                var sub = new Subject();
                sub.SubjectNumOfStudent = db.Subjects.Find(map.SubjectID).SubjectNumOfStudent;


                //check whether stud has reg this suj or yet

                bool canReg = true;
                
                var list2 = new List<StudentsManagement.Models.Mapping>();
                list2 = db.Mappings.Where(i => i.StudentID == map.StudentID).ToList();
                foreach (var item in list2)
                {
                    if (item.SubjectID == map.SubjectID)
                        canReg = false;
                }   


                if (num < sub.SubjectNumOfStudent && canReg) 
                {
                    db.Subjects.Find(map.SubjectID).SubjectCurrentNumber += 1;
                    db.Mappings.Add(map);
                    db.SaveChanges();
                }

                else
                {
                    return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { data = "The class is FULL or you have REGISTERD it ALREADY! \nChoose others!" } };
                }




            }
           return View(map);
            
        }
        //httpget
        public ActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSubject([Bind(Include = "SubjectID,SubjectName,SubjectNumOfStudent")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
               
            }

            return View(subject);
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
