namespace cho500.Migrations
{
    using Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<cho500.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(cho500.Models.ApplicationDbContext context)
        {
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

            //context.BloodTypes.AddOrUpdate(
            //    B => B.Name,
            //    new BloodTypes { Name = "O-" },
            //    new BloodTypes { Name = "O+" },
            //    new BloodTypes { Name = "A-" },
            //    new BloodTypes { Name = "A+" },
            //    new BloodTypes { Name = "B-" },
            //    new BloodTypes { Name = "B+" },
            //    new BloodTypes { Name = "AB-" },
            //    new BloodTypes { Name = "AB+" }
            //    );
            //context.SaveChanges();
        }
    }
}
