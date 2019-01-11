namespace Colander.Migrations.Seeder
{
    interface ISeeder
    {
        void Seed(WordServices.ColanderDBContext context);
    }
}
