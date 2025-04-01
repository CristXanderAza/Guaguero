using Guaguero.Domain.Entities.Sindicatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Guaguero.Persistence.Base.Configurations.SindicatoConfigurations
{
    public class BusConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(b => b.BusID);
            
            builder.HasMany(b => b.Travels)
                .WithOne(t => t.Bus)
                .HasForeignKey(t => t.BusID);

            
        }
    }
}
