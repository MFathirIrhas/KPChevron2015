using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using KPChevron2015.Models;

namespace KPChevron2015.DAL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DataContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Well> Wells { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<GeneralParameter> GeneralParameters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //base.OnModelCreating(modelBuilder);
        }

    }
}