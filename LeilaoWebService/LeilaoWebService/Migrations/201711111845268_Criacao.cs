namespace LeilaoWebService.Migrations
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
                        LeilaoID = c.Int(nullable: false, identity: true),
                        Natureza = c.String(),
                        Forma = c.String(),
                        DataDeInicio = c.DateTime(nullable: false),
                        DataDeFim = c.DateTime(nullable: false),
                        LanceMinimo = c.Double(nullable: false),
                        LanceMaximo = c.Double(nullable: false),
                        Usuario_UsuarioID = c.Int(),
                    })
                .PrimaryKey(t => t.LeilaoID)
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioID)
                .Index(t => t.Usuario_UsuarioID);
            
            CreateTable(
                "dbo.Lote",
                c => new
                    {
                        LoteID = c.Int(nullable: false, identity: true),
                        Leilao_LeilaoID = c.Int(),
                    })
                .PrimaryKey(t => t.LoteID)
                .ForeignKey("dbo.Leilao", t => t.Leilao_LeilaoID)
                .Index(t => t.Leilao_LeilaoID);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        BreveDescricao = c.String(),
                        DescricaoCompleta = c.String(),
                        Categoria = c.String(),
                        Lote_LoteID = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoID)
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
            DropForeignKey("dbo.Lote", "Leilao_LeilaoID", "dbo.Leilao");
            DropForeignKey("dbo.Produto", "Lote_LoteID", "dbo.Lote");
            DropIndex("dbo.Produto", new[] { "Lote_LoteID" });
            DropIndex("dbo.Lote", new[] { "Leilao_LeilaoID" });
            DropIndex("dbo.Leilao", new[] { "Usuario_UsuarioID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Produto");
            DropTable("dbo.Lote");
            DropTable("dbo.Leilao");
        }
    }
}
