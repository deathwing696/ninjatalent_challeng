namespace ninja_challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioModelo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Countries", "Name", c => c.String());
            AddColumn("dbo.Countries", "Alpha3Code", c => c.String());
            AddColumn("dbo.Countries", "Capital", c => c.String());
            AddColumn("dbo.Countries", "Region", c => c.String());
            AddColumn("dbo.Countries", "NativeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Countries", "NativeName");
            DropColumn("dbo.Countries", "Region");
            DropColumn("dbo.Countries", "Capital");
            DropColumn("dbo.Countries", "Alpha3Code");
            DropColumn("dbo.Countries", "Name");
        }
    }
}
