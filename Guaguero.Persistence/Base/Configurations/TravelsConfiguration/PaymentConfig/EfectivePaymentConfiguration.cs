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
    public class EfectivePaymentConfiguration : IEntityTypeConfiguration<EfectivePayment>
    {
        public void Configure(EntityTypeBuilder<EfectivePayment> builder)
        {
            //throw new NotImplementedException();
        }
    }
}
