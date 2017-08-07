namespace DYF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_TypePesee_Entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TypePesees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            AddColumn("Pesees", "IdTypePesee", c => c.Int(nullable: false));
            CreateIndex("Pesees", "IdTypePesee");
            AddForeignKey("Pesees", "IdTypePesee", "TypePesees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Pesees", "IdTypePesee", "TypePesees");
            DropIndex("Pesees", new[] { "IdTypePesee" });
            DropColumn("Pesees", "IdTypePesee");
            DropTable("TypePesees");
        }
    }
}
