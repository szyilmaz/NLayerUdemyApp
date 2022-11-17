using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Repositories;
using System.Linq;

namespace NLayer.Service.Services
{
    public class BankaService : Service<Banka>, IBankaService
    {
        private readonly IGenericRepository<Banka> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBankaRepository _bankaRepository;

        public BankaService(IGenericRepository<Banka> repository, IUnitOfWork unitOfWork, IMapper mapper, IBankaRepository bankaRepository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bankaRepository = bankaRepository;
        }

        public async Task<List<DetailedHareketDto>> GetHareketler(int MusteriId, int HareketTipId)
        {
            var query = _bankaRepository.GetHareketler();

            query = query.Where(c => c.MusteriId == MusteriId && (HareketTipId > 0 ? c.HareketTipId == HareketTipId : 1 == 1)).OrderBy(c=>c.HareketTarihi);

            var hareketler = await query.ToListAsync();

            var dtos = _mapper.Map<List<DetailedHareketDto>>(hareketler);

            return dtos;
        }

        public decimal GetHareketToplam(int MusteriId, int HareketTipId)
        {
            var query = _bankaRepository.GetHareketler();

            query = query.Where(c => c.MusteriId == MusteriId && c.HareketTipId == HareketTipId).OrderBy(c => c.HareketTarihi);

            decimal bakiye = query.Sum(c => c.Tutar);

            return bakiye;
        }

        public async Task<decimal> GetBakiye(int MusteriId)
        {
            var query = _bankaRepository.GetHareketler();

            var sonuc = await query.Where(c=>c.MusteriId == MusteriId).GroupBy(c => c.HareketTipId).Select(g => new { TipId = g.Key, Tutar = g.Sum(x => x.Tutar)}).ToListAsync();

            decimal giris = sonuc.Where(c => c.TipId == 3).FirstOrDefault().Tutar;
            decimal cikis = sonuc.Where(c => c.TipId == 4).FirstOrDefault().Tutar;

            return giris - cikis;
        }

        public async Task<decimal> GetSomething(int MusteriId)
        {
            var query = _bankaRepository.GetHareketler();

            var sonuc = await query.Where(c => c.MusteriId == MusteriId).GroupBy(c => c.HareketTipId).Select(g => new { TipId = g.Key, Tutar = g.Sum(x => x.Tutar) }).ToListAsync();

            decimal giris = sonuc.Where(c => c.TipId == 3).FirstOrDefault().Tutar;
            decimal cikis = sonuc.Where(c => c.TipId == 4).FirstOrDefault().Tutar;

            return giris - cikis;
        }

        public async Task<decimal> GetSubeTipi_LokasyonMusteriDovizGrupluHareketToplami(int SubeTipiID)
        {
            var query = _bankaRepository.GetHareketler();

            var sonuc = await query
                .Where(c => c.SubeTipiId == SubeTipiID)
                .GroupBy(c => new 
                { 
                    c.LokasyonId, 
                    c.MusteriId, 
                    c.DovizTipiId 
                })
                .Select(g => new 
                { 
                    TipId = g.Key, 
                    Tutar = g.Sum(x => x.Tutar) 
                })
                .ToListAsync();
            return sonuc.Sum(c=>c.Tutar);
        }

        public async Task<decimal> GetHesapTipleri_AyYilGrupluHareketToplami(List<int> HesapTipleri)
        {
            var query = _bankaRepository.GetHareketler();

            var sonuc = await query
                .Where(c => c.HesapTipleri.)
                .GroupBy(c => new
                {
                    c.HareketTarihi.Month,
                    c.HareketTarihi.Year,
                })
                .Select(g => new
                {
                    TipId = g.Key,
                    Tutar = g.Sum(x => x.Tutar)
                })
                .ToListAsync();
            return sonuc.Sum(c => c.Tutar);
        }
    }
}
