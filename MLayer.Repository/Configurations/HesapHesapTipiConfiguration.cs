using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using NLayer.Core.Entities;

namespace NLayer.Repository.Configurations
{
    public class HesapHesapTipiConfiguration : IEntityTypeConfiguration<HesapHesapTipi>
    {
        public void Configure(EntityTypeBuilder<HesapHesapTipi> builder)
        {
            builder.HasKey(x => new { x.HesapId, x.HesapTipiId });
        }
    }
}
