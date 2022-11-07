using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Configurations
{
    public class OgrenciConfiguration : IEntityTypeConfiguration<Ogrenci>
    {
        public void Configure(EntityTypeBuilder<Ogrenci> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property<string>(x => x.Adi).IsRequired().HasMaxLength(100);
            builder.Property<string>(x => x.Soyadi).IsRequired().HasMaxLength(100);
            builder.ToTable("Ogrenciler");
        }
    }
}
