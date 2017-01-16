namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mod_date_Update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ToDoItems", "Modified", c => c.DateTime());
            AlterColumn("dbo.ToDoLists", "Modified", c => c.DateTime());
            AlterColumn("dbo.Users", "Modified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ToDoLists", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ToDoItems", "Modified", c => c.DateTime(nullable: false));
        }
    }
}
