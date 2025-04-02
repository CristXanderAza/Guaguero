using Guaguero.Domain.Entities.Logistic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Persistence.Base.Configurations.Users
{
    public class DiscountSolicitudConfiguration : IEntityTypeConfiguration<DiscountSolicitud>
    {
        public void Configure(EntityTypeBuilder<DiscountSolicitud> builder)
        {
            builder.HasKey(d => d.SolicitudID);
            
            builder.HasOne(d => d.Discount)
                .WithMany()
                .HasForeignKey(d => d.SolicitudID)
                .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(d => d.Customer)
                .WithOne()
                .HasForeignKey<DiscountSolicitud>(d => d.CustomerID)
                .OnDelete(DeleteBehavior.NoAction); ;


        }
    }
}
