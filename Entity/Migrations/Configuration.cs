namespace Entity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Entity.EntityDataModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Entity.EntityDataModel context)
        {
            context.Categories.AddOrUpdate(c => c.CategoryID,
                new Category() {CategoryName = "test1"});

            context.Regions.AddOrUpdate(r => r.RegionID,
                new Region() {RegionDescription = "test1"});

            context.Territories.AddOrUpdate(t => t.TerritoryID,
                new Territory() {TerritoryDescription = "test1", RegionID = 1});
        }
    }
}
