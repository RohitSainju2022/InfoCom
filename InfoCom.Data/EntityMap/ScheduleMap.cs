using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoCom.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoCom.Data.EntityMap
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired(false).HasMaxLength(255).HasColumnType("nvarchar"); ;
            builder.Property(x => x.Description).IsRequired(false).HasColumnType("nvarchar(max)"); ;
            builder.Property(x => x.Status).IsRequired(false).HasMaxLength(50).HasColumnType("nvarchar");
            builder.Property(x => x.CreatedAt).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.DueDate).IsRequired(false).HasColumnType("datetime");
            builder.Property(x => x.IsDeleted).HasAnnotation("DefaultValue", "false");

        }
    }
}
