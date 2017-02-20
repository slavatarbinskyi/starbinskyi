using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
	public partial class added_inviteusers : DbMigration
	{
		public override void Up()
		{
			CreateTable(
					"dbo.InviteUsers",
					c => new
					{
						Id = c.Int(false, true),
						Email = c.String(),
						GuidId = c.String()
					})
				.PrimaryKey(t => t.Id);
		}

		public override void Down()
		{
			DropTable("dbo.InviteUsers");
		}
	}
}