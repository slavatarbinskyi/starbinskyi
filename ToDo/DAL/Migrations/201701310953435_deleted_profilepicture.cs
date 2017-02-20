using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
	public partial class deleted_profilepicture : DbMigration
	{
		public override void Up()
		{
			DropColumn("dbo.Users", "ProfilePicture");
		}

		public override void Down()
		{
			AddColumn("dbo.Users", "ProfilePicture", c => c.Binary());
		}
	}
}