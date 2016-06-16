using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colander.WordService
{
    public class ColanderRepository : WordRepository, IColanderRepository
    {
        public IEnumerable<Word> GetWordsForSession()
        {

            //return null;
        }
    }
    public interface IColanderRepository : IWordRepository
    {
        IEnumerable<Word> GetWordsForSession();
    }
   
}