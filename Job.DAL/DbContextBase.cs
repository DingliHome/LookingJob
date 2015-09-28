using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Job.DAL.Maps;
using Job.Model.Entities;

namespace Job.DAL
{
    public class DbContextBase : DbContext
    {
        static DbContextBase()
        {
            Database.SetInitializer<DbContextBase>(new CreateDatabaseIfNotExists<DbContextBase>());
        }
        public DbContextBase():base("jobConnectionString")
        {

        }

        public DbSet<JobInfo> JobInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new JobInfoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
