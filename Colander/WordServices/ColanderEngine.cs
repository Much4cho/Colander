using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colander.WordServices
{
    public class ColanderEngine : IColanderEngine
    {
        //private IWordColanderRepository _colanderRepository;

        //public ColanderEngine(IWordColanderRepository colanderRepository)
        //{
        //    _colanderRepository = colanderRepository;
        //}

        private IWordColanderService _colanderService;
        private IWordService _wordService;

        public ColanderEngine(IWordColanderService colanderService, IWordService wordService)
        {
            _colanderService = colanderService;
            _wordService = wordService;
            _colanderService.CreateColanderLists();
        }
        public Word Randomize(int? id)
        {
            Random random = new Random();
            var words = _wordService.GetForListId(id);
            Word word = null;

            while (words.Any() && word == null)
            {
                word = words.ElementAt(random.Next(words.Count()));
            }

            return word;
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
                Original.GuessedRight = DateTime.Now;
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
        Word Randomize(int? id);
        void Move(Word word, int id);
        bool Check(Word Original, string Translation);
    }
}