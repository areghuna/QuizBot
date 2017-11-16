using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QuestionBankApi.Models;

namespace QuestionBankApi.Controllers
{
    public class QuestionPapersAPIController : ApiController
    {
        private QuestionBankApiContext db = new QuestionBankApiContext();

        // GET: api/QuestionPapersAPI
        public IQueryable<QuestionPaper> GetQuestionPapers()
        {
            return db.QuestionPapers;
        }

        // GET: api/QuestionPapersAPI/5
        [ResponseType(typeof(QuestionPaper))]
        public IHttpActionResult GetQuestionPaper(int id)
        {
            //QuestionPaper questionPaper = db.QuestionPapers.Find(id);
            QuestionPaper questionPaper = db.QuestionPapers.Where(u => u.QuestionPaperId == id)
                    .Include(u => u.Questions)
                    .FirstOrDefault();

            if (questionPaper == null)
            {
                return NotFound();
            }

            return Ok(questionPaper);
        }

        // PUT: api/QuestionPapersAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionPaper(int id, QuestionPaper questionPaper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionPaper.QuestionPaperId)
            {
                return BadRequest();
            }

            db.Entry(questionPaper).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionPaperExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/QuestionPapersAPI
        [ResponseType(typeof(QuestionPaper))]
        public IHttpActionResult PostQuestionPaper(QuestionPaper questionPaper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionPapers.Add(questionPaper);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = questionPaper.QuestionPaperId }, questionPaper);
        }

        // DELETE: api/QuestionPapersAPI/5
        [ResponseType(typeof(QuestionPaper))]
        public IHttpActionResult DeleteQuestionPaper(int id)
        {
            QuestionPaper questionPaper = db.QuestionPapers.Find(id);
            if (questionPaper == null)
            {
                return NotFound();
            }

            db.QuestionPapers.Remove(questionPaper);
            db.SaveChanges();

            return Ok(questionPaper);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionPaperExists(int id)
        {
            return db.QuestionPapers.Count(e => e.QuestionPaperId == id) > 0;
        }
    }
}