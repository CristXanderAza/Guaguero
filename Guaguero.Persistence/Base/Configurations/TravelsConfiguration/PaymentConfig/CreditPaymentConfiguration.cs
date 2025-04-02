using Guaguero.Domain.Entities.Travels.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Persistence.Base.Configurations.TravelsConfiguration.PaymentConfig
{
    public class CreditPaymentConfiguration : IEntityTypeConfiguration<CreditPayment>
    {
        public void Configure(EntityTypeBuilder<CreditPayment> builder)
        {
           // throw new NotImplementedException();
        }
    }
}
