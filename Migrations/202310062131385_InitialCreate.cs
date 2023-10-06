namespace ninja_challenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Alpha2Code = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Alpha2Code);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Countries");
        }
    }
}
