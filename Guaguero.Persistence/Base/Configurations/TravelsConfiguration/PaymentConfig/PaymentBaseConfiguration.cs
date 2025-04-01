using Guaguero.Domain.Entities.Travels.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Persistence.Base.Configurations.TravelsConfiguration.PaymentConfig
{
    public class PaymentBaseConfiguration : IEntityTypeConfiguration<PaymentBase>
    {
        public void Configure(EntityTypeBuilder<PaymentBase> builder)
        {
             builder
             .HasDiscriminator<string>("TipoPago")
             .HasValue<EfectivePayment>("Efectivo")
             .HasValue<CreditPayment>("Balance");

            builder.HasKey(p => p.PaymentID);
        }
    }
}
