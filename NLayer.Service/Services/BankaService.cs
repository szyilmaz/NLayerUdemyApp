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
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

            query = query.Where(c => c.MusteriId == MusteriId && (HareketTipId > 0 ? c.HareketTipId == HareketTipId : 1 == 1)).OrderBy(c => c.HareketTarihi);

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

            var sonuc = await query.Where(c => c.MusteriId == MusteriId).GroupBy(c => c.HareketTipId).Select(g => new { TipId = g.Key, Tutar = g.Sum(x => x.Tutar) }).ToListAsync();

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

        public async Task<List<string>> GetSubeTipi_LokasyonMusteriDovizGrupluHareketToplami(int SubeTipiID)
        {
            var query = _bankaRepository.GetHareketler();

            var sonuc = await query
                .Where(c => c.SubeTipiId == SubeTipiID)
                .GroupBy(c => new
                {
                    c.SubeTipiAdi,
                    c.LokasyonId,
                    c.LokasyonAdi,
                    c.MusteriId,
                    c.MusteriAdi,
                    c.DovizTipiId,
                    c.DovizTipiAdi
                })
                .Select(g => new
                {
                    SubeTipiAdi = g.Key.SubeTipiAdi,
                    Lokasyon = g.Key.LokasyonAdi,
                    MusteriAdi = g.Key.MusteriAdi,
                    DovizTipiAdi = g.Key.DovizTipiAdi,
                    Tutar = g.Sum(x => x.Tutar)
                })
                .ToListAsync();
            return sonuc.Select(c=>c.SubeTipiAdi+ " " + c.Lokasyon + " " + c.MusteriAdi + " " + c.Tutar.ToString("N2") + " " + c.DovizTipiAdi).ToList();
        }

        public async Task<List<string>> GetHesapTipleri_AyYilGrupluHareketToplami(List<int> HesapTipleri)
        {
            var query = _bankaRepository.GetHareketler();

            foreach (var item in HesapTipleri)
            {
                query = query.Where(c => c.HesapTipleri.Any(d => d.HesapTipi.Id == item));
            }

            var sonuc = await query
                .GroupBy(c => new
                {
                    c.MusteriId,
                    c.MusteriAdi,
                    c.HareketTarihi.Month,
                    c.HareketTarihi.Year,
                    c.DovizTipiId,
                    c.DovizTipiAdi
                })
                .Select(g => new
                {
                    TipId = g.Key,
                    Yil = g.Key.Year,
                    Ay = g.Key.Month,
                    Tutar = g.Sum(x => x.Tutar),
                    MusteriAdi = g.Key.MusteriAdi,
                    DovizTipi = g.Key.DovizTipiAdi
                }).OrderBy(c=>c.MusteriAdi)
                .ToListAsync();

            return sonuc.Select(c=>c.MusteriAdi + " " + c.Yil+"-"+c.Ay + " " + c.Tutar.ToString("N2") + " " + c.DovizTipi).ToList();
        }

        public async Task<List<string>> GetTarih_MusteriLokasyonBakiye(DateTime Tarih)
        {
            var query = _bankaRepository.GetHareketler();

            var sonuc = await query
                .Where(c => c.HareketTarihi < Tarih)
                .GroupBy(c => new
                {
                    c.MusteriId,
                    c.MusteriAdi,
                    c.LokasyonId,
                    c.LokasyonAdi,
                    c.DovizTipiId,
                    c.DovizTipiAdi
                })
                .Select(g => new
                {
                    TipId = g.Key,
                    GirisTutar = g.Where(c=>c.HareketTipId == 3).Sum(x => x.Tutar),
                    CikisTutar = g.Where(c => c.HareketTipId == 4).Sum(x => x.Tutar),
                    Bakiye = g.Where(c => c.HareketTipId == 3).Sum(x => x.Tutar)- g.Where(c => c.HareketTipId == 4).Sum(x => x.Tutar),
                    MusteriAdi = g.Key.MusteriAdi,
                    DovizTipi = g.Key.DovizTipiAdi,
                    LokasyonAdi = g.Key.LokasyonAdi
                }).OrderBy(c => c.MusteriAdi)
                .ToListAsync();

            return sonuc.Select(c => c.LokasyonAdi + " " + c.MusteriAdi + " " + c.Bakiye.ToString("N2") + " " + c.DovizTipi).ToList();
        }

        public async Task<List<string>> TumFiltre_HesapHareketleriBakiyeli(HareketFiltreDto Filtre)
        {
            var query = _bankaRepository.GetHareketler();

            var sonuc = await query
                .GroupBy(c => new
                {
                    c.MusteriId,
                    c.MusteriAdi,
                    c.LokasyonId,
                    c.LokasyonAdi,
                    c.DovizTipiId,
                    c.DovizTipiAdi
                })
                .Select(g => new
                {
                    TipId = g.Key,
                    GirisTutar = g.Where(c => c.HareketTipId == 3).Sum(x => x.Tutar),
                    CikisTutar = g.Where(c => c.HareketTipId == 4).Sum(x => x.Tutar),
                    Bakiye = g.Where(c => c.HareketTipId == 3).Sum(x => x.Tutar) - g.Where(c => c.HareketTipId == 4).Sum(x => x.Tutar),
                    MusteriAdi = g.Key.MusteriAdi,
                    DovizTipi = g.Key.DovizTipiAdi,
                    LokasyonAdi = g.Key.LokasyonAdi
                }).OrderBy(c => c.MusteriAdi)
                .ToListAsync();

            return sonuc.Select(c => c.LokasyonAdi + " " + c.MusteriAdi + " " + c.Bakiye.ToString("N2") + " " + c.DovizTipi).ToList();
        }

        public async Task<List<string>> HesapTipiDovizTipi_SubeVeyaLokasyonBazliHesapToplamlari(int HesapTipiId, int DovizTipiId, int SubeLokasyon)
        {
            var query = _bankaRepository.GetHareketler();

            query = query.Where(c => c.HesapTipleri.Where(c => c.HesapTipi.Id == HesapTipiId).Any() && c.DovizTipiId == DovizTipiId);

            List<string> sonuc = new List<string>();

            if (SubeLokasyon == 1)//şube
            {
                var sonucQuery = await query
               .GroupBy(c => new
               {
                   c.SubeId,
                   c.SubeAdi,
                   c.DovizTipiId,
                   c.DovizTipiAdi
               })
               .Select(g => new
               {
                   TipId = g.Key,
                   GirisTutar = g.Where(c => c.HareketTipId == 3).Sum(x => x.Tutar),
                   CikisTutar = g.Where(c => c.HareketTipId == 4).Sum(x => x.Tutar),
                   Bakiye = g.Where(c => c.HareketTipId == 3).Sum(x => x.Tutar) - g.Where(c => c.HareketTipId == 4).Sum(x => x.Tutar),
                   DovizTipi = g.Key.DovizTipiAdi,
                   SubeAdi = g.Key.SubeAdi
               }).OrderBy(c => c.SubeAdi)
               .ToListAsync();

                sonuc = sonucQuery.Select(c => "Şube : " +c.SubeAdi + " " + c.Bakiye.ToString("N2") + " " + c.DovizTipi).ToList();
            }
            else
            {
                var sonucQuery = await query
              .GroupBy(c => new
              {
                  c.LokasyonId,
                  c.LokasyonAdi,
                  c.DovizTipiId,
                  c.DovizTipiAdi
              })
              .Select(g => new
              {
                  TipId = g.Key,
                  GirisTutar = g.Where(c => c.HareketTipId == 3).Sum(x => x.Tutar),
                  CikisTutar = g.Where(c => c.HareketTipId == 4).Sum(x => x.Tutar),
                  Bakiye = g.Where(c => c.HareketTipId == 3).Sum(x => x.Tutar) - g.Where(c => c.HareketTipId == 4).Sum(x => x.Tutar),
                  DovizTipi = g.Key.DovizTipiAdi,
                  LokasyonAdi = g.Key.LokasyonAdi
              }).OrderBy(c => c.LokasyonAdi)
              .ToListAsync();

                sonuc = sonucQuery.Select(c => "Lokasyon : " +c.LokasyonAdi + " " + c.Bakiye.ToString("N2") + " " + c.DovizTipi).ToList();
            }

            return sonuc;
        }

        public async Task<List<string>> TarihBanka_DovizHesapTipiGrupluBakiye(DateTime Tarih, int BankaId)
        {
            var query = _bankaRepository.GetHareketler2();
            var sonuc = await query
                .Where(c => c.HareketTarihi < Tarih && c.BankaId == BankaId)
                .GroupBy(c => new
                {
                    c.HesapTipiId,
                    c.HesapTipiAdi,
                    c.DovizTipiId,
                    c.DovizTipiAdi
                })
                .Select(g => new
                {
                    TipId = g.Key,
                    GirisTutar = g.Where(c => c.HareketTipId == 3).Sum(x => x.Tutar),
                    CikisTutar = g.Where(c => c.HareketTipId == 4).Sum(x => x.Tutar),
                    Bakiye = g.Where(c => c.HareketTipId == 3).Sum(x => x.Tutar) - g.Where(c => c.HareketTipId == 4).Sum(x => x.Tutar),
                    HesapTipiAdi = g.Key.HesapTipiAdi,
                    DovizTipi = g.Key.DovizTipiAdi
                }).OrderBy(c => c.HesapTipiAdi)
                .ToListAsync();

            return sonuc.Select(c => c.HesapTipiAdi + " " + c.Bakiye.ToString("N2") + " " + c.DovizTipi).ToList();

        }

        public async Task<List<string>> HesapTipiDoviz_LokasyonIcinHesabindaEnCokParaOlanMusteriler(int HesapTipi, int DovizTipiId)
        {
            var query = _bankaRepository.GetHareketler();

            var query2 = query.Where(c => c.HesapTipleri.Where(c=>c.HesapTipiId == HesapTipi).Any() && c.DovizTipiId == DovizTipiId)
                .GroupBy(c => new
                {
                    c.MusteriId,
                    c.MusteriAdi,
                    c.LokasyonId,
                    c.LokasyonAdi,
                    c.DovizTipiId,
                    c.DovizTipiAdi
                })
                .Select(g => new
                {
                    GirisTutar = g.Where(c => c.HareketTipId == 3).Sum(x => x.Tutar),
                    CikisTutar = g.Where(c => c.HareketTipId == 4).Sum(x => x.Tutar),
                    Bakiye = g.Where(c => c.HareketTipId == 3).Sum(x => x.Tutar) - g.Where(c => c.HareketTipId == 4).Sum(x => x.Tutar),
                    MusteriAdi = g.Key.MusteriAdi,
                    LokasyonAdi = g.Key.LokasyonAdi,
                    DovizTipi = g.Key.DovizTipiAdi
                }).OrderBy(c => c.MusteriAdi);

            var res = from element in query2
                      group element by element.LokasyonAdi
            into groups
                      select groups.OrderByDescending(p => p.Bakiye).First();

            var sonuc = await res.ToListAsync();

            return sonuc.Select(c => c.MusteriAdi + " " + c.Bakiye.ToString("N2") + " " + c.DovizTipi).ToList();

        }
    }
}