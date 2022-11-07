using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Services;

namespace NLayer.Web.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly IOgrenciService _ogrenciService;
        private readonly IDersService _dersService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OgrenciController(IOgrenciService ogrenciService, IDersService dersService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _ogrenciService = ogrenciService;
            _dersService = dersService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _ogrenciService.GetOgrenciWithDers());
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
    }
}