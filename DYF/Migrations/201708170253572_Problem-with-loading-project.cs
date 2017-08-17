namespace DYF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Problemwithloadingproject : DbMigration
    {
        public override void Up()
        {
            AddColumn("Pesees", "EcartType", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Pesees", "EcartType");
        }
    }
}
