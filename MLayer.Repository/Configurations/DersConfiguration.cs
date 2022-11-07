using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Configurations
{
    public class DersConfiguration : IEntityTypeConfiguration<Ders>
    {
        public void Configure(EntityTypeBuilder<Ders> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property<string>(x => x.Adi).IsRequired().HasMaxLength(100);
            builder.ToTable("Dersler");
        }
    }
}
