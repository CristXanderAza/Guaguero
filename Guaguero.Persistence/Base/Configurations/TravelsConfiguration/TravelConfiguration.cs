using Guaguero.Domain.Entities.Travels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Persistence.Base.Configurations.TravelsConfiguration
{
    public class TravelConfiguration : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> builder)
        {
            builder.HasKey(t => t.TravelID);

            builder.HasMany(t => t.Quotas)
                .WithOne(q => q.Travel)
                .HasForeignKey(q => q.TravelID)
                .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(t => t.Employee)
                .WithMany()
                .HasForeignKey(t => t.EmpleoyeeID)
                .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(t => t.Route)
                .WithMany(r => r.Travels)
                .HasForeignKey(t => t.RouteID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.NearestWayPoint)
                .WithMany()
                .HasForeignKey(t => t.NearestWayPointID);

            builder.OwnsOne(wp => wp.ActualLocation, c =>
            {
                c.Property(p => p.Lat)
                  .HasColumnName("Actual_Lat")
                  .HasColumnType("decimal(9,6)");

                c.Property(p => p.Lng)
                  .HasColumnName("Actual_Lng")
                  .HasColumnType("decimal(9,6)");
            });
        }
    }
}
