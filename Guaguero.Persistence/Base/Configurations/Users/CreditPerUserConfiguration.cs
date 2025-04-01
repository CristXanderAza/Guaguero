using Guaguero.Domain.Entities.Sindicatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Persistence.Base.Configurations.Users
{
    public class CreditPerUserConfiguration : IEntityTypeConfiguration<CreditPerUser>
    {
        public void Configure(EntityTypeBuilder<CreditPerUser> builder)
        {
            builder.HasKey(c => c.CreditPerUserID);

            builder.Property(c => c.Amount)
                .HasColumnType("decimal(10,2)");

            builder.HasMany(c => c.Payments)
                .WithOne(p => p.CreditPerUser)
                .HasForeignKey(p => p.CreditPerUserID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Reloads)
                .WithOne()
                .HasForeignKey(r => r.CreditID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
