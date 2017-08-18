namespace DYF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Model_DetailPesee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "DetailsPesees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Poids = c.Int(nullable: false),
                        NombreDeSujets = c.Int(nullable: false),
                        IdPesee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Pesees", t => t.IdPesee, cascadeDelete: true)
                .Index(t => t.IdPesee);
            
        }
        
        public override void Down()
        {
            DropForeignKey("DetailsPesees", "IdPesee", "Pesees");
            DropIndex("DetailsPesees", new[] { "IdPesee" });
            DropTable("DetailsPesees");
        }
    }
}
