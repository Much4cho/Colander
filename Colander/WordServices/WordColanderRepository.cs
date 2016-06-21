using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colander.WordServices
{
    public class WordColanderRepository : IWordColanderRepository
    {
        private ColanderDBContext _db;
        public WordColanderRepository()
        {
            _db = new ColanderDBContext();
        }


        public IEnumerable<WordColander> ShowColanders()
        {
            return _db.WordColanders.ToList();
        }
        public IEnumerable<Word> GetForColanderId(int? wordColanderId)
        {
            return _db.WordColanders.First(list => list.WordColanderID == wordColanderId).Words;
        }
        public bool DoesColanderExist(int colanderId)
        {
            if (_db.WordColanders.Find(colanderId) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public void Add(int id)
        {
            var colander = new WordColander() { WordColanderID = id};
            _db.WordColanders.Add(colander);
            _db.SaveChanges();
        }
        public void Delete(WordColander colander)
        {
            _db.WordColanders.Remove(colander);
            _db.SaveChanges();
        }
        void Dispose()
        {
            _db.Dispose();
        }
    }
    public interface IWordColanderRepository
    {
        IEnumerable<WordColander> ShowColanders();
        IEnumerable<Word> GetForColanderId(int? wordColanderId);
        bool DoesColanderExist(int colanderId);
        void Add(int id);
        void Delete(WordColander colander);
    }
}