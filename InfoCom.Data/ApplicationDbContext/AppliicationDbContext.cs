using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using InfoCom.Data.EntityMap;
using InfoCom.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCom.Data.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }
        public virtual DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ScheduleMap());
            ApplicationDbConfiguration.Seed(modelBuilder);
        }
    }
}
