namespace SW.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valor_fixo_promocao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promocao", "ValorFixo", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promocao", "ValorFixo");
        }
    }
}
