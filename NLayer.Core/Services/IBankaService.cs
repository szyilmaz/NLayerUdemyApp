using NLayer.Core.DTOs;
using NLayer.Core.Entities;

namespace NLayer.Core.Services
{
    public interface IBankaService : IService<Banka>
    {
        Task<List<DetailedHareketDto>> GetHareketler(int MusteriId, int HareketTipId);
        decimal GetHareketToplam(int MusteriId, int HareketTipId);
        Task<decimal> GetBakiye(int MusteriId);
        Task<decimal> GetSubeTipi_LokasyonMusteriDovizGrupluHareketToplami(int SubeTipiID);
    }
}
