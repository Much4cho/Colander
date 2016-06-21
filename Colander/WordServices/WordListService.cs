using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Colander.WordServices
{
    public class WordListService : IWordListService
    {
        private IWordListRepository _wordListRepository;

        public WordListService(IWordListRepository wordListRepository)
        {
            _wordListRepository = wordListRepository;
        }


        public IEnumerable<WordList> ShowLists()
        {
            return _wordListRepository.ShowLists();
        }
        public WordList GetById(int id)
        {
            return _wordListRepository.GetById(id);
        }

        public void Add(WordList wordList)
        {
            _wordListRepository.Add(wordList);
        }
        public void Edit(WordList wordList)
        {
            _wordListRepository.Edit(wordList);
        }
        public void Delete(WordList wordList)
        {
            _wordListRepository.Delete(wordList);
        }
    }

    public interface IWordListService
    {
        WordList GetById(int id);
        IEnumerable<WordList> ShowLists();
        void Add(WordList wordList);
        void Edit(WordList wordList);
        void Delete(WordList wordList);
    }

}