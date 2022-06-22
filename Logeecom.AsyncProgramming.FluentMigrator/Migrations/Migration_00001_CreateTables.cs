using FluentMigrator;

namespace Logeecom.AsyncProgramming.FluentMigrator.Migrations
{
    [Migration(1, "Create tables")]
    public class Migration_00001_CreateTables : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Awards")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable();

            Create.Table("Directors")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Film_count").AsInt32().NotNullable();

            Create.Table("Genres")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable();

            Create.Table("Actors")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Film_count").AsInt32().NotNullable();

            Create.Table("Films")
               .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
               .WithColumn("Name").AsString().NotNullable()
               .WithColumn("Country").AsString().NotNullable()
               .WithColumn("Year").AsInt32().NotNullable()
               .WithColumn("GenreId").AsGuid().NotNullable().ForeignKey("Genres", "Id")
               .WithColumn("DirectorId").AsGuid().NotNullable().ForeignKey("Awards", "Id")
               .WithColumn("AwardId").AsGuid().Nullable().ForeignKey("Directors", "Id");

            Create.Table("Acts")
                .WithColumn("ActorId").AsGuid().NotNullable().ForeignKey("Actors", "Id")
                .WithColumn("FilmId").AsGuid().NotNullable().ForeignKey("Films", "Id");

            Create.PrimaryKey().OnTable("Acts").Columns("ActorId", "FilmId");
        }
    }
}