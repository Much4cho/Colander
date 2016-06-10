using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colander.WordService
{
    public class WordListService
    {
        private WordListDBContext _db;

        public WordListService()
        {
            _db = new WordListDBContext();
        }
        public WordList GetById(int id)
        {
            return _db.WordLists.Find(id);
        }

        public void Add(WordList wordList)
        {
            _db.WordLists.Add(wordList);
            _db.SaveChanges();
        }
    }
}