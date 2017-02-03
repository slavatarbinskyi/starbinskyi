namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_tags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagToDoLists",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        ToDoList_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.ToDoList_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.ToDoLists", t => t.ToDoList_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.ToDoList_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagToDoLists", "ToDoList_Id", "dbo.ToDoLists");
            DropForeignKey("dbo.TagToDoLists", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagToDoLists", new[] { "ToDoList_Id" });
            DropIndex("dbo.TagToDoLists", new[] { "Tag_Id" });
            DropTable("dbo.TagToDoLists");
            DropTable("dbo.Tags");
        }
    }
}
