namespace LeilaoWebPersistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criação : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leilao",
                c => new
                    {
                        LeilaoID = c.Int(nullable: false, identity: true),
                        Natureza = c.String(),
                        Forma = c.String(),
                        DataDeInicio = c.DateTime(nullable: false),
                        DataDeFim = c.DateTime(nullable: false),
                        LanceMinimo = c.Double(nullable: false),
                        LanceMaximo = c.Double(nullable: false),
                        Lote_LoteID = c.Int(),
                        Usuario_UsuarioID = c.Int(),
                    })
                .PrimaryKey(t => t.LeilaoID)
                .ForeignKey("dbo.Lote", t => t.Lote_LoteID)
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioID)
                .Index(t => t.Lote_LoteID)
                .Index(t => t.Usuario_UsuarioID);
            
            CreateTable(
                "dbo.Lote",
                c => new
                    {
                        LoteID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.LoteID);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BreveDescricao = c.String(),
                        DescricaoCompleta = c.String(),
                        Categoria = c.String(),
                        Lote_LoteID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lote", t => t.Lote_LoteID)
                .Index(t => t.Lote_LoteID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Cnpj = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leilao", "Usuario_UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Leilao", "Lote_LoteID", "dbo.Lote");
            DropForeignKey("dbo.Produto", "Lote_LoteID", "dbo.Lote");
            DropIndex("dbo.Produto", new[] { "Lote_LoteID" });
            DropIndex("dbo.Leilao", new[] { "Usuario_UsuarioID" });
            DropIndex("dbo.Leilao", new[] { "Lote_LoteID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Produto");
            DropTable("dbo.Lote");
            DropTable("dbo.Leilao");
        }
    }
}
