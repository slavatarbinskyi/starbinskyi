namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delet_manyconfig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagToDoLists", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagToDoLists", "ToDoList_Id", "dbo.ToDoLists");
            DropIndex("dbo.TagToDoLists", new[] { "Tag_Id" });
            DropIndex("dbo.TagToDoLists", new[] { "ToDoList_Id" });
            DropTable("dbo.TagToDoLists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagToDoLists",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        ToDoList_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.ToDoList_Id });
            
            CreateIndex("dbo.TagToDoLists", "ToDoList_Id");
            CreateIndex("dbo.TagToDoLists", "Tag_Id");
            AddForeignKey("dbo.TagToDoLists", "ToDoList_Id", "dbo.ToDoLists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TagToDoLists", "Tag_Id", "dbo.Tags", "Id", cascadeDelete: true);
        }
    }
}
