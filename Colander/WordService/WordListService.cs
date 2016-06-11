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

    public class WordService
    {
        private WordListDBContext _db;
        //public int? CurrentListID { get; set; }

        public WordService()
        {
            _db = new WordListDBContext();
        }

        public IEnumerable<Word> GetForListId(int? wordListId)
        {

            return _db.WordLists.First(list => list.WordListID == wordListId).Words;

            //return _db.WordLists.Find(wordListId).Words;
        }
        public Word GetForWordId(int? wordId)
        {
            return _db.Words.Find(wordId);
        }
    }
}