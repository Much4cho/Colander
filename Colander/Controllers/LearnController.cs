using Colander.WordService;
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
        private WordListDBContext db = new WordListDBContext();
        private WordService.WordService wordService = new WordService.WordService();
        public string usersAnswer;


        //Random words 
        // GET: Learn
        public ActionResult Learn(int? id)
        {

            if (id == null)
            {

                //id = wordService.CurrentListID;

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            //Word word = db.Words.Find(id);
            //wordService.CurrentListID = id;
            //var word = wordService.GetForWordId(id);
            Random random = new Random();
            var words = wordService.GetForListId(id);
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

                //id = wordService.CurrentListID;

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            //Word word = db.Words.Find(id);
            //wordService.CurrentListID = id;
            var word = wordService.GetForWordId(id);
            if (word == null)
            {
                return HttpNotFound();
            }

            return View(word);

        }
    }
}