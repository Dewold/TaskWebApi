namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedConnection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CareerHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HireDate = c.DateTime(nullable: false, storeType: "date"),
                        DismissalDate = c.DateTime(storeType: "date"),
                        EmployeeId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.HireDate)
                .Index(t => t.DismissalDate)
                .Index(t => t.EmployeeId)
                .Index(t => t.PositionId);

            CreateTable(
                "dbo.Employees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 70),
                    LastName = c.String(nullable: false, maxLength: 70),
                    Salary = c.Decimal(nullable: false, precision: 8, scale: 2, storeType: "numeric"),
                    CurrentPositionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.FirstName)
                .Index(t => t.LastName);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CareerHistories", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.CareerHistories", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "CurrentPositionId", "dbo.Positions");
            DropIndex("dbo.Positions", new[] { "Name" });
            DropIndex("dbo.Employees", new[] { "CurrentPositionId" });
            DropIndex("dbo.Employees", new[] { "LastName" });
            DropIndex("dbo.Employees", new[] { "FirstName" });
            DropIndex("dbo.CareerHistories", new[] { "PositionId" });
            DropIndex("dbo.CareerHistories", new[] { "EmployeeId" });
            DropIndex("dbo.CareerHistories", new[] { "DismissalDate" });
            DropIndex("dbo.CareerHistories", new[] { "HireDate" });
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
            DropTable("dbo.CareerHistories");
        }
    }
}
