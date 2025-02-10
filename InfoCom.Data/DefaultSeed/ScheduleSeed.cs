using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoCom.Models;

namespace InfoCom.Data.DefaultSeed
{
    public  class ScheduleSeed
    {
        public static List<Schedule> DefaultScheduleSeed()
        {
            List<Schedule> schedules = new List<Schedule>  {
            new Schedule()
            {
                    Id = 1,
                    Title = "DemoTitle",
                    Status = "BackLog",
                    Description = "I am Demo description",
                    CreatedAt = DateTime.Now,
                    DueDate = DateTime.Now,
            },
            new Schedule()
            {
                    Id = 2,
                    Title = "DemoTitle2",
                    Status ="ToDO",
                    Description = "I am Demo description two",
                    CreatedAt = DateTime.Now,
                    DueDate = DateTime.Now,
            },
            new Schedule()
            {
                    Id = 3,
                    Title = "DemoTiTle3",
                    Status = "InProgress",
                    Description = "I am Demo description three",
                    CreatedAt = DateTime.Now,
                    DueDate = DateTime.Now,
            },
            new Schedule()
            {
                    Id = 4,
                    Title = "DemoTiTle4",
                    Status = "Reviewing",
                    Description = "I am Demo description four",
                    CreatedAt = DateTime.Now,
                    DueDate = DateTime.Now,
            },
            new Schedule()
            {
                    Id = 5,
                    Title = "DemoTiTle5",
                    Status = "Revieving",
                    Description = "I am Demo description five",
                    CreatedAt = DateTime.Now,
                    DueDate = DateTime.Now,
            },
            new Schedule()
            {
                    Id = 6,
                    Title = "DemoTiTle6",
                    Status = "QATesting",
                    Description = "I am Demo description six",
                    CreatedAt = DateTime.Now,
                    DueDate = DateTime.Now,
            },
            };
            return schedules;
        }
    }
}
