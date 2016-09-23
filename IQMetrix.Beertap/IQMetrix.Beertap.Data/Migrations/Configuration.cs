using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeertapContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BeertapContext context)
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
            //context.Offices.AddOrUpdate(
            //    o => o.Id,
            //    new Office() { Id = 1, Name = "Vancouver", Location = "Vancouver, Canada" },
            //    new Office() { Id = 2, Name = "Regina", Location = "Regina, Canada" },
            //    new Office() { Id = 3, Name = "Winnipeg", Location = "Winnipeg, Canada" },
            //    new Office() { Id = 4, Name = "Davidson", Location = "North Carolina" },
            //    new Office() { Id = 5, Name = "Manila", Location = "Manila, Philippines" },
            //    new Office() { Id = 6, Name = "Sydney", Location = "Sydney, Australia" }
            //    );

            //context.Kegs.AddOrUpdate(
            //    o => o.Id,
            //    new Keg() { Id = 1, KegState = KegState.New, Capacity = 5000, Remaining = 5000, Content = "Draft Beer", OfficeId = 1 },
            //    new Keg() { Id = 2, KegState = KegState.New, Capacity = 5000, Remaining = 5000, Content = "Draft Beer", OfficeId = 2 },
            //    new Keg() { Id = 3, KegState = KegState.New, Capacity = 5000, Remaining = 5000, Content = "Draft Beer", OfficeId = 3 },
            //    new Keg() { Id = 4, KegState = KegState.New, Capacity = 5000, Remaining = 5000, Content = "Draft Beer", OfficeId = 4 },
            //    new Keg() { Id = 5, KegState = KegState.New, Capacity = 5000, Remaining = 5000, Content = "Draft Beer", OfficeId = 5 },
            //    new Keg() { Id = 6, KegState = KegState.New, Capacity = 5000, Remaining = 5000, Content = "Draft Beer", OfficeId = 6 }
            //    );
        }
    }
}
