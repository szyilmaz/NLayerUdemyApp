using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Repositories;

namespace NLayer.Service.Services
{
    public class DersService : Service<Ders>, IDersService
    {
        private readonly IGenericRepository<Ders> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDersRepository _dersRepository;

        public DersService(IGenericRepository<Ders> repository, IUnitOfWork unitOfWork, IMapper mapper, IDersRepository dersRepository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dersRepository = dersRepository;
        }

        public async Task<List<DersWithOgrenciDto>> GetDersWithOgrenci()
        {
            var data = await _dersRepository.GetDersWithOgrenci();

            var dataDto = _mapper.Map<List<DersWithOgrenciDto>>(data);

            return dataDto;
        }
    }
}
