using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
	public partial class upd_created : DbMigration
	{
		public override void Up()
		{
			AlterColumn("dbo.ToDoItems", "Created", c => c.DateTime(false, defaultValueSql: "GETUTCDATE()"));
			AlterColumn("dbo.ToDoLists", "Created", c => c.DateTime(false, defaultValueSql: "GETUTCDATE()"));
			AlterColumn("dbo.Users", "Created", c => c.DateTime(false, defaultValueSql: "GETUTCDATE()"));
		}

		public override void Down()
		{
			AlterColumn("dbo.Users", "Created", c => c.DateTime(false));
			AlterColumn("dbo.ToDoLists", "Created", c => c.DateTime(false));
			AlterColumn("dbo.ToDoItems", "Created", c => c.DateTime(false));
		}
	}
}