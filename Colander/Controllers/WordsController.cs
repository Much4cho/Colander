using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Colander.WordServices;

namespace Colander.Controllers
{
    public class WordIndexViewModel
    {
        public IEnumerable<Word> Words { get; set; }
        public int WordListId { get; set; }
    }


    public class WordsController : Controller
    {
        //private WordListDBContext db = new WordListDBContext();
        private WordServices.IWordService _wordService;
        private int? CurrentListID = null;

        public WordsController(IWordService wordService)
        {
            _wordService = wordService;
        }

        // GET: Words
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Word word = db.Words.Find(id);
            //CurrentListID = id;
            ViewBag.CurrentListID = id;

            IEnumerable<Word> words = _wordService.GetForListId(id);
            var wordsView = new WordIndexViewModel() { Words = words, WordListId = (int)id };
            //var words = db.Words.Include(w => w.WordList);

            return View(wordsView);
        }



        // GET: Words/Create
        public ActionResult Create(int? id)
        {
            //ViewBag.WordListID = new SelectList(db.WordLists, "WordListID", "WordListID");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = new Word() { WordListID = (int)id };
            return View(word);
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



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_wordService.Dispose();

            }
            base.Dispose(disposing);
        }
    }
}
