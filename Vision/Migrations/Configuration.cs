namespace Vision.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Administrator"))
            {
                roleManager.Create(new IdentityRole("Administrator"));
            }

            var user = new ApplicationUser { UserName = "testUser1" };


            if (userManager.FindByName("testUser1") == null)
            {
                var result = userManager.Create(user, "password");

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Administrator");
                }

            }
            context.SaveChanges();

            var trainigEventTypes = new List<TrainingEventType>
            {
                new TrainingEventType{Id = 1, Type="TestEventType"}
            };
            trainigEventTypes.ForEach(s => context.TrainingEventTypes.Add(s));
            context.SaveChanges();

            var trainingEvents = new List<TrainingEvent>
            {
                new TrainingEvent{MonthInterval = 6, Name = "Test Six Month Trainig Event 1",TrainingEventTypeId=1, DateCreated=DateTime.Now, Id=1},
                new TrainingEvent{MonthInterval = 6, Name = "Test Six Month Trainig Event 2",TrainingEventTypeId=1, DateCreated=DateTime.Now, Id=2},
                new TrainingEvent{MonthInterval = 12, Name = "Test Twelve Month Trainig Event 1",TrainingEventTypeId=1, DateCreated=DateTime.Now, Id=3},
                new TrainingEvent{MonthInterval = 12, Name = "Test Twelve Month Trainig Event 2",TrainingEventTypeId=1, DateCreated=DateTime.Now, Id=4}
            };
            trainingEvents.ForEach(s => context.TrainingEvents.AddOrUpdate(s));
            context.SaveChanges();

            var trainingCompletes = new List<TrainingCompleted>
            {
                new TrainingCompleted{UserId = user.Id, ApprovedByUserId = user.Id, DateCompleted = new DateTime(2014,01,01), TrainingEventId = trainingEvents.Single(t => t.Name=="Test Six Month Trainig Event 1").Id},
                new TrainingCompleted{UserId = user.Id, ApprovedByUserId = user.Id, DateCompleted = new DateTime(2014,05,01), TrainingEventId = trainingEvents.Single(t => t.Name=="Test Six Month Trainig Event 2").Id},
                new TrainingCompleted{UserId = user.Id, ApprovedByUserId = user.Id, DateCompleted = new DateTime(2014,01,01), TrainingEventId = trainingEvents.Single(t => t.Name=="Test Twelve Month Trainig Event 1").Id},
                new TrainingCompleted{UserId = user.Id, ApprovedByUserId = user.Id, DateCompleted = new DateTime(2014,05,01), TrainingEventId = trainingEvents.Single(t => t.Name=="Test Twelve Month Trainig Event 2").Id}
            };
            trainingCompletes.ForEach(s => context.TrainingCompleted.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
