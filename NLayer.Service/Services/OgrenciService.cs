using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class OgrenciService : Service<Ogrenci>, IOgrenciService
    {
        private readonly IGenericRepository<Ogrenci> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOgrenciRepository _ogrenciRepository;

        public OgrenciService(IGenericRepository<Ogrenci> repository, IUnitOfWork unitOfWork, IMapper mapper, IOgrenciRepository ogrenciRepository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _ogrenciRepository = ogrenciRepository;
        }

        public async Task<List<OgrenciWithDersDto>> GetOgrenciWithDers()
        {
            var data = await _ogrenciRepository.GetOgrenciWithDers();

            var dataDto = _mapper.Map<List<OgrenciWithDersDto>>(data);

            return dataDto;
        }

        public async Task<List<OgrenciWithDersDto>> GetOgrenciWithDers(OgrenciFilterDto filter)
        {
            var data = await _ogrenciRepository.GetOgrenciWithDers(filter);
            var dataDto = _mapper.Map<List<OgrenciWithDersDto>>(data);
            return dataDto;
        }

        public async Task AddDersToOgrenci(OgrenciDersSaveDto dto)
        {
            var ogrenci = await _repository.GetByIdAsync(dto.OgrenciId);

            if (ogrenci.OgrenciDersleri == null)
            {
                ogrenci.OgrenciDersleri = new List<OgrenciDers>();
            }
            ogrenci.OgrenciDersleri.Add(_mapper.Map<OgrenciDers>(dto));
            _ogrenciRepository.Update(ogrenci);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateOgrenciWithDers(OgrenciUpdateWithDersDto dto)
        {
            var ogrenci = await _ogrenciRepository.GetOgrenciWithDers(dto.Id);
            ogrenci.Adi = dto.Adi;
            ogrenci.Soyadi = dto.Soyadi;
            ogrenci.OgrenciDersleri.Clear();
            foreach (var ders in dto.Dersler.Where(c=>c.Checked))
            {
                ogrenci.OgrenciDersleri.Add(new OgrenciDers { DersId = ders.Id, OgrenciId = dto.Id });
            }
            _ogrenciRepository.Update(ogrenci);
            await _unitOfWork.CommitAsync();
        }
    }
}
