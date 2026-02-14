using FluentMigrator;

namespace Routinner.Infrastructure.Migrations.Versions;

[Migration(DatabaseVersions.TABLE_ROUTINE, "Create table to create routine")]
public class Version02 : VersionsBase
{
    public override void Up()
    {
        CreateTable("Routines")
           .WithColumn("Name").AsString(255).NotNullable()
           .WithColumn("StartDate").AsDate().NotNullable()
           .WithColumn("EndDate").AsDate().NotNullable();
    }
}
