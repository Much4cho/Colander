using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Colander.WordService;

namespace Colander.Controllers
{
    public class WordViewModel
    {
        public int WordID { get; set; }
        public string WordOriginal { get; set; }
        public string WordTranslation { get; set; }

        public int WordListID { get; set; }
    }

    public class WordsController : Controller
    {
        //private WordListDBContext db = new WordListDBContext();
        private WordService.IWordService _wordService = new WordService.WordService();
        private static int? CurrentListID = null;

        public WordsController(IWordService wordService)
        {
            _wordService = wordService;
        }

        // GET: Words
        public ActionResult Index(int? id)
        {
            if (id == null)
            {

                //if (CurrentListID == null)
                //{
                //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                //}

                //id = CurrentListID;

            }
            //Word word = db.Words.Find(id);
            //CurrentListID = id;
            ViewBag.CurrentListID = id;

            IEnumerable<Word> words = _wordService.GetForListId(id);


            //var words = db.Words.Include(w => w.WordList);

            return View(words.ToList());
        }



        // GET: Words/Create
        public ActionResult Create(int? id)
        {
            //ViewBag.WordListID = new SelectList(db.WordLists, "WordListID", "WordListID");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }

        // POST: Words/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WordID,WordOriginal,WordTranslation,WordListID")] Word word)
        {
            if (ModelState.IsValid)
            {
                //db.Words.Add(word);
                //db.SaveChanges();
                _wordService.Add(word);
                return RedirectToAction("Index", new { id = CurrentListID });
            }

            //ViewBag.WordListID = new SelectList(db.WordLists, "WordListID", "WordListID", word.WordListID);
            return View(word);
        }



        // GET: Words/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Word word = db.Words.Find(id);
            Word word = _wordService.GetForWordId(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            //ViewBag.WordListID = new SelectList(db.WordLists, "WordListID", "WordListID", word.WordListID);
            return View(word);
        }

        // POST: Words/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WordID,WordOriginal,WordTranslation,WordListID")] Word word)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(word).State = EntityState.Modified;
                //db.SaveChanges();
                _wordService.Edit(word);
                return RedirectToAction("Index");
            }
            //ViewBag.WordListID = new SelectList(db.WordLists, "WordListID", "WordListID", word.WordListID);
            return View(word);
        }



        // GET: Words/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Word word = db.Words.Find(id);
            Word word = _wordService.GetForWordId(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        // POST: Words/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Word word = db.Words.Find(id);
            Word word = _wordService.GetForWordId(id);
            //db.Words.Remove(word);
            //db.SaveChanges();
            _wordService.Delete(word);

            return RedirectToAction("Index");
        }



        //protected override void dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.dispose();
        //    }
        //    base.dispose(disposing);
        //}
    }
}
