using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace Routinner.Infrastructure.Migrations.Versions;

public abstract class VersionsBase : ForwardOnlyMigration
{
    protected ICreateTableColumnOptionOrWithColumnSyntax CreateTable(string table)
    {
        return Create.Table(table)
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("CreateOn").AsDateTime().NotNullable();
    }
}
