namespace DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
