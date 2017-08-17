namespace DYF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removing_field_ecarty_type : DbMigration
    {
        public override void Up()
        {
            DropColumn("Pesees", "EcartType");
        }
        
        public override void Down()
        {
            AddColumn("Pesees", "EcartType", c => c.Double(nullable: false));
        }
    }
}
