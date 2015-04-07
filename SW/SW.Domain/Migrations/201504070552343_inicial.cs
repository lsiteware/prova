namespace SW.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromocaoAtivaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Promocao", t => t.PromocaoAtivaId)
                .Index(t => t.PromocaoAtivaId);
            
            CreateTable(
                "dbo.Promocao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        QuantidadeProdutos = c.Int(nullable: false),
                        TipoCobranca = c.Int(nullable: false),
                        ValorFixo = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "PromocaoAtivaId", "dbo.Promocao");
            DropIndex("dbo.Produto", new[] { "PromocaoAtivaId" });
            DropTable("dbo.Promocao");
            DropTable("dbo.Produto");
        }
    }
}
