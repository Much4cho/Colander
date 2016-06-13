using Colander.WordService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Colander.Controllers
{
    public class WordListsController : Controller
    {
        private WordListDBContext db = new WordListDBContext();
        private WordListService wordListService = new WordListService();


        // GET: WordLists
        public ActionResult Index()
        {
            return View(db.WordLists.ToList());
        }



        // GET: WordLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WordLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WordListID,WordListName")] WordList wordList)
        {
            if (ModelState.IsValid)
            {
                db.WordLists.Add(wordList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wordList);
        }



        // GET: WordLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordList wordList = db.WordLists.Find(id);
            if (wordList == null)
            {
                return HttpNotFound();
            }
            return View(wordList);
        }

        // POST: WordLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WordListID,WordListName")] WordList wordList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wordList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wordList);
        }



        // GET: WordLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordList wordList = db.WordLists.Find(id);
            if (wordList == null)
            {
                return HttpNotFound();
            }
            return View(wordList);
        }

        // POST: WordLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WordList wordList = db.WordLists.Find(id);
            db.WordLists.Remove(wordList);
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
