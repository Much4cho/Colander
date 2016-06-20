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
        private List<Word> currentSession = new List<Word>();
        private List<Word> gotRightDuringThisSession = new List<Word>();

        public ColanderEngine(IWordColanderService colanderService, IWordService wordService)
        {
            _colanderService = colanderService;
            _wordService = wordService;
            _colanderService.CreateColanderLists();
        }
        public void CreateNowColander(int? id)
        {
            TimeSpan colanderFactor;
            foreach (var word in _wordService.GetForListId(id))
            {
                switch (word.WordColanderID)
                {
                    case 0:
                        colanderFactor = TimeSpan.FromDays(1);
                        break;
                    case 1:
                        colanderFactor = TimeSpan.FromDays(2);
                        break;
                    case 2:
                        colanderFactor = TimeSpan.FromDays(3);
                        break;
                    case 3:
                        colanderFactor = TimeSpan.FromDays(5);
                        break;
                    case 4:
                        colanderFactor = TimeSpan.FromDays(8);
                        break;
                    case 5:
                        colanderFactor = TimeSpan.FromDays(13);
                        break;
                    case 6:
                        colanderFactor = TimeSpan.FromDays(21);
                        break;
                    case 7:
                        colanderFactor = TimeSpan.FromDays(34);
                        break;
                    case 8:
                        colanderFactor = TimeSpan.FromDays(55);
                        break;
                    case 9:
                        colanderFactor = TimeSpan.FromDays(89);
                        break;
                    default:
                        colanderFactor = TimeSpan.FromDays(1);
                        break;
                }
                if (word.GuessedRight==null || DateTime.UtcNow - (DateTime)word.GuessedRight > colanderFactor)
                {
                    currentSession.Add(word);
                }
            }
        }

        public Word ColanderRandomize(int? id)
        {
            Random random = new Random();
            Word word = null;

            while (currentSession.Any() && word == null)
            {
                word = currentSession.ElementAt(random.Next(currentSession.Count()));
            }

            return word;
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

        public void AddToGotRightList(Word word)
        {
            gotRightDuringThisSession.Add(word);
        }

        public void MoveUp()
        {
            foreach (var item in gotRightDuringThisSession)
            {
                item.WordColanderID++;
            }
        }
        public void MoveWord(Word word, int id)
        {
            word.WordColanderID = id;
        }

        public bool Check(Word Original, string Translation)
        {
            bool outcome;
            if (Original.WordTranslation.ToLower() == Translation.ToLower())
            {
                Original.GuessedRight = DateTime.UtcNow;
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
        void CreateNowColander(int? id);
        Word ColanderRandomize(int? id);
        Word Randomize(int? id);
        void AddToGotRightList(Word word);
        void MoveUp();
        void MoveWord(Word word, int id);
        bool Check(Word Original, string Translation);
    }
}