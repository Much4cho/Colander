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
    public class WordViewModel
    {
        public IEnumerable<Word> Words { get; set; }
        public int WordListId { get; set; }
        public Word ViewWord { get; set; }
    }


    public class WordsController : Controller
    {
        private WordServices.IWordService _wordService;
        private IColanderEngine _colanderEngine;

        public WordsController(IWordService wordService, IColanderEngine colanderEngine)
        {
            _wordService = wordService;
            _colanderEngine = colanderEngine;
        }



        // GET: Words
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<Word> words = _wordService.GetForListId(id);
            var wordsView = new WordViewModel() { Words = words, WordListId = (int)id };
            //var words = db.Words.Include(w => w.WordList);

            return View(wordsView);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var word = _wordService.GetForWordId(id);
            return View(word);
        }

        // GET: Words/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var word = new Word() { WordListID = (int)id };
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
                _wordService.Add(word);
                return RedirectToAction("Index", new { id = word.WordListID });
            }
            return View(word);
        }



        // GET: Words/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = _wordService.GetForWordId(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        // POST: Words/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WordID,WordOriginal,WordTranslation,WordListID,WordColanderID,Created,GuessedRight")] Word word)
        {
            if (ModelState.IsValid)
            {
                _wordService.Edit(word);
                return RedirectToAction("Index", new { id = word.WordListID });
            }
            return View(word);
        }



        // GET: Words/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
            Word word = _wordService.GetForWordId(id);
            _wordService.Delete(word);

            return RedirectToAction("Index", new { id = word.WordListID });
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
