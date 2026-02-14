using FluentMigrator;

namespace Routinner.Infrastructure.Migrations.Versions;

[Migration(DatabaseVersions.USER_ID_FOR_ROUTINE, "Add user id column in routine table.")]
public class Version03 : VersionsBase
{
    public override void Up()
    {
        Alter.Table("Routines").AddColumn("UserId").AsInt64().Nullable();
    }
}
