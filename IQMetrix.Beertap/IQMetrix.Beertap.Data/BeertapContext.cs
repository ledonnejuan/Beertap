using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQMetrix.Beertap.Data.Migrations;
using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.Data
{
    public class BeertapContext : DbContext
    {
        public BeertapContext() : base("name=BeertapConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BeertapContext, Configuration>("BeertapConnectionString"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Office> Offices { get; set; }
        public DbSet<Keg> Kegs { get; set; }
        public DbSet<BeerMug> BeerMugs { get; set; }
    }
}
