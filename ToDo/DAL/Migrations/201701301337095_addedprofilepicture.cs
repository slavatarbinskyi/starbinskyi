using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
	public partial class addedprofilepicture : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.Users", "ProfilePicture", c => c.Binary());
		}

		public override void Down()
		{
			DropColumn("dbo.Users", "ProfilePicture");
		}
	}
}