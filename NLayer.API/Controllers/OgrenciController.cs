using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core;
using NLayer.Core.Services;
using NLayer.API.Filters;
using NLayer.Service.Services;

namespace NLayer.API.Controllers
{
    public class OgrenciController : CustomBaseController
    {
        private readonly IMapper _mapper; 
        private readonly IOgrenciService _ogrenciService;

        public OgrenciController(IMapper mapper, IOgrenciService ogrenciService)
        {
            _mapper = mapper;
            _ogrenciService = ogrenciService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOgrenciWithDers()
        {
            var sonuc = await _ogrenciService.GetOgrenciWithDers();

            var sonucDto = _mapper.Map<List<OgrenciWithDersDto>>(sonuc.ToList());

            return CreateActionResult(CustomResponseDto<List<OgrenciWithDersDto>>.Success(200, sonucDto));

            //return CreateActionResult(await _productService.GetProductsWithCategory());
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var data = await _ogrenciService.GetAllAsync();
            var dataDto = _mapper.Map<List<OgrenciDto>>(data.ToList());
            return CreateActionResult(CustomResponseDto<List<OgrenciDto>>.Success(200, dataDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Ogrenci>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _ogrenciService.GetByIdAsync(id);
            var dataDto = _mapper.Map<OgrenciDto>(data);
            return CreateActionResult(CustomResponseDto<OgrenciDto>.Success(200, dataDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(OgrenciDto ogrenciDto)
        {
            var ogrenci = await _ogrenciService.AddAsync(_mapper.Map<Ogrenci>(ogrenciDto));
            var sonuc = _mapper.Map<OgrenciDto>(ogrenci);
            return CreateActionResult(CustomResponseDto<OgrenciDto>.Success(200, sonuc));
        }

        [HttpPost("DersKaydet")]
        public async Task<IActionResult> DersKaydet(OgrenciDersSaveDto ogrenciSaveDto)
        {
            await _ogrenciService.AddDersToOgrenci(ogrenciSaveDto);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }

        [HttpPut]
        public async Task<IActionResult> Update(OgrenciUpdateDto ogrenciDto)
        {
            await _ogrenciService.UpdateAsync(_mapper.Map<Ogrenci>(ogrenciDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _ogrenciService.GetByIdAsync(id);

            if (product == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "bu id'ye ait ürün bulunamadı"));
            }

            await _ogrenciService.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
