using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colander.WordService
{
    public class CoalnderEngine : IColander
    {
        public IEnumerable<IEnumerable<Word>> ColanderSystem;

        public ColanderEngine()
        {

        }


        public void Move(Word word, int id)
        {
            word.ColanderID = id;
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