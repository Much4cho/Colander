using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colander.WordService
{
    public class Business : IBusiness
    {
        public IEnumerable<IEnumerable<Word>> ColanderSystem;

        public Business()
        {

        }


        public void Move(Word word, List<Word> GCList)
        {

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

    public interface IBusiness
    {
        void Move(Word word, List<Word> GCList);
        bool Check(Word Original, string Translation);
    }
}