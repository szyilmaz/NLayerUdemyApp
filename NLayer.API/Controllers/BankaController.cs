using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
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

    [HttpGet]
    public async Task<IActionResult> All(int MusteriId, int HareketTipId)
    {
        var entities = await _bankaService.GetHareketler(MusteriId,HareketTipId);
        return CreateActionResult(CustomResponseDto<List<DetailedHareketDto>>.Success(200, entities));
    }

    [HttpGet("Toplam")]
    public IActionResult Toplam(int MusteriId, int HareketTipId)
    {
        var entities = _bankaService.GetHareketToplam(MusteriId, HareketTipId);

        return CreateActionResult(CustomResponseDto<decimal>.Success(200, entities));
    }

    [HttpGet("Bakiye")]
    public async Task<IActionResult> Bakiye(int MusteriId)
    {
        var entities = await _bankaService.GetBakiye(MusteriId);

        return CreateActionResult(CustomResponseDto<decimal>.Success(200, entities));
    }

    [HttpGet("GetSubeTipi_LokasyonMusteriDovizGrupluHareketToplami")]
    public async Task<IActionResult> GetSubeTipi_LokasyonMusteriDovizGrupluHareketToplami(int SubeId)
    {
        var entities = await _bankaService.GetSubeTipi_LokasyonMusteriDovizGrupluHareketToplami(SubeId);

        return CreateActionResult(CustomResponseDto<decimal>.Success(200, entities));
    }
}