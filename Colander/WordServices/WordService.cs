using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Colander.WordServices
{
    public class WordService : IWordService
    {
        private IWordRepository _wordRepository;

        public WordService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }


        public IEnumerable<Word> GetForListId(int? wordListId)
        {
            return _wordRepository.GetForListId(wordListId);
        }
        public IEnumerable<Word> GetForGuessedRight(int? wordListId)
        {
            return _wordRepository.GetForGuessedRight(wordListId);
        }
        public Word GetForWordId(int? wordId)
        {
            return _wordRepository.GetForWordId(wordId);
        }

        public void Add(Word word)
        {
            //word.AddDate = DateTime.UtcNow;
            //if (word.WordTranslation.Length >= 10)
            //{
            //    word.IsComplicated = true;
            //}
            word.WordColanderID = 1;
            word.Created = DateTime.UtcNow;
            //_wordRepository.AddColander((int)word.WordColanderID);
            _wordRepository.Add(word);
        }
        public void Edit(Word word)
        {
            _wordRepository.Edit(word);
        }
        public void Delete(Word word)
        {
            _wordRepository.Delete(word);
        }
    }

    public interface IWordService
    {
        IEnumerable<Word> GetForListId(int? wordListId);
        IEnumerable<Word> GetForGuessedRight(int? wordListId);
        Word GetForWordId(int? wordId);
        void Add(Word word);
        void Edit(Word word);
        void Delete(Word word);
    }
}