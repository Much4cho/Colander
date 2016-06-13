using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Colander.WordService
{
    public class WordListService : IWordListService
    {
        private WordListDBContext _db;

        public WordListService()
        {
            _db = new WordListDBContext();
        }


        public void ShowLists()
        {
            _db.WordLists.ToList();
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
        public void Edit(WordList wordList)
        {
            _db.Entry(wordList).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void Delete(WordList wordList)
        {
            _db.WordLists.Remove(wordList);
            _db.SaveChanges();
        }
    }

    public interface IWordListService
    {
        WordList GetById(int id);
        void Add(WordList wordList);
        void Edit(WordList wordList);
        void Delete(WordList wordList);
    }

}