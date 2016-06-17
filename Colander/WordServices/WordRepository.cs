using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Colander.WordServices
{
    public class WordRepository : IWordRepository
    {
        private WordListDBContext _db;

        public WordRepository()
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

        public void Add(Word word)
        {
            _db.Words.Add(word);
            _db.SaveChanges();
        }

        public void Edit(Word word)
        {
            _db.Entry(word).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void Delete(Word word)
        {
            _db.Words.Remove(word);
            _db.SaveChanges();
        }
        void Dispose()
        {
            _db.Dispose();
        }
        public void AddColander(int id)
        {
            if ((_db.WordColanders.Find(id) == null))
            {
                _db.WordColanders.Add(new WordColander() { WordColanderID = id});
                _db.SaveChanges();
            }
        }
    }
    public interface IWordRepository
    {
        IEnumerable<Word> GetForListId(int? wordListId);
        Word GetForWordId(int? wordId);
        void Add(Word word);
        void Edit(Word word);
        void Delete(Word word);
        void AddColander(int id);
    }
}