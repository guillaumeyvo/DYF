namespace DYF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Achats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrixUnitaire = c.Int(nullable: false),
                        Quantite = c.Int(nullable: false),
                        CoutTotal = c.Int(nullable: false),
                        MontantRegle = c.Int(nullable: false),
                        DateAchat = c.DateTime(nullable: false, precision: 0),
                        DateLivraison = c.DateTime(nullable: false, precision: 0),
                        Commentaires = c.String(unicode: false),
                        IdFournisseur = c.Int(nullable: false),
                        IdProduit = c.Int(nullable: false),
                        IdTypeProduit = c.Int(nullable: false),
                        MatierePremiere_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Fournisseurs", t => t.IdFournisseur, cascadeDelete: true)
                .ForeignKey("Produits", t => t.IdProduit, cascadeDelete: true)
                .ForeignKey("MatierePremieres", t => t.MatierePremiere_Id)
                .ForeignKey("TypeProduits", t => t.IdTypeProduit, cascadeDelete: true)
                .Index(t => t.IdFournisseur)
                .Index(t => t.IdProduit)
                .Index(t => t.MatierePremiere_Id)
                .Index(t => t.IdTypeProduit);
            
            CreateTable(
                "Fournisseurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(unicode: false),
                        Adresse = c.String(unicode: false),
                        Telephone = c.String(unicode: false),
                        DateAjout = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Produits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(unicode: false),
                        LibelleUnite = c.String(unicode: false),
                        IdTypeProduit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("TypeProduits", t => t.IdTypeProduit, cascadeDelete: true)
                .Index(t => t.IdTypeProduit);
            
            CreateTable(
                "CoutProduits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrixUnitaire = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        IdProduit = c.Int(nullable: false),
                        IdTypeProduit = c.Int(nullable: false),
                        IdFournisseur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Fournisseurs", t => t.IdFournisseur, cascadeDelete: true)
                .ForeignKey("Produits", t => t.IdProduit, cascadeDelete: true)
                .ForeignKey("TypeProduits", t => t.IdTypeProduit, cascadeDelete: true)
                .Index(t => t.IdFournisseur)
                .Index(t => t.IdProduit)
                .Index(t => t.IdTypeProduit);
            
            CreateTable(
                "TypeProduits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "HistoriqueUtilisationProduits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PourcentageUtilise = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        IdAchat = c.Int(nullable: false),
                        IdProduit = c.Int(nullable: false),
                        IdRepartitionBande = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Achats", t => t.IdAchat, cascadeDelete: true)
                .ForeignKey("Produits", t => t.IdProduit, cascadeDelete: true)
                .ForeignKey("RepartitionBandes", t => t.IdRepartitionBande, cascadeDelete: true)
                .Index(t => t.IdAchat)
                .Index(t => t.IdProduit)
                .Index(t => t.IdRepartitionBande);
            
            CreateTable(
                "RepartitionBandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EffectifInitial = c.Int(nullable: false),
                        EffectifActuel = c.Int(nullable: false),
                        TotalMortalite = c.Int(nullable: false),
                        Description = c.String(unicode: false),
                        Nom = c.String(unicode: false),
                        IdBande = c.Int(nullable: false),
                        IdBatiment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Bandes", t => t.IdBande, cascadeDelete: true)
                .ForeignKey("Batiments", t => t.IdBatiment, cascadeDelete: true)
                .Index(t => t.IdBande)
                .Index(t => t.IdBatiment);
            
            CreateTable(
                "Bandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EffectifInitial = c.Int(nullable: false),
                        DateArrivee = c.DateTime(nullable: false, precision: 0),
                        DateSortie = c.DateTime(nullable: false, precision: 0),
                        Nom = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        B_Actif = c.Boolean(nullable: false),
                        B_VenteTotale = c.Boolean(nullable: false),
                        IdTypeVolaille = c.Int(nullable: false),
                        IdRaceVolaille = c.Int(nullable: false),
                        IdAchat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Achats", t => t.IdAchat, cascadeDelete: true)
                .ForeignKey("RaceVolailles", t => t.IdRaceVolaille, cascadeDelete: true)
                .ForeignKey("TypeVolailles", t => t.IdTypeVolaille, cascadeDelete: true)
                .Index(t => t.IdAchat)
                .Index(t => t.IdRaceVolaille)
                .Index(t => t.IdTypeVolaille);
            
            CreateTable(
                "RaceVolailles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "TypeVolailles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Batiments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        B_Occupe = c.Boolean(nullable: false),
                        Effectif_Maximum = c.Int(nullable: false),
                        Description = c.String(unicode: false),
                        Nom = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Consommations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 0),
                        NombreDeKilos = c.Int(nullable: false),
                        CoutConsommation = c.Double(nullable: false),
                        IdRepartitionBande = c.Int(nullable: false),
                        IdProductionAliment = c.Int(nullable: false),
                        IdFormule = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Formules", t => t.IdFormule, cascadeDelete: true)
                .ForeignKey("ProductionAliments", t => t.IdProductionAliment, cascadeDelete: true)
                .ForeignKey("RepartitionBandes", t => t.IdRepartitionBande, cascadeDelete: true)
                .Index(t => t.IdFormule)
                .Index(t => t.IdProductionAliment)
                .Index(t => t.IdRepartitionBande);
            
            CreateTable(
                "Formules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantite = c.Int(nullable: false),
                        Nom = c.String(unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "MatierePremieres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(unicode: false),
                        Unite = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "ProductionAliments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreDeTonne = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        CoutDeRevientParSac = c.Double(nullable: false),
                        NombreDeSac = c.Int(nullable: false),
                        IdFormule = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Formules", t => t.IdFormule, cascadeDelete: true)
                .Index(t => t.IdFormule);
            
            CreateTable(
                "HistoriquePathologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateDebutPathologie = c.DateTime(nullable: false, precision: 0),
                        DateDebutTraitementPathologie = c.DateTime(nullable: false, precision: 0),
                        B_Curratif = c.Boolean(nullable: false),
                        IdPathologie = c.Int(nullable: false),
                        IdRepartitionBande = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Pathologies", t => t.IdPathologie, cascadeDelete: true)
                .ForeignKey("RepartitionBandes", t => t.IdRepartitionBande, cascadeDelete: true)
                .Index(t => t.IdPathologie)
                .Index(t => t.IdRepartitionBande);
            
            CreateTable(
                "Pathologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "TraitementPathologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdHistoriquePathologie = c.Int(nullable: false),
                        IdProduit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("HistoriquePathologies", t => t.IdHistoriquePathologie, cascadeDelete: true)
                .ForeignKey("Produits", t => t.IdProduit, cascadeDelete: true)
                .Index(t => t.IdHistoriquePathologie)
                .Index(t => t.IdProduit);
            
            CreateTable(
                "Mortalites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        IdRepartitionBande = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("RepartitionBandes", t => t.IdRepartitionBande, cascadeDelete: true)
                .Index(t => t.IdRepartitionBande);
            
            CreateTable(
                "Pesees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreDeSujetsPeses = c.Int(nullable: false),
                        PoidsMoyen = c.Double(nullable: false),
                        Homogeneite = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        EcartType = c.Double(nullable: false),
                        AgeDesSujetEnSemaine = c.Int(nullable: false),
                        IdRepartitionBande = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("RepartitionBandes", t => t.IdRepartitionBande, cascadeDelete: true)
                .Index(t => t.IdRepartitionBande);
            
            CreateTable(
                "ProductionOeufs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreDOeufs = c.Int(nullable: false),
                        NombreDOeufsCasses = c.Int(nullable: false),
                        IdRepartitionBande = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("RepartitionBandes", t => t.IdRepartitionBande, cascadeDelete: true)
                .Index(t => t.IdRepartitionBande);
            
            CreateTable(
                "VenteVolailles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreDeVolailles = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        PrixUnitaire = c.Double(nullable: false),
                        IdRepartitionBande = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("RepartitionBandes", t => t.IdRepartitionBande, cascadeDelete: true)
                .Index(t => t.IdRepartitionBande);
            
            CreateTable(
                "Dettes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateContractation = c.DateTime(nullable: false, precision: 0),
                        B_Actif = c.Boolean(nullable: false),
                        MontantInitial = c.Int(nullable: false),
                        IdAchat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Achats", t => t.IdAchat, cascadeDelete: true)
                .Index(t => t.IdAchat);
            
            CreateTable(
                "HistoriqueReglementDettes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateReglement = c.DateTime(nullable: false, precision: 0),
                        IdDette = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Dettes", t => t.IdDette, cascadeDelete: true)
                .Index(t => t.IdDette);
            
            CreateTable(
                "HistoriqueRepartitionBandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 0),
                        NombreDeSujetAjoute = c.Int(nullable: false),
                        IdBatiment = c.Int(nullable: false),
                        IdRepartitionBande = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Batiments", t => t.IdBatiment, cascadeDelete: true)
                .ForeignKey("RepartitionBandes", t => t.IdRepartitionBande, cascadeDelete: true)
                .Index(t => t.IdBatiment)
                .Index(t => t.IdRepartitionBande);
            
            CreateTable(
                "ReferencePoidsMoyens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgeEnSeamine = c.Int(nullable: false),
                        PoidsMoyen = c.Double(nullable: false),
                        IdRaceVolaille = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("RaceVolailles", t => t.IdRaceVolaille, cascadeDelete: true)
                .Index(t => t.IdRaceVolaille);
            
            CreateTable(
                "VenteOeufs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreDePlaquettes = c.Int(nullable: false),
                        NombreDOeuf = c.Int(nullable: false),
                        DateDeVente = c.DateTime(nullable: false, precision: 0),
                        PrixUnitaire = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "ProduitFournisseurs",
                c => new
                    {
                        Produit_Id = c.Int(nullable: false),
                        Fournisseur_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produit_Id, t.Fournisseur_Id })                
                .ForeignKey("Produits", t => t.Produit_Id, cascadeDelete: true)
                .ForeignKey("Fournisseurs", t => t.Fournisseur_Id, cascadeDelete: true)
                .Index(t => t.Produit_Id)
                .Index(t => t.Fournisseur_Id);
            
            CreateTable(
                "MatierePremiereFormules",
                c => new
                    {
                        MatierePremiere_Id = c.Int(nullable: false),
                        Formule_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MatierePremiere_Id, t.Formule_Id })                
                .ForeignKey("MatierePremieres", t => t.MatierePremiere_Id, cascadeDelete: true)
                .ForeignKey("Formules", t => t.Formule_Id, cascadeDelete: true)
                .Index(t => t.MatierePremiere_Id)
                .Index(t => t.Formule_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ReferencePoidsMoyens", "IdRaceVolaille", "RaceVolailles");
            DropForeignKey("HistoriqueRepartitionBandes", "IdRepartitionBande", "RepartitionBandes");
            DropForeignKey("HistoriqueRepartitionBandes", "IdBatiment", "Batiments");
            DropForeignKey("HistoriqueReglementDettes", "IdDette", "Dettes");
            DropForeignKey("Dettes", "IdAchat", "Achats");
            DropForeignKey("Achats", "IdTypeProduit", "TypeProduits");
            DropForeignKey("HistoriqueUtilisationProduits", "IdRepartitionBande", "RepartitionBandes");
            DropForeignKey("VenteVolailles", "IdRepartitionBande", "RepartitionBandes");
            DropForeignKey("ProductionOeufs", "IdRepartitionBande", "RepartitionBandes");
            DropForeignKey("Pesees", "IdRepartitionBande", "RepartitionBandes");
            DropForeignKey("Mortalites", "IdRepartitionBande", "RepartitionBandes");
            DropForeignKey("TraitementPathologies", "IdProduit", "Produits");
            DropForeignKey("TraitementPathologies", "IdHistoriquePathologie", "HistoriquePathologies");
            DropForeignKey("HistoriquePathologies", "IdRepartitionBande", "RepartitionBandes");
            DropForeignKey("HistoriquePathologies", "IdPathologie", "Pathologies");
            DropForeignKey("Consommations", "IdRepartitionBande", "RepartitionBandes");
            DropForeignKey("ProductionAliments", "IdFormule", "Formules");
            DropForeignKey("Consommations", "IdProductionAliment", "ProductionAliments");
            DropForeignKey("MatierePremiereFormules", "Formule_Id", "Formules");
            DropForeignKey("MatierePremiereFormules", "MatierePremiere_Id", "MatierePremieres");
            DropForeignKey("Achats", "MatierePremiere_Id", "MatierePremieres");
            DropForeignKey("Consommations", "IdFormule", "Formules");
            DropForeignKey("RepartitionBandes", "IdBatiment", "Batiments");
            DropForeignKey("Bandes", "IdTypeVolaille", "TypeVolailles");
            DropForeignKey("RepartitionBandes", "IdBande", "Bandes");
            DropForeignKey("Bandes", "IdRaceVolaille", "RaceVolailles");
            DropForeignKey("Bandes", "IdAchat", "Achats");
            DropForeignKey("HistoriqueUtilisationProduits", "IdProduit", "Produits");
            DropForeignKey("HistoriqueUtilisationProduits", "IdAchat", "Achats");
            DropForeignKey("ProduitFournisseurs", "Fournisseur_Id", "Fournisseurs");
            DropForeignKey("ProduitFournisseurs", "Produit_Id", "Produits");
            DropForeignKey("CoutProduits", "IdTypeProduit", "TypeProduits");
            DropForeignKey("Produits", "IdTypeProduit", "TypeProduits");
            DropForeignKey("CoutProduits", "IdProduit", "Produits");
            DropForeignKey("CoutProduits", "IdFournisseur", "Fournisseurs");
            DropForeignKey("Achats", "IdProduit", "Produits");
            DropForeignKey("Achats", "IdFournisseur", "Fournisseurs");
            DropIndex("ReferencePoidsMoyens", new[] { "IdRaceVolaille" });
            DropIndex("HistoriqueRepartitionBandes", new[] { "IdRepartitionBande" });
            DropIndex("HistoriqueRepartitionBandes", new[] { "IdBatiment" });
            DropIndex("HistoriqueReglementDettes", new[] { "IdDette" });
            DropIndex("Dettes", new[] { "IdAchat" });
            DropIndex("Achats", new[] { "IdTypeProduit" });
            DropIndex("HistoriqueUtilisationProduits", new[] { "IdRepartitionBande" });
            DropIndex("VenteVolailles", new[] { "IdRepartitionBande" });
            DropIndex("ProductionOeufs", new[] { "IdRepartitionBande" });
            DropIndex("Pesees", new[] { "IdRepartitionBande" });
            DropIndex("Mortalites", new[] { "IdRepartitionBande" });
            DropIndex("TraitementPathologies", new[] { "IdProduit" });
            DropIndex("TraitementPathologies", new[] { "IdHistoriquePathologie" });
            DropIndex("HistoriquePathologies", new[] { "IdRepartitionBande" });
            DropIndex("HistoriquePathologies", new[] { "IdPathologie" });
            DropIndex("Consommations", new[] { "IdRepartitionBande" });
            DropIndex("ProductionAliments", new[] { "IdFormule" });
            DropIndex("Consommations", new[] { "IdProductionAliment" });
            DropIndex("MatierePremiereFormules", new[] { "Formule_Id" });
            DropIndex("MatierePremiereFormules", new[] { "MatierePremiere_Id" });
            DropIndex("Achats", new[] { "MatierePremiere_Id" });
            DropIndex("Consommations", new[] { "IdFormule" });
            DropIndex("RepartitionBandes", new[] { "IdBatiment" });
            DropIndex("Bandes", new[] { "IdTypeVolaille" });
            DropIndex("RepartitionBandes", new[] { "IdBande" });
            DropIndex("Bandes", new[] { "IdRaceVolaille" });
            DropIndex("Bandes", new[] { "IdAchat" });
            DropIndex("HistoriqueUtilisationProduits", new[] { "IdProduit" });
            DropIndex("HistoriqueUtilisationProduits", new[] { "IdAchat" });
            DropIndex("ProduitFournisseurs", new[] { "Fournisseur_Id" });
            DropIndex("ProduitFournisseurs", new[] { "Produit_Id" });
            DropIndex("CoutProduits", new[] { "IdTypeProduit" });
            DropIndex("Produits", new[] { "IdTypeProduit" });
            DropIndex("CoutProduits", new[] { "IdProduit" });
            DropIndex("CoutProduits", new[] { "IdFournisseur" });
            DropIndex("Achats", new[] { "IdProduit" });
            DropIndex("Achats", new[] { "IdFournisseur" });
            DropTable("MatierePremiereFormules");
            DropTable("ProduitFournisseurs");
            DropTable("VenteOeufs");
            DropTable("ReferencePoidsMoyens");
            DropTable("HistoriqueRepartitionBandes");
            DropTable("HistoriqueReglementDettes");
            DropTable("Dettes");
            DropTable("VenteVolailles");
            DropTable("ProductionOeufs");
            DropTable("Pesees");
            DropTable("Mortalites");
            DropTable("TraitementPathologies");
            DropTable("Pathologies");
            DropTable("HistoriquePathologies");
            DropTable("ProductionAliments");
            DropTable("MatierePremieres");
            DropTable("Formules");
            DropTable("Consommations");
            DropTable("Batiments");
            DropTable("TypeVolailles");
            DropTable("RaceVolailles");
            DropTable("Bandes");
            DropTable("RepartitionBandes");
            DropTable("HistoriqueUtilisationProduits");
            DropTable("TypeProduits");
            DropTable("CoutProduits");
            DropTable("Produits");
            DropTable("Fournisseurs");
            DropTable("Achats");
        }
    }
}
