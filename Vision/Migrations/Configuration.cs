namespace Vision.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vision.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Vision.DataAccessLayer.VisionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Vision.DataAccessLayer.VisionContext context)
        {
            var divisions = new List<Division>
            {
                new Division{Name = "JTAC"}
            };
            divisions.ForEach(s => context.Divisions.AddOrUpdate(s));
            context.SaveChanges();
            var trainingTables = new List<TrainingTable>
            {
                new TrainingTable{Name = "IQT", DivisionId=1} 
            };
            trainingTables.ForEach(s => context.TrainingTables.AddOrUpdate(s));
            context.SaveChanges();
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
