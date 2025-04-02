using Guaguero.Domain.Entities.Sindicatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Guaguero.Persistence.Base.Configurations.SindicatoConfigurations
{
    public class SindicatoConfiguraction : IEntityTypeConfiguration<Sindicato>
    {
        public void Configure(EntityTypeBuilder<Sindicato> builder)
        {
            builder.HasKey(s => s.SindicatoID);
            builder.HasIndex(s => s.Name);

            builder.HasMany(s => s.Buses)
                .WithOne(b => b.Sindicato)
                .HasForeignKey(b => b.SindicatoID)
                .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasMany(s => s.Routes)
                 .WithMany(r => r.Sindicatos)
                 .UsingEntity(j => j.ToTable("SindicatoRoutes"));   
        }
    }
}
