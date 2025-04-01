using Guaguero.Domain.Entities.Logistic.Routes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Guaguero.Domain.Entities.Sindicatos;
using System.Reflection.Emit;

namespace Guaguero.Persistence.Base.Configurations.Logistic
{
    public class WayPointConfiguration : IEntityTypeConfiguration<WayPoint>
    {
        public void Configure(EntityTypeBuilder<WayPoint> builder)
        { 
            builder.HasKey(wp => wp.WayPointID);
            builder.Property(wp => wp.StepIndex)
                .IsRequired();

            builder.HasIndex(wp => wp.StepIndex);



            // Almacenar Coordinate en columnas separadas
            builder.OwnsOne(wp => wp.Coordinate, c =>
            {
                c.Property (p => p.Lat)
                  .HasColumnName("WayPoint_Lat")
                  .HasColumnType("decimal(9,6)");

                c.Property(p => p.Lng)
                  .HasColumnName("WayPoint_Lng")
                  .HasColumnType("decimal(9,6)");
            });
        }
    }
}
