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
                .HasForeignKey(q => q.TravelID);

            builder.HasOne(t => t.Employee)
                .WithMany()
                .HasForeignKey(t => t.EmpleoyeeID);

            builder.HasOne(t => t.Route)
                .WithMany(r => r.Travels)
                .HasForeignKey(t => t.RouteID);
        }
    }
}
