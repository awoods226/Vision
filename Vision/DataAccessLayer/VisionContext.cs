using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Vision.Models;

namespace Vision.DataAccessLayer
{
    public class VisionContext : IdentityDbContext<ApplicationUser>
    {
        public VisionContext()
            : base("VisionContext")
        {

        }
        public DbSet<TrainingEvent> TrainingEvents { get; set; }
        public DbSet<TrainingEventType> TrainingEventTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}