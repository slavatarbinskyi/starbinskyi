using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
	public partial class fix_cr : DbMigration
	{
		public override void Up()
		{
			DropColumn("dbo.Tags", "Created");
		}

		public override void Down()
		{
			AddColumn("dbo.Tags", "Created", c => c.DateTime(false));
		}
	}
}