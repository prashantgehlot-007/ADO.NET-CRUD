using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dayone.Models;

namespace dayone.Controllers
{
    public class StudentController : Controller
    {
        StudentDBManager db = new StudentDBManager();
        // GET: Student
        public ActionResult Index()
        {
            List<Student> slist = db.GetAllStudent();
            return View(slist);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student s = db.SearchStudent(id);
            return View(s);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            Student s = new Student();
            return View(s);
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student s)
        {
            try
            {
                // TODO: Add insert logic here
                db.SaveStudent(s);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student s = db.SearchStudent(id);
            return View(s);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student s)
        {
            try
            {
                db.UpdateStudent(s);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student s = db.SearchStudent(id);
            return View(s);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Student s)
        {
            try
            {
                db.DeleteStudent(id);
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
