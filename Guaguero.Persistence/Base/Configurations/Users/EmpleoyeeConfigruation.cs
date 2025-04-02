using Guaguero.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Guaguero.Persistence.Base.Configurations.Users
{
    public class EmpleoyeeConfigruation : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(e => e.Sindicato)
                .WithMany()
                .HasForeignKey(e => e.SindicatoID)
                .OnDelete(DeleteBehavior.NoAction); ;
        }
    }
}
