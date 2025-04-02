using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Entities.Travels.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Persistence.Base.Configurations.TravelsConfiguration
{
    public class QuotaConfiguration : IEntityTypeConfiguration<Quota>
    {
        public void Configure(EntityTypeBuilder<Quota> builder)
        {
            builder.HasKey(q => q.QuotaID);
            builder.HasIndex(q => q.TravelID);
            builder.HasIndex(Q => Q.EntryStep);

            builder.HasOne(q => q.Customer)
                .WithMany(c => c.Quotas)
                .HasForeignKey(q => q.CustomerID)
                .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(q => q.Payment)
                .WithOne(p => p.Quota)
                .HasForeignKey<PaymentBase>(p => p.PaymentID)
                .OnDelete(DeleteBehavior.NoAction); ;


        }
    }
    
}
