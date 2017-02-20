using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
	public partial class Added_createdToTagToDoLists : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.TagToDoLists", "Created", c => c.DateTime(false, defaultValueSql: "GETUTCDATE()"));
		}

		public override void Down()
		{
			DropColumn("dbo.TagToDoLists", "Created");
		}
	}
}