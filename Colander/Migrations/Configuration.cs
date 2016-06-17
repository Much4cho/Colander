namespace Colander.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Colander.WordServices.ColanderDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Colander.WordService.WordListDBContext";
        }

        protected override void Seed(Colander.WordServices.ColanderDBContext context)
        {
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
