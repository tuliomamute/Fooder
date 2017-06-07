namespace Fooder.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CATEGORIAS",
                c => new
                    {
                        CATEGORIA_ID = c.Int(nullable: false),
                        NOME = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CATEGORIA_ID);
            
            CreateTable(
                "dbo.PRODUTOS",
                c => new
                    {
                        PRODUTO_ID = c.Int(nullable: false),
                        NOME = c.String(maxLength: 100, unicode: false),
                        CATEGORIA_ID = c.Int(),
                    })
                .PrimaryKey(t => t.PRODUTO_ID)
                .ForeignKey("dbo.CATEGORIAS", t => t.CATEGORIA_ID)
                .Index(t => t.CATEGORIA_ID);
            
            CreateTable(
                "dbo.ESTOQUE",
                c => new
                    {
                        PRODUTO_ID = c.Int(nullable: false),
                        MERCADO_ID = c.Int(nullable: false),
                        ULTIMA_ATUALIZACAO = c.String(maxLength: 20, unicode: false),
                        PRECO = c.Decimal(precision: 20, scale: 2),
                    })
                .PrimaryKey(t => new { t.PRODUTO_ID, t.MERCADO_ID })
                .ForeignKey("dbo.MERCADOS", t => t.MERCADO_ID)
                .ForeignKey("dbo.PRODUTOS", t => t.PRODUTO_ID)
                .Index(t => t.PRODUTO_ID)
                .Index(t => t.MERCADO_ID);
            
            CreateTable(
                "dbo.MERCADOS",
                c => new
                    {
                        MERCADO_ID = c.Int(nullable: false),
                        NOME = c.String(maxLength: 100, unicode: false),
                        MAPA = c.String(maxLength: 500, unicode: false),
                        URL = c.String(maxLength: 255, unicode: false),
                        URL_OFICIAL = c.String(maxLength: 255, unicode: false),
                        URL_MAPA = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.MERCADO_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ESTOQUE", "PRODUTO_ID", "dbo.PRODUTOS");
            DropForeignKey("dbo.ESTOQUE", "MERCADO_ID", "dbo.MERCADOS");
            DropForeignKey("dbo.PRODUTOS", "CATEGORIA_ID", "dbo.CATEGORIAS");
            DropIndex("dbo.ESTOQUE", new[] { "MERCADO_ID" });
            DropIndex("dbo.ESTOQUE", new[] { "PRODUTO_ID" });
            DropIndex("dbo.PRODUTOS", new[] { "CATEGORIA_ID" });
            DropTable("dbo.MERCADOS");
            DropTable("dbo.ESTOQUE");
            DropTable("dbo.PRODUTOS");
            DropTable("dbo.CATEGORIAS");
        }
    }
}
