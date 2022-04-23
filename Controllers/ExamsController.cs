using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project_asm.Data;
using project_asm.Models;

namespace project_asm.Controllers
{
    public class ExamsController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: Exams
        public ActionResult Index()
        {
            var exam = db.Exam.Include(e => e.Faculty).Include(e => e.Room).Include(e => e.Subject);
            return View(exam.ToList());
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exam.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            ViewBag.FacultyId = new SelectList(db.Faculty, "FacultyId", "FacultyName");
            ViewBag.RoomId = new SelectList(db.Room, "RoomId", "RoomName");
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamId,SubjectId,FacultyId,RoomId,StartTime,ExamDate,ExamDuration,Status")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exam.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultyId = new SelectList(db.Faculty, "FacultyId", "FacultyName", exam.FacultyId);
            ViewBag.RoomId = new SelectList(db.Room, "RoomId", "RoomName", exam.RoomId);
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName", exam.SubjectId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exam.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyId = new SelectList(db.Faculty, "FacultyId", "FacultyName", exam.FacultyId);
            ViewBag.RoomId = new SelectList(db.Room, "RoomId", "RoomName", exam.RoomId);
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName", exam.SubjectId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamId,SubjectId,FacultyId,RoomId,StartTime,ExamDate,ExamDuration,Status")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacultyId = new SelectList(db.Faculty, "FacultyId", "FacultyName", exam.FacultyId);
            ViewBag.RoomId = new SelectList(db.Room, "RoomId", "RoomName", exam.RoomId);
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName", exam.SubjectId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exam.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exam.Find(id);
            db.Exam.Remove(exam);
            db.SaveChanges();
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
