using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WebApp.Data.Entities;

namespace WebApp.DBContext
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Context : DbContext, IObjectContextAdapter
    {
        public Context() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Person> People { get; set; }
    }
}