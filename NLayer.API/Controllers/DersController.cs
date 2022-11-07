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
    public class DersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IDersService _service;

        public DersController(IMapper mapper, IDersService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDersWithOgrenci()
        {
            var sonuc = await _service.GetDersWithOgrenci();

            var sonucDto = _mapper.Map<List<DersWithOgrenciDto>>(sonuc.ToList());

            return CreateActionResult(CustomResponseDto<List<DersWithOgrenciDto>>.Success(200, sonucDto));

            //return CreateActionResult(await _productService.GetProductsWithCategory());
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var data = await _service.GetAllAsync();
            var dataDto = _mapper.Map<List<DersDto>>(data.ToList());
            return CreateActionResult(CustomResponseDto<List<DersDto>>.Success(200, dataDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Ogrenci>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            var dataDto = _mapper.Map<DersDto>(data);
            return CreateActionResult(CustomResponseDto<DersDto>.Success(200, dataDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(DersDto ogrenciDto)
        {
            var ogrenci = await _service.AddAsync(_mapper.Map<Ders>(ogrenciDto));
            var sonuc = _mapper.Map<DersDto>(ogrenci);
            return CreateActionResult(CustomResponseDto<DersDto>.Success(200, sonuc));
        }

        [HttpPut]
        public async Task<IActionResult> Update(DersUpdateDto dersDto)
        {
            await _service.UpdateAsync(_mapper.Map<Ders>(dersDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "bu id'ye ait ürün bulunamadı"));
            }

            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
