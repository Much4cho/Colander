﻿using Colander.WordServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Colander.Controllers
{
    public class LearnController : Controller
    {
        private IWordService _wordService;
        private IColanderEngine _colanderEngine;
        private IWordListService _wordListService;

        public LearnController(IWordService wordService, IWordListService wordListService, IColanderEngine colanderEngine)
        {
            _wordService = wordService;
            _wordListService = wordListService;
            _colanderEngine = colanderEngine;
        }

        //Random words 
        // GET: Learn
        public ActionResult Learn(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Random random = new Random();
            //var words = _wordService.GetForListId(id);
            //Word word = null;

            //while (words.Any() && word == null)
            //{
            //    word = words.ElementAt(random.Next(words.Count()));
            //}
            _colanderEngine.CreateNowColander(id);
            Word word = _colanderEngine.ColanderRandomize(id);

            if (word == null)
            {
                //return HttpNotFound();
                word = _colanderEngine.Randomize(id);
                //return RedirectToAction("AllLearned", new { id = id });
            }
            return View(word);
        }
        public ActionResult Right(int? id)
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
            word.GuessedRight = DateTime.UtcNow;
            word.GuessedRightDuringThisSession = true;
            _wordService.Edit(word);
            _colanderEngine.AddToGotRightList(word);
            return RedirectToAction("Learn", new { id = word.WordListID });
        }
        public ActionResult Wrong(int? id)
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
            return RedirectToAction("Learn", new { id = word.WordListID });
        }
        //Specified word
        // GET: LearnWord

        public ActionResult LearnWord(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var word = _wordService.GetForWordId(id);
            if (word == null)
            {
                return HttpNotFound();
            }

            return View(word);
        }

        public ActionResult EndSession(int? id)
        {
            var words = _wordService.GetForGuessedRight(id);
            foreach (var word in words)
            {
                word.WordColanderID++;
                word.GuessedRightDuringThisSession = false;
                _wordService.Edit(word);
            }

            return RedirectToAction("Index", "Words", new { id = id });
        }
        public ActionResult AllLearned(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordList hihi = _wordListService.GetById((int)id);
            return View(hihi);
        }
    }
}