using Guaguero.Domain.Entities.Sindicatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


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
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Reloads)
                .WithOne()
                .HasForeignKey(r => r.CreditID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Customer)
                .WithOne(c => c.Credit)
                .HasForeignKey<CreditPerUser>(c => c.CustomerID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
