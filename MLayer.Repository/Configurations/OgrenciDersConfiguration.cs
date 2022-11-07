using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Configurations
{
    public class OgrenciDersConfiguration : IEntityTypeConfiguration<OgrenciDers>
    {
        public void Configure(EntityTypeBuilder<OgrenciDers> builder)
        {
            builder.HasKey(x => new { x.OgrenciId, x.DersId });
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Ogrenci).WithMany(y => y.OgrenciDersleri).HasForeignKey(z => z.OgrenciId);
            builder.HasOne(x => x.Ders).WithMany(y => y.DersOgrencileri).HasForeignKey(z => z.DersId);
        }
    }
}
