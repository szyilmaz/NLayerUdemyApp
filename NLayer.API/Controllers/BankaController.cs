using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;

namespace NLayer.API.Controllers;

public class BankaController : CustomBaseController
{
    private readonly IMapper _mapper;
    private readonly IBankaService _bankaService;

    public BankaController(IMapper mapper, IBankaService bankaService)
    {
        _mapper = mapper;
        _bankaService = bankaService;
    }

    [HttpGet("01_GetSubeTipi_LokasyonMusteriDovizGrupluHareketToplami")]
    public async Task<IActionResult> GetSubeTipi_LokasyonMusteriDovizGrupluHareketToplami(int SubeTipiId)
    {
        var entities = await _bankaService.GetSubeTipi_LokasyonMusteriDovizGrupluHareketToplami(SubeTipiId);

        return CreateActionResult(CustomResponseDto<List<string>>.Success(200, entities));
    }

    [HttpGet("02_GetHesapTipleri_AyYilGrupluHareketToplami")]
    public async Task<IActionResult> GetHesapTipleri_AyYilGrupluHareketToplami(string HesapTipleri)
    {
        var liste = HesapTipleri.Split(',').Select(c=> int.Parse(c)).ToList();

        var entities = await _bankaService.GetHesapTipleri_AyYilGrupluHareketToplami(liste);

        return CreateActionResult(CustomResponseDto<List<string>>.Success(200, entities));
    }

    [HttpGet("03_GetTarih_MusteriLokasyonBakiye")]
    public async Task<IActionResult> GetTarih_MusteriLokasyonBakiye(DateTime Tarih)
    {
        var entities = await _bankaService.GetTarih_MusteriLokasyonBakiye(Tarih);

        return CreateActionResult(CustomResponseDto<List<string>>.Success(200, entities));
    }

    [HttpGet("04_TumFiltre_HesapHareketleriBakiyeli")]
    public async Task<IActionResult> TumFiltre_HesapHareketleriBakiyeli([FromQuery] HareketFiltreDto Filtre)
    {
        var entities = await _bankaService.TumFiltre_HesapHareketleriBakiyeli(Filtre);
        return CreateActionResult(CustomResponseDto<List<string>>.Success(200, entities));
    }

    [HttpGet("05_HesapTipiDovizTipi_SubeVeyaLokasyonBazliHesapToplamlari")]
    public async Task<IActionResult> HesapTipiDovizTipi_SubeVeyaLokasyonBazliHesapToplamlari(int HesapTipiId, int DovizTipiId, int SubeLokasyon)
    {
        var entities = await _bankaService.HesapTipiDovizTipi_SubeVeyaLokasyonBazliHesapToplamlari(HesapTipiId, DovizTipiId, SubeLokasyon);

        return CreateActionResult(CustomResponseDto<List<string>>.Success(200, entities));
    }

    [HttpGet("06_TarihBanka_DovizHesapTipiGrupluBakiye")]
    public async Task<IActionResult> TarihBanka_DovizHesapTipiGrupluBakiye(DateTime Tarih, int BankaId)
    {
        var entities = await _bankaService.TarihBanka_DovizHesapTipiGrupluBakiye(Tarih , BankaId);
        return CreateActionResult(CustomResponseDto<List<string>>.Success(200, entities));
    }

    [HttpGet("07_HesapTipiDoviz_LokasyonIcinHesabindaEnCokParaOlanMusteriler")]
    public async Task<IActionResult> HesapTipiDoviz_LokasyonIcinHesabindaEnCokParaOlanMusteriler(int HesapTipi, int DovizTipiId)
    {
        var entities = await _bankaService.HesapTipiDoviz_LokasyonIcinHesabindaEnCokParaOlanMusteriler(HesapTipi, DovizTipiId);

        return CreateActionResult(CustomResponseDto<List<string>>.Success(200, entities));
    }
}