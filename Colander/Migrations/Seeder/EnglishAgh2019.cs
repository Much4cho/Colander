using Colander.WordServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WordCol = Colander.WordServices.WordColander;

namespace Colander.Migrations.Seeder
{
    public class EnglishAgh2019 : ISeeder
    {
        public void Seed(ColanderDBContext context)
        {
            var wordColander = new WordCol();

            var list = new WordList
            {
                WordListName = "Angielski AGH 2019 B2",
                Words = new List<Word>()
            };

            using (var fileStream = new FileStream(@"C:\Code\Colander\Colander\Migrations\Seeder\agh.txt", FileMode.Open, FileAccess.Read))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var splitted = line.Split('-');

                    list.Words.Add(new Word
                    {
                        WordColanderID = 1,
                        Created = DateTime.UtcNow,
                        WordOriginal = splitted[0],
                        WordTranslation = splitted[1]
                    });
                }
            }

            context.WordColanders.Add(wordColander);
            context.WordLists.Add(list);
        }
    }
}