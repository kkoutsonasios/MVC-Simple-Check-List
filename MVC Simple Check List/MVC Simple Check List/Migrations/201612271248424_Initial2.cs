namespace MVC_Simple_Check_List.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CheckListItems", "CheckList_Id", c => c.Int());
            CreateIndex("dbo.CheckListItems", "CheckList_Id");
            AddForeignKey("dbo.CheckListItems", "CheckList_Id", "dbo.CheckLists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckListItems", "CheckList_Id", "dbo.CheckLists");
            DropIndex("dbo.CheckListItems", new[] { "CheckList_Id" });
            DropColumn("dbo.CheckListItems", "CheckList_Id");
            DropTable("dbo.CheckLists");
        }
    }
}
