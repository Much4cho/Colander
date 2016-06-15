﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Colander.WordService
{
    public class WordService : IWordService
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

        public void Add(Word word)
        {
            //word.AddDate = DateTime.UtcNow;
            //if (word.WordTranslation.Length >= 10)
            //{
            //    word.IsComplicated = true;
            //}

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

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            //base.Dispose(disposing);
        }
    }

    public interface IWordService
    {
        IEnumerable<Word> GetForListId(int? wordListId);
        Word GetForWordId(int? wordId);
        void Add(Word word);
        void Edit(Word word);
        void Delete(Word word);
    }
}