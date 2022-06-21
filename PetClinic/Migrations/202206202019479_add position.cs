namespace PetClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addposition : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Position_PositionId", "dbo.Positions");
            DropIndex("dbo.AspNetUsers", new[] { "Position_PositionId" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Position_PositionId", newName: "PositionId");
            AlterColumn("dbo.AspNetUsers", "PositionId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "PositionId");
            AddForeignKey("dbo.AspNetUsers", "PositionId", "dbo.Positions", "PositionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PositionId", "dbo.Positions");
            DropIndex("dbo.AspNetUsers", new[] { "PositionId" });
            AlterColumn("dbo.AspNetUsers", "PositionId", c => c.Int());
            RenameColumn(table: "dbo.AspNetUsers", name: "PositionId", newName: "Position_PositionId");
            CreateIndex("dbo.AspNetUsers", "Position_PositionId");
            AddForeignKey("dbo.AspNetUsers", "Position_PositionId", "dbo.Positions", "PositionId");
        }
    }
}
