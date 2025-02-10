using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoCom.Data.DefaultSeed;
using InfoCom.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCom.Data.ApplicationDbContext
{
    public class ApplicationDbConfiguration
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().HasData(ScheduleSeed.DefaultScheduleSeed());
        }
    }
}
