namespace ninja_challenge.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<deathwing696.Bd>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "deathwing696.Bd";
        }

        protected override void Seed(deathwing696.Bd context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
