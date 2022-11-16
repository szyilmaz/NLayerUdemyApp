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
    public async Task<IActionResult> All()
    {
        var entities = await _bankaService.GetBankalarWithSube();
        var dtos = _mapper.Map<List<BankaDto>>(entities.ToList());
        return CreateActionResult(CustomResponseDto<List<BankaDto>>.Success(200, dtos));
    }
}