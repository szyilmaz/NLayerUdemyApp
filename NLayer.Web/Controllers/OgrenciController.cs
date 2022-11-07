using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Services;
using System.Diagnostics;
using System.Linq.Expressions;

namespace NLayer.Web.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly IOgrenciService _ogrenciService;
        private readonly IDersService _dersService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memCache;
        const string cacheKey = "catalogKey";

        public OgrenciController(IOgrenciService ogrenciService, IDersService dersService, IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache memCache)
        {
            _ogrenciService = ogrenciService;
            _dersService = dersService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _memCache = memCache;
        }

        public async Task<IActionResult> Index()
        {
            var veri = new List<OgrenciWithDersDto>();

            if (!_memCache.TryGetValue(cacheKey, out veri))
            {
                //Burada cache için belirli ayarlamaları yapıyoruz.Cache süresi,önem derecesi gibi
                var cacheExpOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                    Priority = CacheItemPriority.Normal
                };
                //Bu satırda belirlediğimiz key'e göre ve ayarladığımız cache özelliklerine göre kategorilerimizi in-memory olarak cache'liyoruz.
                veri = await _ogrenciService.GetOgrenciWithDers();
                _memCache.Set(cacheKey, veri, cacheExpOptions);
            }
            return View(veri);
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(OgrenciDto dto)
        {
            if (ModelState.IsValid)
            {
                await _ogrenciService.AddAsync(_mapper.Map<Ogrenci>(dto));
                await _unitOfWork.CommitAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

        [ServiceFilter(typeof(NotFoundFilter<Ogrenci>))]
        public async Task<IActionResult> Update(int id)
        {
            var ogrenciler = await _ogrenciService.GetOgrenciWithDers();
            var ogrenci = ogrenciler.Where(c => c.Id == id).FirstOrDefault();

            var ogrenciMapped = _mapper.Map<OgrenciWithDersDto>(ogrenci);

            OgrenciUpdateWithDersDto viewData = new OgrenciUpdateWithDersDto();

            viewData.Id = ogrenciMapped.Id;
            viewData.Adi = ogrenciMapped.Adi;
            viewData.Soyadi = ogrenciMapped.Soyadi;

            var dersler = await _dersService.GetAllAsync();
            var derslerDto = _mapper.Map<List<DersDto>>(dersler.ToList());

            var derslerChecked = _mapper.Map<List<DersCheckedDto>>(derslerDto);

            foreach (var ders in derslerChecked)
            {
                ders.Checked = ogrenci.OgrenciDersleri.Where(c => c.DersId == ders.Id).Any() ? true : false;
            }

            viewData.Dersler = derslerChecked;
            return View(viewData);
        }

        [HttpPost]
        public async Task<IActionResult> Update(OgrenciUpdateWithDersDto dto)
        {
            if (ModelState.IsValid)
            {
                await _ogrenciService.UpdateOgrenciWithDers(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var ogrenci = await _ogrenciService.GetByIdAsync(id);

            await _ogrenciService.RemoveAsync(ogrenci);

            return RedirectToAction(nameof(Index));
        }

        private Expression<Func<TData, bool>> CreateFilter<TData, TKey>(Expression<Func<TData, TKey>> selector, TKey valueToCompare)
        {
            var parameter = Expression.Parameter(typeof(TData));
            var expressionParameter = Expression.Property(parameter, GetParameterName(selector));

            var body = Expression.GreaterThan(expressionParameter, Expression.Constant(valueToCompare, typeof(TKey)));
            return Expression.Lambda<Func<TData, bool>>(body, parameter);
        }

        private string GetParameterName<TData, TKey>(Expression<Func<TData, TKey>> expression)
        {
            if (!(expression.Body is MemberExpression memberExpression))
            {
                memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }

            return memberExpression.ToString().Substring(2);
        }
    }

    

}