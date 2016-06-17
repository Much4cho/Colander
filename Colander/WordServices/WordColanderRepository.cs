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

        public IEnumerable<Word> GetForColanderId(int? wordColanderId)
        {
            return _db.WordColanders.First(list => list.WordColanderID == wordColanderId).Words;
        }
        public void Add(WordColander colander)
        {
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
        IEnumerable<Word> GetForColanderId(int? wordColanderId);
        void Add(WordColander colander);
        void Delete(WordColander colander);

    }
}