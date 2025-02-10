using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using InfoCom.Data.DefaultSeed;
using InfoCom.Model;
using Microsoft.EntityFrameworkCore;

namespace InfoCom.Data.InfoComDbContext
{
    public class ApplicationDbConfiguration
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().HasData(ScheduleSeed.DefaultScheduleSeed());
        }
    }
}
