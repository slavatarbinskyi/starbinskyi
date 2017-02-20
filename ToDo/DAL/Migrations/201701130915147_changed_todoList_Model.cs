using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
	public partial class changed_todoList_Model : DbMigration
	{
		public override void Up()
		{
			DropForeignKey("dbo.ToDoLists", "User_Id", "dbo.Users");
			DropIndex("dbo.ToDoLists", new[] {"User_Id"});
			AlterColumn("dbo.ToDoLists", "User_Id", c => c.Int(false));
			CreateIndex("dbo.ToDoLists", "User_Id");
			AddForeignKey("dbo.ToDoLists", "User_Id", "dbo.Users", "Id", true);
		}

		public override void Down()
		{
			DropForeignKey("dbo.ToDoLists", "User_Id", "dbo.Users");
			DropIndex("dbo.ToDoLists", new[] {"User_Id"});
			AlterColumn("dbo.ToDoLists", "User_Id", c => c.Int());
			CreateIndex("dbo.ToDoLists", "User_Id");
			AddForeignKey("dbo.ToDoLists", "User_Id", "dbo.Users", "Id");
		}
	}
}