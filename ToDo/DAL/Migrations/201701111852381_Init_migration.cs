using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
	public partial class Init_migration : DbMigration
	{
		public override void Up()
		{
			CreateTable(
					"dbo.ToDoItems",
					c => new
					{
						Id = c.Int(false, true),
						Text = c.String(),
						Priority = c.Int(false),
						IsCompleted = c.Boolean(false),
						IsNotify = c.Boolean(false),
						NextNotifyTime = c.DateTime(false),
						Created = c.DateTime(false),
						Modified = c.DateTime(false),
						ToDoList_Id = c.Int(false)
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.ToDoLists", t => t.ToDoList_Id, true)
				.Index(t => t.ToDoList_Id);

			CreateTable(
					"dbo.ToDoLists",
					c => new
					{
						Id = c.Int(false, true),
						Name = c.String(),
						Created = c.DateTime(false),
						Modified = c.DateTime(false),
						User_Id = c.Int()
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Users", t => t.User_Id)
				.Index(t => t.User_Id);

			CreateTable(
					"dbo.Users",
					c => new
					{
						Id = c.Int(false, true),
						UserName = c.String(false),
						Password = c.String(),
						Email = c.String(false),
						Created = c.DateTime(false),
						Modified = c.DateTime(false)
					})
				.PrimaryKey(t => t.Id);
		}

		public override void Down()
		{
			DropForeignKey("dbo.ToDoLists", "User_Id", "dbo.Users");
			DropForeignKey("dbo.ToDoItems", "ToDoList_Id", "dbo.ToDoLists");
			DropIndex("dbo.ToDoLists", new[] {"User_Id"});
			DropIndex("dbo.ToDoItems", new[] {"ToDoList_Id"});
			DropTable("dbo.Users");
			DropTable("dbo.ToDoLists");
			DropTable("dbo.ToDoItems");
		}
	}
}