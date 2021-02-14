namespace SmartLab.Identity.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartLab.Identity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SmartLab.Identity.Models.ApplicationDbContext context)
        {
            var identityRole = new IdentityRole("LaboratoryWorker");

            context.Roles.AddOrUpdate(identityRole);
        }
    }
}
