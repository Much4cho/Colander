using Colander.WordService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Colander.Controllers
{
    public class LearnController : Controller
    {
        private WordListDBContext db = new WordListDBContext();
        // GET: Learn
        public ActionResult Learn()
        {
            return View();
        }
    }
}