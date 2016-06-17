using Colander.WordServices;
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
        public string usersAnswer;

        public LearnController(IWordService wordService)
        {
            _wordService = wordService;
        }


        //Random words 
        // GET: Learn
        public ActionResult Learn(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Random random = new Random();
            var words = _wordService.GetForListId(id);
            Word word = null;

            while (words.Any() && word == null)
            {
                word = words.ElementAt(random.Next(words.Count()));
            }

            if (word == null)
            {
                return HttpNotFound();
            }


            return View(word);

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
    }
}