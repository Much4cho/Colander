using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Colander.WordServices
{
    public class WordListRepository : IWordListRepository
    {
        private WordListDBContext _db;

        public WordListRepository()
        {
            _db = new WordListDBContext();
        }


        public IEnumerable<WordList> ShowLists()
        {
            return _db.WordLists.ToList();
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
        public void Dispose()
        {
            _db.Dispose();
        }
        
    }

    public interface IWordListRepository
    {
        WordList GetById(int id);
        IEnumerable<WordList> ShowLists();
        void Add(WordList wordList);
        void Edit(WordList wordList);
        void Delete(WordList wordList);

    }
}