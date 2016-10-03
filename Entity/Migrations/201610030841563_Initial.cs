namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            RenameTable("Region", "Regions");

            CreateTable("dbo.CreditCards",
                c => new
                {
                    Number = c.Int(nullable: false, identity: true),
                    ExpiryDate = c.DateTime(),
                    CardHolder = c.String(maxLength: 200),
                    EmployeeID = c.Int(nullable: false)
                })
                .PrimaryKey(t => t.Number)
                .ForeignKey("dbo.Employees", t => t.EmployeeID);

            AddColumn("dbo.Employees", "BasedDate", d => d.DateTime());
        }
        
        public override void Down()
        {
            RenameTable("Regions", "Region");

            DropTable("dbo.CreditCard");

            DropColumn("dbo.Employees", "BasedDate");
        }
    }
}
