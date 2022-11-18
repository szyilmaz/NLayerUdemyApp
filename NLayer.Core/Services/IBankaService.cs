using NLayer.Core.DTOs;
using NLayer.Core.Entities;

namespace NLayer.Core.Services
{
    public interface IBankaService : IService<Banka>
    {
        Task<List<DetailedHareketDto>> GetHareketler(int MusteriId, int HareketTipId);
        decimal GetHareketToplam(int MusteriId, int HareketTipId);
        Task<decimal> GetBakiye(int MusteriId);
        Task<List<string>> GetSubeTipi_LokasyonMusteriDovizGrupluHareketToplami(int SubeTipiID);
        Task<List<string>> GetHesapTipleri_AyYilGrupluHareketToplami(List<int> HesapTipleri);
        Task<List<string>> GetTarih_MusteriLokasyonBakiye(DateTime Tarih);
        Task<List<string>> HesapTipiDovizTipi_SubeVeyaLokasyonBazliHesapToplamlari(int HesapTipiId, int DovizTipiId, int SubeLokasyon);
        Task<List<string>> TarihBanka_DovizHesapTipiGrupluBakiye(DateTime Tarih, int BankaId);
        Task<List<string>> HesapTipiDoviz_LokasyonIcinHesabindaEnCokParaOlanMusteriler(int HesapTipi, int DovizTipiId);
    }
}