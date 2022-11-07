using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core;
using NLayer.Core.Services;
using NLayer.API.Filters;

namespace NLayer.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            var sonuc = await _productService.GetProductsWithCategory();

            var productsDto = _mapper.Map<List<ProductDto>>(sonuc.ToList());

            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));

            //return CreateActionResult(await _productService.GetProductsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _productService.GetAllAsync();

            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());

            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            var sonuc = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, sonuc));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "bu id'ye ait ürün bulunamadı"));
            }

            await _productService.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
