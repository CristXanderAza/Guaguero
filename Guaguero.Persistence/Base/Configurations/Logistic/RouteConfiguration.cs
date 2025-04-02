using Guaguero.Domain.Entities.Logistic.Routes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Persistence.Base.Configurations.Logistic
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasKey(r => r.RouteID);

            builder.Property(r => r.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(r => r.Description)
                   .HasMaxLength(500);

            builder.Property(r => r.Origin)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(r => r.Destination)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(r => r.GeoJSON)
                   .HasColumnType("nvarchar(max)"); // Para almacenar datos geoespaciales en formato JSON

            builder.Property(r => r.Distance)
                   .HasColumnType("decimal(10,2)");

            builder.Property(r => r.Duration)
                   .HasColumnType("decimal(10,2)");

            // Relación One-to-Many con WayPoints
            builder.HasMany(r => r.WayPoints)
                   .WithOne()
                   .HasForeignKey(wp => wp.RouteID)
                   .OnDelete(DeleteBehavior.NoAction);

            // Configuración para Coordinate como Owned Entity
            builder.OwnsOne(r => r.OriginPoint, op =>
            {
                op.Property(c => c.Lat)
                  .HasColumnName("Origin_Lat")
                  .HasColumnType("decimal(9,6)");
                op.Property(c => c.Lng)
                  .HasColumnName("Origin_Lng")
                  .HasColumnType("decimal(9,6)");
            });

            builder.OwnsOne(r => r.DestinationPoint, dp =>
            {
                dp.Property(c => c.Lat)
                  .HasColumnName("Destination_Lat")
                  .HasColumnType("decimal(9,6)");

                dp.Property(c => c.Lng)
                  .HasColumnName("Destination_Lng")
                  .HasColumnType("decimal(9,6)");
            });
        }
    }
}
