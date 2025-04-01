using Guaguero.Domain.Entities.Sindicatos;
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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasOne(c => c.Discount)
                .WithMany()
                .HasForeignKey(c => c.DiscountID);

            builder.HasOne(c => c.Credit)
                .WithOne()
                .HasForeignKey<CreditPerUser>(c => c.CustomerID);
        }
    }
}
