using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Repositories;

namespace NLayer.Service.Services
{
    public class BankaService : Service<Banka>, IBankaService
    {
        private readonly IGenericRepository<Banka> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBankaRepository _bankaRepository;

        public BankaService(IGenericRepository<Banka> repository, IUnitOfWork unitOfWork, IMapper mapper, IBankaRepository bankaRepository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bankaRepository = bankaRepository;
        }

        public async Task<List<BankaDto>> GetBankalarWithSube()
        {
            var bankalar = await _bankaRepository.GetBankalarWithSube();

            var dtos = _mapper.Map<List<BankaDto>>(bankalar);

            return dtos;
        }
    }
}
