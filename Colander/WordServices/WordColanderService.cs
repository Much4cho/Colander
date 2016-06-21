using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colander.WordServices
{
    public class WordColanderService : IWordColanderService
    {
        private IWordColanderRepository _colanderRepository;
        public WordColanderService(IWordColanderRepository colanderRepository)
        {
            _colanderRepository = colanderRepository;
        }

        public void CreateColanderLists()
        {
                for (int i = 1; i < 11; i++)
                {
                    if (!_colanderRepository.DoesColanderExist(i))
                    {
                        _colanderRepository.Add(i); 
                    }
                }
        }
    }
    public interface IWordColanderService
    {
        void CreateColanderLists();
    }
}