using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
	public partial class added_created_tags : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.Tags", "Created", c => c.DateTime(false));
		}

		public override void Down()
		{
			DropColumn("dbo.Tags", "Created");
		}
	}
}