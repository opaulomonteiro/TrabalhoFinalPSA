namespace LeilaoWebPersistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leilao",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Natureza = c.String(),
                        Forma = c.String(),
                        DataDeInicio = c.DateTime(nullable: false),
                        DataDeFim = c.DateTime(nullable: false),
                        LanceMinimo = c.Double(nullable: false),
                        LanceMaximo = c.Double(nullable: false),
                        Lote_ID = c.Int(),
                        Usuario_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lote", t => t.Lote_ID)
                .ForeignKey("dbo.Usuario", t => t.Usuario_ID)
                .Index(t => t.Lote_ID)
                .Index(t => t.Usuario_ID);
            
            CreateTable(
                "dbo.Lote",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BreveDescricao = c.String(),
                        DescricaoCompleta = c.String(),
                        Categoria = c.String(),
                        Lote_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lote", t => t.Lote_ID)
                .Index(t => t.Lote_ID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Cnpj = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leilao", "Usuario_ID", "dbo.Usuario");
            DropForeignKey("dbo.Leilao", "Lote_ID", "dbo.Lote");
            DropForeignKey("dbo.Produto", "Lote_ID", "dbo.Lote");
            DropIndex("dbo.Produto", new[] { "Lote_ID" });
            DropIndex("dbo.Leilao", new[] { "Usuario_ID" });
            DropIndex("dbo.Leilao", new[] { "Lote_ID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Produto");
            DropTable("dbo.Lote");
            DropTable("dbo.Leilao");
        }
    }
}
