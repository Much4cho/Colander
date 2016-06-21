using Colander.WordServices;
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
        //private WordListDBContext db = new WordListDBContext();
        private WordServices.IWordListService _wordListService;
        public WordListsController(IWordListService wordListService)
        {
            _wordListService = wordListService;
        }



        // GET: WordLists
        public ActionResult Index()
        {
            return View(_wordListService.ShowLists());
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
                _wordListService.Add(wordList);
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
            WordList wordList = _wordListService.GetById((int)id);
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
                _wordListService.Edit(wordList);
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
            WordList wordList = _wordListService.GetById((int)id);
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
            WordList wordList = _wordListService.GetById(id);
            _wordListService.Delete(wordList);
            return RedirectToAction("Index");
        }



        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
