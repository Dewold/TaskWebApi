namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "CurrentPositionId", "dbo.Positions");
            DropForeignKey("dbo.CareerHistories", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CareerHistories", "PositionId", "dbo.Positions");
            DropIndex("dbo.Employees", new[] { "CurrentPositionId" });
            AddForeignKey("dbo.CareerHistories", "EmployeeId", "dbo.Employees", "Id");
            AddForeignKey("dbo.CareerHistories", "PositionId", "dbo.Positions", "Id");
            DropColumn("dbo.Employees", "CurrentPositionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "CurrentPositionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CareerHistories", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.CareerHistories", "EmployeeId", "dbo.Employees");
            CreateIndex("dbo.Employees", "CurrentPositionId");
            AddForeignKey("dbo.CareerHistories", "PositionId", "dbo.Positions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CareerHistories", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "CurrentPositionId", "dbo.Positions", "Id", cascadeDelete: true);
        }
    }
}
