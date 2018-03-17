namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addingGenreRecords : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(Name)Values('Comedy')");
            Sql("Insert into Genres(Name)Values('Action')");
            Sql("Insert into Genres(Name)Values('Family')");
            Sql("Insert into Genres(Name)Values('Romance')");
            Sql("Insert into Genres(Name)Values('Horror')");
        }

        public override void Down()
        {
        }
    }
}
