namespace DevContactDirectory.Migrations
{
    using DevContactDirectory.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DevContactDirectory.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DevContactDirectory.Models.ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category() { Name = "Frontend Developer" });
                context.Categories.Add(new Category() { Name = "Backend Developer" });
                context.SaveChanges();
            }

            if (context.Categories.Any() && !context.Developers.Any())
            {
                var cat = context.Categories.FirstOrDefault();
                context.Developers.Add(new Developer() { Firstname= "Victor", Lastname ="Bolum", CategoryId = cat.Id, Email = "victorbolum@yahoo.com"});
                context.SaveChanges();
            }
        }
    }
}
