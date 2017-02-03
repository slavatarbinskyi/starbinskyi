namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rel_man_to_man : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagToDoLists",
                c => new
                    {
                        TagId = c.Int(nullable: false),
                        ToDoListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.ToDoListId })
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.ToDoLists", t => t.ToDoListId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.ToDoListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagToDoLists", "ToDoListId", "dbo.ToDoLists");
            DropForeignKey("dbo.TagToDoLists", "TagId", "dbo.Tags");
            DropIndex("dbo.TagToDoLists", new[] { "ToDoListId" });
            DropIndex("dbo.TagToDoLists", new[] { "TagId" });
            DropTable("dbo.TagToDoLists");
        }
    }
}
