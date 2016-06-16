using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colander.WordServices
{
    public class ColanderEngine : IColanderEngine
    {
        public IEnumerable<IEnumerable<Word>> ColanderSystem;

        public ColanderEngine()
        {
            var 
        }


        public void Move(Word word, int id)
        {
            word.WordColanderID = id;
        }

        public bool Check(Word Original, string Translation)
        {
            bool outcome;
            if (Original.WordTranslation.ToLower() == Translation.ToLower())
            {
                outcome = true;
            }
            else
            {
                outcome = false;
            }
            return outcome;
        }
        
    }

    public interface IColanderEngine
    {
        void Move(Word word, int id);
        bool Check(Word Original, string Translation);
    }
}