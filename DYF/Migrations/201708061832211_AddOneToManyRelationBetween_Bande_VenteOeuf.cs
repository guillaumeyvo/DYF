namespace DYF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOneToManyRelationBetween_Bande_VenteOeuf : DbMigration
    {
        public override void Up()
        {
            AddColumn("VenteOeufs", "IdBande", c => c.Int(nullable: false));
            CreateIndex("VenteOeufs", "IdBande");
            AddForeignKey("VenteOeufs", "IdBande", "Bandes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("VenteOeufs", "IdBande", "Bandes");
            DropIndex("VenteOeufs", new[] { "IdBande" });
            DropColumn("VenteOeufs", "IdBande");
        }
    }
}
