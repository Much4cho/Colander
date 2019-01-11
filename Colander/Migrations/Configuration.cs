namespace Colander.Migrations
{
    using Colander.Migrations.Seeder;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WordServices.ColanderDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Colander.WordService.WordListDBContext";
        }

        protected override void Seed(WordServices.ColanderDBContext context)
        {
            if (context.Words.Any()) return;

            IList<ISeeder> seeders = new List<ISeeder>
            {
                new EnglishAgh2019()
            };

            foreach (var seeder in seeders)
            {
                seeder.Seed(context);
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.WordLists.AddOrUpdate(w => w.WordListName,
            //    new WordService.WordList
            //    {
            //        WordListName = "EN Sports",
            //        Words 
            //    },
            //    new WordService.WordList
            //    {
            //        WordListName = ""
            //    }
            
            //);
        }
    }
}
