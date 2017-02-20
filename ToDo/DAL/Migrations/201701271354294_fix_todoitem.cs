using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
	public partial class fix_todoitem : DbMigration
	{
		public override void Up()
		{
			AlterColumn("dbo.ToDoItems", "Priority", c => c.Int());
			AlterColumn("dbo.ToDoItems", "IsNotify", c => c.Boolean());
			AlterColumn("dbo.ToDoItems", "NextNotifyTime", c => c.DateTime());
		}

		public override void Down()
		{
			AlterColumn("dbo.ToDoItems", "NextNotifyTime", c => c.DateTime(false));
			AlterColumn("dbo.ToDoItems", "IsNotify", c => c.Boolean(false));
			AlterColumn("dbo.ToDoItems", "Priority", c => c.Int(false));
		}
	}
}