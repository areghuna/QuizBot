using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuestionBankApi.Models;

namespace QuestionBankApi.Controllers
{
    public class QuestionPapersController : Controller
    {
        private QuestionBankApiContext db = new QuestionBankApiContext();

        // GET: QuestionPapers
        public ActionResult Index()
        {
            return View(db.QuestionPapers.ToList());
        }

        // GET: QuestionPapers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionPaper questionPaper = db.QuestionPapers.Find(id);
            if (questionPaper == null)
            {
                return HttpNotFound();
            }
            return View(questionPaper);
        }

        // GET: QuestionPapers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionPapers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionPaperId,QuestionPaperName,QuestionPaperDescription")] QuestionPaper questionPaper)
        {
            if (ModelState.IsValid)
            {
                db.QuestionPapers.Add(questionPaper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionPaper);
        }

        // GET: QuestionPapers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionPaper questionPaper = db.QuestionPapers.Find(id);
            if (questionPaper == null)
            {
                return HttpNotFound();
            }
            return View(questionPaper);
        }

        // POST: QuestionPapers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionPaperId,QuestionPaperName,QuestionPaperDescription")] QuestionPaper questionPaper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionPaper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionPaper);
        }

        // GET: QuestionPapers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionPaper questionPaper = db.QuestionPapers.Find(id);
            if (questionPaper == null)
            {
                return HttpNotFound();
            }
            return View(questionPaper);
        }

        // POST: QuestionPapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionPaper questionPaper = db.QuestionPapers.Find(id);
            db.QuestionPapers.Remove(questionPaper);
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
