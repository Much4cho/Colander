using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Colander.WordServices
{
    public class WordList
    {
        public int WordListID { get; set; }

        [Display(Name = "Word List Name")]
        public string WordListName { get; set; }

        public virtual List<Word> Words { get; set; }
    }
    public class Word
    {
        public int WordID { get; set; }
        public string WordOriginal { get; set; }
        public string WordTranslation { get; set; }


        public int WordListID { get; set; }
        public virtual WordList WordList { get; set; }


        public int? WordColanderID { get; set; }
        public virtual WordColander WordColander {get; set;}
    }
    public class WordColander
    {
        public int WordColanderID { get; set; }
        public virtual List<Word> Words { get; set; }
    }

    public class WordListDBContext : DbContext
    {
        public DbSet<WordList> WordLists { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordColander> WordColanders { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Word>().HasKey(word => word.WordID);
        //}
    }
}