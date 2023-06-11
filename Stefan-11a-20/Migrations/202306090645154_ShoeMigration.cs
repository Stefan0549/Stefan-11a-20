namespace Stefan_11a_20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoeMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Size = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Discription = c.String(),
                        ShoeType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShoeTypes", t => t.ShoeType_Id)
                .Index(t => t.ShoeType_Id);
            
            CreateTable(
                "dbo.ShoeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shoes", "ShoeType_Id", "dbo.ShoeTypes");
            DropIndex("dbo.Shoes", new[] { "ShoeType_Id" });
            DropTable("dbo.ShoeTypes");
            DropTable("dbo.Shoes");
        }
    }
}
