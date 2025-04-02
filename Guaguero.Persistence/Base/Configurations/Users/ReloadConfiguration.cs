using Guaguero.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Persistence.Base.Configurations.Users
{
    public class ReloadConfiguration : IEntityTypeConfiguration<Reload>
    {
        public void Configure(EntityTypeBuilder<Reload> builder)
        {
            builder.HasKey(builder => builder.ReloadID);

            builder.Property(builder => builder.Amount)
                .HasColumnType("decimal(10,2)");

            builder.HasOne(builder => builder.CreditPerUser)
                .WithMany()
                .HasForeignKey(builder => builder.CreditID)
                .OnDelete(DeleteBehavior.NoAction); ;
        }
    }
}
